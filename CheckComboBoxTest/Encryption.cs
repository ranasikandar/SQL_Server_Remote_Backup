﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;

namespace EncDec
{
    class Encryption
    {
        /// <summary>
        /// Encryption Key
        /// </summary>
        static string Key
        {
            get
            {
                return ("ranasikandar@mail.com--RanaSikandar@mail.com");
            }
        }

        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="Key">The key.</param>
        /// <param name="IV">The IV.</param>
        /// <returns></returns>
        private static byte[] EncryptString(byte[] clearText, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearText, 0, clearText.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="Password">The password.</param>
        /// <returns></returns>
        private static string EncryptString(string clearText, string Password)
        {
            byte[] clearBytes;
            try
            {
                clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] encryptedData = EncryptString(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="cipherData">The cipher data.</param>
        /// <param name="Key">The key.</param>
        /// <param name="IV">The IV.</param>
        /// <returns></returns>
        private static byte[] DecryptString(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="Password">The password.</param>
        /// <returns></returns>
        private static string DecryptString(string cipherText, string Password)
        {
            byte[] cipherBytes;
            try
            {
                cipherBytes = Convert.FromBase64String(cipherText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] decryptedData = DecryptString(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }


        public static string Encrypt(string clearText) { return (EncryptString(clearText, Key)); }

        public static string Decrypt(string cipheredText) { return (DecryptString(cipheredText, Key)); }
    }
}
