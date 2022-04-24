using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Json;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_ModalDlg
{
    public partial class OrderFastMenus : UserControlBase
    {
        /// <summary>
        /// 模型类别 0 内容 1分类 2用户
        /// </summary>

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //快捷菜单
                List<Entity.FastMenu> lst = BLL.FastMenu.Instance.FillList();
                List<Entity.FastMenu> nls = (from li in lst where li.UserID==base.UserID
                                             orderby li.OrderID //descending
                                             select li).ToList();
                rpList.DataSource = nls;
                rpList.DataBind();
            }
        }
    }
}