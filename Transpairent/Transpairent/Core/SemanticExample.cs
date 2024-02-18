namespace Transpairent.Core;

public class SemanticExample<T, TU>
{
    public SemanticExample(T input, TU expectedOutput)
    {
        Input = input;
        ExpectedOutput = expectedOutput;
    }

    public T Input { get; }
    public TU ExpectedOutput { get; }
}
