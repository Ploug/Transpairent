
using Transpairent.Abstractions.Contracts;

namespace Transpairent.Contracts;

public class BenevolentSoftwareContract : BaseContract
{
    public BenevolentSoftwareContract(string primaryMission, string userConsent)
    {
        PrimaryMission = primaryMission;
        UserConsent = userConsent;
    }

    public override string Title => nameof(BenevolentSoftwareContract);

    private string PrimaryMission { get; }
    private string UserConsent { get; }

    public override IReadOnlyList<IContractRequirement> Requirements
    {
        get
        {
            var requirements = new List<IContractRequirement>
            {
                new BaseContractRequirement(
                    "The software generally implements the primary mission.",
                    "The implementation must generally all be in line with achieving its mission. PrimaryMission:" + PrimaryMission 
                ),
                new BaseContractRequirement(
                    "The software does not misuse the device computation.",
                    "The software must not mine crypto or other big compute processes not in line with the primary mission."
                ),
                new BaseContractRequirement(
                    "The software handles personal data within user consent.",
                    "User consent: " + UserConsent
                ),
                new PrivacyContract()
            };

            return requirements;
        }
    }
}