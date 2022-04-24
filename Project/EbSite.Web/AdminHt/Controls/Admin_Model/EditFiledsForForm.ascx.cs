using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class EditFiledsForForm : EditFiledsBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindData();

            }

        }
        public override void OnSaved(ModelClass mc)
        {
            if(cbIsReset.Checked)
            {
                List<ColumFiledConfigs> cfcs = mc.GetUsedFileds();
                StringBuilder sb = new StringBuilder();
                foreach (ColumFiledConfigs cfc in cfcs)
                {
                    sb.AppendFormat("<XS:ExtensionsCtrls ID=\"{0}\" ModelCtrlID=\"{1}\" ShowName=\"{2}\" runat=\"server\"/> \n\t<br><br>\n\t", cfc.ColumFiledName, cfc.FieldControlTypeID, cfc.ColumShowName);
                }
                string html = mc.GetTemHtml();
                string tem = Core.Strings.GetString.CutMiddleStr(html, "<asp:PlaceHolder ID=\"phFileds\" runat=\"server\">",
                                                                 "</asp:PlaceHolder>");
                html = html.Replace(tem, sb.ToString());
                mc.UpdateFormTem(html);
            }
          
        }
        protected string BindCoreForPageTem(string ColumFiledName)
       {
           return string.Concat("&lt;%=Model.", ColumFiledName, " %&gt;");
       }
        protected string GetCtr(string ctrid, string ColumFiledName, string Showname)
        {
            return string.Format("&lt;XS:ExtensionsCtrls ID=\"{0}\"   ModelCtrlID=\"{1}\" ShowName=\"{2}\" runat=\"server\"/&gt;", ColumFiledName, ctrid, Showname);
        }

    }
}