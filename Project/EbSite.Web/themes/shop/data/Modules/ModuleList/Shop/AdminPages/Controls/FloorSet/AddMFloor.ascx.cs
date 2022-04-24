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
    public partial class AddMFloor : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "手机楼层添加";
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

            }
        }

        override protected void InitModifyCtr()
        {
            if (!string.IsNullOrEmpty(SID))
            {
                ModuleCore.Entity.MFloorSet model = ModuleCore.BLL.MFloorSetInfo.Instance.GetEntity(int.Parse(SID));
                if (!Equals(model, null))
                {
                    tbFloorName.Text = model.FloorName;
                    tbFloorID.Text = model.FloorId.ToString();
                    ShowColor.Color = model.FloorColor;
                     tbPicUrl.Text =model.AdPicUrl;
                     this.txtFloorLink.Text = model.FloorUrl;
                    this.txtTitle.Text= model.AdName;
                }
            }
        }

        override protected void SaveModel()
        {

            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.Entity.MFloorSet model = new ModuleCore.Entity.MFloorSet();

                model.FloorName = tbFloorName.Text;
                model.FloorId = int.Parse(tbFloorID.Text);
                model.FloorColor = ShowColor.Color;
                model.AdUrl = FloorPic.CtrValue;
                model.AdPicUrl = tbPicUrl.Text;
                model.FloorUrl = this.txtFloorLink.Text;
                model.AdName = this.txtTitle.Text;
                EbSite.Modules.Shop.ModuleCore.BLL.MFloorSetInfo.Instance.Add(model);
            }
            else
            {
                ModuleCore.Entity.MFloorSet model = ModuleCore.BLL.MFloorSetInfo.Instance.GetEntity(int.Parse(SID));
                model.FloorName = tbFloorName.Text;
                model.FloorId = int.Parse(tbFloorID.Text);
                model.FloorColor = ShowColor.Color;
                model.AdUrl = FloorPic.CtrValue;
                model.AdPicUrl = tbPicUrl.Text;
                model.FloorUrl = this.txtFloorLink.Text;
                model.AdName = this.txtTitle.Text;
                EbSite.Modules.Shop.ModuleCore.BLL.MFloorSetInfo.Instance.Update(model);
            }
        }
    }
}