using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.UserPages.Controls.BBS
{
    public partial class bbslist : MPUCBaseListForUser//MPUCBaseList
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
        protected string GetID
        {
            get
            {
                string id = Request.QueryString["tid"];
                if (!string.IsNullOrEmpty(id))
                {
                    return Request.QueryString["tid"];
                }
                return "0";
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
                GetBbsSection();
                //InitRpBK();
                //InitRpXT();
                //InitRpJH();
                //InitrpGdXT();
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


        #region 新方法
       
        /// <summary>
        /// 得到版块 的大类名称 parentid=0
        /// </summary>
        private void GetBbsSection()
        {
            if (GetID != "0")
            {
                //子类的分类绑定
                bbsSectionChild.DataSource = ModuleCore.BLL.Channels.Instance.GetListArray("parentid=" + GetID);
                bbsSectionChild.DataBind();
            }
            else
            {
                bbsSection.DataSource = ModuleCore.BLL.Channels.Instance.GetListArray("parentid=0");
                bbsSection.DataBind();
            }
        }
        protected void bbsSection_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ModuleCore.Entity.Channels dv = (ModuleCore.Entity.Channels)e.Item.DataItem;

                Repeater rep = e.Item.FindControl("rpquestionlist") as Repeater;//找到里层的repeater对象

                rep.DataSource = ModuleCore.BLL.Channels.Instance.GetListArray("parentid=" + dv.id);
                rep.DataBind();
            }
        }

       
        /// <summary>
        /// 得到主版块的定向页面的地址 若还有子类到 | 没有子类 t=12;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetChannelUrl(int id, string name)
        {
            string strUrl = "";
            string T1 = "<a href='?t=1&tid=" + id + "'>" + name + " </a> ";
          //  string T2 = "<a href='?t=2&tid=" + id + "'> " + name + "</a> ";

            //List<ModuleCore.Entity.Channels> ls = ModuleCore.BLL.Channels.Instance.GetListArray("parentid=" + id);
            //if (ls.Count > 0)
            //{
            //    strUrl = T2;
            //}
            //else
            //{
            //    strUrl = T1;
            //}
            return T1;
        }

      
        /// <summary>
        /// 版块的名称
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            ModuleCore.Entity.Channels md = ModuleCore.BLL.Channels.Instance.GetEntity(int.Parse(GetID));
            return md.ChannelName;
        }
        /// <summary>
        /// 得到版块的信息 主题 帖子 最后发帖时间
        /// </summary>
        /// <returns></returns>
        public string GetSectionInfo(int ChannelsID)
        {
            //主题: 2, 帖数: 5
            // <br />
            // 最后发表: 2011-06-28 11:13
            string info = "";
            long themeSum = 0;//主题数 为旗下所有版块的总数
            long topiceSum = 0;//帖子数 为旗下所有版块的总数
            DateTime lastDt;//最后发表时间 最的回复 如果没有回复就是发主题时间
            themeSum = ModuleCore.BLL.Topics.TopicSum("ChannelID="+ChannelsID, false);
            topiceSum = ModuleCore.BLL.Topics.TopicSum("ChannelID=" + ChannelsID, true);




            return "";
            


        }
        #endregion
    }
}