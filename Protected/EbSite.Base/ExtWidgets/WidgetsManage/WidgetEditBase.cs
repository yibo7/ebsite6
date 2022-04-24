using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets.WidgetsManage
{
    /// <summary>
    /// 编辑部件基础类--开发时对应的edit.ascx
    /// </summary>
    public abstract class WidgetEditBase : EditBase
    {
        public WidgetEditBase()
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
        /// Gets or sets a value indicating whether [show title].
        /// </summary>
        /// <value><c>true</c> if [show title]; otherwise, <c>false</c>.</value>
        public bool ShowTitle
        {
            get { return _ShowTitle; }
            set { _ShowTitle = value; }
        }

        /// <summary>
        /// Saves this the basic widget settings such as the Title.
        /// </summary>
        //public abstract void Save();

        public virtual void Save()
        {
            if (!Equals(OnUpdateTitle, null))
            {
                OnUpdateTitle();
            }
        }
        public delegate void UpdateTitleDelegate();
        public UpdateTitleDelegate OnUpdateTitle;
        public static void ToUpdateTitle(string sID, string sTitle, ExtensionType Extensiontype)
        {
            if (!string.IsNullOrEmpty(sTitle))
            {
                if (Extensiontype==ExtensionType.HomeWidget)
                {
                    HomeWidgetManage.DataBLL.Instance.UpdataTitle(sID, sTitle);
                }
                else
                {
                    ExtWidgets.WidgetsManage.DataBLL.Instance.UpdataTitle(sID, sTitle);
                }
                
            }
                
        }
        public Guid GetBoxStyleID
        {
            get
            {
                GetSettings();
                return BoxStyleId;
            }
        }
        #region Settings


        #region 提供对列表数据的操作接口,数据将以xml保存到硬盘

        public Guid GetModifyID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["did"]))
                {
                    return new Guid(Request["did"]);
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 不让&did=重复，所以这样处理
        /// </summary>
        protected string sUrlToAdd
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["did"]))
                {
                    //"&did="
                    string[] sA = Core.Strings.GetString.SplitString(Request.RawUrl, "&did=");
                    return sA[0];
                }
                else
                {
                    return Request.RawUrl;
                }
            }
        }
        protected virtual void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Equals(e.CommandName, "modifymodel"))
            {

                string sID = e.CommandArgument.ToString();
                string sUrl = string.Concat(sUrlToAdd, "&did=", sID);

                Response.Redirect(sUrl);

            }
            else if (Equals(e.CommandName, "deletemodel"))
            {
                Delete(new Guid(e.CommandArgument.ToString()));
                Response.Redirect(sUrlToAdd);
            }
        }
        /// <summary>
        /// 是否关闭保存按钮,使用到数据表的部件，有可能要自定义添加数据按钮，这时用不上保存按钮,所以可以重写此为true来关闭
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDisabledSave()
        {
            return false;
        }

        #region 对数据表类型部件的表数据处理
        private EbSite.BLL.WidgetsDataBLL _WD;
        protected EbSite.BLL.WidgetsDataBLL WD
        {
            get
            {
                if (Equals(_WD, null))
                {
                    //string dtname = "dtname" + WidgetID;

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
            return WD.Fills();
        }
        /// <summary>
        /// 添加插入一条记录
        /// </summary>
        /// <param name="ColumnValues">记录值，注意，这里的值务必要与类初始化时的列对应</param>
        public Guid InsertData(List<string> ColumnValues)
        {
            ColumnValues.Add(DateTime.Now.ToString());
            return WD.InsertData(ColumnValues);
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataRow SelectData(Guid id)
        {
            return WD.SelectData(id);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ID">记录id</param>
        /// <param name="ColumnValues">记录值，注意，这里的值务必要与类初始化时的列对应</param>
        public void Update(Guid ID, List<string> ColumnValues)
        {
            ColumnValues.Add(DateTime.Now.ToString());
            WD.Update(ID, ColumnValues);
        }
        public void Update(Guid ID, string ColumnName, string ColumnValue)
        {
            WD.Update(ID, ColumnName, ColumnValue);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="ID"></param>
        public void Delete(Guid ID)
        {
            WD.Delete(ID);
        }
        #endregion
        
        #endregion


        #endregion




    }
}
