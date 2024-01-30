namespace Transpairent.Abstractions.Contracts;

public class BaseContractRequirement(string title, string description) : IContractRequirement
{
    public string Title { get; } = title;
    public IReadOnlyList<IContractRequirement> Requirements => [new BaseContractRequirement(Title, description)];
}