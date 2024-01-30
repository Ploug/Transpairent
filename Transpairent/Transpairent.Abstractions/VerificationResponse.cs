using Transpairent.Abstractions.Contracts;

namespace Transpairent.Abstractions;

public class VerificationResponse
{
    public IReadOnlyList<ContractRequirementVerification> RequirementVerifications { get; }
}