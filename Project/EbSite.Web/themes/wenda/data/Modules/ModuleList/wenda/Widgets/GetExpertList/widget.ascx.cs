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


namespace EbSite.Modules.Wenda.Widgets.GetExpertList
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
        private void LoadCarExpert()
        {
          
            StringDictionary settings = base.GetSettings();
           
            
            //Repeater rp = new Repeater();
            List<ModuleCore.Entity.ExpertsInfo> models=ModuleCore.BLL.ExpertsControl.Instance.FillList();
            if (models != null && models.Count > 0)
            {
                List<ModuleCore.Entity.ExpertsInfo> dataList = (from i in models where i.IsAudit==1 orderby i.id descending select i).Take(50).ToList();
                if (dataList != null && dataList.Count > 0)
                {
                    rpList.DataSource = dataList;
                    rpList.DataBind();
                   
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
                return "GetExpertList";
            }
        }

       
    }
}