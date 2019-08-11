using Microsoft.Win32;
using System.IO;

namespace RSAExample.Kernel
{
    public static class DialogsManager
    {
        /// <summary>
        /// Save key to the file
        /// </summary>
        /// <param name="DataToSave">Data to save</param>
        /// <param name="IsPrivate">Indicate the key type</param>
        public static void Save(string DataToSave, bool IsPrivate)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                DefaultExt = IsPrivate ? "pvKey" : "pbKey",
                FileName = "key",
                AddExtension = true
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, DataToSave);
            }
        }

        /// <summary>
        /// Show dialog to open key
        /// </summary>
        /// <param name="IsPrivate">Indicate the key type</param>
        /// <returns></returns>
        public static string Open(bool IsPrivate)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                DefaultExt = IsPrivate ? "pvKey" : "pbKey",
                Filter = IsPrivate ? "Private key (*.pvKey)|*.pvKey" : "Public key (*.pbKey)|*.pbKey"
            };

            return dialog.ShowDialog() == true ? dialog.FileName : string.Empty;
        }
    }
}
