using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Modules.Shop.ExtensionsCtrls.ClassType
{
    public partial class Ctrl : ModelCtrlBase
    {
        public override void LoadData()
        {
            if (ClassID > 0)
            {
                EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel(ClassID);
                drpClassTypeList.Items.Add(new ListItem("产品", "1"));
                drpClassTypeList.Items.Add(new ListItem("文章", "2"));
                drpClassTypeList.SelectedValue = md.Annex9.ToString();
                drpClassTypeList.DataBind();
            }
        }
        public override string Name
        {
            get { return "ClassType"; }
        }
        public override void SetValue(string sValue)
        {
            drpClassTypeList.SelectedValue = sValue;
            // selClass.Value = sValue;
        }
        public override string GetValue()
        {
            return drpClassTypeList.SelectedValue;
            // return selClass.Value;
        }
        private int ClassID
        {
            get
            {
                int iClassID = Core.Utils.StrToInt(Request.QueryString["cid"], 0);
                if (iClassID < 1)
                {
                    if (ContentID > 0)
                    {
                        EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(ContentID,GetSiteID);
                        return md.ClassID;
                    }
                }

                return iClassID;
            }
        }
        private int ContentID
        {
            get
            {
                return Core.Utils.StrToInt(Request.QueryString["id"], 0);
            }
        }
    }
}