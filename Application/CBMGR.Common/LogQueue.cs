//-----------------------------------------------------------------------
// <copyright file="LogQueue.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class LogQueue
    {
        #region Fields
        /// <summary>
        /// Queue of logs.
        /// </summary>
        private static Queue<Log> logs;

        /// <summary>
        /// Thread to write logs.
        /// </summary>
        private static Thread logThread;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes static members of the LogQueue class.
        /// </summary>
        static LogQueue()
        {
            logs = new Queue<Log>();
            logThread = new Thread(CheckLogQueue);
            logThread.IsBackground = true;
            logThread.Start();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Add a log to log queue
        /// </summary>
        /// <param name="log">Log to add</param>
        public static void AddToLogQueue(Log log)
        {
            lock (logs)
            {
                logs.Enqueue(log);
            }
        }

        /// <summary>
        /// Add a exception to log queue
        /// </summary>
        /// <param name="ex">Exception to add</param>
        public static void AddToLogQueue(Exception ex)
        {
            Log log = new Log(ex);
            AddToLogQueue(log);
        }

        /// <summary>
        /// Add a message to log queue
        /// </summary>
        /// <param name="msg">Message to add</param>
        public static void AddToLogQueue(string msg)
        {
            Log log = new Log(msg);
            AddToLogQueue(log);
        }

        /// <summary>
        /// Add message and exception to log queue
        /// </summary>
        /// <param name="msg">Message to add</param>
        /// <param name="ex">Exception to add</param>
        public static void AddToLogQueue(string msg, Exception ex)
        {
            Log log = new Log(msg, ex);
            AddToLogQueue(log);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Check the queue if there is any log to write.
        /// </summary>
        private static void CheckLogQueue()
        {
            while (true)
            {
                lock (logs)
                {
                    if (logs.Count > 0)
                    {
                        Log log = logs.Dequeue();
                        log.Write();
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                }
            }
        }
        #endregion
    }
}