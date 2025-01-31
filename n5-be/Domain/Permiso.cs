using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5_BE.Domain.Entities
{
    public class Permiso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string NombreEmpleado { get; set; }
        public required string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
        public TipoPermisos? TipoPermisos { get; set; }
        [NotMapped]
        public string? TipoPermisoDescripcion { get; set; }
    }
}