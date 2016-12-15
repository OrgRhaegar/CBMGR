//-----------------------------------------------------------------------
// <copyright file="Security.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Common
{
    using System;
    using System.Configuration;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Common security
    /// </summary>
    public class Security
    {
        #region Filed
        /// <summary>
        /// Aes key array
        /// </summary>
        private byte[] aesKey;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the Security class.
        /// </summary>
        public Security()
        {
            string key = ConfigurationManager.AppSettings["AesKey"];
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("Can not find aes key.");
            }
            else if (key.Length != 16 || key.Length != 24 || key.Length != 32)
            {
                throw new Exception("The lengh of aes key is incorrect.");
            }

            this.aesKey = Encoding.UTF8.GetBytes(key);
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets aes key array
        /// </summary>
        private byte[] AesKeyArray
        {
            get
            {
                return this.aesKey;
            }
        }
        #endregion

        #region Public method
        /// <summary>
        /// MD5 Encrypt
        /// </summary>
        /// <param name="data">Origin data string</param>
        /// <returns>Encrypted data string</returns>
        public string GetMD5String(string data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] resultBYtes = md5.ComputeHash(dataBytes);
            string md5Str = Convert.ToBase64String(resultBYtes);
            return md5Str;
        }

        /// <summary>
        /// Aes Encrypt
        /// </summary>
        /// <param name="data">Origin data string</param>
        /// <returns>Encrypted data string</returns>
        public string GetAesEncryptedString(string data)
        {
            byte[] dataArray = Encoding.UTF8.GetBytes(data);
            RijndaelManaged aes = this.GetAesProvider();
            ICryptoTransform encryptor = aes.CreateEncryptor();
            dataArray = encryptor.TransformFinalBlock(dataArray, 0, dataArray.Length);
            string result = Convert.ToBase64String(dataArray);
            return result;
        }

        /// <summary>
        /// Aes Decrypt
        /// </summary>
        /// <param name="data">Encrypted data string</param>
        /// <returns>Origin data string</returns>
        public string GetAesDecryptedString(string data)
        {
            byte[] dataArray = Convert.FromBase64String(data);
            RijndaelManaged aes = this.GetAesProvider();
            ICryptoTransform decryptor = aes.CreateDecryptor();
            dataArray = decryptor.TransformFinalBlock(dataArray, 0, dataArray.Length);
            string result = Encoding.UTF8.GetString(dataArray);
            return result;
        }
        #endregion

        #region Private method
        /// <summary>
        /// Get aes provider
        /// </summary>
        /// <returns>Aes provider</returns>
        private RijndaelManaged GetAesProvider()
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.Key = this.AesKeyArray;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            return aes;
        }
        #endregion
    }
}