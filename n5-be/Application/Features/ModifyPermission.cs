namespace N5_BE.Application.Features.Permisos.Commands.ModifyPermission
{
    public class ModifyPermissionCommand
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; } = null!;
        public string ApellidoEmpleado { get; set; } = null!;
        public int TipoPermiso { get; set; }
    }
}