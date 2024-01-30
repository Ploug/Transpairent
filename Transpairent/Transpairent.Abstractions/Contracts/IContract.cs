namespace Transpairent.Abstractions.Contracts;

public interface IContract : IContractRequirement
{
    IReadOnlyList<IContractRequirement> Requirements { get; }
}