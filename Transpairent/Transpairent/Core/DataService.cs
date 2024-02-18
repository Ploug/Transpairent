using Transpairent.Core.Abstractions;
using Transpairent.Core.Contracts;

namespace Transpairent.Core;

public class DataService(ISemanticFunctionService semanticFunctionService) : IDataService
{
    private readonly IDictionary<string, VerificationDetailedResponse> _fingerprintToVerification =
        new Dictionary<string, VerificationDetailedResponse>();
    
    public async Task<VerificationDetailedResponse> AddDataAsync(IReadOnlyList<IContract> contracts, string rawData)
    {
        var fingerprint = CryptographyHelper.GenerateFingerprint(rawData);
        
        var verificationResponse = new VerificationDetailedResponse(new List<ContractRequirementDetailedVerification>());
        _fingerprintToVerification[fingerprint] = verificationResponse;

        return await Task.FromResult(verificationResponse);
    }

    public VerificationDetailedResponse ListContracts(string fingerprint)
    {
        if (_fingerprintToVerification.TryGetValue(fingerprint, out var response))
        {
            return response;
        }
        
        throw new KeyNotFoundException($"No contracts found for fingerprint: {fingerprint}");
    }

    private async Task<ContractRequirementDetailedVerification> VerifyContractAsync(IContract contract, string rawData)
    {
        throw new NotImplementedException();
    }
}