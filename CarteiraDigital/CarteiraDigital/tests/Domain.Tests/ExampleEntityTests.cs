using Xunit;

public class ExampleEntityTests
{
    [Fact]
    public void ExampleEntity_ShouldHaveValidProperties()
    {
        // Arrange
        var exampleEntity = new ExampleEntity
        {
            Id = 1,
            Name = "Test Entity"
        };

        // Act & Assert
        Assert.Equal(1, exampleEntity.Id);
        Assert.Equal("Test Entity", exampleEntity.Name);
    }

    [Fact]
    public void ExampleEntity_ShouldBeEqual_WhenSameId()
    {
        // Arrange
        var exampleEntity1 = new ExampleEntity { Id = 1, Name = "Entity 1" };
        var exampleEntity2 = new ExampleEntity { Id = 1, Name = "Entity 2" };

        // Act
        var areEqual = exampleEntity1.Equals(exampleEntity2);

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void ExampleEntity_ShouldNotBeEqual_WhenDifferentId()
    {
        // Arrange
        var exampleEntity1 = new ExampleEntity { Id = 1, Name = "Entity 1" };
        var exampleEntity2 = new ExampleEntity { Id = 2, Name = "Entity 2" };

        // Act
        var areEqual = exampleEntity1.Equals(exampleEntity2);

        // Assert
        Assert.False(areEqual);
    }
}