using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctrtem
{
    public partial class EditTem : UserControlBaseSave
    {

         public override string Permission
        {
            get
            {
                return "182";
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
            Entity.Templates model = TempFactory.Instance.GetModelByCache(new Guid(SID),GetSiteID);
            string sTemHtml = FObject.ReadFile(Server.MapPath(string.Concat(Base.AppStartInit.IISPath, model.TemPath)));
            txtTem.Text = sTemHtml;
            BindWebPartList();
        }

        override protected void SaveModel()
        {
            if (!string.IsNullOrEmpty(SID))
            {

                Entity.Templates model = TempFactory.Instance.GetModelByCache(new Guid(SID), GetSiteID);
                string sTemHtml = txtTem.Text;
                FObject.WriteFile(Server.MapPath(model.TemPath), sTemHtml);

            }
        }

        //private Guid ID
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request["id"]))
        //        {
        //            return new Guid(Request["id"]);
        //        }

        //        return Guid.Empty;
        //    }
        //}
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    if (ID!=Guid.Empty)
        //    {

        //        Entity.Templates model = BLL.Templates.GetModelByCache(ID);
        //       string sTemHtml = FObject.ReadFile(Server.MapPath(string.Concat(Base.AppStartInit.IISPath, model.TemPath)));
        //       txtTem.Text = sTemHtml;


        //        BindWebPartList();
        //    }
            
        //}
        private void BindWebPartList()
        {
            List<Entity.WidgetShow> lst = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList(); //WidgetUtils.GetWidgetsList(WidgetUtils.ZoneName);

            foreach (WidgetShow widget in lst)
            {
                ListItem li = new ListItem();

                li.Text = widget.Title;
                li.Value = EbSite.Control.Widget.GetWidgetCtrCoder(widget.ID.ToString(), widget.Title); //string.Concat("<XS:Widget   WidgetID=\"", widget.ID, "\" runat=\"server\"/>");

                drWebPartList.Items.Add(li);
            }
        }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (ID != Guid.Empty)
        //    {

        //        Entity.Templates model = BLL.Templates.GetModelByCache(ID);
        //        string sTemHtml = txtTem.Text;
        //        FObject.WriteFile(Server.MapPath(model.TemPath), sTemHtml);
                
        //    }
        //}
    }
}