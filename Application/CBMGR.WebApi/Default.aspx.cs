using System;

namespace CBMGR.WebApi
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.date.InnerText = DateTime.Now.ToString("yyyy-mm-dd HH:MM:ss");
        }
    }
}