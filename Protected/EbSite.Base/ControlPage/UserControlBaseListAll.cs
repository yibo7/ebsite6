using System.Web;
using EbSite.BLL;
using EbSite.Base.Configs.SysConfigs;

using EbSite.Control;
using EbSite.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Base.ControlPage
{

    public abstract class UserControlBaseListAll : UserControlBase
    {
        virtual protected Guid MenuAddID
        {
            get { return Guid.Empty; }
        }
        
        protected int ListCount = 0;
        protected PagesContrl pcPage;
        protected PlaceHolder phSearchColumns;
        //搜索类型，0普通搜索，1为高级搜索
        protected int SearchType = 0;

        protected virtual object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        protected abstract bool IsListCtrNull { get; }
        protected abstract void BindSearchData();
        protected abstract void Delete(object ID);
        protected abstract void gdList_Bind();
        protected abstract object LoadList(out int iCount);
        protected virtual void CopyData(object ID)
        {
            
        }
        //YHL 2014-1-24 载入列表之前的验证
        protected virtual bool On_Loading()
        {
            return true;
        }
        /// <summary>
        /// 获取所选ID集合
        /// </summary>
        protected abstract List<string> GetSelKeys { get; }

        public UserControlBaseListAll()
        {
            //base.Load += new EventHandler(this.BasePage_Load);
        }

        protected void BasePage_Load()
        {
            if (!object.Equals(this.pcPage, null))
            {
                if (this.pcPage.PageSize==0)//在ascx设置了值后，这里将大于0,所以页面模板优先
                    this.pcPage.PageSize = this.iPageSize;
                this.pcPage.Linktype = LinkType.Aspx;
            }

            if (!base.IsPostBack && !IsListCtrNull)
            {
                if (this.IsCurrentSearch)
                {
                    if (On_Loading())
                    {
                        this.gdList_Bind();
                    }
                }
                else
                {
                    this.BindSearchData();
                }
            }
            
            
        }

        

        protected virtual string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return this.BulderSearchPram(IsValueEmpytNoSearch, this.GetSearchParameters);

        }
        /// <summary>
        /// 查询参数，可以重写，默认获取页面里的 phSearchConlumns控件里的控件集合构造参数
        /// </summary>
        protected virtual SearchParameter[] GetSearchParametersAdv
        {
            get
            {
                return new SearchParameter[0];
            }
        }
        /// <summary>
        /// 获取高级查询的sql语句
        /// </summary>
        /// <param name="IsValueEmpytNoSearch"></param>
        /// <returns></returns>
        protected virtual string BulderSearchWhereAdv(bool IsValueEmpytNoSearch)
        {
            return this.BulderSearchPram(IsValueEmpytNoSearch, this.GetSearchParametersAdv);

        }


        /// <summary>
        /// 获取查询sql语句
        /// </summary>
        /// <param name="IsValueEmpytNoSearch"></param>
        /// <returns></returns>
        private string BulderSearchPram(bool IsValueEmpytNoSearch, SearchParameter[] SParameter)
        {
            string str = "";
            StringBuilder builder = new StringBuilder();
            SearchParameter[] SearchPrm = SParameter;
            for (int i = 0; i < SearchPrm.Length; i++)
            {
                SearchParameter parameter = SearchPrm[i];
                if (!string.IsNullOrEmpty(parameter.ColumnValue) || !IsValueEmpytNoSearch)
                {
                    if (parameter.IsString)
                    {
                        if (parameter.SearchWhere == EmSearchWhere.模糊匹配)
                        {
                            builder.AppendFormat("{0} {1} '%{2}%' {3} ", new object[] { parameter.ColumnName, this.GetSearchMatch(parameter.SearchWhere), parameter.ColumnValue, this.GetSearchLink(parameter.SearchLink) });
                        }
                        else
                        {
                            builder.AppendFormat("{0} {1} '{2}' {3} ", new object[] { parameter.ColumnName, this.GetSearchMatch(parameter.SearchWhere), parameter.ColumnValue, this.GetSearchLink(parameter.SearchLink) });
                        }
                    }
                    else
                    {
                        builder.AppendFormat("{0} {1} {2} {3} ", new object[] { parameter.ColumnName, this.GetSearchMatch(parameter.SearchWhere), parameter.ColumnValue, this.GetSearchLink(parameter.SearchLink) });
                    }
                }
            }
            str = builder.ToString().Trim();
            int length = -1;
            if (str.LastIndexOf("or") > -1)
            {
                length = str.LastIndexOf("or");
                return str.Substring(0, length);
            }
            if (str.LastIndexOf("and") > -1)
            {
                length = str.LastIndexOf("and");
                str = str.Substring(0, length);
            }
            return str;
        }
        
        private string GetSearchLink(EmSearchLink en)
        {
            switch (en)
            {
                case EmSearchLink.或者or:
                    return "or";

                case EmSearchLink.与连and:
                    return "and";

                case EmSearchLink.不连用于最后一个:
                    return " ";
            }
            return "and";
        }

        private string GetSearchMatch(EmSearchWhere en)
        {
            switch (en)
            {
                case EmSearchWhere.相等匹配:
                    return "=";

                case EmSearchWhere.模糊匹配:
                    return "like";

                case EmSearchWhere.大于:
                    return ">";

                case EmSearchWhere.小于:
                    return "<";
            }
            return "=";
        }

        protected void SetWhere(string swhere)
        {
            base.Session["swhere"] = swhere;
        }

        protected string GetWhere(bool IsValueEmpytNoSearch)
        {
            string str = base.Session["swhere"] as string;
            if (string.IsNullOrEmpty(str.Trim()))
            {
                if (object.Equals(this.SearchType, 0))
                {
                    str = this.BulderSearchWhere(IsValueEmpytNoSearch);
                }
                else
                {
                    str = this.BulderSearchWhereAdv(IsValueEmpytNoSearch);
                }
                if (!string.IsNullOrEmpty(str))
                {
                    str = str + "" + this.WhereAppend;
                    base.Session["swhere"] = str;
                }
              
            }
            //HttpContext.Current.Response.Write("条件：" + str + "   当前机器：" + Core.Utils.GetServerIP());
            return str;
        }

        protected virtual void lbDeleteMore_Click(object sender, EventArgs e)
        {
            foreach (string selKey in GetSelKeys)
            {
                this.Delete(selKey);
            }
            base.Response.Redirect(base.Request.RawUrl);
        }

        protected virtual void lbSearch_Click(object sender, EventArgs e)
        {
            base.Session["swhere"] = "";
            if (!object.Equals(this.pcPage, null) && (this.pcPage.PageIndex > 1))
            {
                this.pcPage.PageIndex = 1;
            }
            this.BindSearchData();
        }
     
        protected void PageCtr_Bind(string sOrtherPram)
        {
            if (!object.Equals(this.pcPage, null))
            {
                
                this.pcPage.AllCount = this.ListCount;
                this.pcPage.OtherPram = this.GetSplitPagePram + sOrtherPram;
                //this.pcPage.CurrentClass = "Pages_Current";
                //this.pcPage.ParentClass = "PagesClass";
            }
        }
        
        protected string GetPageName
        {
            get
            {
                if (base.Request.RawUrl.IndexOf("?") > 0)
                {
                    return base.Request.RawUrl.Split(new char[] { '?' })[0];
                }
                return base.Request.RawUrl;
            }
        }

        protected Guid GetParentMenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Request["mpid"]))
                {
                    return new Guid(base.Request["mpid"]);
                }
                return Guid.Empty;
            }
        }

        /// <summary>
        /// 查询参数，可以重写，默认获取页面里的 phSearchConlumns控件里的控件集合构造参数
        /// </summary>
        protected virtual SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> list = new List<SearchParameter>();
                if (!object.Equals(this.phSearchColumns, null))
                {
                    foreach (System.Web.UI.Control control in this.phSearchColumns.Controls)
                    {
                        if (!object.Equals(control.ID, null))
                        {
                            string iD = control.ID;
                            string valueFromControl = Utils.GetValueFromControl(control);
                            SearchParameter item = new SearchParameter();
                            item.ColumnName = iD;
                            item.ColumnValue = valueFromControl;
                            item.IsString = true;
                            item.SearchLink = EmSearchLink.与连and;
                            item.SearchWhere = EmSearchWhere.相等匹配;
                            list.Add(item);
                        }
                    }
                }
                return list.ToArray();
            }
        }
        /// <summary>
        /// 分页参数，可以重写
        /// </summary>
        protected virtual string GetSplitPagePram
        {
            get
            {
                string str = "";
                if (base.PageType > -1)
                {
                    str = string.Format("t,{0}", base.PageType);
                }
                else
                {
                    str = string.Format("msid,{0}|mpid,{1}", this.GetSubMenuID, this.GetParentMenuID);
                }
                if (this.GetSubPageType > 0)
                {
                    str = str + "|st," + this.GetSubPageType;
                }
                return str;
            }
        }
        protected virtual string GetUrl
        {
            get
            {

                return string.Format("{0}?mpid={1}&msid={2}", this.GetPageName, this.GetParentMenuID, this.GetSubMenuID);
            }
        }
        
        protected Guid GetSubMenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Request["msid"]))
                {
                    return new Guid(base.Request["msid"]);
                }
                return Guid.Empty;
            }
        }

        protected int GetSubPageType
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Request["st"]))
                {
                    return int.Parse(base.Request["st"]);
                }
                return 0;
            }
        }

       

        virtual protected int iPageSize
        {
            get
            {
                return 20;
            }
        }
        /// <summary>
        /// 当前是否非搜索,返回true为不是搜索,返回否
        /// </summary>
        protected bool IsCurrentSearch
        {
            get
            {
                return string.IsNullOrEmpty(base.Request["qt"]);
            }
        }

        protected virtual string WhereAppend
        {
            get
            {
                return "";
            }
        }
    }

    

    
}
