using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web
{
    public partial class errapp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Exception ex = Server.GetLastError().GetBaseException();

                //if (ex != null)
                //{
                //    StringBuilder sb = new StringBuilder();

                //    sb.AppendFormat("错误的信息:{0}</br>", ex.Message);
                //    sb.AppendFormat("出错的方法名:{0}</br>", ex.TargetSite.Name);
                //    sb.AppendFormat("出错的类名:{0}</br>", ex.TargetSite.DeclaringType.FullName);
                //    sb.AppendFormat("错误的堆栈:{0}</br>", ex.StackTrace.Replace(" 位置 ", "<br/> 位置 "));

                //    lbErr.Text = sb.ToString();

                //}
                Response.StatusCode = 503;
                // 清空最后的错误
                Server.ClearError();
            }
        }
    }
}