using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class ConfigToClass : Base.ControlPage.UserControlBaseSave
    {

        public override string Permission
        {
            get
            {
                return "59";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
              return  "id";
            }
        }

        //private Entity.NewsClass cm = null;
        override protected void InitModifyCtr()
        {
            int iConfigID = int.Parse(SID);           


        }
        override protected void SaveModel()
        {
            int classId = int.Parse(SID);
            int selConfigId = int.Parse(drpConfigs.SelectedValue);
            var modelClass = BLL.NewsClass.GetModelByCache(classId);
            modelClass.ConfigId = selConfigId;
            BLL.NewsClass.Update(modelClass);
            Core.Utils.AppRestart();
            //Response.Redirect(Request.RawUrl);
        }
         

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int iCount = 0;
                drpConfigs.DataValueField = "id";
                drpConfigs.DataTextField = "ConfigName";
                drpConfigs.DataSource = BLL.ClassConfigs.Instance.GetListPages(1, 10000, "", "", out iCount, base.GetSiteID);
                drpConfigs.DataBind();
                int classId = int.Parse(SID);
                var modelClass = BLL.NewsClass.GetModelByCache(classId);
                var modelConfig = BLL.ClassConfigs.Instance.GetEntity(modelClass.ConfigId);
                if(modelConfig != null)
                {
                    drpConfigs.SelectedValue = modelClass.ConfigId.ToString();
                    txtTips.Text = string.Format("【{0}】当前配置是【{1}】",modelClass.ClassName, modelConfig.ConfigName);
                }
                else
                {
                    txtTips.Text = "当前分类还没有配置，这是不正常的情况！";
                }

            }
            
        }
         
    }
}