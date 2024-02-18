using System.Security.Cryptography;
using System.Text;

namespace Transpairent.Core;

public static class CryptographyHelper
{
    public static string GenerateFingerprint(string data)
    {
        var dataBytes = Encoding.UTF8.GetBytes(data);

        using SHA256 sha256 = SHA256.Create();
        
        var hashBytes = sha256.ComputeHash(dataBytes);

        var builder = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            builder.AppendFormat("{0:x2}", b);
        }
        return builder.ToString();
    }
}