using Ace.CSharp.DataFaker;
using Ace.CSharp.DataFaker.Sample;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

{
    Console.WriteLine("Generating FooDto(s) using the Fake class..");

    var fooDto = Fake.Of<FooDto, FakeDto>();
    var fooDtos = Fake.ManyOf<FooDto, FakeDto>();

    Console.WriteLine($"Foo Id: {fooDto.Id}");
    Console.WriteLine($"Foos count: {fooDtos.Count}");
    Console.WriteLine();
}

{
    Console.WriteLine("Generating FooDto(s) using the wrapper (FakeDto) around the Fake class..");

    var fooDto = FakeDto.Of<FooDto>();
    var fooDtos = FakeDto.ManyOf<FooDto>();

    Console.WriteLine($"Foo Id: {fooDto.Id}");
    Console.WriteLine($"Foos count: {fooDtos.Count}");
    Console.WriteLine();
}

{
    Console.WriteLine("Generating Foo(s) using the Fake class..");

    var foo = Fake.Of<FooEntity, FakeEntity>();
    var foos = Fake.ManyOf<FooEntity, FakeEntity>();

    Console.WriteLine($"Foo Id: {foo.Id}");
    Console.WriteLine($"Foos count: {foos.Count}");
    Console.WriteLine();
}

{
    Console.WriteLine("Generating Foo(s) using the wrapper (FakeEntity) around the Fake class..");

    var foo = FakeEntity.Of<FooEntity>();
    var foos = FakeEntity.ManyOf<FooEntity>();

    Console.WriteLine($"Foo Id: {foo.Id}");
    Console.WriteLine($"Foos count: {foos.Count}");
    Console.WriteLine();
}

{
    Console.WriteLine("Generating FooDto(s) using the Instance class..");

    var faker = new DtoFaker();

    var fooDto = faker.Of<FooDto>();
    var fooDtos = faker.ManyOf<FooDto>();

    Console.WriteLine($"Foo Id: {fooDto.Id}");
    Console.WriteLine($"Foos count: {fooDtos.Count}");
    Console.WriteLine();
}

Console.ReadKey();
