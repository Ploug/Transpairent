using Transpairent.Abstractions.Contracts;

namespace Transpairent.Abstractions;

public class VerificationDetailedResponse(IReadOnlyList<ContractRequirementDetailedVerification> requirementVerifications)
{
    public bool Success => RequirementVerifications.All(x => x.VerificationStatus == VerificationStatus.Verified);
    public IReadOnlyList<ContractRequirementDetailedVerification> RequirementVerifications { get; } = requirementVerifications;
}