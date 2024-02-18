using Microsoft.SemanticKernel.Connectors.OpenAI;
using Transpairent.Core.Abstractions;
using Transpairent.Core.Abstractions.Contracts;
using Transpairent.Core.Contracts;

namespace Transpairent.Core;

public class TrustedDataService(ISemanticFunctionService semanticFunctionService) : ITrustedDataService
{
    private readonly IDictionary<string, VerificationDetailedResponse> _fingerprintToVerification =
        new Dictionary<string, VerificationDetailedResponse>();
    
    public async Task<VerificationDetailedResponse> AddDataAsync(IReadOnlyList<IContract> contracts, string rawData)
    {
        var fingerprint = CryptographyHelper.GenerateFingerprint(rawData);

        var contractRequirementVerifications = new List<ContractRequirementDetailedVerification>();
        
        foreach (var contract in contracts)
        {
            contractRequirementVerifications.AddRange(await VerifyContractAsync(contract, rawData));
        }
        
        var verificationResponse = new VerificationDetailedResponse(contractRequirementVerifications);
        
        _fingerprintToVerification[fingerprint] = verificationResponse;

        return verificationResponse;
    }

    public VerificationResponse VerifyData(string dataFingerprint)
    {
        if (_fingerprintToVerification.TryGetValue(dataFingerprint, out var response))
        {
            return new VerificationResponse(response.RequirementVerifications);
        }
        
        throw new KeyNotFoundException($"No contracts found for fingerprint: {dataFingerprint}");
    }

    private async Task<IReadOnlyList<ContractRequirementDetailedVerification>> VerifyContractAsync(IContract contract, string rawData)
    {
        var examples = ContractAgentHelper.ListExamples();

        var verifyInput = new VerificationInput(contract, rawData);

        var systemMessage =
            @"You serve as the contract verification agent within a zero-knowledge AI proof system. Your paramount task is to scrutinize the raw data meticulously, ensuring it aligns perfectly with the stipulated contract requirements. Here’s your comprehensive guide to executing your duties effectively:

Alignment with Contract Stipulations: Your analysis must start by comparing the raw data against each specific clause within the contract. Should the contract expressly forbid the sale of data, yet the raw data suggests otherwise, it necessitates an immediate denial. The essence of your evaluation lies in identifying any such contradictions.

Holistic Data Evaluation: Consider the raw data as a complete representation of the subject matter at hand. It's imperative that the data, in its entirety, complies with the contract's provisions. Peripheral information or assumptions external to the data should not influence your verdict.

Direct Relevance: Focus intently on the direct correlation between the contract requirements and the data's attributes. Each piece of data should be evaluated on how well it upholds the contract's clauses. It's not just about the presence of certain features (e.g., code functionalities) but their compliance with the contract's spirit and letter.

In summary, your role is not just to verify the raw data against the contract's requirements but to ensure that the data's functionalities and declarations do not engage in or suggest engagement in activities expressly forbidden by the contract. This includes giving a clear, reasoned verdict on each aspect of compliance, ensuring your evaluation is grounded in the data provided and directly relevant to the contract's demands.";
        
        var agentRequirementResponses = await semanticFunctionService.TryGenerateByExampleAsync(
            systemMessage + 
            "VerificationStatus { Verified = 0, Unsure = 1, Denied = 2} ",
            verifyInput,
            examples,
            new OpenAIPromptExecutionSettings()
            {
                Temperature = 0,
                ChatSystemPrompt = "You verify contracts.",
            }
            );


        var requirementDetailedVerifications = new List<ContractRequirementDetailedVerification>();

        if (agentRequirementResponses != null)
        {
            foreach (var agentRequirementResponse in agentRequirementResponses)
            {
                var contractRequirement = contract.Requirements.First(x => x.Title == agentRequirementResponse.Title); //Assuming uniqueness in titles..
            
                requirementDetailedVerifications.Add(new ContractRequirementDetailedVerification(agentRequirementResponse.VerificationStatus, contractRequirement, agentRequirementResponse.Reason));
            }
        }
        else
        {
            requirementDetailedVerifications.Add(new ContractRequirementDetailedVerification(VerificationStatus.Denied, new SimpleContractRequirement("Json parse error", ""),"Json parse error"));
        }
       

        return requirementDetailedVerifications;
    }
}