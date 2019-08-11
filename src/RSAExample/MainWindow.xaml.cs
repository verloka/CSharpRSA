using RSAExample.Kernel;
using System.IO;
using System.Security;
using System.Windows;

namespace RSAExample
{
    public partial class MainWindow : Window
    {
        EncryptProvider eProvider;
        DecryptProvider dProvider;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnGenerte_Click(object sender, RoutedEventArgs e)
        {
            gridWait.Visibility = Visibility.Visible;

            KeyManager km = new KeyManager(2048);
            await km.Init();
            await km.GenerateKeys();
            tbPrivate.Text = km.GetPrivateKey();
            tbPublic.Text = km.GetPublicKey();

            gridWait.Visibility = Visibility.Hidden;
        }

        private void BtnSavePublic_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbPublic.Text))
                DialogsManager.Save(tbPublic.Text, false);
        }

        private void BtnSavePrivate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbPrivate.Text))
                DialogsManager.Save(tbPrivate.Text, true);
        }

        private async void tabControlSelectionchanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(tbString.IsSelected)
            {
                gridWait.Visibility = Visibility.Visible;

                eProvider = new EncryptProvider(2048);
                eProvider.EncryptError += EProvider_EncryptError;
                await eProvider.Init();

                dProvider = new DecryptProvider(2048);
                dProvider.DecryptError += DProvider_DecryptError;
                await dProvider.Init();

                tbPBKey.Text = string.Empty;
                tbPVKey.Text = string.Empty;
                tbToEncrypt.Text = string.Empty;
                tbEncrypted.Text = string.Empty;
                tbResult.Text = string.Empty;

                gridWait.Visibility = Visibility.Hidden;
            }
        }

        private void DProvider_DecryptError(object sender, Base.DecryptEventArgs e)
        {
            MessageBox.Show(e.GetMessage(), "RSA Example", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void EProvider_EncryptError(object sender, Base.EncryptEventArgs e)
        {
            MessageBox.Show(e.GetMessage(), "RSA Example", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void BtnLoadPVKey_Click(object sender, RoutedEventArgs e)
        {
            string path = DialogsManager.Open(true);
            if(!string.IsNullOrWhiteSpace(path))
            {
                if(File.Exists(path))
                {
                    tbPVKey.Text = path;
                    dProvider.LoadKey(File.ReadAllText(path));
                }
                else
                {
                    MessageBox.Show("File not exist.", "RSA Example", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnLoadPBKey_Click(object sender, RoutedEventArgs e)
        {
            string path = DialogsManager.Open(false);
            if (!string.IsNullOrWhiteSpace(path))
            {
                if (File.Exists(path))
                {
                    tbPBKey.Text = path;
                    eProvider.LoadKey(File.ReadAllText(path));
                }
                else
                {
                    MessageBox.Show("File not exist.", "RSA Example", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbToEncrypt.Text))
            {
                tbEncrypted.Text = eProvider.EncryptText(tbToEncrypt.Text);
            }
        }

        private void BtnDecrypr_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = dProvider.DecryptText(tbEncrypted.Text);
        }
    }
}
