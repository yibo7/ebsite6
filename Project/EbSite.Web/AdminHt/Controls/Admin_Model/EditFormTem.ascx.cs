using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class EditFormTem : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindWebRep();
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
            txtTem.Text = mc.GetTemHtml();
        }

        override protected void SaveModel()
        {
            ModelClass mc = new ModelClass();
            if (ModelID != Guid.Empty)
            {
                mc = bllModel.GeModelByID(ModelID);
                mc.UpdateFormTem(txtTem.Text);
            }

        }

        /// <summary>
        /// 绑定自定内容
        /// </summary>
        private void BindWebRep()
        {
            ModelInterface bllModel = new FormModel(GetSiteID);
            ModelClass mc = bllModel.GeModelByID(ModelID);
            List<ColumFiledConfigs> lsUsedFileds = mc.GetUsedFileds();
            rpGetExtList.DataSource = lsUsedFileds;
            rpGetExtList.DataBind();
        }
        public object ExtntsionStr(string CoulumFiledName,string FieldControlTypeID,string ColumShowName)
        {
            string str=string.Concat("<XS:ExtensionsCtrls  ID=\"", CoulumFiledName, "\" ModelCtrlID=\"",
                                         FieldControlTypeID, "\" ShowName= \"", ColumShowName,
                                         "\" runat=\"server\"/>");
            return str;
        }
    }
}