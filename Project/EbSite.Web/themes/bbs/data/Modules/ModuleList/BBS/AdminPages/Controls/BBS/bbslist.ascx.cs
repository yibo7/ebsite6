using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBS
{
    public partial class bbslist : MPUCBaseList//MPUCBaseList
    {
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        public override string PageName
        {
            get
            {
                return "讨论区列表";
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
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("96f965a7-4280-40cf-bea8-e40aca400171");
            }
        }
        protected string pid = "";
        protected string sid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitRpBK();
                InitRpXT();
                InitRpJH();
                InitrpGdXT();
            }
            pid = Convert.ToString(base.MenuID);
            sid = Convert.ToString(base.ModuleID);
        }
        public override string Permission
        {
            get
            {
                return "1";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "?t=10";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return null;
           // return ModuleCore.BLL.toupiaobt.Instance.GetListPagesByGkuName(pcPage.PageIndex, pcPage.PageSize, out iCount, UserName);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

        }

        protected void InitRpXT()
        {

            rpXt.DataSource = ModuleCore.BLL.Topics.Instance.getListArrayByXT();
            rpXt.DataBind();
        }

        protected void InitRpJH()
        {
            rpJH.DataSource = ModuleCore.BLL.Topics.Instance.getListArrayByJH();
            rpJH.DataBind();
        }
        protected void InitRpBK()
        {
            rpBK.DataSource = ModuleCore.BLL.Channels.Instance.GetListArray("");
            rpBK.DataBind();
        }
        protected void InitrpGdXT()
        {
            List<ModuleCore.Entity.Topics> listAll = ModuleCore.BLL.Topics.Instance.getListArrayByXT();
            List<ModuleCore.Entity.Topics> listL = new List<ModuleCore.Entity.Topics>();
            List<ModuleCore.Entity.Topics> listR = new List<ModuleCore.Entity.Topics>();
            for (int i = 0; i < listAll.Count / 2; i++)
            {
                listL.Add(listAll[i]);
            }

            for (int i = listAll.Count / 2; i < listAll.Count; i++)
            {
                listR.Add(listAll[i]);
            }
            rpGdXTL.DataSource = listL;
            rpGdXTL.DataBind();
            rpGdXTR.DataSource = listR;
            rpGdXTR.DataBind();
        }
        protected string getChannelMasters(int ChannelId)
        {
            if (ModuleCore.BLL.ChannelMasters.Instance.GetEntityByChannelId(ChannelId) != null)
            {
                return ModuleCore.BLL.ChannelMasters.Instance.GetEntityByChannelId(ChannelId).UserName;
            }
            else
            {
                return "";
            }
        }

        protected ModuleCore.Entity.Topics getTopic(int ChannelId)
        {
            if (ModuleCore.BLL.Topics.Instance.GetEntityByChannelID(ChannelId) != null)
            {
                return ModuleCore.BLL.Topics.Instance.GetEntityByChannelID(ChannelId);
            }
            else
            {
                ModuleCore.Entity.Topics bbst = new ModuleCore.Entity.Topics();
                return bbst;
            }
        }
        protected int GetTopicCount(string bkId, string key)
        {
            return ModuleCore.BLL.Topics.Instance.GetListArrayByBkId(bkId, key).Count;
        }

        protected string Ms(string ChannelDescription)
        {
            string cd = "";
            if (ChannelDescription.Length > 35)
            {
                cd = ChannelDescription.Substring(0, 35) + "....";
            }
            else
            {
                cd = ChannelDescription;
            }
            return cd;
        }
    }
}