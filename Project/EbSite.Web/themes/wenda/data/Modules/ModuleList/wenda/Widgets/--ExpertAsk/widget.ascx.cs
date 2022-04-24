using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL;
using EbSite.BLL.Ctrtem;
using EbSite.BLL.User;
using EbSite.Modules.Wenda.ModuleCore.Entity;


namespace EbSite.Modules.Wenda.Widgets.ExpertAsk
{
    public partial class widget : WidgetBase
    {
   
        // Methods
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                LoadCarExpert();
            }
        }
        /// <summary>
        /// 向专家提问
        /// </summary>
        protected  int ExUid
        {
            get
            {
                string uid = Request.QueryString["uid"];

                return Core.Utils.StrToInt(uid, 0);
            }
        }
        /// <summary>
        /// 向用户提问
        /// </summary>
        protected int UserUid
        {
            get
            {
                string uid = Request.QueryString["u"];

                return Core.Utils.StrToInt(uid, 0);
            }
        }
        protected string sInfo = "";
       
        private void LoadCarExpert()
        {
            string temp = "<div class=\"zjinfo\">"+
                            " <div class=\"zjphoto\">  <a href=\"{5}\" target=\"_blank\">"+
           " <img id=\"AvatarBig\" src='{6}' width=\"180\" /></a> </div>"+
                             "<div class=\"zjmes\">"+
                               " <div class=\"zjname\">"+
                                   " <li><span>{1}</span></li>"+
                                   " <li>擅长领域：<font color=\"#6D9520\">{2}</font></li>"+
                                    "<li>擅长品牌：<font color=\"#6D9520\">{3}</font></li>"+
                                "</div>"+
                                "<div class=\"zjintro\">"+
                                    "<span>专家简介：</span>"+
                                    "<li>{4}</li>"+
                                "</div></div></div>";


            string tempUser = "<div class=\"zjinfo\">" +
                           " <div class=\"zjphoto\">  <a href=\"{5}\" target=\"_blank\">" +
          " <img id=\"AvatarBig\" src='{6}' width=\"180\" /></a> </div>" +
                            "<div class=\"zjmes\">" +
                              " <div class=\"zjname\">" +
                                  " <li><span>{1}</span></li>" +
                                  " <li> 级别：<font color=\"#6D9520\">{2}</font></li>" +
                                   "<li>积分：<font color=\"#6D9520\">{3}</font></li>" +
                               "</div>" +
                               "<div class=\"zjintro\">" +
                                   "<span>简介：</span>" +
                                   "<li>{4}</li>" +
                               "</div></div></div>";
            if (ExUid > 0)
            {
                ModuleCore.Entity.ExpertsInfo md = new ExpertsInfo();
                StringDictionary settings = base.GetSettings();

                List<ModuleCore.Entity.ExpertsInfo> models = ModuleCore.BLL.ExpertsControl.Instance.FillList();
                List<ModuleCore.Entity.ExpertsInfo> dataList =
                    (from i in models where i.UserID == ExUid select i).ToList();
                if (dataList.Count > 0)
                {
                    md = dataList[0];//EbSite.Base.Host.Instance.GetUserSiteUrl(md.UserName)
                    sInfo = string.Format(temp, md.UserID, md.UserNiName, md.Field, md.Brand, md.JianJie,
                                          "/jieda-1-"+md.UserID+"-1.ashx",
                                          EbSite.Base.Host.Instance.AvatarBig(Convert.ToInt32(md.UserID.ToString())));
                }
            }

            if(UserUid>0)
            {
                EbSite.Base.EntityAPI.MembershipUserEb md = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(UserUid);
                if(!Equals(md,null))
                {
                    sInfo = string.Format(tempUser, UserUid, md.UserName, md.UserLevel, md.Credits, "简历",
                                         EbSite.Base.Host.Instance.GetUserSiteUrl(md.UserName),
                                         md.AvatarBig);
                }
            }


        }
        public override bool IsEditable
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                return "ExpertAsk";
            }
        }

       
    }
}