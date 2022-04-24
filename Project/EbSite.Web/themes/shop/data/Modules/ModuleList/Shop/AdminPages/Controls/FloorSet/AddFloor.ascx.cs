using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.FloorSet
{
    public partial class AddFloor : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "楼层添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "96";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack&&string.IsNullOrEmpty(SID))
            {
               // TopBindClass();
              //  RightBindClass();
            }
        }

        //private void TopBindClass()
        //{
        //    cblTopClass.DataValueField = "ID";
        //    cblTopClass.DataTextField = "ClassName";
        //    cblTopClass.DataSource = BLL.NewsClass.GetContentClassesTree(SettingInfo.Instance.GetSiteID);
        //    cblTopClass.DataBind();

        //}
        //private void RightBindClass()
        //{
        //    cblRightClass.DataValueField = "ID";
        //    cblRightClass.DataTextField = "ClassName";
        //    cblRightClass.DataSource = BLL.NewsClass.GetContentClassesTree(SettingInfo.Instance.GetSiteID);
        //    cblRightClass.DataBind();

        //}
        override protected void InitModifyCtr()
        {

            ModuleCore.Entity.FloorSet model = ModuleCore.BLL.FloorSetInfo.Instance.GetEntity(int.Parse(SID));
            if (!Equals(model, null))
            {
                tbFloorName.Text = model.FloorName;
                tbFloorID.Text = model.FloorId.ToString();
                ShowColor.Color = model.FloorColor;
                //FloorPic.CtrValue = model.FloorPic;
                //tbPicUrl.Text = model.FloorPicUrl;



                //TopBindClass();
                //RightBindClass();

                //if (!string.IsNullOrEmpty(model.TopClassItem))
                //{
                //    string[] aItems = model.TopClassItem.Split(',');
                //    foreach (ListItem li in cblTopClass.Items)
                //    {
                //        if (Core.Strings.Validate.InArray(li.Value, aItems))
                //        {
                //            li.Selected = true;
                //        }
                //    }
                //}

                //if (!string.IsNullOrEmpty(model.RightClassItem))
                //{
                //    string[] aItems = model.RightClassItem.Split(',');
                //    foreach (ListItem li in cblRightClass.Items)
                //    {
                //        if (Core.Strings.Validate.InArray(li.Value, aItems))
                //        {
                //            li.Selected = true;
                //        }
                //    }
                //}
            }
        }
        #region
        //private string GetTopItems()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (ListItem li in cblTopClass.Items)
        //    {
        //        if (li.Selected)
        //        {
        //            sb.Append(li.Value);
        //            sb.Append(",");
        //        }
        //    }
        //    if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
        //    return sb.ToString();
        //}

        //private string GetRightItems()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (ListItem li in cblRightClass.Items)
        //    {
        //        if (li.Selected)
        //        {
        //            sb.Append(li.Value);
        //            sb.Append(",");
        //        }
        //    }
        //    if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
        //    return sb.ToString();
        //}

        //private string GetProductIDs()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    List<InfoProduct> ls = this.FloorParts.ProductInfo;
        //    foreach (InfoProduct li in ls)
        //    {

        //        sb.Append(li.ID);
        //        sb.Append(",");

        //    }
        //    if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
        //    return sb.ToString();
        //}
        #endregion

        override protected void SaveModel()
        {

            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.Entity.FloorSet model = new ModuleCore.Entity.FloorSet();

                model.FloorName = tbFloorName.Text;
                model.FloorId = int.Parse(tbFloorID.Text);
                model.FloorColor = ShowColor.Color;
                //model.FloorPic = FloorPic.CtrValue;
                //model.FloorPicUrl = tbPicUrl.Text;
                //model.TopClassItem = GetTopItems();
                //model.RightClassItem = GetRightItems();
                //model.ProductIds = GetProductIDs();
                EbSite.Modules.Shop.ModuleCore.BLL.FloorSetInfo.Instance.Add(model);
            }
            else
            {
                ModuleCore.Entity.FloorSet model = ModuleCore.BLL.FloorSetInfo.Instance.GetEntity(int.Parse(SID));
                model.FloorName = tbFloorName.Text;
                model.FloorId = int.Parse(tbFloorID.Text);
                model.FloorColor = ShowColor.Color;
                //model.FloorPic = FloorPic.CtrValue;
                //model.FloorPicUrl = tbPicUrl.Text;
                //model.TopClassItem = GetTopItems();
                //model.RightClassItem = GetRightItems();
                //model.ProductIds = GetProductIDs();
                EbSite.Modules.Shop.ModuleCore.BLL.FloorSetInfo.Instance.Update(model);
            }
        }
    }
}