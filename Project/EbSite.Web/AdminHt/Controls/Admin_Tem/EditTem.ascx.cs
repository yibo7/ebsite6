using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Core.FSO;
using EbSite.Entity;
using Templates = EbSite.Entity.Templates;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    public partial class EditTem : BaseAdd
    {
        public override string Permission
        {
            get
            {
                return "97";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        protected override bool IsSaveCloseWinBox
        {
            get
            {
                return false;
            }
        }
        public override string PageName
        {
            get
            {
                return "编辑模板";
            }
        }
        override protected void InitModifyCtr()
        {

            //Entity.Templates model = TempFactory.Instance.GetModelByCache(new Guid(SID));
            Entity.Templates model = TemBll.GetModelByCache(new Guid(SID),GetSiteID);

            //读取模板信息
            string sTemHtml = FObject.ReadFile(model.TemFullPath);
            txtTem.Text = sTemHtml;

            //BindColumns(model.TemType);

            //BindWebPartList();
            //BindIncList();
            //BindOtherLink();
        }
        override protected void SaveModel()
        {
            //Entity.Templates model = TempFactory.Instance.GetModelByCache(new Guid(SID));
            Entity.Templates model = TemBll.GetModelByCache(new Guid(SID), GetSiteID);
            

            string sTemHtml = txtTem.Text;
            FObject.WriteFile(Server.MapPath(model.TemPath), sTemHtml);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //ctbTag.EndLiteral = llTagEnd;
            //ctbTag.Items = "部件与公共模块#tg1|字段调用#tg2|连接调用#tg3|函数调用#tg4";

            SelTempFields9.CurrentThemeName = base.CurrentThemeName;
            SelTempFields9.ThemesType = base.ThemesType;
        }

        ///// <summary>
        ///// 以当前模板类别，绑定对应的模型
        ///// </summary>
        ///// <param name="TemType"> 0为首页类，1分类页类，2为内容页类，3为专题面页类</param>
        //private void BindColumns(int TemType)
        //{
        //    //Entity.Templates model = TempFactory.Instance.GetModelByCache(new Guid(SID));

        //    Entity.Templates model = TemBll.GetModelByCache(new Guid(SID),GetSiteID);

        //    drpAllColumns.DataTextField = "Text";
        //    drpAllColumns.DataValueField = "Value";
        //    drpAllColumns.DataSource = TemBll.GetAllColumns();// TempFactory.Instance.GetAllColumns();
        //    drpAllColumns.DataBind();
        //    //switch (TemType)
        //    //{
        //    //    case 0://首页类
        //    //        //drpModels.Enabled = false;
        //    //        ClassColumns.Visible = false;
        //    //        ContentColumns.Visible = false;
        //    //        drpClassColumns.Enabled = false;
        //    //        drpContentColumns.Enabled = false;
        //    //        break;
        //    //    case 1://分类页类
        //    //        drpClassColumns.DataTextField = "Text";
        //    //        drpClassColumns.DataValueField = "Value";
        //    //        drpClassColumns.DataSource =TemBll.GetClassColumns(model.ModelClassID);// TempFactory.Instance.GetClassColumns(model.ModelClassID);
        //    //        drpClassColumns.DataBind();
        //    //        drpContentColumns.DataTextField = "Text";
        //    //        drpContentColumns.DataValueField = "Value";
        //    //        //yhl 于2012-02-06 操作 原因给分类模板选好模型后，不能一起搞定插入内容字段列表
        //    //        //drpContentColumns.DataSource = BLL.Templates.GetContentColumnsForList(model.ModelClassID);
        //    //        drpContentColumns.DataSource =TemBll.GetContentColumnsForList(Guid.Empty);// TempFactory.Instance.GetContentColumnsForList(Guid.Empty);
        //    //        drpContentColumns.DataBind();

        //    //        drpContentColumns.HintInfo = "当前模板为分类模板，所以调用这里的字段要在列表控件（rpGetClassList）的ItemTemplate里调用，否则会出错";

        //    //        break;
        //    //    case 2://内容页类
        //    //        drpContentColumns.DataTextField = "Text";
        //    //        drpContentColumns.DataValueField = "Value";
        //    //        drpContentColumns.DataSource = TemBll.GetContentColumns(model.ModelClassID);// TempFactory.Instance.GetContentColumns(model.ModelClassID);
        //    //        drpContentColumns.DataBind();

        //    //        ClassColumns.Visible = false;
        //    //        drpClassColumns.Visible = false;
        //    //        break;
        //    //    case 3://专题面页类
        //    //        //drpModels.Enabled = false;
        //    //        drpClassColumns.DataTextField = "Text";
        //    //        drpClassColumns.DataValueField = "Value";
        //    //        drpClassColumns.DataSource =TemBll.GetSpecialColumns();// TempFactory.Instance.GetSpecialColumns();
        //    //        drpClassColumns.DataBind();
        //    //        drpContentColumns.DataTextField = "Text";
        //    //        drpContentColumns.DataValueField = "Value";
        //    //        drpContentColumns.DataSource =TemBll.GetContentColumnsForList(model.ModelClassID);// TempFactory.Instance.GetContentColumnsForList(model.ModelClassID);
        //    //        drpContentColumns.DataBind();

        //    //        drpContentColumns.HintInfo = "当前模板为专题类，所以调用这里的字段要在列表控件（rpSpecialList）的ItemTemplate里调用，否则会出错";

        //    //        break;


        //    //}
        //}
        //private void BindOtherLink()
        //{
        //    ListItem li = new ListItem("标签列表连接", "<a href=\"<%=HostApi.TagsList(1) %>\" >所有标签</a>");
        //    drpOtherLink.Items.Add(li);

        //    li = new ListItem("在线用户列表", string.Format("<a href=\"{0}u/useronline.aspx %>\" >在线用户</a>",Base.AppStartInit.IISPath));
        //    drpOtherLink.Items.Add(li);
        //}
        ///// <summary>
        ///// 绑定部件
        ///// </summary>
        //private void BindWebPartList()
        //{
        //    List<Entity.WidgetShow> lst = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList();//WidgetUtils.GetWidgetsList(WidgetUtils.ZoneName);)

        //    foreach (WidgetShow widget in lst)
        //    {
        //        ListItem li = new ListItem();

        //        li.Text = widget.Title;
        //        li.Value = EbSite.Control.Widget.GetWidgetCtrCoder(widget.DataID.ToString(), widget.Title);// string.Concat("<XS:Widget   WidgetID=\"", widget.ID, "\" runat=\"server\"/>");

        //        drWebPartList.Items.Add(li);
        //    }
        //}
        //private void BindIncList()
        //{

        //    //List<Entity.Templates> lst = BLL.TemplateInc.IncsList;
        //    List<Entity.Templates> lst = TemBll.IncBll.IncsList;
            

        //    foreach (Templates md in lst)
        //    {
        //        ListItem li = new ListItem();

        //        li.Text = md.TemName;
        //        li.Value = string.Format("<!--#include file=\"{0}\" -->", md.TemPath);

        //        drpIncs.Items.Add(li);
        //    }
        //}

        

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