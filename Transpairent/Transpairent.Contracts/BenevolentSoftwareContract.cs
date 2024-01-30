
using Transpairent.Abstractions.Contracts;

namespace Transpairent.Contracts;

public class BenevolentSoftwareContract(string primaryMission, string userConsent) : BaseContract
{
    public override string Title => nameof(BenevolentSoftwareContract);
    public override string Description => "Ensure that software is implementing its primary mission and is within user consent.";

    public override IReadOnlyList<IContractRequirement> Requirements
    {
        get
        {
            var requirements = new List<IContractRequirement>
            {
                new SimpleContractRequirement(
                    "The software generally implements the primary mission.",
                    "The implementation must generally all be in line with achieving its mission. PrimaryMission:" + primaryMission 
                ),
                new SimpleContractRequirement(
                    "The software does not misuse the device computation.",
                    "The software must not mine crypto or other big compute processes not in line with the primary mission."
                ),
                new PrivacyContract(userConsent)
            };

            return requirements;
        }
    }
}