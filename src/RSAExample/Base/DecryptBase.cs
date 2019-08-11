using System;

namespace RSAExample.Base
{
    public class DecryptBase : CryptBase
    {
        public event DecryptEventHandler DecryptError;

        /// <summary>
        /// Decrypt array of bytes
        /// </summary>
        /// <param name="ToDecrypt">Data to decrypt</param>
        /// <returns></returns>
        public byte[] DecryptBytes(byte[] ToDecrypt)
        {
            byte[] arr = null;
            try
            {
                arr = Provider.Decrypt(ToDecrypt, false);
            }
            catch(Exception e)
            {
                DecryptError?.Invoke(this, new DecryptEventArgs($"Cannot decrypt. Message: {e.Message}"));
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
