using RSAExample.Base;
using System;
using System.Security;
using System.Text;

namespace RSAExample.Kernel
{

    public class DecryptProvider : DecryptBase
    {
        public DecryptProvider()
        {
            KeySize = 2048;
            Password = new SecureString();
        }

        public DecryptProvider(int KeySize)
        {
            this.KeySize = KeySize;
            Password = new SecureString();
        }

        public DecryptProvider(int KeySize, SecureString Password)
        {
            this.KeySize = KeySize;
            this.Password = Password;
        }

        /// <summary>
        /// Decrypt text
        /// </summary>
        /// <param name="ToDecrypt">Data to decrypt</param>
        /// <returns></returns>
        public string DecryptText(string ToDecrypt)
        {
            return Encoding.UTF8.GetString(DecryptBytes(Convert.FromBase64String(ToDecrypt)));
        }
    }
}
