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
            if (saveMessageToFile(cipherText, "k"))
                label2.Text = "Message is saved and ready to be recieved.";

            label2.Visible = true;
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
            return message;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private bool saveMessageToFile(byte[] message, string type)
        {
            string path = "./messages/" + type + ".txt";
            
            if (!Directory.Exists("./ messages"))
                Directory.CreateDirectory("./messages");

            if (!File.Exists(path))
                File.Create(path);
            File.WriteAllBytes(path, message);

            return true;
        }

        private void AESButton_Click(object sender, EventArgs e)
        {
            // generate random message and IV
            byte[] message = generateMessageOfLength(25);
            keys.AES.GenerateIV();
            byte[] iv = keys.AES.IV;
            byte[] key = keys.AES.Key;

            // use IV and key to encrypt the message
            byte[] ciphertext = EncryptStringToBytes_Aes(message.ToString(), key, iv);

            saveMessageToFile(ciphertext, "AESCiphertext");
            saveMessageToFile(iv, "AESiv");
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }
    }
}
