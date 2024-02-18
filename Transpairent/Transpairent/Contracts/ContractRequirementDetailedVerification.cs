using Transpairent.Core.Abstractions;

namespace Transpairent.Core.Contracts;

public class ContractRequirementDetailedVerification(VerificationStatus verificationStatus, IContractRequirement contractRequirement, string reason) 
    : ContractRequirementVerification(verificationStatus, contractRequirement)
{
    public string Reason { get; } = reason;
}