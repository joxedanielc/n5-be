using Microsoft.EntityFrameworkCore;
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
            var permisos = await _unitOfWork.PermisoRepository
                .Query()
                .Include(p => p.TipoPermisos)
                .ToListAsync();

            return permisos.Select(p => new Permiso
            {
                Id = p.Id,
                NombreEmpleado = p.NombreEmpleado,
                ApellidoEmpleado = p.ApellidoEmpleado,
                TipoPermiso = p.TipoPermiso,
                FechaPermiso = p.FechaPermiso,
                TipoPermisoDescripcion = p.TipoPermisos?.Descripcion ?? ""
            }).ToList();
        }
    }
}