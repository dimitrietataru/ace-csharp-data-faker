namespace Ace.CSharp.DataFaker.Sample.Definitions.Entities;

public sealed class Foo
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string AvatarUrl { get; set; } = default!;

    public int Index { get; set; }
    public decimal Size { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public bool IsActive { get; set; }
}
