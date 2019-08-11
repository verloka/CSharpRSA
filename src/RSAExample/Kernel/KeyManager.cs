using RSAExample.Extensions;
using RSAExample.Interface;
using System.Security;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace RSAExample.Kernel
{
    public class KeyManager : IProvider
    {
        RSAParameters pvKey;
        RSAParameters pbKey;

        public int KeySize { get; set; }
        public SecureString Password { get; set; }
        public RSACryptoServiceProvider Provider { get; set; }

        public KeyManager()
        {
            KeySize = 2048;
            Password = new SecureString();
        }

        public KeyManager(int KeySize)
        {
            this.KeySize = KeySize;
            Password = new SecureString();
        }

        public KeyManager(int KeySize, SecureString Password)
        {
            this.KeySize = KeySize;
            this.Password = Password;
        }

        /// <summary>
        /// Init <see cref="RSACryptoServiceProvider"/>
        /// </summary>
        /// <returns></returns>
        public Task Init()
        {
            return Task.Factory.StartNew(() =>
            {
                /*CspParameters parameters = new CspParameters
                {
                    KeyPassword = Password
                };*/
                
                Provider = new RSACryptoServiceProvider(KeySize/*, parameters*/);
            });
        }

        /// <summary>
        /// Generate private and public keys
        /// </summary>
        /// <returns></returns>
        public Task GenerateKeys()
        {
            return Task.Factory.StartNew(() =>
            {
                pvKey = Provider.ExportParameters(true);
                pbKey = Provider.ExportParameters(false);
            });
        }

        /// <summary>
        /// Get private key
        /// </summary>
        /// <returns></returns>
        public string GetPrivateKey()
        {
            return pvKey.GetKeyString();
        }

        /// <summary>
        /// Get public key
        /// </summary>
        /// <returns></returns>
        public string GetPublicKey()
        {
            return pbKey.GetKeyString();
        }
    }
}
