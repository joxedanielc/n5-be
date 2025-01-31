using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;
using N5_BE.Infra.Data;
using N5_BE.Infra;
using N5_BE.Infra.Repositories;

namespace N5_BE.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<Permiso> PermisoRepository { get; }
        public IRepository<TipoPermisos> TipoPermisosRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            PermisoRepository = new GenericRepository<Permiso>(context);
            TipoPermisosRepository = new GenericRepository<TipoPermisos>(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}