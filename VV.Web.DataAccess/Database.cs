using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace VV.Web.DataAccess
{
    public sealed class Database
    {
        private static string cString;

        public static string ConnectionString
        {
            get
            {
                cString = System.Configuration.ConfigurationManager.ConnectionStrings["NHDataModel"].ConnectionString;
                cString = cString.Replace("orange", "1NVYaqbp@39876");
                return cString;//decryptConnectionStrings(cString);
            }
            set
            {
                cString = value;
            }
        }
        private Database()
        {
        }

        private static string decryptConnectionStrings(string connectionString)
        {
            try
            {

                //string cipherText;
                //int startIndex = 0;
                //int endIndex = 0;

                SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder(connectionString);
                if (connectionString.Contains("Password"))
                {
                    //startIndex = connectionString.IndexOf("Password=") + ("Password=").Length;
                    //endIndex = connectionString.LastIndexOf(';');
                    //cipherText = connectionString.Substring(startIndex, (endIndex - startIndex));

                    connString.Password = decryptString(connString.Password);
                    connString.UserID = decryptString(connString.UserID);
                    return connString.ToString();
                }
            }
            catch
            {
                return connectionString;
            }

            return connectionString;
        }

        private static string decryptString(string cipherText)
        {
            string initVector;
            string passPhrase;
            string saltValue;
            string hashAlgorithm;
            int keySize;
            int pIter;

            initVector = "1NVY#$ads77epo29";
            passPhrase = "pH7s8a6#&!";
            saltValue = "s*#sfas@1";
            hashAlgorithm = "SHA1";
            keySize = Convert.ToInt32("256");
            pIter = Convert.ToInt32("6");

            if (cipherText != null)
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                // Convert our ciphertext into a byte array.
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                // First, we must create a password, from which the key will be 
                // derived. This password will be generated from the specified 
                // passphrase and salt value. The password will be created using
                // the specified hash algorithm. Password creation can be done in
                // several iterations.
                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                hashAlgorithm,
                                                                pIter);

                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes = password.GetBytes(keySize / 8);

                // Create uninitialized Rijndael encryption object.
                RijndaelManaged symmetricKey = new RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate decryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                // Define cryptographic stream (always use Read mode for encryption).
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold ciphertext;
                // plaintext is never longer than ciphertext.
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                // Start decrypting.
                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);

                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                // Convert decrypted data into a string. 
                // Let us assume that the original plaintext string was UTF8-encoded.
                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           decryptedByteCount);
                return plainText;
            }

            return cipherText;
        }
    }
}
