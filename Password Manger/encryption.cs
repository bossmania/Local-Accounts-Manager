using System;
using System.Security.Cryptography;
using System.Text;

namespace Encryption
{
    public class encryption
    {
        static Aes createCipher()
        {
            //create the aes cipher for encryption
            Aes cipher = Aes.Create();
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Mode = CipherMode.CBC;

            return cipher;
        }

        public Tuple<byte[], byte[], byte[]> encrypt(string message)
        {
            //create the cipher and the encrypter
            Aes cipher = createCipher();
            ICryptoTransform cryptTransform = cipher.CreateEncryptor();

            //encypt the message
            byte[] plainText = Encoding.UTF8.GetBytes(message);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);

            //return the message with other info
            Tuple<byte[], byte[], byte[]> info = Tuple.Create<byte[], byte[], byte[]>(cipherText, cipher.Key, cipher.IV);
            return info;
        }

        public string decrypt(byte[] cipherText, byte[] key, byte[] IV)
        {
            //create a cipher and set the IV
            Aes cipher = createCipher();
            cipher.IV = IV;
            cipher.Key = key;

            //create the decryptor and decode the message
            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] plainText = cryptTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);
            string message = Encoding.UTF8.GetString(plainText);

            return message;
        }
    }
}