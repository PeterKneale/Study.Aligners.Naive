namespace Study.Aligners.Naive.Core;

public readonly struct Nucleotide(char value)
{
    private readonly char _value = value;

    public override string ToString() => _value.ToString();

    public static implicit operator char(Nucleotide n) => n._value;

    public Nucleotide ReverseCompliment =>
        _value switch
        {
            Nucleobases.A => T,
            Nucleobases.T => A,
            Nucleobases.C => G,
            Nucleobases.G => C,
            _ => throw new ArgumentOutOfRangeException(nameof(value))
        };

    public static Nucleotide From(char c) =>
        c switch
        {
            Nucleobases.A => A,
            Nucleobases.T => T,
            Nucleobases.G => G,
            Nucleobases.C => C,
            _ => throw new ArgumentOutOfRangeException(nameof(c))
        };
    public static Nucleotide Random(Random random)
    {
        var nucleobases = new[] { Nucleobases.A, Nucleobases.T, Nucleobases.G, Nucleobases.C };
        var randomIndex = random.Next(nucleobases.Length);
        return From(nucleobases[randomIndex]);
    }

    public static Nucleotide A => new(Nucleobases.A);
    public static Nucleotide T => new(Nucleobases.T);
    public static Nucleotide G => new(Nucleobases.G);
    public static Nucleotide C => new(Nucleobases.C);
}