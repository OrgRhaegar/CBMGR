//-----------------------------------------------------------------------
// <copyright file="IMail.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Interface
{
    /// <summary>
    /// Interface of email.
    /// </summary>
    public interface IMail
    {
        /// <summary>
        /// Send a mail async
        /// </summary>
        /// <param name="recipient">recipients</param>
        /// <param name="cc">mail cc</param>
        /// <param name="to">mail to</param>
        /// <param name="subject">mail subject</param>
        /// <param name="body">mai body</param>
        /// <returns></returns>
        ActionResult SendMailAsync(string[] recipient, string[] cc, string subject, string body);

        /// <summary>
        /// Send a mail
        /// </summary>
        /// <param name="recipient">recipients</param>
        /// <param name="cc">mail cc</param>
        /// <param name="subject">mail subject</param>
        /// <param name="body">mai body</param>
        /// <returns></returns>
        ActionResult SendMail(string[] recipient, string[] cc,string subject, string body);
    }
}