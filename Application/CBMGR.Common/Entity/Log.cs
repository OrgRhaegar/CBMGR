//-----------------------------------------------------------------------
// <copyright file="Log.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Common
{
    using System;
    using System.IO;
    using System.Text;

    public class Log
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the Log class.
        /// </summary>
        public Log()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Log class.
        /// </summary>
        /// <param name="msg">Log message</param>
        public Log(string msg)
        {
            this.LogMessage = msg;
            this.Excep = null;
        }

        /// <summary>
        /// Initializes a new instance of the Log class.
        /// </summary>
        /// <param name="ex">Log exception</param>
        public Log(Exception ex)
        {
            this.LogMessage = string.Empty;
            this.Excep = ex;
        }

        /// <summary>
        /// Initializes a new instance of the Log class.
        /// </summary>
        /// <param name="msg">Log message</param>
        /// <param name="ex">Log exception</param>
        public Log(string msg, Exception ex)
        {
            this.LogMessage = msg;
            this.Excep = ex;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets log message.
        /// </summary>
        public string LogMessage { get; set; }

        /// <summary>
        /// Gets or sets log exception.
        /// </summary>
        public Exception Excep { get; set; }
        #endregion

        #region Pulbic methods
        /// <summary>
        /// Write log
        /// </summary>
        public void Write()
        {
            string logFiel = GlobalConfig.GlobalPars["LogFile"];
            using (FileStream fs = new FileStream(logFiel, FileMode.Append))
            {
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.WriteLine("Date:{0}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                sw.WriteLine("Message:{0}", this.LogMessage);
                if (this.Excep != null)
                {
                    sw.WriteLine(this.Excep);
                }

                sw.Close();
                fs.Close();
            }
        }
        #endregion
    }
}