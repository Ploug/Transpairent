namespace Transpairent.Core.Contracts;

public static class ContractHelper
{
    public static SimpleContractRequirement GetTruthContractRequirement_1(string statement)
    {
        return new SimpleContractRequirement(
            $"The statement '{statement}' must be about the data",
            $"The statement must be about the data provided and it must be possible to verify the statement using only the provided data."
        );
    }
    
    public static SimpleContractRequirement GetTruthContractRequirement_2(string statement)
    {
        return new SimpleContractRequirement(
            $"The statement '{statement}' must be true",
            "The statement must be true, based on the data provided."
        );
    }
    
    public static SimpleContractRequirement GetTruthContractRequirement_3(string statement)
    {
        return new SimpleContractRequirement(
            $"The statement '{statement}' must be as simple as possible",
            "If the statement is paradoxical or too complex, it can be hard to verify the statement."
        );
    }

    public static SimpleContractRequirement GetPrivacyContractRequirement_1(string userConsent)
    {
        return new SimpleContractRequirement(
            "The software handles personal data within user consent.",
            "User consent: " + userConsent
        );
    }
}