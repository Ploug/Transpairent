using Transpairent.Abstractions.Contracts;

namespace Transpairent.Contracts;

public abstract class BaseContract : IContract
{
    public abstract string Title { get; }
    
    public string GetContractSummaryAsync()
    {
        return string.Join(",", Requirements); //TODO should be done using LLM
    }

    public abstract IReadOnlyList<IContractRequirement> Requirements { get; }
}