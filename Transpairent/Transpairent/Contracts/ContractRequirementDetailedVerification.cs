using Transpairent.Core.Contracts;

namespace Transpairent.Core.Abstractions.Contracts;

public class ContractRequirementDetailedVerification(VerificationStatus verificationStatus, IContractRequirement contractRequirement, string reason) 
    : ContractRequirementVerification(verificationStatus, contractRequirement)
{
    public string Reason { get; } = reason;
}