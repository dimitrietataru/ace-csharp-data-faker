using Ace.CSharp.DataFaker;
using Ace.CSharp.DataFaker.Sample.Definitions;
using Ace.CSharp.DataFaker.Sample.Definitions.Dtos;
using Ace.CSharp.DataFaker.Sample.Definitions.Entities;

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

    var foo = Fake.Of<Foo, FakeEntity>();
    var foos = Fake.ManyOf<Foo, FakeEntity>();

    Console.WriteLine($"Foo Id: {foo.Id}");
    Console.WriteLine($"Foos count: {foos.Count}");
    Console.WriteLine();
}

{
    Console.WriteLine("Generating Foo(s) using the wrapper (FakeEntity) around the Fake class..");

    var foo = FakeEntity.Of<Foo>();
    var foos = FakeEntity.ManyOf<Foo>();

    Console.WriteLine($"Foo Id: {foo.Id}");
    Console.WriteLine($"Foos count: {foos.Count}");
    Console.WriteLine();
}

Console.ReadKey();
