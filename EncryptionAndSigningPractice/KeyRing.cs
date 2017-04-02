using System;
using System.Collections.Generic;
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
    }
}
