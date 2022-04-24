using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Modules.Shop.ExtensionsCtrls.TypeNames
{
    public partial class Ctrl : ModelCtrlBase
    {
        public override void LoadData()
        {

            List<ModuleCore.Entity.TypeNames> ls = ModuleCore.BLL.TypeNames.Instance.GetListArray(0, "", "");
            drpGoodsType.DataSource = ls;
            drpGoodsType.DataValueField = "id";
            drpGoodsType.DataTextField = "TypeName";
            drpGoodsType.DataBind();
            drpGoodsType.Items.Insert(0, new ListItem("请选择", ""));
            if (!IsPostBack)
            {
                if (ClassID > 0)
                {
                    EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel(ClassID);
                    drpGoodsType.SelectedValue = md.Annex8;
                }

            }
       
        }
        public override string Name
        {
            get { return "TypeNames"; }
        }
        public override void SetValue(string sValue)
        {
            drpGoodsType.SelectedValue = sValue;
        }
        public override string GetValue()
        {
            return drpGoodsType.SelectedValue;
        }
        private int ClassID
        {
            get
            {
                return Core.Utils.StrToInt(Request.QueryString["cid"], 0);
            }
        }
    }
}