using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.UseCorde
{
    public partial class Corde : MPUCBaseList
    {
       
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("37bc928e-75a9-458d-95a4-3fe00536f71d");
            }
        }
        public override string PageName
        {
            get
            {
                return "代码引用";
            }
        }
        public override string Permission
        {
            get
            {
                return "19";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
       

        override protected string AddUrl
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string js = string.Format("<script id=\"orderboxchat\" type=\"text/javascript\" src=\"{0}js/odc.js\"></script>",GetModulePath);
            txtCorde.Text = js;

            txtChatLink.Text = HostApi.GetModuleUrl(new Guid("c55d792e-6af0-41ee-a3ef-b5e6cfda3457"),
                                                    new Guid("e4f5742a-aaf0-4f12-ad86-3ce03ce9e56a"));
        }
        override protected object LoadList(out int iCount)
        {
            throw new NotImplementedException();
        }

        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            throw new NotImplementedException();
        }
       
    }
}