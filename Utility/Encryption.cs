using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Utility
{
    /// <summary>
    /// A utility class used to encrypt and decrypt a file
    /// </summary>
    public static class Encryption
    {
        /// <summary>
        /// Used to encrypt a file
        /// </summary>
        /// <param name="unecryptedFileName">The plain text filename</param>
        /// <param name="encryptedFileName">The encrypted filename</param>
        /// <param name="key">The provided key</param>
        public static void Encrypt(string unecryptedFileName, string encryptedFileName, string key)
        {
            //FileStream object instances
            FileStream plainTextFileStream = new FileStream(unecryptedFileName, FileMode.Open, FileAccess.Read);
            FileStream encryptedFileStream = new FileStream(encryptedFileName, FileMode.Create, FileAccess.Write);

            //DESCryptoServiceProvider object instance
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(key);

            //ICryptoTransform object instance
            ICryptoTransform desEncrypt = DES.CreateEncryptor();

            //CryptoStream object instance
            CryptoStream cryptostreamEncr = new CryptoStream(encryptedFileStream, desEncrypt, CryptoStreamMode.Write);

            byte[] bytearray = new byte[plainTextFileStream.Length];
            plainTextFileStream.Read(bytearray, 0, bytearray.Length);
            cryptostreamEncr.Write(bytearray, 0, bytearray.Length);

            //Close the streams objects
            cryptostreamEncr.Close();
            plainTextFileStream.Close();
            encryptedFileStream.Close();
        }

        /// <summary>
        /// Used to decrypt a file
        /// </summary>
        /// <param name="encryptedFileName">The name of the encrypted file</param>
        /// <param name="unecryptedFileName">The name of the plain text file</param>
        /// <param name="key">The provided key</param>
        public static void Decrypt(string encryptedFileName, string unecryptedFileName, string key)
        {
            //StreamWriter object instance
            StreamWriter swDecrypted = new StreamWriter(unecryptedFileName);

            try
            {
                //DESCryptoServiceProvider object instance
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);

                //FileStream object instance
                FileStream fsDecrypt = new FileStream(encryptedFileName, FileMode.Open, FileAccess.Read);

                //ICryptoTransform object instance
                ICryptoTransform desDecrypt = DES.CreateDecryptor();

                //CryptoStream object instance
                CryptoStream cryptostreamDecr = new CryptoStream(fsDecrypt, desDecrypt, CryptoStreamMode.Read);

                swDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
                swDecrypted.Flush();
                swDecrypted.Close();
            }
            catch (Exception e)
            {
                swDecrypted.Close();
                throw new Exception(e.Message);
            }
        }
    }
}
