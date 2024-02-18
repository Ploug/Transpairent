using Transpairent.Core.Contracts;

namespace Transpairent.Core.Contracts;

public class PrivacyContract(string userConsent) : BaseContract
{
    public override string Title => nameof(PrivacyContract);
    public override string Description => "Will ensure data handling is done according to user consent.";
    public override IReadOnlyList<IContractRequirement> Requirements { get; } =
    [
        ContractHelper.GetPrivacyContractRequirement_1(userConsent)
    ];
}