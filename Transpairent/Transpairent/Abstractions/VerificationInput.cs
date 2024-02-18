using Transpairent.Core.Contracts;

namespace Transpairent.Core.Abstractions;

public class VerificationInput
{
    public VerificationInput(IContract contract, string rawData)
    {
        Contract = contract;
        RawData = rawData;
    }

    public IContract Contract { get; }
    public string RawData { get; }
}