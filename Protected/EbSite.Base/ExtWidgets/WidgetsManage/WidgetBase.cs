using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Threading;
using System.Web.UI;
using EbSite.BLL;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets.WidgetsManage
{
    /// <summary>
    /// 前台显示控件基础类--开发时对应的 widget.ascx
    /// </summary>
    public abstract class WidgetBase : ExtWidgets.ShowBase
    {
        virtual public string CacheKey
        {
            get
            {
                return string.Empty;
            }
        }
        public WidgetBase()
        {
            base.Extensiontype = ExtensionType.Widget;
            

        }

       
        //public override ExtensionType ExtensionTp
        //{
        //    get
        //    {
        //        return ExtensionType.Widget;
        //    }
        //}

        private bool _ShowTitle;
        /// <summary>
        /// 是否显示标题，目前没用到，以后做为可视化时使用
        /// </summary>
        /// <value><c>true</c> if [show title]; otherwise, <c>false</c>.</value>
        public bool ShowTitle
        {
            get { return _ShowTitle; }
            set { _ShowTitle = value; }
        }

      

        private string _Zone;
        /// <summary>
        /// 控件列表
        /// </summary>
        public string Zone
        {
            get { return _Zone; }
            set { _Zone = value; }
        }

        /// <summary>
        /// 部件在前端是否可以编辑
        /// <remarks>
        /// The only way a widget can be editable is by adding a edit.ascx file to the widget folder.
        /// </remarks>
        /// </summary>
        public abstract bool IsEditable { get; }



        /// <summary>
        /// 是否显示头部
        /// </summary>
        /// <value><c>true</c> if the header is visible; otherwise, <c>false</c>.</value>
        public virtual bool DisplayHeader
        {
            get { return true; }
        }
        /// <summary>
        /// 在空间部件里设置连接
        /// </summary>
        public virtual string TitleLink
        {
            get { return ""; }
        }


        //private string _WidgetType;
        ///// <summary>
        ///// 部件的控件类型，一样是供给可移动式模板使用(编辑时)
        ///// </summary>
        //public string WidgetType
        //{
        //    get { return _WidgetType; }
        //    set { _WidgetType = value; }
        //}

        #region 提供对列表数据的操作接口,数据将以xml保存到硬盘

        private EbSite.BLL.WidgetsDataBLL _WD;
        private EbSite.BLL.WidgetsDataBLL WD
        {
            get
            {
                if (Equals(_WD, null))
                {
                    _WD = new WidgetsDataBLL(InitColumns(), DataID.ToString());

                }
                return _WD;
            }
        }
        public virtual List<string> InitColumns()
        {
            return new List<string>();
        }
        public DataTable GetSettingsTable()
        {
            if (DataID == Guid.Empty) return null;
            DataTable dt =  WD.Fills();
            dt.DefaultView.Sort = "AddDate";
            return dt;
        }
         
        /// <summary>
        /// 可以让调用的页面传入参数
        /// </summary>
        /// <value>The pram.</value>
        public string Pram { get; set; }

        //public  DataTable GetSettingsTable(Guid ID)
        //{

        //    BLL.WidgetsDataBLL bllWD = new WidgetsDataBLL(InitColumns(), ID.ToString());

        //    if (ID == Guid.Empty) return null;
        //    return bllWD.Fills();
        //}

        //public DataRow GetSettingsRow(string wdID, string rID)
        //{
        //    DataTable dt = GetSettingsTable(new Guid(wdID));

        //   DataRow[] rows =  dt.Select(string.Concat("id='", rID,"'"));

        //    if(rows.Length>0)
        //    {
        //        return rows[0];
        //    }
        //    return null;
        //}

        #endregion

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter"></see> 
        /// object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"></see> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(Name))
                throw new NullReferenceException("名字不能为空!");
            base.Render(writer);

            //StringBuilder sb = new StringBuilder();

            //sb.Append("<div class=\"widget " + this.Name.Replace(" ", string.Empty).ToLowerInvariant() + "\" id=\"widget" + WidgetID + "\">");

            //********如果有系统管理权限将输出以下*********************************
            //if (Thread.CurrentPrincipal.IsInRole(BlogSettings.Instance.AdministratorRole))
            //{

            //    sb.Append("<a class=\"delete\" href=\"javascript:void(0)\" onclick=\"BlogEngine.widgetAdmin.removeWidget('" + WidgetID + "');return false\" title=\"" + Resources.labels.delete + " widget\">X</a>");
            //    //if (IsEditable)
            //        sb.Append("<a class=\"edit\" href=\"javascript:void(0)\" onclick=\"BlogEngine.widgetAdmin.editWidget('" + Name + "', '" + WidgetID + "');return false\" title=\"" + Resources.labels.edit + " widget\">" + Resources.labels.edit + "</a>");
            //        sb.Append("<a class=\"move\" href=\"javascript:void(0)\" onclick=\"BlogEngine.widgetAdmin.initiateMoveWidget('" + WidgetID + "');return false\" title=\"" + Resources.labels.move + " widget\">" + Resources.labels.move + "</a>");
            //}
            //**********************************************************************
            //if (ShowTitle)
            //    sb.Append("<h4>" + Title + "</h4>");
            //else
            //    sb.Append("<br />");

            //sb.Append("<div class=\"content\">");

            //writer.Write(sb.ToString());
            //输出控件内容
            //base.Render(writer);

            //    writer.Write("</div>");
            //    writer.Write("</div>");
        }
    }
}
