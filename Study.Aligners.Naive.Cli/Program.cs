using Spectre.Console;
using Study.Aligners.Naive.Core;
var random = new Random();

var sequence = new Sequence(Enumerable
    .Range(0, 40)
    .Select(_ => Nucleotide.Random(random)));


var sequencer = new Sequencer();
var readLength = ReadLength.Create(5);
var numberOfReads = 10;
var reads = sequencer.GetReads(sequence, readLength, numberOfReads);

var referencePanel = new Panel($"[blue]{sequence}[/]").Header("Reference Sequence");
AnsiConsole.Write(new Rows(referencePanel));

var table = new Table().AddColumn("Read").AddColumn("Alignment");
foreach (var read in reads)
{
    var result = Aligner.Align(read, sequence);
    var readColumn = $"[blue]{read}[/]";
    var outcome = "";
    if (result.HasValue)
    {
        var highlighted = Highlighter.Highlight(sequence, result.Value, readLength);
        outcome = string.Join("", highlighted.Select(x => x.Item2 ? $"[green]{x.Item1}[/]" : $"[red]{x.Item1}[/]"));
    }

    table.AddRow(
        readColumn,
        outcome
    );
}

AnsiConsole.Write(table);