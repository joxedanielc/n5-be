using Moq;
using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;

namespace N5_BE.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mock = new Mock<IUnitOfWork>();

            // Mock Permission Repository
            var permisoRepository = new Mock<IRepository<Permiso>>();
            permisoRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Permiso>
                {
                    new Permiso { Id = 1, NombreEmpleado = "John", ApellidoEmpleado = "Doe", TipoPermiso = 1, FechaPermiso = System.DateTime.UtcNow },
                    new Permiso { Id = 2, NombreEmpleado = "Jane", ApellidoEmpleado = "Doe", TipoPermiso = 2, FechaPermiso = System.DateTime.UtcNow }
                });

            permisoRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => new Permiso { Id = id, NombreEmpleado = "Test", ApellidoEmpleado = "User", TipoPermiso = 1, FechaPermiso = System.DateTime.UtcNow });

            permisoRepository.Setup(repo => repo.AddAsync(It.IsAny<Permiso>()))
                .ReturnsAsync((Permiso permiso) => permiso);

            permisoRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Permiso>()))
                .Returns(Task.CompletedTask);

            mock.Setup(uow => uow.PermisoRepository).Returns(permisoRepository.Object);

            return mock;
        }

        public static Mock<IElasticService> GetElasticService()
        {
            var mock = new Mock<IElasticService>();
            mock.Setup(es => es.IndexPermissionAsync(It.IsAny<Permiso>()))
                .Returns(Task.CompletedTask);

            return mock;
        }
    }
}