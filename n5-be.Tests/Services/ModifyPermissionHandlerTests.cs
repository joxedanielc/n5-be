using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using N5_BE.Application.Features.Permisos.Commands.ModifyPermission;
using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;
using N5_BE.Tests.Mocks;
using Xunit;

namespace N5_BE.Tests.Services
{
    public class ModifyPermissionHandlerTests
    {
        private readonly ModifyPermissionCommandHandler _handler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IElasticService> _mockElasticService;

        public ModifyPermissionHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _mockElasticService = MockUnitOfWork.GetElasticService();
            _handler = new ModifyPermissionCommandHandler(_mockUnitOfWork.Object, _mockElasticService.Object);
        }

        [Fact]
        public async Task Handle_Should_Update_Permission_And_Reindex_It()
        {
            var command = new ModifyPermissionCommand
            {
                Id = 1,
                NombreEmpleado = "Dani",
                ApellidoEmpleado = "Castro",
                TipoPermiso = 2
            };

            var result = await _handler.Handle(command);

            result.Should().BeTrue();
            _mockUnitOfWork.Verify(uow => uow.PermisoRepository.UpdateAsync(It.IsAny<Permiso>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CompleteAsync(), Times.Once);
            _mockElasticService.Verify(es => es.IndexPermissionAsync(It.IsAny<Permiso>()), Times.Once);
        }
    }
}