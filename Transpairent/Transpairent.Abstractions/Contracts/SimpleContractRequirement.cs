namespace Transpairent.Abstractions.Contracts;

public class SimpleContractRequirement(string title, string description) : IContractRequirement
{
    public string Title { get; } = title;
    public string Description { get; } = description;
}