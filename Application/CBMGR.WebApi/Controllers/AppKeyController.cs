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

    [RoutePrefix("cbmgr/api/appkey")]
    public class AppKeyController : ApiController
    {
        private IAppKey iAppkey
        {
            get
            {
                return GlobalConfig.IocContainer.Resolve<IAppKey>();
            }
        }

        [Route("create")]
        [HttpGet]
        public string CreateAppKey(string email)
        {
            ActionResult result = new ActionResult();
            try
            {
                result = this.iAppkey.RequestAppKey(email.Trim());
            }
            catch
            {
                result.Message = "Failed to request a new app key.";
            }

            return result.ToJSON();
        }

        [Route("get")]
        [HttpGet]
        public string GetAppKey(string email)
        {
            ActionResult result = new ActionResult();
            try
            {
                result = this.iAppkey.GetAppKeyByEmail(email);
            }
            catch
            {
                result.Message = "Failed to get app key.";
            }

            return result.ToJSON();
        }

        [Route("reset")]
        [HttpGet]
        public string ResetKey(string email)
        {
            ActionResult result = new ActionResult();
            try
            {
                result = this.iAppkey.ResetAppKey(email);
            }
            catch
            {
                result.Message = "Failed to reset app key.";
            }

            return result.ToJSON();
        }
    }
}