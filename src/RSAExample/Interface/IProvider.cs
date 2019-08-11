using System.Security;
using System.Security.Cryptography;

namespace RSAExample.Interface
{
    public interface IProvider
    {
        int KeySize { get; set; }
        SecureString Password { get; set; }
        RSACryptoServiceProvider Provider { get; set; }
    }
}
