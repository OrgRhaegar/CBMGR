//-----------------------------------------------------------------------
// <copyright file="ActionResult.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Interface
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Common action result of method.
    /// </summary>
    public class ActionResult
    {
        /// <summary>
        /// Initializes a new instance of the ActionResult class.
        /// </summary>
        public ActionResult()
        {
            this.Result = true;
            this.ResultValue = 0;
            this.Message = string.Empty;
            this.Ex = null;
        }

        /// <summary>
        /// Gets or sets a value indicating whether calling of method is success.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Gets or sets result value of method calling, can be any data type.
        /// </summary>
        public object ResultValue { get; set; }

        /// <summary>
        /// Gets or sets addtional message of method calling.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets exception of method calling.
        /// </summary>
        public Exception Ex { get; set; }

        /// <summary>
        /// Get json string of this entity
        /// </summary>
        /// <returns>Json string of this entity.</returns>
        public string ToJSON()
        {
            string jsonStr = JsonConvert.SerializeObject(this);
            return jsonStr;
        }
    }
}