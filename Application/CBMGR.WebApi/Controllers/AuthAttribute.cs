namespace CBMGR.WebApi.Controllers
{
    #region using
    using System.Net.Http.Headers;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    #endregion

    public class AuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AuthenticationHeaderValue auth = actionContext.Request.Headers.Authorization;
            if (auth != null && auth.Parameter != null)
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
        }
    }
}