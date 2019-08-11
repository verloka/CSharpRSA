using System;

namespace RSAExample.Base
{
    public delegate void EncryptEventHandler(object sender, EncryptEventArgs e);

    public class EncryptEventArgs : EventArgs
    {
        readonly string Message;

        public EncryptEventArgs(string Message)
        {
            this.Message = Message;
        }

        public string GetMessage() => Message;
    }
}
