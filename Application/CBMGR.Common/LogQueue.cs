//-----------------------------------------------------------------------
// <copyright file="LogQueue.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Common
{
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
        /// Add a log to queue
        /// </summary>
        /// <param name="log">Log to add</param>
        public void AddToLogQueue(Log log)
        {
            lock (logs)
            {
                logs.Enqueue(log);
            }
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