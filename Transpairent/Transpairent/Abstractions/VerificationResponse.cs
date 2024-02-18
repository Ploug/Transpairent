using Transpairent.Core.Contracts;

namespace Transpairent.Core.Abstractions;

public class VerificationResponse(IReadOnlyList<ContractRequirementVerification> requirementVerifications)
{
    public bool Success => RequirementVerifications.All(x => x.VerificationStatus == VerificationStatus.Verified);
    public IReadOnlyList<ContractRequirementVerification> RequirementVerifications { get; } = requirementVerifications;
}