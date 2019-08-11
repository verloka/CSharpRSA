using RSAExample.Extensions;
using System.Security;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace RSAExample.Base
{
    public class CryptBase
    {
        public int KeySize { get; set; }
        public SecureString Password { get; set; }
        public RSACryptoServiceProvider Provider { get; set; }

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
        /// Load key to the Provider
        /// </summary>
        /// <param name="Data">Key</param>
        public void LoadKey(string Data)
        {
            Provider.ImportParameters(Data.GetKeyRSA());
        }
    }
}
