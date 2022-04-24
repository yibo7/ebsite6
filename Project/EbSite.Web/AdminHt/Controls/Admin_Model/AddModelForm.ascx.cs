using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class AddModelForm : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public ModelInterface bllModel
        {
            get
            {
                return new FormModel(GetSiteID);

            }
        }

        public override string Permission
        {
            get
            {
                return "102";
            }
        }
        /// <summary>
        /// 获取模型ID
        /// </summary>
        private Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return new Guid(Request["id"]);
                }
                return Guid.Empty;
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            ModelClass mc = bllModel.GeModelByID(ModelID);
            
            txtModelName.Text = mc.ModelName;
            txtTempName.CtrValue = mc.FormTempName;
            txtTempName.ReadOnly = true;
            cbIsSystem.Checked = mc.IsSystem;
        }

        override protected void SaveModel()
        {
            ModelClass mc = new ModelClass();
            if (ModelID != Guid.Empty)
            {
                mc = bllModel.GeModelByID(ModelID);
               
            }
            else
            {
                mc.ID = Guid.NewGuid();
                mc.Configs = bllModel.GetDefaultColumList();
            }
            mc.ModelName = txtModelName.Text;
            mc.FormTempName = txtTempName.CtrValue;
            mc.IsSystem = cbIsSystem.Checked;
            if (ModelID == Guid.Empty)
            {
                bllModel.AddModel(mc);
                mc.AddFormTem();
            }
            else
            {
                bllModel.Save();

            }
            //base.ColseGreyBox(true);
        }
    }
}