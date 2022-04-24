
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Modules.Shop.ModuleCore.Entity;
using ListItemModel = EbSite.Base.EntityAPI.ListItemModel;

namespace EbSite.Modules.Shop.Widgets.MobileFlash
{
    public partial class widget : WidgetBase
    {

        public override void LoadData()
        {

            StringDictionary settings = GetSettings();

            List<ModuleCore.Entity.MFlash> ls5 = ModuleCore.BLL.MFlashInfo.Instance.FillList();
            this.rpList.DataSource = ls5;
            this.rpList.DataBind();
            

        }




        public override string Name
        {
            get { return "MobileFlash"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


    }


}