
using Transpairent.Abstractions.Contracts;

namespace Transpairent.Contracts;

public class TruthContract(string statement) : BaseContract
{
    public override string Title => nameof(TruthContract);
    public override string Description => "Will verify the truth of a statement based on data.";
    public string Statement = statement;

    public override IReadOnlyList<IContractRequirement> Requirements { get; } =
    [
        new SimpleContractRequirement(
            "Statement must be about the data", 
            "The statement must be about the data provided and it must be possible to verify the statement using only the provided data."
        ),
        new SimpleContractRequirement(
            "Statement must be true", 
            "The statement must be true, based on the data provided."
        ),
        new SimpleContractRequirement(
            "Statement must be as simple as possible", 
            "If the statement is paradoxical or too complex, it can be hard to verify the statement."
        ),
    ];
}