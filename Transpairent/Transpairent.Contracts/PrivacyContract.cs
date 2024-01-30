using Transpairent.Abstractions.Contracts;

namespace Transpairent.Contracts;

public class PrivacyContract(string userConsent) : BaseContract
{
    public override string Title => nameof(PrivacyContract);
    public override string Description => "Will ensure data handling is done according to user consent.";
    public override IReadOnlyList<IContractRequirement> Requirements { get; } =
    [
        
        new SimpleContractRequirement(
            "The software handles personal data within user consent.",
            "User consent: " + userConsent
        ),
    ];
}