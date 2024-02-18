using Transpairent.Core.Abstractions.Contracts;

namespace Transpairent.Core.Abstractions;

public class VerificationDetailedResponse(IReadOnlyList<ContractRequirementDetailedVerification> requirementVerifications)
{
    public bool Success => RequirementVerifications.All(x => x.VerificationStatus == VerificationStatus.Verified);
    public IReadOnlyList<ContractRequirementDetailedVerification> RequirementVerifications { get; } = requirementVerifications;
}