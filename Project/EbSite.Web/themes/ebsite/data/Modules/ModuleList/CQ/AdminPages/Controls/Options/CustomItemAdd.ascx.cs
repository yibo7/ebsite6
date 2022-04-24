using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.AdminPages.Controls.Options
{
    public partial class CustomItemAdd : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("af348cbd-fe9e-4e69-9680-cf3f713c8cc1");
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        //private int iParentID
        //{
        //    get
        //    {
        //        if(!string.IsNullOrEmpty(Request["pid"]))
        //        {
        //            return int.Parse(Request["pid"]);
        //        }
        //        return 0;
        //    }
        //}
        protected override void OnBasePageLoading()
        {
            ParentID.DataTextField = "ItemName";
            ParentID.DataValueField = "ID";
           ParentID.DataSource =  ModuleCore.BLL.CustomItems.Instance.GetParents();
           ParentID.DataBind();

           if (!string.IsNullOrEmpty(Request["pid"]))
           {
               ParentID.SelectedValue = Request["pid"];
           }

        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.CustomItems.Instance.InitModifyCtr(int.Parse(SID), phCtrList);
        }
        override protected void SaveModel()
        {

            ModuleCore.BLL.CustomItems.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
        }

    }
}