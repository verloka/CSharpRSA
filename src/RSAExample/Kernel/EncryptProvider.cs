using RSAExample.Base;
using System;
using System.Security;
using System.Text;

namespace RSAExample.Kernel
{
    public class EncryptProvider : EncryptBase
    {
        public EncryptProvider()
        {
            KeySize = 2048;
            Password = new SecureString();
        }

        public EncryptProvider(int KeySize)
        {
            this.KeySize = KeySize;
            Password = new SecureString();
        }

        public EncryptProvider(int KeySize, SecureString Password)
        {
            this.KeySize = KeySize;
            this.Password = Password;
        }

        /// <summary>
        /// Encrypt text
        /// </summary>
        /// <param name="ToEncrypt">Data to encrypt</param>
        /// <returns></returns>
        public string EncryptText(string ToEncrypt)
        {
            return Convert.ToBase64String(EncryptBytes(Encoding.UTF8.GetBytes(ToEncrypt)));
        }
    }
}
