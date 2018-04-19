//-----------------------------------------------------------------------
// <copyright file="SysController.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.WebApi.Controllers
{
    #region usingusing System;
    using System.Web.Http;
    using CBMGR.Common;
    using CBMGR.Interface;
    using Unity;
    #endregion

    [RoutePrefix("cbmgr/api/system")]
    public class SysController : ApiController
    {
        [Route("newkey")]
        [HttpGet]
        public string CreateAppKey(string email)
        {
            ActionResult result = new ActionResult();
            try
            {
                ISystem isys = GlobalConfig.IocContainer.Resolve<ISystem>();
                result = isys.RequestAppKey(email.Trim());
            }
            catch
            {
                result.Result = false;
                result.Message = "Failed to request a new app key.";
            }

            return result.ToJSON();
        }
    }
}