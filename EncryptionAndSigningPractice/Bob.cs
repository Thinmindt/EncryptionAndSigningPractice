﻿using System;
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
                GetHMACButton.Visible = true;
                GetDigiSigButton.Visible = true;
            }
            catch
            {
                label3.Text = "Please send k first.";
                label3.Visible = true;
            }
        }

        private void getAESButton_Click(object sender, EventArgs e)
        {
            // get iv and ciphertext
            byte[] ciphertext = readFromFile("AESCiphertext");
            byte[] iv = readFromFile("AESiv");
            keys.AES.IV = iv;

            // decrypt ciphertext
            byte[] message = keys.DecryptAES(ciphertext);

            // display message
            label4.Text = "message = " + ByteArrayToString(message) + " iv = " + ByteArrayToString(iv);
            label4.Visible = true;
        }

        private void GetHMACButton_Click(object sender, EventArgs e)
        {
            byte[] message = readFromFile("HMACMessage");
            byte[] hashFromSender = readFromFile("HMACHash");

            byte[] hashToVerify = keys.HMAC(message);

            if (ByteArraysEqual(hashFromSender, hashToVerify))
                label5.Text = "Verification Successful. Hash = " + ByteArrayToString(hashToVerify);
            else
                label5.Text = "Verification Failed. Hash = " + ByteArrayToString(hashToVerify);
            label5.Visible = true;
        }

        private void GetDigiSigButton_Click(object sender, EventArgs e)
        {
            byte[] message = readFromFile("DigiSigMessage");
            byte[] signature = readFromFile("DigiSigSignature");

            if (keys.DigitalSignatureVerify(message, signature))
                label6.Text = "Signature Verified Successfully";
            else
                label6.Text = "Signature Verification Failed";

            label6.Visible = true;
        }

        private bool ByteArraysEqual(byte[] hashFromSender, byte[] hashToVerify)
        {
            bool equal = true;
            for (int i = 0; i < hashToVerify.Length; i++)
            {
                if (hashFromSender[i] != hashToVerify[i])
                    equal = false;
            }
            return equal;
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

        public void setAlicePublicKey(RSAParameters AlicePublicKey)
        {
            keys.setOtherPublicRSA(AlicePublicKey);
        }

        internal RSAParameters getBobPublicKey()
        {
            return keys.getMyPublicRSA();
        }

        private void Bob_Load(object sender, EventArgs e)
        {

        }
    }
}
