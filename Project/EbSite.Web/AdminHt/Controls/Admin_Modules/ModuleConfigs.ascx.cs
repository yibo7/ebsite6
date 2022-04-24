using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EbSite.Base.Modules;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    //public class ConfigModel
    //{
    //    public ConfigModel(string sId, string sName)
    //    {
    //        this.Id = sId;
    //        this.Name = sName;
    //    }
    //    public string Id { get; set; }
    //    public string Name { get; set; }
    //}

    public partial class ModuleConfigs : BasePage
    {
        public override string Permission
        {
            get
            {
                return "237";
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            InitEditor();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //ctbTag.EndLiteral = llTagEnd;
            //ucPageTags.Title = "系统设置";
            if (!IsPostBack)
            {
               
            }

        }
        private void InitEditor()
        {
            if (string.IsNullOrEmpty(sModulePath)) return;
            string fileName = string.Concat(sModulePath, "Setting.ascx");

            if (File.Exists(Server.MapPath(fileName)))
            {
                
                Base.Modules.Settings edit = (Base.Modules.Settings)LoadControl(fileName);
                
                edit.ID = "mdconfigs"; 
                phEdit.Controls.Add(edit); 

                //List<ConfigModel> lstConfigModel = new List<ConfigModel>();

                //if (edit.TagsList.Count > 0) //如果有新列表
                //{

                //    List<ListItemModel> lstItems = edit.TagsList;
                //    //StringBuilder sb = new StringBuilder();
                //    foreach (ListItemModel lstItem in lstItems)
                //    {
                //        lstConfigModel.Add(new ConfigModel(lstItem.Value, lstItem.Text));
                //        //sb.AppendFormat("{0}#{1}|", lstItem.Text, lstItem.Value);
                //    }

                //    //sb.Remove(sb.Length - 1, 1);

                //    //ctbTag.Items = string.Format("模块信息#defaultconfigs|{0}", sb.ToString());
                //    phEdit.Controls.Add(edit);
                //}
                //else
                //{
                //    lstConfigModel.Add(new ConfigModel("tg1", "模块配置"));
                //    //ctbTag.Items = "模块信息#defaultconfigs|模块配置#tg1";
                //    System.Web.UI.Control ct = Page.ParseControl("<div class=\"tab-pane\" id=\"tg1\" >");
                //    phEdit.Controls.Add(ct);
                //    phEdit.Controls.Add(edit);
                //    ct = Page.ParseControl("</div>");
                //    phEdit.Controls.Add(ct);
                //}

                //rpModulesConfigs.DataSource = lstConfigModel;
                //rpModulesConfigs.DataBind();

                ////edit.Load += new EventHandler(InitDefaultData);

                //ctbTag.EndLiteral = llTagEnd;

                //System.Web.UI.Control ct = Page.ParseControl("<div id=\"tg1\" >");
                //phEdit.Controls.Add(ct);
                //phEdit.Controls.Add(edit);
                //ct = Page.ParseControl("</div>");
                //phEdit.Controls.Add(ct);

            }
            else
            {
                Tips("出错了", "找不到相应的模块配置文件[Setting.ascx]！", "");
            }

            //cbIsClose.Checked = Model.IsClose;

        }
        //private void InitDefaultData(object sender, EventArgs e)
        //{
        //   Base.Modules.Settings st =  (Base.Modules.Settings) sender;
            
        //   ColseInfo.Text = st.ColseInfo;
        //   cbIsClose.Checked = st.IsSaveColseOpen;
        //}
 

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Base.Modules.Settings edit = (Base.Modules.Settings)FindControl("mdconfigs");
            if (!Equals(edit,null))
            {
                //edit.ColseInfo = ColseInfo.Text;
                //edit.IsSaveColseOpen = cbIsClose.Checked;
                edit.Save();

                //EbSite.BLL.ModulesBll.Modules.Instance.CloseOpenModel(GetModuleID, cbIsClose.Checked);
            }
                

            //WidgetEditBase.OnSaved();
        }
    }
}