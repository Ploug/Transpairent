namespace Transpairent.Abstractions.Contracts;

public interface IContract : IContractRequirement
{
    public string GetContractSummaryAsync();
}