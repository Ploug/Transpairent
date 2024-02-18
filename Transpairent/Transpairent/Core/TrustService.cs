using Transpairent.Core.Abstractions;
using Transpairent.Core.Contracts;

namespace Transpairent.Core;

public class TrustService : ITrustService
{
    public VerificationResponse VerifyData(IContract contract, string dataId, string dataFingerprint)
    {
        throw new NotImplementedException();
    }
}