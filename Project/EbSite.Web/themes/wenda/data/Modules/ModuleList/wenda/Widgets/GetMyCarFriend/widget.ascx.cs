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


namespace EbSite.Modules.Wenda.Widgets.GetMyCarFriend
{
    public partial class widget : WidgetBase
    {
   
        // Methods
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                LoadExpertData();
            }
        }

        private void LoadExpertData()
        {
            StringDictionary settings = base.GetSettings();
            string strFlag = "0";
            if (settings.ContainsKey("txtKey"))
            {
                strFlag = settings["txtKey"].ToString();
            }
            int recordCount=0;
            //显示数量
            int showCount =9;
            int roleID = 1;
            if (strFlag.Equals("1"))
            {
                showCount = 9;
                roleID = 5;
            }

            List<EbSite.Base.EntityAPI.MembershipUserEb> modelList = EbSite.BLL.User.MembershipUserEb.Instance.GetListPages(0, showCount, false, out recordCount, roleID);
            if (modelList != null && modelList.Count > 0)
            {
                this.rpSubClass.DataSource = modelList;
                this.rpSubClass.DataBind();
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
                return "GetMyCarFriend";
            }
        }

    }
}