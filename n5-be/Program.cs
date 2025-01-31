using Microsoft.EntityFrameworkCore;
using N5_BE.Application.Features.Permisos.Commands.ModifyPermission;
using N5_BE.Application.Features.Permisos.Commands.RequestPermission;
using N5_BE.Application.Features.Permisos.Queries.GetPermissions;
using N5_BE.Application.Interfaces;
using N5_BE.Infra.Data;
using N5_BE.Infra.Elastic;
using N5_BE.Infra.UnitOfWork;
using Nest;

var builder = WebApplication.CreateBuilder(args);

var dbHost = builder.Configuration["Database:Host"] ?? "localhost";
var dbPort = builder.Configuration["Database:Port"] ?? "3306";
var dbUser = builder.Configuration["Database:User"] ?? "root";
var dbPass = builder.Configuration["Database:Password"] ?? "12345678";
var dbName = builder.Configuration["Database:Name"] ?? "N5_DB";

var connectionString =
    $"Server={dbHost};Port={dbPort};Database={dbName};User={dbUser};Password={dbPass};";


builder.Services.AddSingleton<IElasticClient>(sp =>
{
    var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
        .DefaultIndex("permisos-index");

    return new ElasticClient(settings);
});

builder.Services.AddScoped<IElasticService, ElasticService>();
builder.Services.AddScoped<RequestPermissionCommandHandler>();
builder.Services.AddScoped<ModifyPermissionCommandHandler>();
builder.Services.AddScoped<GetPermissionsQueryHandler>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.Run();