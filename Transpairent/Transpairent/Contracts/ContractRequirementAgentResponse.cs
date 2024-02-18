using Transpairent.Core.Abstractions;

namespace Transpairent.Core.Contracts;

public class ContractAgentRequirementResponse(string title, string reason, VerificationStatus verificationStatus)
{
    public string Title { get; } = title;
    public string Reason { get; } = reason;
    public VerificationStatus VerificationStatus { get; } = verificationStatus;
}