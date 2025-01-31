using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;

namespace N5_BE.Application.Features.Permisos.Commands.RequestPermission
{
    public class RequestPermissionCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticService _elasticService;

        public RequestPermissionCommandHandler(IUnitOfWork unitOfWork, IElasticService elasticService)
        {
            _unitOfWork = unitOfWork;
            _elasticService = elasticService;
        }

        public async Task<int> Handle(RequestPermissionCommand command)
        {
            var permiso = new Permiso
            {
                NombreEmpleado = command.NombreEmpleado,
                ApellidoEmpleado = command.ApellidoEmpleado,
                TipoPermiso = command.TipoPermiso,
                FechaPermiso = command.FechaPermiso
            };

            await _unitOfWork.PermisoRepository.AddAsync(permiso);
            await _unitOfWork.CompleteAsync();

            await _elasticService.IndexPermissionAsync(permiso);

            return permiso.Id;
        }
    }
}