using Ace.CSharp.DataFaker.Exceptions;
using Ace.CSharp.DataFaker.Internal.Symbols;
using Ace.CSharp.DataFaker.Tests.Fakers;

namespace Ace.CSharp.DataFaker.Tests;

public sealed class AbstractDataFakerTests
{
    [Fact]
    internal void GivenOfWhenPropertyIsConfiguredThenGeneratesData()
    {
        // Arrange
        AbstractDataFaker<FakeEntity> fakeEntity = new FakeEntity();

        // Act
        var entity = fakeEntity.Of<FooEntity>();

        // Assert
        entity.Should().NotBeNull().And.BeOfType<FooEntity>();
    }

    [Fact]
    internal void GivenOfWhenPropertyIsNotConfiguredThenThrowsException()
    {
        // Arrange
        AbstractDataFaker<FakeEntity> fakeEntity = new FakeEntity();

        // Act
        var action = () => fakeEntity.Of<BarEntity>();

        // Assert
        action.Should().Throw<InstanceFakerNotFoundException<BarEntity, FakeEntity>>();
    }

    [Fact]
    internal void GivenManyOfWhenPropertyIsConfiguredThenGeneratesData()
    {
        // Arrange
        AbstractDataFaker<FakeEntity> fakeEntity = new FakeEntity();

        // Act
        var entities = fakeEntity.ManyOf<FooEntity>();

        // Assert
        entities.Should().NotBeNull().And.BeOfType<List<FooEntity>>();
        entities.Should().NotBeEmpty().And.HaveCount(Constants.ManyOfCount);
    }

    [Fact]
    internal void GivenManyOfWhenPropertyIsConfiguredAndCountIsSpecifiedThenGeneratesData()
    {
        // Arrange
        AbstractDataFaker<FakeEntity> fakeEntity = new FakeEntity();
        int count = 10;

        // Act
        var entities = fakeEntity.ManyOf<FooEntity>(count);

        // Assert
        entities.Should().NotBeNull().And.BeOfType<List<FooEntity>>();
        entities.Should().NotBeEmpty().And.HaveCount(count);
    }

    [Fact]
    internal void GivenManyOfWhenPropertyIsNotConfiguredThenThrowsException()
    {
        // Arrange
        AbstractDataFaker<FakeEntity> fakeEntity = new FakeEntity();

        // Act
        var action = () => fakeEntity.ManyOf<BarEntity>();

        // Assert
        action.Should().Throw<InstanceFakerNotFoundException<BarEntity, FakeEntity>>();
    }
}
