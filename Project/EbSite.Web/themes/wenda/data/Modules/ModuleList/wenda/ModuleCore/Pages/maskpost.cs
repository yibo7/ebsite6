using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class maskpost : EbSite.Base.Page.BasePage
    {
        //public bool IsExpert = false;
        public ModuleCore.Entity.ExpertsInfo mdExpert ;
        public EbSite.Base.EntityAPI.MembershipUserEb mdUser;
        protected global::System.Web.UI.WebControls.PlaceHolder phExpert;
        protected global::System.Web.UI.WebControls.PlaceHolder phUser;

        protected EbSite.Control.TextBoxVl txtValidCode;

        /// <summary>
        /// 向专家提问
        /// </summary>
        protected int ExUid
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
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "发表问题";
            phExpert.Visible = false;
            phUser.Visible = false;
            if (ExUid > 0)
            {
                List<ModuleCore.Entity.ExpertsInfo> models = ModuleCore.BLL.ExpertsControl.Instance.FillList();
                List<ModuleCore.Entity.ExpertsInfo> dataList =
                    (from i in models where i.UserID == ExUid select i).ToList();
                if (dataList.Count > 0)
                {
                    mdExpert = dataList[0];//EbSite.Base.Host.Instance.GetUserSiteUrl(md.UserName)
                    phExpert.Visible = true;
                }
                else
                {
                    Tips("出错了","找不到对应的专家！");
                }
            }
            else if (UserUid>0)
            {
                mdUser = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(UserUid);
                if (Equals(mdUser, null))
                {   
                    mdUser = new EbSite.Base.EntityAPI.MembershipUserEb();
                    phUser.Visible = false;//没有此用户 
                }
                else
                {
                    phUser.Visible = true;
                }
               
            }

        }
       
    }
}