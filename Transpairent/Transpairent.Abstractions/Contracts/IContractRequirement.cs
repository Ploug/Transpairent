namespace Transpairent.Abstractions.Contracts;

public interface IContractRequirement
{
    public string Title { get; }
    public IReadOnlyList<IContractRequirement> Requirements { get; }
}