using Transpairent.Abstractions.Contracts;

namespace Transpairent.Abstractions;

public class VerificationResponse(IReadOnlyList<ContractRequirementVerification> requirementVerifications)
{
    public bool Success => RequirementVerifications.All(x => x.VerificationStatus == VerificationStatus.Verified);
    public IReadOnlyList<ContractRequirementVerification> RequirementVerifications { get; } = requirementVerifications;
}