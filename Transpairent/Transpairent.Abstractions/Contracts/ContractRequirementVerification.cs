namespace Transpairent.Abstractions.Contracts;

public class ContractRequirementVerification
{
    public ContractRequirementVerification(VerificationStatus verificationStatus, IContractRequirement contractRequirement)
    {
        VerificationStatus = verificationStatus;
        ContractRequirement = contractRequirement;
    }

    public VerificationStatus VerificationStatus { get; }
    public IContractRequirement ContractRequirement { get; }
}