
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL;

namespace EbSite.Widgets.GetUserMsg
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!base.IsPostBack)
                {
                    int sTop =Convert.ToInt32(settings["CountTitle"]);
                    //string usname = EbSite.Base.Host.Instance.UserName;
                    List<Msg> ls = EbSite.BLL.Msg.GetNewList(sTop,UserID);
                    //List<Msg> newls = (from i in ls orderby i.SendDate descending select i).Take(sTop).ToList();
                    rpSubMsg.DataSource = ls;
                    string TemPath = "";
                    TemPath = base.TemBll.GetTemPath(TemPath);
                    if (!string.IsNullOrEmpty(TemPath))
                    {

                        rpSubMsg.ItemTemplate = LoadTemplate(TemPath);
                    }
                    rpSubMsg.DataBind();

                }
            }
        }


        public override string Name
        {
            get { return "GetUserMsg"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}