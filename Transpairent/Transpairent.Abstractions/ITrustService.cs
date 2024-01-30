using Transpairent.Abstractions.Contracts;

namespace Transpairent.Abstractions;

public interface ITrustService
{
    public VerificationResponse VerifyData(IContract contract, string dataId, string dataFingerprint);
}