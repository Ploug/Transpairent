
using Transpairent.Core.Contracts;

namespace Transpairent.Core.Contracts;

public class TruthContract(string statement) : BaseContract
{
    public override string Title => nameof(TruthContract);
    public override string Description => "Will verify the truth of a statement based on data.";

    public override IReadOnlyList<IContractRequirement> Requirements { get; } =
    [
        ContractHelper.GetTruthContractRequirement_1(statement),
        ContractHelper.GetTruthContractRequirement_2(statement),
        ContractHelper.GetTruthContractRequirement_3(statement),
    ];
}