using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class AskRemarkList : CommentListBase
    {
        

        override protected string AddUrl
        {
            get
            {
                return "t=13";//不是添加，回复用
            }
        }
       
    }
}