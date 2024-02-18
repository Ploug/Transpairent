using Transpairent.Core.Contracts;

namespace Transpairent.Core.Abstractions;

public interface ITrustService
{
    public VerificationResponse VerifyData(IContract contract, string dataId, string dataFingerprint);
}