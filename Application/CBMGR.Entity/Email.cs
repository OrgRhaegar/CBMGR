//-----------------------------------------------------------------------
// <copyright file="Email.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Entity
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using Unity;
    using CBMGR.Interface;
    using CBMGR.Common;

    public class Email : IMail
    {
        #region field
        /// <summary>
        /// Mail server.
        /// </summary>
        private string server;

        /// <summary>
        /// Mail server port.
        /// </summary>
        private int port;

        /// <summary>
        /// Mail server login name.
        /// </summary>
        private string userName;

        /// <summary>
        /// Mail server login password.
        /// </summary>
        private string password;

        /// <summary>
        /// Mail server login password.
        /// </summary>
        private string Password
        {
            get
            {
                ISecurity isecurity = GlobalConfig.IocContainer.Resolve<ISecurity>();
                return isecurity.GetAesDecryptedString(this.password);
            }
        }

        /// <summary>
        /// Mail sneder.
        /// </summary>
        public string sender;

        /// <summary>
        /// Enalbe SSL
        /// </summary>
        public bool enableSSL;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the Email class.
        /// </summary>
        public Email()
        {
            this.server = GlobalConfig.GlobalPars["MailServer"];
            this.port = Convert.ToInt32(GlobalConfig.GlobalPars["MailPort"]);
            this.userName = GlobalConfig.GlobalPars["MailUser"];
            this.password = GlobalConfig.GlobalPars["MailPwd"];
            this.sender = GlobalConfig.GlobalPars["MailSender"];
            this.enableSSL = Convert.ToBoolean(GlobalConfig.GlobalPars["MailEnalbeSSL"]);
        }
        #endregion

        #region members of IMail
        /// <summary>
        /// Send a mail async
        /// </summary>
        /// <param name="recipient">recipients</param>
        /// <param name="cc">mail cc</param>
        /// <param name="subject">mail subject</param>
        /// <param name="body">mai body</param>
        /// <returns>Action result</returns>
        public ActionResult SendMail(string[] recipient, string[] cc, string subject, string body)
        {
            ActionResult result = new ActionResult();
            try
            {
                SmtpClient client = this.GetMailClient();
                MailMessage mail = this.GetMailMessage(recipient, cc, subject, body);
                client.Send(mail);
                result.Message = "Mail has been sent.";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ResultValue = ex;
                result.Message = "Send email failde.";
            }

            return result;
        }

        /// <summary>
        /// Send a mail async
        /// </summary>
        /// <param name="recipient">recipients</param>
        /// <param name="cc">mail cc</param>
        /// <param name="subject">mail subject</param>
        /// <param name="body">mai body</param>
        /// <returns>Action result</returns>
        public ActionResult SendMailAsync(string[] recipient, string[] cc,string subject, string body)
        {
            ActionResult result = new ActionResult();
            try
            {
                SmtpClient client = this.GetMailClient();
                MailMessage mail = this.GetMailMessage(recipient, cc, subject, body);
                client.SendAsync(mail, null);
                result.Message = "Mail has been sent.";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ResultValue = ex;
                result.Message = "Send email failde.";
            }

            return result;
        }
        #endregion

        #region Private method
        /// <summary>
        /// Create a smtp client by configuration
        /// </summary>
        /// <returns>Smtp client</returns>
        private SmtpClient GetMailClient()
        {
            SmtpClient client = new SmtpClient();
            client.Host = this.server;
            client.Port = this.port;
            client.EnableSsl = this.enableSSL;
            client.Credentials = new NetworkCredential(this.userName, this.Password);
            return client;
        }

        /// <summary>
        /// Create a mail message to send.
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns>Mail message.</returns>
        private MailMessage GetMailMessage(string[] recipient, string[] cc, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(this.sender);
            foreach (string addr in recipient)
            {
                mail.To.Add(addr);
            }

            if (cc != null && cc.Length > 0)
            {
                foreach (string addr in cc)
                {
                    mail.CC.Add(addr);
                }
            }

            mail.Subject = subject;
            mail.Body = body;
            return mail;
        }
        #endregion
    }
}