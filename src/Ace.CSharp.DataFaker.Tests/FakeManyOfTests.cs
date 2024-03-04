using Ace.CSharp.DataFaker.Exceptions;
using Ace.CSharp.DataFaker.Internal.Symbols;
using Ace.CSharp.DataFaker.Tests.Fakers;

namespace Ace.CSharp.DataFaker.Tests;

public sealed class FakeManyOfTests
{
    [Fact]
    internal static void GivenManyOfWhenContainerIsNotGivenAndCountIsDefaultThenGeneratesData()
    {
        // Arrange

        // Act
        var dtos = Fake.ManyOf<FooDto>();

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().NotBeEmpty().And.HaveCount(Constants.ManyOfCount);
    }

    [Fact]
    internal static void GivenManyOfWhenContainerIsNotGivenAndCountIsSpecifiedThenGeneratesData()
    {
        // Arrange
        int count = 10;

        // Act
        var dtos = Fake.ManyOf<FooDto>(count);

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().NotBeEmpty().And.HaveCount(count);
    }

    [Fact]
    internal static void GivenManyOfWhenContainerIsNotGivenAndRangeIsSpecifiedThenGeneratesData()
    {
        // Arrange
        int minCount = 10;
        int maxCount = 100;

        // Act
        var dtos = Fake.ManyOf<FooDto>(minCount, maxCount);

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().HaveCountGreaterThanOrEqualTo(minCount).And.HaveCountLessThanOrEqualTo(maxCount);
    }

    [Fact]
    internal static void GivenManyOfWhenContainerIsConfiguredAndCountIsDefaultThenGeneratesData()
    {
        // Arrange

        // Act
        var dtos = Fake.ManyOf<FooDto, FakeDto>();

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().NotBeEmpty().And.HaveCount(Constants.ManyOfCount);
    }

    [Fact]
    internal static void GivenManyOfWhenContainerIsConfiguredAndCountIsSpecifiedThenGeneratesData()
    {
        // Arrange
        int count = 10;

        // Act
        var dtos = Fake.ManyOf<FooDto, FakeDto>(count);

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().NotBeEmpty().And.HaveCount(count);
    }

    [Fact]
    internal static void GivenManyOfWhenContainerIsConfiguredAndRangeIsSpecifiedThenGeneratesData()
    {
        // Arrange
        int minCount = 10;
        int maxCount = 100;

        // Act
        var dtos = Fake.ManyOf<FooDto, FakeDto>(minCount, maxCount);

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().HaveCountGreaterThanOrEqualTo(minCount).And.HaveCountLessThanOrEqualTo(maxCount);
    }

    [Fact]
    internal static void GivenManyOfWhenContainerIsNotConfiguredAndCountIsDefaultThenThrowsException()
    {
        // Arrange

        // Act
        var action = () => Fake.ManyOf<BarDto, FakeDto>();

        // Assert
        action.Should().Throw<StaticFakerNotFoundException<BarDto>>();
    }

    [Fact]
    internal static void GivenManyOfWhenContainerIsNotConfiguredAndCountIsSpecifiedThenThrowsException()
    {
        // Arrange
        int count = 10;

        // Act
        var action = () => Fake.ManyOf<BarDto, FakeDto>(count);

        // Assert
        action.Should().Throw<StaticFakerNotFoundException<BarDto>>();
    }

    [Fact]
    internal static void GivenManyOfWhenContainerIsNotConfiguredAndRangeIsSpecifiedThenThrowsException()
    {
        // Arrange
        int minCount = 10;
        int maxCount = 100;

        // Act
        var action = () => Fake.ManyOf<BarDto, FakeDto>(minCount, maxCount);

        // Assert
        action.Should().Throw<StaticFakerNotFoundException<BarDto>>();
    }

    [Fact]
    internal static void GivenManyOfOrDefaultWhenContainerIsConfiguredAndCountIsDefaultThenGeneratesData()
    {
        // Arrange

        // Act
        var dtos = Fake.ManyOfOrDefault<FooDto, FakeDto>();

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().NotBeEmpty().And.HaveCount(Constants.ManyOfCount);
    }

    [Fact]
    internal static void GivenManyOfOrDefaultWhenContainerIsConfiguredAndCountIsSpecifiedThenGeneratesData()
    {
        // Arrange
        int count = 10;

        // Act
        var dtos = Fake.ManyOfOrDefault<FooDto, FakeDto>(count);

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().NotBeEmpty().And.HaveCount(count);
    }

    [Fact]
    internal static void GivenManyOfOrDefaultWhenContainerIsConfiguredAndRangeIsSpecifiedThenGeneratesData()
    {
        // Arrange
        int minCount = 10;
        int maxCount = 100;

        // Act
        var dtos = Fake.ManyOfOrDefault<FooDto, FakeDto>(minCount, maxCount);

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<FooDto>>();
        dtos.Should().HaveCountGreaterThanOrEqualTo(minCount).And.HaveCountLessThanOrEqualTo(maxCount);
    }

    [Fact]
    internal static void GivenManyOfOrDefaultWhenContainerIsNotConfiguredAndCountIsDefaultThenGeneratesDataGracefully()
    {
        // Arrange

        // Act
        var dtos = Fake.ManyOfOrDefault<BarDto, FakeDto>();

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<BarDto>>();
        dtos.Should().NotBeEmpty().And.HaveCount(Constants.ManyOfCount);
    }

    [Fact]
    internal static void GivenManyOfOrDefaultWhenContainerIsNotConfiguredAndCountIsSpecifiedThenGeneratesDataGracefully()
    {
        // Arrange
        int count = 10;

        // Act
        var dtos = Fake.ManyOfOrDefault<BarDto, FakeDto>(count);

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<BarDto>>();
        dtos.Should().NotBeEmpty().And.HaveCount(count);
    }

    [Fact]
    internal static void GivenManyOfOrDefaultWhenContainerIsNotConfiguredAndRangeIsSpecifiedThenGeneratesDataGracefully()
    {
        // Arrange
        int minCount = 10;
        int maxCount = 100;

        // Act
        var dtos = Fake.ManyOfOrDefault<BarDto, FakeDto>(minCount, maxCount);

        // Assert
        dtos.Should().NotBeNull().And.BeOfType<List<BarDto>>();
        dtos.Should().HaveCountGreaterThanOrEqualTo(minCount).And.HaveCountLessThanOrEqualTo(maxCount);
    }
}
