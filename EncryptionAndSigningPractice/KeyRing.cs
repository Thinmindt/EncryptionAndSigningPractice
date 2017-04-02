using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAndSigningPractice
{
    class KeyRing
    {
        public RSACryptoServiceProvider myRSA;
        public RSACryptoServiceProvider otherRSA;
        public AesManaged AES;

        public KeyRing()
        {
            AES = new AesManaged();
            myRSA = new RSACryptoServiceProvider();
            otherRSA = new RSACryptoServiceProvider();
        }

        public RSAParameters getMyPublicRSA()
        {
            return myRSA.ExportParameters(false);
        }

        public void setOtherPublicRSA(RSAParameters otherPublicKey)
        {
            otherRSA.Dispose();
            otherRSA.ImportParameters(otherPublicKey);
        }

        public void generateK()
        {
            AES.GenerateKey();
        }

        public byte[] getK()
        {
            return AES.Key;
        }
        
        public byte[] EncryptAES(byte[] plain)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(plain, 0, plain.Length);
            cs.Close();
            return ms.ToArray();
        }
        
        public byte[] DecryptAES(byte[] encrypted)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(encrypted, 0, encrypted.Length);
            cs.Close();
            return ms.ToArray();
        }

        public byte[] HMAC(byte[] message)
        {
            byte[] k = AES.Key;
            SHA256 sha = new SHA256Managed();

            // compute H(k | H(k | m))
            byte[] innerHash = sha.ComputeHash(concatByteArray(k, message));
            byte[] completeHash = sha.ComputeHash(concatByteArray(k, innerHash));

            return completeHash;
        }

        public byte[] DigitalSignatureSign(byte[] message)
        {
            // compute hash of message
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(message);

            // sign with RSA
            byte[] signature = myRSA.SignHash(hash, "SHA256");
            return signature;
        }

        public bool DigitalSignatureVerify(byte[] message, byte[] signatureFromSender)
        {
            // compute hash of message
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(message);

            // verify with RSA
            if (otherRSA.VerifyHash(hash, "SHA256", signatureFromSender))
                return true;
            else
                return false;
        }

        private byte[] concatByteArray(byte[] first, byte[] second)
        {
            byte[] combined = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, combined, 0, first.Length);
            Buffer.BlockCopy(second, 0, combined, first.Length, second.Length);
            return combined;
        }
    }
}
