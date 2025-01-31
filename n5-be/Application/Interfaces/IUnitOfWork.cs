using N5_BE.Domain.Entities;

namespace N5_BE.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Permiso> PermisoRepository { get; }
        IRepository<TipoPermisos> TipoPermisosRepository { get; }

        Task<int> CompleteAsync();
    }
}