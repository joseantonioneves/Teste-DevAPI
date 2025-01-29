using Xunit;
using Moq;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Tests
{
    public class ExampleServiceTests
    {
        private readonly ExampleService _exampleService;
        private readonly Mock<IExampleRepository> _mockRepository;

        public ExampleServiceTests()
        {
            _mockRepository = new Mock<IExampleRepository>();
            _exampleService = new ExampleService(_mockRepository.Object);
        }

        [Fact]
        public void Create_ShouldAddExampleEntity()
        {
            // Arrange
            var exampleEntity = new ExampleEntity { Id = 1, Name = "Test" };
            _mockRepository.Setup(repo => repo.Add(exampleEntity)).Verifiable();

            // Act
            _exampleService.Create(exampleEntity);

            // Assert
            _mockRepository.Verify(repo => repo.Add(exampleEntity), Times.Once);
        }

        [Fact]
        public void Update_ShouldModifyExampleEntity()
        {
            // Arrange
            var exampleEntity = new ExampleEntity { Id = 1, Name = "Updated Test" };
            _mockRepository.Setup(repo => repo.Update(exampleEntity)).Verifiable();

            // Act
            _exampleService.Update(exampleEntity);

            // Assert
            _mockRepository.Verify(repo => repo.Update(exampleEntity), Times.Once);
        }

        [Fact]
        public void Delete_ShouldRemoveExampleEntity()
        {
            // Arrange
            var exampleEntityId = 1;
            _mockRepository.Setup(repo => repo.Remove(exampleEntityId)).Verifiable();

            // Act
            _exampleService.Delete(exampleEntityId);

            // Assert
            _mockRepository.Verify(repo => repo.Remove(exampleEntityId), Times.Once);
        }
    }
}