using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace n5_be.Migrations
{
    public partial class SeedPermissionTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "TipoPermisos",
                            columns: new[] { "Descripcion" },
                            values: new object[] { "Create" }
                        );

            migrationBuilder.InsertData(
                table: "TipoPermisos",
                columns: new[] { "Descripcion" },
                values: new object[] { "Edit" }
            );

            migrationBuilder.InsertData(
                table: "TipoPermisos",
                columns: new[] { "Descripcion" },
                values: new object[] { "Update" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                            table: "TipoPermisos",
                            keyColumn: "Descripcion",
                            keyValue: "Create"
                        );

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Descripcion",
                keyValue: "Edit"
            );

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Descripcion",
                keyValue: "Update"
            );
        }
    }
}
