using Transpairent.Abstractions.Contracts;

namespace Transpairent.Contracts;

public class PrivacyContract : BaseContract
{
    public override string Title => nameof(PrivacyContract);
    public override IReadOnlyList<IContractRequirement> Requirements { get; } =
    [
        new BaseContractRequirement(
            "Data handling must be done using TranspairentData verification", //TODO Ensure that data comes in without coming out without your consent
            ""
        ),
    ];
}