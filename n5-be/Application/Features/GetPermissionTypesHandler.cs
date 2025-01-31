using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;

namespace N5_BE.Application.Features.Permisos.Queries.GetPermissionTypes
{
    public class GetPermissionTypesQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionTypesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TipoPermisos>> Handle(GetPermissionTypesQuery query)
        {
            var permissionTypes = await _unitOfWork.TipoPermisosRepository.GetAllAsync();
            return permissionTypes.ToList();
        }
    }
}