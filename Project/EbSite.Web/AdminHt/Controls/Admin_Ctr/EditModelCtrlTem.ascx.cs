using System;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctr
{
    public partial class EditModelCtrlTem : EbSite.Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "111";
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
                        sPath = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetPath_Show(Request["type"]);
                    }
                    else
                    {
                        sPath = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetPath_Show(Request["type"], new Guid(Request["modulid"]));
                    }

                }
                return sPath;

                //string sPath = "";
                //if (!string.IsNullOrEmpty(Request["type"]))
                //{
                //    sPath = Base.AppStartInit.IISPath + "ExtensionsCtrls/" + Request["type"] + "/Ctrl.ascx";
                //}
                //return sPath;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(WigetsPath))
                {
                    txtTem.Text = EbSite.Core.FSO.FObject.ReadFile(Server.MapPath(WigetsPath));
                }

            }
        }
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(WigetsPath))
        //    {
        //        string sTemHtml = txtTem.Text;
        //        EbSite.Core.FSO.FObject.WriteFile(Server.MapPath(WigetsPath), sTemHtml);

        //    }
        //}
    }
}