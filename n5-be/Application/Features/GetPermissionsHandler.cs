using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;

namespace N5_BE.Application.Features.Permisos.Queries.GetPermissions
{
    public class GetPermissionsQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Permiso>> Handle(GetPermissionsQuery query)
        {
            var permisos = await _unitOfWork.PermisoRepository.GetAllAsync();
            return permisos.ToList();
        }
    }
}