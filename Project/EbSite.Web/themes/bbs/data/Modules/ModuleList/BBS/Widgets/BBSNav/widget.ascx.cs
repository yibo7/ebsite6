using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.BBS.Widgets.BBSNav
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {

            if (!base.IsPostBack)
            {
                int iTop = 10;
             
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("txtCount"))
                {
                     iTop = int.Parse(settings["txtCount"]);

                }

                rpDataList.DataSource = ModuleCore.BLL.TopicReplies.Instance.GetListArray(10, " TopicID ");
                rpDataList.DataBind();
            }
        }
        public override string Name
        {
            get { return "BBSNav"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }

       

    }
}