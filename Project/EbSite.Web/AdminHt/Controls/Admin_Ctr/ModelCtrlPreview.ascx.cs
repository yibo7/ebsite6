using System;
using System.IO;
using System.Xml;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctr
{
    public partial class ModelCtrlPreview : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "109";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ExtensionsCtrls.ModelCtrlID = new Guid(SID);
        }
        override protected void InitModifyCtr()
        {

           

            //string cType = Request.QueryString["type"];
            //string id = SID;//Request.QueryString["id"];
            ////if (!string.IsNullOrEmpty(Request.QueryString["zone"]))
            ////    zone = Request.QueryString["zone"];
            //XmlDocument doc = ModelCtrlUtils.GetXmlDocument();
            //XmlNode node = doc.SelectSingleNode("//widget[@id=\"" + id + "\"]");

            //string fileName = Base.AppStartInit.IISPath + "ExtensionsCtrls/" + cType + "/Ctrl.ascx";

            //if (File.Exists(Server.MapPath(fileName)))
            //{
            //    ModelCtrlBase edit = (ModelCtrlBase)LoadControl(fileName);
            //    edit.CtrlID = new Guid(node.Attributes["id"].InnerText);
            //    edit.Title = node.Attributes["title"].InnerText;
            //    edit.ID = "ModelCtrlEdit";
            //    //edit.ShowTitle = bool.Parse(node.Attributes["showTitle"].InnerText);
            //    //edit.LoadCtrl();
            //    phEdit.Controls.Add(edit);
            //}
        }

        override protected void SaveModel()
        {

            lbDemoInfo.Text = ExtensionsCtrls.CtrlValue;

            //foreach (System.Web.UI.Control uc in phEdit.Controls)
            //{
            //    Type tp = uc.GetType();

            //    if (tp.BaseType.BaseType == typeof(ModelCtrlBase))
            //    {
            //        ModelCtrlBase myuc = (ModelCtrlBase)uc;

            //        lbDemoInfo.Text = myuc.GetValue();
            //    }
            //}
            
        }
    }
}