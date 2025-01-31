using System.Threading.Tasks;
using N5_BE.Domain.Entities;

namespace N5_BE.Application.Interfaces
{
    public interface IElasticService
    {
        Task IndexPermissionAsync(Permiso permiso);
    }
}