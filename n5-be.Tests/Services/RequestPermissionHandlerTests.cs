using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using N5_BE.Application.Features.Permisos.Commands.RequestPermission;
using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;
using N5_BE.Tests.Mocks;
using Xunit;
using Xunit.Abstractions;

namespace N5_BE.Tests.Services
{
    public class RequestPermissionHandlerTests
    {
        private readonly ITestOutputHelper _output;
        private readonly RequestPermissionCommandHandler _handler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IElasticService> _mockElasticService;

        public RequestPermissionHandlerTests(ITestOutputHelper output)
        {
            _output = output;
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _mockElasticService = MockUnitOfWork.GetElasticService();
            _handler = new RequestPermissionCommandHandler(_mockUnitOfWork.Object, _mockElasticService.Object);
        }

        [Fact]
        public async Task Handle_Should_Create_Permission_And_Index_It()
        {
            var command = new RequestPermissionCommand
            {
                NombreEmpleado = "John",
                ApellidoEmpleado = "Doe",
                TipoPermiso = 1,
                FechaPermiso = DateTime.UtcNow
            };

            var result = await _handler.Handle(command);
            //TODO: FIX THIS ASSERT
            _output.WriteLine($"Result returned: {result}");
            Assert.True(result > 0);
            _mockUnitOfWork.Verify(uow => uow.PermisoRepository.AddAsync(It.IsAny<Permiso>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CompleteAsync(), Times.Once);
            _mockElasticService.Verify(es => es.IndexPermissionAsync(It.IsAny<Permiso>()), Times.Once);
        }
    }
}