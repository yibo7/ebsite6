using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.Vote
{
    public partial class VoteManage : MPUCBaseList
    {
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        public override string PageName
        {
            get
            {
                return "投票管理";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("a1002378-24ad-4c55-9e86-b2647d9fb111");
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
        public override string Permission
        {
            get
            {
                return "2";
            }
        } public override string PermissionAddID
        {
            get
            {
                return "3";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "5";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "4";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        public string TagCls
        {
            get
            {
                return Request["cls"];
            }
        }


        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.toupiaobt.Instance.GetListPagesByUname(pcPage.PageIndex, pcPage.PageSize, out iCount, UserName);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.toupiaobt.Instance.Delete(long.Parse(iID.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(Request.Form["hName"]);
            string num = Convert.ToString(Request.Form["numName"]);
            ModuleCore.Entity.toupiaobt tpbt = ModuleCore.BLL.toupiaobt.Instance.GetEntity(long.Parse(id));
            if (string.Equals(num, "1"))
            {
                tpbt.type = "已结束";
            }
            else if (string.Equals(num, "2"))
            {
                tpbt.ifopen = "公开";
            }
            else if (string.Equals(num, "3"))
            {
                tpbt.ifopen = "关闭";
            }
            ModuleCore.BLL.toupiaobt.Instance.Update(tpbt);
            Response.Redirect(GetUrl);
        }
        protected override void BindToolBar()
        {
            base.BindToolBar(false,false,true,true,true);
        }
    }
}