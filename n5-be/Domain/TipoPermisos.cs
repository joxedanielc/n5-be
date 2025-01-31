using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5_BE.Domain.Entities
{
    public class TipoPermisos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
    }
}