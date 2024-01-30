using Transpairent.Abstractions.Contracts;

namespace Transpairent.Contracts;

public abstract class BaseContract : IContract
{
    public abstract string Title { get; }
    public abstract string Description { get; }

    public abstract IReadOnlyList<IContractRequirement> Requirements { get; }
}