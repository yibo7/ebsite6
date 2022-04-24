
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.Vote
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                int itop = 10;
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    if (settings.ContainsKey("top"))
                    {
                        itop = int.Parse(settings["top"]);
                    }

                    rpVote.DataSource = BLL.vote.Instance.GetListArray(itop, "");

                    if (settings.ContainsKey("tem"))
                    {
                        string sTem = settings["tem"];
                        sTem = base.TemBll.GetTemPath(sTem);
                        if (!string.IsNullOrEmpty(sTem))
                        {
                            rpVote.ItemTemplate = LoadTemplate(sTem);
                        }
                    }

                    rpVote.DataBind();
             
                }

                

            }
        }
        
        public override string Name
        {
            get { return "Vote"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


        
    }
}