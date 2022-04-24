using System;
using System.IO;
using System.Threading;
using System.Xml;
using EbSite.Base.ControlPage;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctr
{
    public partial class AddCtrls : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "110";
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
            ModelCtrlEditBase mdCtrl = (ModelCtrlEditBase)FindControl("ModelCtrlEdit");
            if (mdCtrl != null)
                mdCtrl.Save();


            bool isChanged = false;
            //XmlDocument doc = ModelCtrlUtils.GetXmlDocument(); 应该可以采用添加来处理
            XmlDocument doc = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetXmlDocument();
            XmlNode node = doc.SelectSingleNode("//widget[@id=\"" + Request.QueryString["id"] + "\"]");
            if (node.Attributes["title"].InnerText != txtTitle.Text.Trim())
            {
                node.Attributes["title"].InnerText = txtTitle.Text.Trim();
                isChanged = true;
            }

            if (isChanged)
                Base.ExtWidgets.ModelCtr.DataBLL.Instance.SaveXmlDocument(doc);
            ModelCtrlEditBase.OnSaved();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();
            }
            string widget = Request.QueryString["type"];
            string id = Request.QueryString["id"];
            //if (!string.IsNullOrEmpty(Request.QueryString["zone"]))
            //    zone = Request.QueryString["zone"];

            if (!string.IsNullOrEmpty(widget) && !string.IsNullOrEmpty(id))
                InitEditor(widget, id);

        }
        //private string zone = WidgetUtils.ModelCtrlListName;
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    string widget = Request.QueryString["type"];
        //    string id = Request.QueryString["id"];
        //   //if (!string.IsNullOrEmpty(Request.QueryString["zone"])) 
        //   //    zone = Request.QueryString["zone"];
          
        //    if (!string.IsNullOrEmpty(widget) && !string.IsNullOrEmpty(id))
        //        InitEditor(widget, id);
        //}

        /// <summary>
        /// Inititiates the editor for widget editing.
        /// </summary>
        /// <param name="type">The type of widget to edit.</param>
        /// <param name="id">The id of the particular widget to edit.</param>
        /// <param name="zone">The zone the widget to be edited is in.</param>
        private void InitEditor(string type, string id)
        {
            Entity.WidgetShow md = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetEntityByID(new Guid(id));
         
            string fileName = "";

            if (md.ModulID == Guid.Empty)
            {
                fileName = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetPath_Edit(type);
            }
            else
            {
                fileName = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetPath_Edit(type, md.ModulID);
            }
            if (File.Exists(Server.MapPath(fileName)))
            {
                ModelCtrlEditBase edit = (ModelCtrlEditBase)LoadControl(fileName);
                edit.DataID = md.DataID;// new Guid(node.Attributes["id"].InnerText);
                edit.Title = md.Title;// node.Attributes["title"].InnerText;
                edit.ID = "ModelCtrlEdit";
                phEdit.Controls.Add(edit);
                edit.LoadData();
            }
            else
            {
                throw new Exception("找不到文件:" + fileName);
            }

            if (!Page.IsPostBack)
            {
                txtTitle.Text = md.Title;// node.Attributes["title"].InnerText;
                txtTitle.Focus();
            }
        }

        private void BindData()
        {

            drpClass.DataTextField = "Title";
            drpClass.DataValueField = "id";
            drpClass.DataSource = BLL.ClassCustom.Provider.Factory.ModelCtrl().Fills();
            drpClass.DataBind();

            
        }
    }
}