namespace CBMGR.WebApi.Controllers
{
    #region using
    using System.Web.Http;
    #endregion

    [RoutePrefix("cbmgr/api/test")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("getdata")]
        public string GetRequest(string data)
        {
            return string.Format("Parameter recieved:{0}", data);
        }

        [HttpPost]
        [Route("postdata")]
        public string PostRequest(dynamic data)
        {
            return string.Format("Parameter recieved:{0}", data.ToString());
        }
    }
}