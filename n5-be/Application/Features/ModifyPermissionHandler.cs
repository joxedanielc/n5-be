using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;

namespace N5_BE.Application.Features.Permisos.Commands.ModifyPermission
{
    public class ModifyPermissionCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticService _elasticService;

        public ModifyPermissionCommandHandler(IUnitOfWork unitOfWork, IElasticService elasticService)
        {
            _unitOfWork = unitOfWork;
            _elasticService = elasticService;
        }

        public async Task<bool> Handle(ModifyPermissionCommand command)
        {
            var permiso = await _unitOfWork.PermisoRepository.GetByIdAsync(command.Id);
            if (permiso == null)
                return false;

            permiso.NombreEmpleado = command.NombreEmpleado;
            permiso.ApellidoEmpleado = command.ApellidoEmpleado;
            permiso.TipoPermiso = command.TipoPermiso;

            await _unitOfWork.PermisoRepository.UpdateAsync(permiso);
            await _unitOfWork.CompleteAsync();

            await _elasticService.IndexPermissionAsync(permiso);

            return true;
        }
    }
}