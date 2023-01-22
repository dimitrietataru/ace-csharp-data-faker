using Ace.CSharp.DataFaker.Exceptions;
using Ace.CSharp.DataFaker.Tests.Fakers;

namespace Ace.CSharp.DataFaker.Tests;

public sealed class FakeOfTests
{
    [Fact]
    internal static void GivenFakeOfWhenContainerIsNotGivenThenGeneratesData()
    {
        // Arrange

        // Act
        var dto = Fake.Of<FooDto>();

        // Assert
        dto.Should().NotBeNull().And.BeOfType<FooDto>();
    }

    [Fact]
    internal static void GivenFakeOfWhenContainerIsConfiguredThenGeneratesData()
    {
        // Arrange

        // Act
        var dto = Fake.Of<FooDto, FakeDto>();

        // Assert
        dto.Should().NotBeNull().And.BeOfType<FooDto>();
    }

    [Fact]
    internal static void GivenFakeOfWhenContainerIsNotConfiguredThenThrowsException()
    {
        // Arrange

        // Act
        var action = () => Fake.Of<BarDto, FakeDto>();

        // Assert
        action.Should().Throw<FakerNotFoundException<BarDto>>();
    }

    [Fact]
    internal static void GivenFakeOfOrDefaultWhenContainerIsConfiguredThenGeneratesData()
    {
        // Arrange

        // Act
        var dto = Fake.OfOrDefault<FooDto, FakeDto>();

        // Assert
        dto.Should().NotBeNull().And.BeOfType<FooDto>();
    }

    [Fact]
    internal static void GivenFakeOfWhenContainerIsNotConfiguredThenGeneratesDataGracefully()
    {
        // Arrange

        // Act
        var dto = Fake.OfOrDefault<BarDto, FakeDto>();

        // Assert
        dto.Should().NotBeNull().And.BeOfType<BarDto>();
    }
}
