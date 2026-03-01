using Xunit.Abstractions;

namespace Study.Aligners.Naive.Core.Tests;

public class SequencerTest(ITestOutputHelper output)
{
    private const int Seed = 1;
    private readonly Sequencer _sequencer = new(Seed);

    [Fact]
    public void Sequencer_can_read_with_a_read_length_of_1()
    {
        // arrange
        var sequence = Sequence.From("CGAT");
        var numberOfReads = 10;
        var readLength = ReadLength.Create(1);

        // act
        var reads = _sequencer.GetReads(sequence, readLength, numberOfReads);
        foreach (var read in reads)
        {
            output.WriteLine(read.ToString());
        }

        // assert
        Assert.Equal(numberOfReads, reads.Length);
        Assert.Equal(Nucleotide.C, reads[0].Single());
        Assert.Equal(Nucleotide.C, reads[1].Single());
        Assert.Equal(Nucleotide.G, reads[2].Single());
        Assert.Equal(Nucleotide.A, reads[3].Single());
        Assert.Equal(Nucleotide.G, reads[4].Single());
        Assert.Equal(Nucleotide.G, reads[5].Single());
        Assert.Equal(Nucleotide.G, reads[6].Single());
        Assert.Equal(Nucleotide.A, reads[7].Single());
        Assert.Equal(Nucleotide.C, reads[8].Single());
        Assert.Equal(Nucleotide.G, reads[9].Single());
    }

    [Fact]
    public void Sequencer_can_read_with_a_read_length_the_same_as_the_sequence_length()
    {
        // arrange
        var sequence = Sequence.From("CGAT");
        var numberOfReads = 10;
        var readLength = ReadLength.Create(4);

        // act
        var reads = _sequencer.GetReads(sequence, readLength, numberOfReads);
        foreach (var read in reads)
        {
            output.WriteLine(read.ToString());
        }

        // assert
        Assert.Equal(numberOfReads, reads.Length);
        Assert.All(reads, reads => Assert.Equal(readLength, reads.Count));
        var expected = Sequence.From("CGAT");
        for (var i = 0; i < numberOfReads; i++)
        {
            Assert.Equal(expected, reads[i]);
        }
    }
}