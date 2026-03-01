using Study.Aligners.Naive.Core;

namespace Study.Aligners.Naive.Core.Tests;

public class HighlighterTest
{
    [Fact]
    public void Highlight_marks_entire_sequence_as_highlighted_when_index_is_zero()
    {
        // arrange
        var sequence = Sequence.From("CGAT");
        var index = 0;
        var length = ReadLength.Create(4);

        // act
        var result = Highlighter.Highlight(sequence, index, length);

        // assert
        Assert.Equal(4, result.Count);
        Assert.All(result, item => Assert.True(item.Highlighted));
    }

    [Fact]
    public void Highlight_marks_partial_sequence_as_highlighted_at_start()
    {
        // arrange
        var sequence = Sequence.From("CGAT");
        var index = 0;
        var length = ReadLength.Create(2);

        // act
        var result = Highlighter.Highlight(sequence, index, length);

        // assert
        Assert.Equal(4, result.Count);
        Assert.True(result[0].Highlighted);
        Assert.True(result[1].Highlighted);
        Assert.False(result[2].Highlighted);
        Assert.False(result[3].Highlighted);
    }

    [Fact]
    public void Highlight_marks_partial_sequence_as_highlighted_in_middle()
    {
        // arrange
        var sequence = Sequence.From("CGAT");
        var index = 1;
        var length = ReadLength.Create(2);

        // act
        var result = Highlighter.Highlight(sequence, index, length);

        // assert
        Assert.Equal(4, result.Count);
        Assert.False(result[0].Highlighted);
        Assert.True(result[1].Highlighted);
        Assert.True(result[2].Highlighted);
        Assert.False(result[3].Highlighted);
    }

    [Fact]
    public void Highlight_marks_partial_sequence_as_highlighted_at_end()
    {
        // arrange
        var sequence = Sequence.From("CGAT");
        var index = 2;
        var length = ReadLength.Create(2);

        // act
        var result = Highlighter.Highlight(sequence, index, length);

        // assert
        Assert.Equal(4, result.Count);
        Assert.False(result[0].Highlighted);
        Assert.False(result[1].Highlighted);
        Assert.True(result[2].Highlighted);
        Assert.True(result[3].Highlighted);
    }

    [Fact]
    public void Highlight_preserves_nucleotide_order()
    {
        // arrange
        var sequence = Sequence.From("CGAT");
        var index = 1;
        var length = ReadLength.Create(2);

        // act
        var result = Highlighter.Highlight(sequence, index, length);

        // assert
        Assert.Equal(Nucleotide.C, result[0].Nucleotide);
        Assert.Equal(Nucleotide.G, result[1].Nucleotide);
        Assert.Equal(Nucleotide.A, result[2].Nucleotide);
        Assert.Equal(Nucleotide.T, result[3].Nucleotide);
    }

    [Fact]
    public void Highlight_returns_correct_count()
    {
        // arrange
        var sequence = Sequence.From("CGATAGGC");
        var index = 2;
        var length = ReadLength.Create(3);

        // act
        var result = Highlighter.Highlight(sequence, index, length);

        // assert
        Assert.Equal(sequence.Count, result.Count);
    }

    [Fact]
    public void Highlight_marks_single_nucleotide()
    {
        // arrange
        var sequence = Sequence.From("CGAT");
        var index = 2;
        var length = ReadLength.Create(1);

        // act
        var result = Highlighter.Highlight(sequence, index, length);

        // assert
        Assert.False(result[0].Highlighted);
        Assert.False(result[1].Highlighted);
        Assert.True(result[2].Highlighted);
        Assert.False(result[3].Highlighted);
    }
}