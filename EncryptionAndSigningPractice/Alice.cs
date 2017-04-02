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

        private void SendK_Click(object sender, EventArgs e)
        {
            label2.Text = "Message saving failed.";

            // use Bob's public key to encrypt k and save it
            byte[] cipherText = keys.otherRSA.Encrypt(keys.getK(), false);
            if (SaveMessageToFile(cipherText, "k"))
                label2.Text = "Message is saved and ready to be recieved.";

            label2.Visible = true;
            AESButton.Visible = true;
            HMACButton.Visible = true;
            DigiSigButton.Visible = true;
        }

        private void AESButton_Click(object sender, EventArgs e)
        {
            // generate random message and IV
            byte[] message = generateMessageOfLength(25);
            keys.AES.GenerateIV();
            byte[] iv = keys.AES.IV;
            label3.Text = "message = " + ByteArrayToString(message) + " iv = " + ByteArrayToString(iv);

            // use IV and key to encrypt the message
            byte[] ciphertext = keys.EncryptAES(message);

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

        private void HMACButton_Click(object sender, EventArgs e)
        {
            // generate and send message
            byte[] message = generateMessageOfLength(30);
            SaveMessageToFile(message, "HMACMessage");

            // get and send hash
            byte[] hash = keys.HMAC(message);
            SaveMessageToFile(hash, "HMACHash");

            // display hash
            label4.Text = "HMAC = " + ByteArrayToString(hash);
            label4.Visible = true;
        }

        private void DigiSigButton_Click(object sender, EventArgs e)
        {
            byte[] message = generateMessageOfLength(40);
            SaveMessageToFile(message, "DigiSigMessage");

            byte[] signature = keys.DigitalSignatureSign(message);
            SaveMessageToFile(signature, "DigiSigSignature");

            label5.Text = "sent message and signature";
            label5.Visible = true;
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

        private bool SaveMessageToFile(byte[] message, string type)
        {
            try
            {
                string path = "./messages/" + type + ".txt";

                if (!Directory.Exists("./ messages"))
                    Directory.CreateDirectory("./messages");

                if (!File.Exists(path))
                    File.Create(path).Close();

                File.WriteAllBytes(path, message);

                return true;
            }
            catch (IOException e)
            {
                throw;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Alice_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
