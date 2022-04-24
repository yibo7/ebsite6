using System;

namespace EbSite.Web.AdminHt.Controls.Admin_Widget
{
    public partial class EditWidgetsTem : EbSite.Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "122";
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
        }

        override protected void SaveModel()
        {
            if (!string.IsNullOrEmpty(WigetsPath))
            {
                string sTemHtml = txtTem.Text;
                EbSite.Core.FSO.FObject.WriteFile(Server.MapPath(WigetsPath), sTemHtml);

            }
        }
        private string WigetsPath
        {
            get
            {
                string sPath = "";
                if (!string.IsNullOrEmpty(Request["type"]))
                {
                    if (Request["modulid"].Equals("0"))
                    {
                        sPath = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetPath_Show(Request["type"]);
                    }
                    else
                    {
                        sPath = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetPath_Show(Request["type"], new Guid(Request["modulid"]));
                    }
                    
                }
                return sPath;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!string.IsNullOrEmpty(WigetsPath))
                {
                    txtTem.Text = EbSite.Core.FSO.FObject.ReadFile(Server.MapPath(WigetsPath));
                }
                
            }
        }
        
    }
}