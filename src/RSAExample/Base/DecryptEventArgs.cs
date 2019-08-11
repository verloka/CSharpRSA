using System;

namespace RSAExample.Base
{
    public delegate void DecryptEventHandler(object sender, DecryptEventArgs e);

    public class DecryptEventArgs : EventArgs
    {
        readonly string Message;

        public DecryptEventArgs(string Message)
        {
            this.Message = Message;
        }

        public string GetMessage() => Message;
    }
}
