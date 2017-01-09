//-----------------------------------------------------------------------
// <copyright file="ISecurity.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Interface
{
    /// <summary>
    /// Interface of security
    /// </summary>
    public interface ISecurity
    {
        /// <summary>
        /// MD5 Encrypt
        /// </summary>
        /// <param name="data">Origin data string</param>
        /// <returns>Encrypted data string</returns>
        string GetMD5String(string data);
        
        /// <summary>
        /// Aes Encrypt
        /// </summary>
        /// <param name="data">Origin data string</param>
        /// <returns>Encrypted data string</returns>
        string GetAesEncryptedString(string data);

        /// <summary>
        /// Aes Decrypt
        /// </summary>
        /// <param name="data">Encrypted data string</param>
        /// <returns>Origin data string</returns>
        string GetAesDecryptedString(string data);
    }
}