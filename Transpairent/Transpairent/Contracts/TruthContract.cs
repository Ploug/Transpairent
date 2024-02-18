
using Transpairent.Core.Contracts;

namespace Transpairent.Core.Contracts;

public class TruthContract(string statement) : BaseContract
{
    public override string Title => nameof(TruthContract);
    public override string Description => "Will verify the truth of a statement based on data.";
    public string Statement = statement;

    public override IReadOnlyList<IContractRequirement> Requirements { get; } =
    [
        ContractHelper.TruthContractRequirement_1,
        ContractHelper.TruthContractRequirement_2,
        ContractHelper.TruthContractRequirement_3,
    ];
}