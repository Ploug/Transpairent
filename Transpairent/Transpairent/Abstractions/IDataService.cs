using Transpairent.Core.Contracts;

namespace Transpairent.Core.Abstractions;

public interface IDataService
{
    public Task<VerificationDetailedResponse> AddDataAsync(IReadOnlyList<IContract> contracts, string data);
    public VerificationDetailedResponse ListContracts(string fingerprint);
}