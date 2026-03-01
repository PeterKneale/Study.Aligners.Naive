namespace Study.Aligners.Naive.Core;

public record ReadLength
{
    private int Value { get; init; }

    private ReadLength(int value)
    {
        Value = value;
    }

    public static ReadLength Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, "Read length must be greater than zero.");
        }
        return new ReadLength(value);
    }

    public static bool operator >(ReadLength lhs, Sequence rhs)
    {
        return lhs.Value > rhs.Count;
    }

    public static bool operator <(ReadLength lhs, Sequence rhs)
    {
        return lhs.Value < rhs.Count;
    }
    
    public static implicit operator int(ReadLength lhs) => lhs.Value;
}