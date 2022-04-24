using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Control.xsPage;

namespace EbSite.Control
{
    [
        DefaultProperty("Text"),
        ToolboxData("<{0}:GridView runat=server></{0}:GridView>")
    ]
    public class GridView : System.Web.UI.WebControls.GridView
    {
        //Stopwatch test = new Stopwatch();
        public GridView()
            : base()
        {
            
            //test.Start();
            //base.HeaderStyle.CssClass = "GridViewHeader";
            this.CssClass = "table m-0";
            //base.RowCreated += new GridViewRowEventHandler(this.gvGrid_RowCreated);
            //base.AlternatingRowStyle.CssClass = "AlternatingRow";
            //base.AlternatingRowStyle.BorderWidth = 0;
            base.CellSpacing = 0;
            base.GridLines = GridLines.None;
            base.BorderStyle = BorderStyle.None;
            //设置没有数据模板
            EmptyDataTemplate x = new EmptyDataTemplate(DataControlRowType.EmptyDataRow);
            base.EmptyDataTemplate = x;
            

        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (!Equals(this.Page,null))
            {
                this.Page.VerifyRenderingInServerForm(this);
            }
            this.PrepareControlHierarchy();
            this.RenderContents(writer);
        }
        //private void MPage_Load(object sender, EventArgs e)
        //{
        //    HttpContext.Current.Response.Write(test.ElapsedMilliseconds);
        //}

        //[Bindable(true), Category("Appearance"), DefaultValue("")]
        //public bool IsShowSWPages
        //{
        //    get
        //    {
        //        if (base.ViewState["IsShowSWPages"] != null)
        //        {
        //            return (bool)base.ViewState["IsShowSWPages"];
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    set
        //    {
        //        base.ViewState["IsShowSWPages"] = value;
        //    }
        //}

        //private int _AllCount = 0;
        //public int XSDataCount
        //{
        //    set
        //    {
        //        _AllCount = value;
        //    }
        //}
        //private void gvGrid_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes.Add("onmouseover", "this.className='GridMouseOver'");
        //        e.Row.Attributes.Add("onmouseout", "if(this.style.borderWidth=='')this.className='';else this.className='AlternatingRow'");
        //    }
        //}
        //public int XSPageIndex
        //{
        //    get
        //    {
        //        return pg.PageIndex;
        //    }
        //}
        //public int XSPageSize
        //{
        //    get
        //    {
        //        return 20; //配置文件里设置
        //    }
        //}

        //private string _XSPagePram;
        //public string XSPagePram
        //{
        //    set
        //    {
        //        _XSPagePram = value;
        //    }
        //}
        //protected PagesContrl pg = new PagesContrl();

        //protected override void CreateChildControls()
        //{
        //    if (IsShowSWPages)
        //    {
        //        pg.PageSize = XSPageSize;
        //        pg.AllCount = _AllCount;
        //        pg.OtherPram = _XSPagePram;
        //        pg.CssClass = "admin_page";
        //        pg.CurrentClass = "admin_page_current";
        //        pg.ParentClass = "admin_page_parent";
        //        Controls.Add(pg);
        //    }

        //}

        //protected override void Render(HtmlTextWriter output)
        //{
        //    base.Render(output);
        //    if (IsShowSWPages)
        //        pg.RenderControl(output);

        //}
    }

    /// <summary>
    /// 定义没有数据的模板
    /// </summary>
    public class EmptyDataTemplate : ITemplate
    {
        private DataControlRowType templateType;
        public EmptyDataTemplate(DataControlRowType type)
        {
            templateType = type;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            switch (templateType)
            {
                case DataControlRowType.EmptyDataRow:
                    Label lc = new Label();
                    lc.ForeColor = System.Drawing.Color.Red;
                    lc.Text = "没有相关数据!";
                    container.Controls.Add(lc);
                    break;
                default:
                    break;
            }
        }
    }
     
}
