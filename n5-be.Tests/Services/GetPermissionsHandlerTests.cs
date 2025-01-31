using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using N5_BE.Application.Features.Permisos.Queries.GetPermissions;
using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;
using N5_BE.Tests.Mocks;
using Xunit;

namespace N5_BE.Tests.Services
{
    public class GetPermissionsHandlerTests
    {
        private readonly GetPermissionsQueryHandler _handler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetPermissionsHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _handler = new GetPermissionsQueryHandler(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_Permissions()
        {
            var result = await _handler.Handle(new GetPermissionsQuery());

            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            _mockUnitOfWork.Verify(uow => uow.PermisoRepository.GetAllAsync(), Times.Once);
        }
    }
}