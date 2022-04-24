using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Core.FSO;
using EbSite.Entity;
using Templates=EbSite.Entity.Templates;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    public partial class IncAdd : BaseAdd
    {
        public override string Permission
        {
            get
            {
                return "205";
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
            //Entity.Templates model = BLL.TemplateInc.GetModelByCache(new Guid(SID));
            Entity.Templates model = TemBll.IncBll.GetModelByCache(new Guid(SID));
            

            //读取模板信息
            string sTemHtml = FObject.ReadFile(Server.MapPath(model.TemPath));
            txtTem.Text = sTemHtml;

            txtTitle.Text = model.TemName;

        }
        override protected void SaveModel()
        {
            //string sThemes = EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.PageStyle;
            Entity.Templates mdNC = new Templates(ThemesFolder);
            string sTemHtml = txtTem.Text;
            string sIncTitle = txtTitle.Text.Trim();
            if (!string.IsNullOrEmpty(SID)) //修改
            {
                //Entity.Templates model = BLL.TemplateInc.GetModelByCache(new Guid(SID));
                Entity.Templates model = TemBll.IncBll.GetModelByCache(new Guid(SID));
                

                model.TemName = sIncTitle;
                //BLL.TemplateInc.Update(model);
                TemBll.IncBll.Update(model);

                FObject.WriteFile(Server.MapPath(model.TemPath), sTemHtml);


            }
            else  //新加
            {
                //生成模板文件

                string sfName = string.Concat("public_", Path.GetRandomFileName(), ".inc");
                string sThemes = CurrentThemeName;
                //string sfPath = string.Concat(IISPath, "themes/", sThemes, "/pages/", sfName);
                string sfPath = string.Concat(IISPath, TemBll.ThemesFolder, "/", sThemes, "/pages/", sfName);
                

                string sPath = Server.MapPath(sfPath);

                if (!Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
                {
                    Core.FSO.FObject.WriteFile(sPath, sTemHtml);
                    mdNC.TemName = sIncTitle;
                    //mdNC.TemPath = sfName;
                    mdNC.TempFileName = sfName;
                    mdNC.Themes = sThemes;// CurrentSite.PageTheme;
                    mdNC.ID = Guid.NewGuid();
                    //BLL.TemplateInc.Add(mdNC);
                    TemBll.IncBll.Add(mdNC);
                }
                else
                {
                    Core.Strings.cJavascripts.MessageShowBack("已经存在与此名称相同的模块文件");

                    return;
                }
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //BindDrpList();
            }
           
            
        }
        ///// <summary>
        ///// 绑定部件
        ///// </summary>
        //private void BindDrpList()
        //{
        //    List<Entity.WidgetShow> lst = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList();// WidgetUtils.GetWidgetsList(WidgetUtils.ZoneName);)

        //    foreach (WidgetShow widget in lst)
        //    {
        //        ListItem li = new ListItem();

        //        li.Text = widget.Title;
        //        li.Value = EbSite.Control.Widget.GetWidgetCtrCoder(widget.DataID.ToString(), widget.Title);// string.Concat("<XS:Widget   WidgetID=\"", widget.ID, "\" runat=\"server\"/>");

        //        drWebPartList.Items.Add(li);
        //    }


        //    drpAllColumns.DataTextField = "Text";
        //    drpAllColumns.DataValueField = "Value";
        //    drpAllColumns.DataSource = TempFactory.Instance.GetAllColumns();
        //    drpAllColumns.DataBind();
        //}
    }
}