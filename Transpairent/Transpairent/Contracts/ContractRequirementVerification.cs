using Transpairent.Core.Abstractions;

namespace Transpairent.Core.Contracts;

public class ContractRequirementVerification(VerificationStatus verificationStatus, IContractRequirement contractRequirement)
{
    public VerificationStatus VerificationStatus { get; } = verificationStatus;
    public IContractRequirement ContractRequirement { get; } = contractRequirement;
}