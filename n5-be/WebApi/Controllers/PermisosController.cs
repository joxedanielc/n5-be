using Microsoft.AspNetCore.Mvc;
using N5_BE.Application.Features.Permisos.Commands.RequestPermission;
using N5_BE.Application.Features.Permisos.Commands.ModifyPermission;
using N5_BE.Application.Features.Permisos.Queries.GetPermissions;
using N5_BE.Application.Features.Permisos.Queries.GetPermissionTypes;

namespace N5_BE.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : ControllerBase
    {
        private readonly RequestPermissionCommandHandler _requestHandler;
        private readonly ModifyPermissionCommandHandler _modifyHandler;
        private readonly GetPermissionsQueryHandler _getHandler;
        private readonly GetPermissionTypesQueryHandler _getPermissionTypeHandler;

        public PermisosController(
            RequestPermissionCommandHandler requestHandler,
            ModifyPermissionCommandHandler modifyHandler,
            GetPermissionsQueryHandler getHandler,
            GetPermissionTypesQueryHandler getPermissionTypeHandler)
        {
            _requestHandler = requestHandler;
            _modifyHandler = modifyHandler;
            _getHandler = getHandler;
            _getPermissionTypeHandler = getPermissionTypeHandler;
        }

        [HttpPost("request")]
        public async Task<IActionResult> RequestPermission([FromBody] RequestPermissionCommand command)
        {
            var newId = await _requestHandler.Handle(command);
            return Ok(new { Id = newId });
        }

        [HttpPut("modify/{id}")]
        public async Task<IActionResult> ModifyPermission(int id, [FromBody] ModifyPermissionCommand command)
        {
            command.Id = id;
            var success = await _modifyHandler.Handle(command);
            if (!success) return NotFound();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _getHandler.Handle(new GetPermissionsQuery());
            return Ok(permissions);
        }

        [HttpGet("permissionTypes")]
        public async Task<IActionResult> GetPermissionTypes()
        {
            var permissionTypes = await _getPermissionTypeHandler.Handle(new GetPermissionTypesQuery());
            return Ok(permissionTypes);
        }
    }
}