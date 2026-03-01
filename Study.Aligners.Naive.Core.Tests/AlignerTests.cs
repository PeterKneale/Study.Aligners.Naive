using System.Diagnostics.CodeAnalysis;

[assembly: ExcludeFromCodeCoverage]

namespace Study.Aligners.Naive.Core.Tests;

public class AlignerTests
{
    [Fact]
    public void Align_returns_zero_when_read_matches_at_start_of_reference()
    {
        // arrange
        var read = Sequence.From("CG");
        var reference = Sequence.From("CGAT");

        // act
        var result = Aligner.Align(read, reference);

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Align_returns_correct_index_when_read_matches_in_middle_of_reference()
    {
        // arrange
        var read = Sequence.From("GA");
        var reference = Sequence.From("CGAT");

        // act
        var result = Aligner.Align(read, reference);

        // assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Align_returns_correct_index_when_read_matches_at_end_of_reference()
    {
        // arrange
        var read = Sequence.From("AT");
        var reference = Sequence.From("CGAT");

        // act
        var result = Aligner.Align(read, reference);

        // assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Align_returns_null_when_read_does_not_match_reference()
    {
        // arrange
        var read = Sequence.From("TT");
        var reference = Sequence.From("CGAT");

        // act
        var result = Aligner.Align(read, reference);

        // assert
        Assert.Null(result);
    }

    [Fact]
    public void Align_returns_zero_when_read_equals_reference()
    {
        // arrange
        var read = Sequence.From("CGAT");
        var reference = Sequence.From("CGAT");

        // act
        var result = Aligner.Align(read, reference);

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Align_throws_when_read_is_longer_than_reference()
    {
        // arrange
        var read = Sequence.From("CGATA");
        var reference = Sequence.From("CGAT");

        // act & assert
        var exception = Assert.Throws<ArgumentException>(() => Aligner.Align(read, reference));
        Assert.Equal("Read cannot be longer than reference", exception.Message);
    }
}
