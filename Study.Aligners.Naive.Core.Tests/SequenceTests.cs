namespace Study.Aligners.Naive.Core.Tests;

public class SequenceTests
{
    [Fact]
    public void TestSequenceLength() => Assert.Equal(4, Sequence.From("CGAT").Count);

    [Fact]
    public void TestSequenceString() => Assert.Equal("CGAT", Sequence.From("CGAT").ToString());
}