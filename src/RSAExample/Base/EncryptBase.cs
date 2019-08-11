using System;

namespace RSAExample.Base
{
    public class EncryptBase : CryptBase
    {
        public event EncryptEventHandler EncryptError;

        /// <summary>
        /// Encrypt array of bytes
        /// </summary>
        /// <param name="ToEncrypt">Data to encrypt</param>
        /// <returns></returns>
        public byte[] EncryptBytes(byte[] ToEncrypt)
        {
            byte[] arr = null;
            try
            {
                arr = Provider.Encrypt(ToEncrypt, false);
            }
            catch(Exception e)
            {
                EncryptError?.Invoke(this, new EncryptEventArgs($"Cannot encrypt. Message: {e.Message}"));
            }
            finally
            {
                if (arr == null)
                    arr = new byte[0];
            }

            return arr;
        }
    }
}
