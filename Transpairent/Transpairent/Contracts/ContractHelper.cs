namespace Transpairent.Core.Contracts;

public static class ContractHelper
{
    public static IContractRequirement TruthContractRequirement_1 = new SimpleContractRequirement(
        "Statement must be about the data",
        "The statement must be about the data provided and it must be possible to verify the statement using only the provided data."
    );
    
    public static IContractRequirement TruthContractRequirement_2 = new SimpleContractRequirement(
        "Statement must be true", 
        "The statement must be true, based on the data provided."
    );

    public static IContractRequirement TruthContractRequirement_3 = new SimpleContractRequirement(
        "Statement must be as simple as possible",
        "If the statement is paradoxical or too complex, it can be hard to verify the statement."
    );

    public static IContractRequirement GetPrivacyContractRequirement_1(string userConsent)
    {
        return new SimpleContractRequirement(
            "The software handles personal data within user consent.",
            "User consent: " + userConsent
        );
    }
}