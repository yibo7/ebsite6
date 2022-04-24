using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.UserPages.Controls.BBS
{
    public partial class BBS_TopicsList : MPUCBaseListForUser
    {
        // protected ModuleCore.Entity.Channels bbsC;
        protected string pid = "";
        protected string sid = "";

        public override string Permission
        {
            get
            {
                return "7";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "";// return "NetDisk.aspx?t=2&mid="+ModuleID;
            }
        }
        protected int GetID
        {
            get
            {
                return int.Parse(Request["tid"]);
            }
        }
      
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("a4482e06-579f-4346-bc7f-5dd2584ae2cd");
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
                GetClassName();
                BindTopice();
                BindChildChannel();
            }
            pid = Convert.ToString(base.MenuID);
            sid = Convert.ToString(base.ModuleID);
        }


        #region 新代码

        protected bool isKey=false;
        /// <summary>
        /// 绑定 主版块下的子版块
        /// </summary>
        public void BindChildChannel()
        {
            //子类的分类绑定
            bbsSectionChild.DataSource = ModuleCore.BLL.Channels.Instance.GetListArray("parentid=" + GetID);
            bbsSectionChild.DataBind();
            if(bbsSectionChild.Items.Count>0)
            {
                isKey = true;
               
            }
        }


        /// <summary>
        /// 上方的 版块名称 主题总数 回复总数
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            //安装使用 主题 6 / 回复 12 今日: 2|主题: 3|帖子: 2 
            string strInfo = "";
            ModuleCore.Entity.Channels md = ModuleCore.BLL.Channels.Instance.GetEntity(GetID);
            strInfo = md.ChannelName + " ";
            List<ModuleCore.Entity.Topics> lsDay = ModuleCore.BLL.Topics.Instance.GetListArray("CreatedTime between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 0:00:00' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59' and ChannelID=" + GetID);
            List<ModuleCore.Entity.Topics> ls = ModuleCore.BLL.Topics.Instance.GetListArray(" ChannelID=" + GetID);

            strInfo += "今日 " + lsDay.Count + "|主题 " + ls.Count;
            return strInfo;
        }
        /// <summary>
        /// 绑定全站 本版置顶块 本版块帖子 
        /// </summary>
        public void BindTopice()
        {

            repAllTopice.DataSource = ModuleCore.BLL.Topics.Instance.GetListArray("SiteOrderTopFlag=1");
            repAllTopice.DataBind();
            repOwnTopRopice.DataSource = ModuleCore.BLL.Topics.Instance.GetListArray("OrderTopFlag=1");
            repOwnTopRopice.DataBind();
            repOwnRopice.DataSource = ModuleCore.BLL.Topics.Instance.GetListArray("SiteOrderTopFlag=0 and OrderTopFlag=0 and  ChannelID=" + GetID);
            repOwnRopice.DataBind();

        }
        /// <summary>
        /// 热帖子 的图片
        /// </summary>
        /// <param name="hits"></param>
        /// <returns></returns>
        public static string PicInfo(int hits)
        {
            string hots = " <img src=\"/Modules/BBS/DataStore/Attachments/img/icons/topic_hot.gif\" />";
            string s = "<img src=\"/Modules/BBS/DataStore/Attachments/img/icons/topic_normal.gif\" />";
            if (hits > 50)
            {
                s = hots;
            }
            return s;
        }
        /// <summary>
        /// 获得到 Repeater  HeaderTemplate 头部信息
        /// </summary>
        /// <returns></returns>
        public string RetChildSection(bool key)
        {
            string str = "";
            if(key)
            {
               str="<div class=\"ctent\"> <div class=\"ctent-top\"> <span class=\"ctent-title\">子版块</span></div> <div class=\"bbs-ctent\">";

            }
            return str;
        }

        public string RetChildSectionFoot(bool key)
        {
            string str = "";
            if (key)
            {
                str = " </div> </div>";

            }
            return str;
        }
        #endregion
    }
}