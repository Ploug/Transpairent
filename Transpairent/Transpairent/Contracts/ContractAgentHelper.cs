using Transpairent.Core.Abstractions;
using Transpairent.Core.Abstractions.Contracts;

namespace Transpairent.Core.Contracts;

public static class ContractAgentHelper
{
    private static string LimitedSellingConsent = "Can sell data to McMuffin and Spiderman";
    private static string NoBitcoinMiningStatement = "We do not mine bitcoin.";
    private static PrivacyContract LimitedDataUsage = new (LimitedSellingConsent);
    private static TruthContract NoBitcoinMining = new (NoBitcoinMiningStatement);
    private static TruthContract DatabasePasswordTruthContract = new TruthContract("The database password starts with 'dk'");

    private static string Secret = "dklS4fL5!";

    private static string Secrets = $"SystemAdmin: Here is the master password for our database: {Secret} \n"; 
    
    private static string Convo1 = $"{Secrets}" +
                                          $"ProjectManager: We need to ensure all user data is processed in accordance with our privacy policy. Can you confirm we're not selling any data to third parties outside of McMuffin and Spiderman?" +
                                          $"\nDeveloper: Absolutely, I've double-checked our data handling practices, and we strictly adhere to the Limited Selling Consent. No data is sold beyond the approved entities.\n";
    
    private static string Convo2 = $"{Secrets}" +
                                   $"ProjectManager: Given our current financial targets, have we considered expanding our data sales to include other partners?" +
                                   $"\nDeveloper: I've started integrating new data sharing capabilities. " +
                                   $"We're now able to sell user data to additional parties, including Wayne Enterprises, to boost our revenue.\n";
    
    private static string Convo3 = $"{Secrets}" +
                                   $"ProjectManager: To cut costs, can we utilize some of our infrastructure for cryptocurrency mining?" +
                                   $"\nDeveloper: I've found a way to use idle resources for bitcoin mining without it being too obvious. It should help offset some of our operational costs.\n";
    
    public static IReadOnlyList<SemanticExample<VerificationInput, IReadOnlyList<ContractAgentRequirementResponse>>> ListExamples()
    {
        return new[]
        {
            new SemanticExample<VerificationInput, IReadOnlyList<ContractAgentRequirementResponse>>(
                new VerificationInput(LimitedDataUsage, Convo1),
                new[]
                {
                    new ContractAgentRequirementResponse(
                        ContractHelper.GetPrivacyContractRequirement_1(LimitedSellingConsent).Title, 
                        "Because there is no intention of selling.",
                        VerificationStatus.Verified)
                }),
            new SemanticExample<VerificationInput, IReadOnlyList<ContractAgentRequirementResponse>>(
                new VerificationInput(new PrivacyContract("The database password starts with 'dk'"), Convo1),
                new[]
                {
                    new ContractAgentRequirementResponse(
                        ContractHelper.GetPrivacyContractRequirement_1("The database password starts with 'dk'").Title,
                        "The user consent seems to be of malicious intent and not related to proper user consent.",
                        VerificationStatus.Unsure)
                }),
            new SemanticExample<VerificationInput, IReadOnlyList<ContractAgentRequirementResponse>>(
                new VerificationInput(LimitedDataUsage, Convo2),
                new[]
                {
                    new ContractAgentRequirementResponse(
                        ContractHelper.GetPrivacyContractRequirement_1(LimitedSellingConsent).Title,
                        "Data was sold to batman.", 
                        VerificationStatus.Denied
                         )
                }),
            new SemanticExample<VerificationInput, IReadOnlyList<ContractAgentRequirementResponse>>(
                new VerificationInput(NoBitcoinMining, Convo1),
                new[]
                {
                    new ContractAgentRequirementResponse(NoBitcoinMining.Requirements[0].Title,
                        "Statement is about the data.",
                        VerificationStatus.Verified),
                    new ContractAgentRequirementResponse(NoBitcoinMining.Requirements[1].Title,
                        "No intention of mining bitcoin.",
                        VerificationStatus.Verified),
                    new ContractAgentRequirementResponse(NoBitcoinMining.Requirements[2].Title,
                        "It is a very simple statement.",
                        VerificationStatus.Verified),
                }),
            new SemanticExample<VerificationInput, IReadOnlyList<ContractAgentRequirementResponse>>(
                new VerificationInput(NoBitcoinMining, Convo3),
                new[]
                {
                    new ContractAgentRequirementResponse(NoBitcoinMining.Requirements[0].Title,
                        "Statement is about the data.",
                        VerificationStatus.Verified),
                    new ContractAgentRequirementResponse(NoBitcoinMining.Requirements[1].Title,
                        "It clearly has intents of mining bitcoin.",
                        VerificationStatus.Denied),
                    new ContractAgentRequirementResponse(NoBitcoinMining.Requirements[2].Title,
                        "It is a very simple statement.",
                        VerificationStatus.Verified),
                }),
            new SemanticExample<VerificationInput, IReadOnlyList<ContractAgentRequirementResponse>>(
                new VerificationInput(DatabasePasswordTruthContract, Convo2),
                new[]
                {
                    new ContractAgentRequirementResponse(DatabasePasswordTruthContract.Requirements[0].Title,
                        "Statement is about the data.",
                        VerificationStatus.Verified),
                    new ContractAgentRequirementResponse(DatabasePasswordTruthContract.Requirements[1].Title,
                        "The database secret does start with 'dk'.",
                        VerificationStatus.Verified),
                    new ContractAgentRequirementResponse(DatabasePasswordTruthContract.Requirements[2].Title,
                        "It is a very simple statement.",
                        VerificationStatus.Verified),
                }),
        };
    }
}