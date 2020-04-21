using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for AesTest.xaml
    /// </summary>
    public partial class AesTest : Window
    {
        public AesTest()
        {
            InitializeComponent();
        }
        private void Encrypt()
        {
            try
            {
                outputText.Text = AesOp.EncryptString(inputText.Text, passwordText.Text);
            }
            catch (CryptographicException ex) { outputText.Text = ex.Message; }
            catch (ArgumentNullException ex) { outputText.Text = ex.Message; }
            catch (FormatException ex) { outputText.Text = ex.Message; }

        }
        private void Decrypt()
        {
            try
            {
                eOutputText.Text = AesOp.DecryptString(encryptedText.Text, ePasswordText.Text);
            }
            catch (CryptographicException ex) { eOutputText.Text = ex.Message; }
            catch (ArgumentNullException ex) { eOutputText.Text = ex.Message; }
            catch (FormatException ex) { eOutputText.Text = ex.Message; }
        }
        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            Encrypt();
        }
        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            Decrypt();
        }

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            Encrypt();
        }

        private void passwordText_KeyDown(object sender, KeyEventArgs e)
        {
            Encrypt();
        }

        private void encryptedText_KeyDown(object sender, KeyEventArgs e)
        {
            Decrypt();
        }

        private void ePasswordText_KeyDown(object sender, KeyEventArgs e)
        {
            Decrypt();
        }
    }
}
