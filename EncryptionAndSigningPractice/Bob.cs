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
    public partial class Bob : Form
    {
        KeyRing keys;

        public Bob()
        {
            InitializeComponent();
            keys = new KeyRing();

        }

        public void setAlicePublicKey(RSAParameters AlicePublicKey)
        {
            keys.setOtherPublicRSA(AlicePublicKey);
        }

        private void Bob_Load(object sender, EventArgs e)
        {

        }

        internal RSAParameters getBobPublicKey()
        {
            return keys.getMyPublicRSA();
        }

        private void GetKButton_Click(object sender, EventArgs e)
        {
            try
            {
                // get ciphertext from file and decrypt
                byte[] cipherText = readFromFile("k");
                byte[] k = keys.myRSA.Decrypt(cipherText, false);

                // use k for AES key
                keys.AES.Key = k;

                // display k
                label3.Text = "k = " + ByteArrayToString(k);
                label3.Visible = true;
                getAESButton.Visible = true;
            }
            catch
            {
                label3.Text = "Please send k first.";
                label3.Visible = true;
            }
        }

        private byte[] readFromFile(string type)
        {
            return File.ReadAllBytes("./messages/" + type + ".txt");
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void getAESButton_Click(object sender, EventArgs e)
        {
            // get iv and ciphertext
            byte[] ciphertext = readFromFile("AESCiphertext");
            byte[] iv = readFromFile("AESiv");
            keys.AES.IV = iv;

            // decrypt ciphertext
            byte[] message = DecryptAES(ciphertext);

            // display message
            label4.Text = "message = " + ByteArrayToString(message) + " iv = " + ByteArrayToString(iv);
            label4.Visible = true;
        }

        public byte[] DecryptAES(byte[] encrypted)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, keys.AES.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(encrypted, 0, encrypted.Length);
            cs.Close();
            return ms.ToArray();
        }
    }
}
