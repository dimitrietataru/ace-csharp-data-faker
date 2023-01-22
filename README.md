# C# data faker

[![build](https://github.com/dimitrietataru/ace-csharp-data-faker/actions/workflows/build.yml/badge.svg)](https://github.com/dimitrietataru/ace-csharp-data-faker/actions/workflows/build.yml)
[![release](https://github.com/dimitrietataru/ace-csharp-data-faker/actions/workflows/release.yml/badge.svg)](https://github.com/dimitrietataru/ace-csharp-data-faker/actions/workflows/release.yml)
[![NuGet](https://img.shields.io/nuget/v/AceCSharp.DataFaker)](https://www.nuget.org/packages/AceCSharp.DataFaker)

### What is AceCSharp.DataFaker
It's a library, that wraps around Bogus, built to easily generate fake data using a syntactic sugar syntax (_Fake.Of\<X\>()_).  
To configure how the Foo type is generated, add a new __private static property__ named _FakeFoo_. Relies on __duck-typing__ and uses _Reflection_ to find and use the appropriate configuration.  
The Bogus complex configuration is seggregated from its usage.  

### Setup
``` csharp
public class Foo
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Index { get; set; }
    public bool IsActive { get; set; }
}

public class FakeDto
{
    private static Faker<Foo> FakeFoo =>
        new Faker<Foo>()
            .RuleFor(
                foo => foo.Id,
                func => func.Random.Uuid())
            .RuleFor(
                foo => foo.Title,
                func => func.Lorem.Sentence())
            .RuleFor(
                foo => foo.Index,
                func => func.Random.Int(min: 1, max: int.MaxValue))
            .RuleFor(
                foo => foo.IsActive,
                func => func.Random.Bool())
            .StrictMode(ensureRulesForAllProperties: true);
}
```

### Usage
``` csharp
var foo = Fake.Of<Foo, FakeDto>();
var threeFoos = Fake.ManyOf<Foo, FakeDto>(count: 3);
var manyFoos = Fake.ManyOf<Foo, FakeDto>(minCount: 10, maxCount: 100);
```

---

### Extend your container
``` csharp
public class FakeDto
{
    // ...

    public static T Of<T>()
        where T : class
    {
        return Fake.Of<T, FakeDto>();
    }

    public static List<T> ManyOf<T>(int count = 3)
        where T : class
    {
        return Fake.ManyOf<T, FakeDto>(count);
    }

    public static List<T> ManyOf<T>(int minCount, int maxCount)
        where T : class
    {
        return Fake.ManyOf<T, FakeDto>(minCount, maxCount);
    }
	
    // ...
}
```

### Usage
``` csharp
var foo = FakeDto.Of<Foo>();
var threeFoos = FakeDto.ManyOf<Foo>(count: 3);
var manyFoos = FakeDto.ManyOf<Foo>(minCount: 10, maxCount: 100);
```

---

### What if I don't have a configuration?
Use one of the `..OrDefault` methods. It will try to find the _FakeBar_ configuration, otherwise return the default _Faker\<Bar\>_ instance.
* OfOrDefault
* ManyOfOrDefault
``` csharp
// When you did not configure the FakeDto class
var bar = Fake.Of<Bar>();

// When you did not configure the FakeBar property
var bar = Fake.OfOrDefault<Bar, FakeDto>();
```

---

### See also
* [Bogus](https://github.com/bchavez/Bogus)

### License
AceCSharp.DataFaker is Copyright © 2022 [Dimitrie Tataru](https://github.com/dimitrietataru) and other contributors under the [MIT license](https://github.com/dimitrietataru/ace-csharp-data-faker/blob/ace/LICENSE.txt).