using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionAndSigningPractice
{
    public partial class Alice : Form
    {
        KeyRing keys;

        public Alice()
        {
            InitializeComponent();
            keys = new KeyRing();
        }

        private void CreateKeys_Click(object sender, EventArgs e)
        {
            // Open Bob's window
            Bob bobWindow = new Bob();
            bobWindow.Show();

            // Share public keys
            bobWindow.setAlicePublicKey(keys.getMyPublicRSA());
            keys.setOtherPublicRSA(bobWindow.getBobPublicKey());

            // generate key, display it, and keep user from generating another key
            keys.generateK();
            byte[] k = keys.getK();

            createKeysButton.Enabled = false;
            shareKeysButton.Visible = true;

            label1.Text = "Generated RSA keys, shared public keys, and generated k = " + ByteArrayToString(k);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Alice_Load(object sender, EventArgs e)
        {

        }

        private void SendK_Click(object sender, EventArgs e)
        {
            label2.Text = "Message saving failed.";

            // use Bob's public key to encrypt k and save it
            byte[] cipherText = keys.otherRSA.Encrypt(keys.getK(), false);
            if (SaveMessageToFile(cipherText, "k"))
                label2.Text = "Message is saved and ready to be recieved.";

            label2.Visible = true;
            AESButton.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private byte[] generateMessageOfLength(int length)
        {
            byte[] message = new byte[length];
            Random r = new Random();
            r.NextBytes(message);
            if (message.Length != length)
                label1.Text = "check out generate message function";
            return message;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private bool SaveMessageToFile(byte[] message, string type)
        {
            try
            {
                string path = "./messages/" + type + ".txt";

                if (!Directory.Exists("./ messages"))
                    Directory.CreateDirectory("./messages");

                if (!File.Exists(path))
                    File.Create(path);

                File.WriteAllBytes(path, message);

                return true;
            }
            catch (IOException e)
            {
                throw;
            }
        }

        private void AESButton_Click(object sender, EventArgs e)
        {
            // generate random message and IV
            byte[] message = generateMessageOfLength(25);
            keys.AES.GenerateIV();
            byte[] iv = keys.AES.IV;
            label3.Text = "message = " + ByteArrayToString(message) + " iv = " + ByteArrayToString(iv);

            // use IV and key to encrypt the message
            byte[] ciphertext = EncryptAES(message);

            // save to file
            if (!SaveMessageToFile(ciphertext, "AESCiphertext"))
            {
                label3.Text = "failed to save ciphertext";
            }
            if (!SaveMessageToFile(iv, "AESiv"))
            {
                label3.Text = "failed to save iv";
            }

            // display message
            label3.Visible = true;
        }

        public byte[] EncryptAES(byte[] plain)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, keys.AES.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(plain, 0, plain.Length);
            cs.Close();
            return ms.ToArray();
        }
    }
}
