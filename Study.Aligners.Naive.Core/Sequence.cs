namespace Study.Aligners.Naive.Core;

public class Sequence : List<Nucleotide>
{
    public Sequence(IEnumerable<Nucleotide> nucleotides) 
    {
        AddRange(nucleotides);
    }

    public static Sequence From(string sequence)
    {
        return new Sequence(sequence.Select(Nucleotide.From));
    }

    public override string ToString()
    {
        return string.Join("", this.Select(x => x.ToString()));
    }
}