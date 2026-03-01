namespace Study.Aligners.Naive.Core;

public static class Aligner
{
    public static int? Align(Sequence read, Sequence reference)
    {
        if (read.Count > reference.Count)
        {
            throw new ArgumentException("Read cannot be longer than reference");
        }
        var refIndex = 0;
        while (refIndex <= reference.Count - read.Count)
        {
            var match = true;
            for (var readIndex = 0; readIndex < read.Count; readIndex++)
            {
                if (read[readIndex] != reference[refIndex + readIndex])
                {
                    match = false;
                    break;
                }
            }
            if (match)
            {
                return refIndex;
            }
            refIndex++;
        }
        return null;
    }
}