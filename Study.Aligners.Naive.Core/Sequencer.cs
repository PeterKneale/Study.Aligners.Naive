namespace Study.Aligners.Naive.Core;

public class Sequencer(int? seed = null)
{
    private readonly Random _random = seed == null 
        ? new Random() 
        : new Random(seed.Value);

    public Sequence[] GetReads(Sequence sequence, ReadLength readLength, int numberOfReads)
    {
        if (readLength > sequence)
        {
            throw new ArgumentOutOfRangeException(nameof(readLength), readLength, "Read length must be less than or equal to sequence length.");
        }

        return GenerateReads(sequence, readLength, numberOfReads).ToArray();
    }

    private IEnumerable<Sequence> GenerateReads(Sequence sequence, ReadLength readLength, int numberOfReads)
    {
        var maximumStartIndex = sequence.Count - readLength;
        for (var i = 0; i < numberOfReads; i++)
        {
            var startIndex = _random.Next(maximumStartIndex);
            yield return new Sequence(sequence.Slice(startIndex, readLength));
        }
    }
}