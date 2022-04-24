using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.BBS.AdminPages.Controls.Vote
{
    public partial class Bbsconfigs_Set : MPUCBaseList
    {
        public override int OrderID
        {
            get
            {
                return 6;
            }
        }
        public override string PageName
        {
            get
            {
                return "投票开关";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("46abce8f-6c9b-4a9f-8fe9-997a6b3da457");
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
        //private string sGetNumber
        //{
        //    get
        //    {
        //        return Request["number"];
        //    }
        //}
        public override string Permission
        {
            get
            {
                return "28";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=10";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return null;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IfKq();
            }
        }

        protected void btnBC_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (rblTP.Items[0].Selected)
            {
                num = 1;
            }
            else if (rblTP.Items[1].Selected)
            {
                num = 0;
            }
            List<ModuleCore.Entity.Topics> bbstList = ModuleCore.BLL.Topics.Instance.GetListArray("");
            for (int i = 0; i < bbstList.Count; i++)
            {
                ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(bbstList[i].id);
                bbst.tag = num;
                ModuleCore.BLL.Topics.Instance.Update(bbst);
            }
            base.ShowTipsPop("修改成功!");
        }

        private void IfKq()
        {
            int k = 0;
            List<ModuleCore.Entity.Topics> bbstList = ModuleCore.BLL.Topics.Instance.GetListArray("");
            for (int i = 0; i < bbstList.Count; i++)
            {
                if (bbstList[i].tag == 1)
                {
                    k = k + 1;
                }
            }

            if (k == bbstList.Count)
            {
                rblTP.Items[0].Selected = true;
            }
            else
            {
                rblTP.Items[1].Selected = true;
            }
        }
    }
}