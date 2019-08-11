using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RSAExample.Extensions
{
    public static class KeyProcessor
    {
        /// <summary>
        /// Convert rsa key to string data
        /// </summary>
        /// <param name="parameters">Key</param>
        /// <returns></returns>
        public static string GetKeyString(this RSAParameters parameters)
        {
            var sw = new StringWriter();
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, parameters);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(sw.ToString()));
        }

        /// <summary>
        /// Convert string to rsa key
        /// </summary>
        /// <param name="parameters">Key</param>
        /// <returns></returns>
        public static RSAParameters GetKeyRSA(this string parameters)
        {
            var buffer = Convert.FromBase64String(parameters);
            MemoryStream stream = new MemoryStream(buffer);
            StreamReader reader = new StreamReader(stream);

            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            return (RSAParameters)xs.Deserialize(reader);
        }
    }
}
