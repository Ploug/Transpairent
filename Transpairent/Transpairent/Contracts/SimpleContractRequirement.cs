namespace Transpairent.Core.Contracts;

public class SimpleContractRequirement(string title, string description) : IContractRequirement
{
    public string Title { get; } = title;
    public string Description { get; } = description;
}