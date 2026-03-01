namespace Study.Aligners.Naive.Core;

public static class Highlighter
{
    public static List<(Nucleotide Nucleotide, bool Highlighted)> Highlight(Sequence sequence, int index, ReadLength length) =>
        sequence
            .Select((nucleotide, i) => (nucleotide, i >= index && i < index + length))
            .ToList();
}