namespace N5_BE.Application.Features.Permisos.Commands.RequestPermission
{
    public class RequestPermissionCommand
    {
        public string NombreEmpleado { get; set; } = null!;
        public string ApellidoEmpleado { get; set; } = null!;
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; } = DateTime.UtcNow;
    }
}