﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PMS.AuthenticateService
{
    public class PasswordEncrypter
    {
        /// <summary>
        ///     Create Singleton class
        /// </summary>
        private static volatile PasswordEncrypter passwordEncrypter;

        private PasswordEncrypter()
        {
        }

        public static PasswordEncrypter Instance
        {
            get
            {
                if (passwordEncrypter != null)
                {
                    return passwordEncrypter;
                }

                lock (typeof(PasswordEncrypter))
                {
                    if (passwordEncrypter == null)
                    {
                        passwordEncrypter = new PasswordEncrypter();
                    }
                }

                return passwordEncrypter;
            }
        }

        public string Encrypt(string textToEncode, string encryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(textToEncode);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]
                {
                            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    textToEncode = Convert.ToBase64String(ms.ToArray());
                }
            }
            return textToEncode;
        }
        public string Decrypt(string textToDecode, string encryptionKey)
        {
            if (!string.IsNullOrEmpty(textToDecode))
            {
                textToDecode = textToDecode?.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(textToDecode);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] {
                                0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                     });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        textToDecode = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return textToDecode;
        }

    }
}
