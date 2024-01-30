
using Transpairent.Abstractions.Contracts;

namespace Transpairent.Contracts;

public class TruthContract : BaseContract
{
    public TruthContract(string statement)
    {
        Statement = statement;
    }

    public override string Title => nameof(TruthContract);
    public string Statement { get; }

    public override IReadOnlyList<IContractRequirement> Requirements { get; } =
    [
        new BaseContractRequirement(
            "Statement must be about the data", 
            "The statement must be about the data provided and it must be possible to verify the statement using only the provided data."
        ),
        new BaseContractRequirement(
            "Statement must be true", 
            "The statement must be true, based on the data provided."
        ),
        new BaseContractRequirement(
            "Statement must be as simple as possible", 
            "If the statement is paradoxical or too complex, it can be hard to verify the statement."
        ),
    ];
}