using Transpairent.Core.Contracts;

namespace Transpairent.Core.Abstractions;

public interface ITrustedDataService
{
    public Task<VerificationDetailedResponse> AddDataAsync(IReadOnlyList<IContract> contracts, string data);
    public VerificationResponse VerifyData(string fingerprint);
}