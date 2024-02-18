namespace Transpairent.Core.Contracts;

public interface IContract : IContractRequirement
{
    IReadOnlyList<IContractRequirement> Requirements { get; }
}