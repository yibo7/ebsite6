using System;
using EbSite.Base.Entity;

namespace EbSite.Entity.Module
{
    /// <summary>
    /// 一个模块页面实体
    /// </summary>
    [Serializable]
    public class ModulePageInfo : XmlEntityBase<Guid>, IComparable<ModulePageInfo> 
    {
        public ModulePageInfo()
        {
            id = Guid.NewGuid();
        }
        
        private string _ParentUrl;
        private Guid _ModuleID;
        private string _FileName;
        private string _PageName;
        private Guid _ParentID;
        private int _OrderID = 0;
        private string _HelpHtml;
        private bool _IsAddToAdminMenus = false;

        private int _ThemesType = 1;//默认1为pc版
        public int ThemesType
        {
            get
            {
                return _ThemesType;
            }
            set
            {
                _ThemesType = value;
            }
        }
        public bool IsAddToAdminMenus
        {
            get
            {
                return _IsAddToAdminMenus;
            }
            set
            {
                _IsAddToAdminMenus = value;
            }
        }
        
        /// <summary>
        /// 此页面的访问权限
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// 模块ID
        /// </summary>
        public Guid ModuleID
        {
            get
            {
                return _ModuleID;
            }
            set
            {
                _ModuleID = value;
            }
        }
        /// <summary>
        /// 帮助文档
        /// </summary>
        public string HelpHtml
        {
            get
            {
                return _HelpHtml;
            }
            set
            {
                _HelpHtml = value;
            }
        }
        /// <summary>
        /// 父页面的连接地址
        /// </summary>
        public string ParentUrl
        {
            get
            {
                return _ParentUrl;
            }
            set
            {
                _ParentUrl = value;
            }
        }
        /// <summary>
        /// 文件名称,其实 是相对连接地址
        /// </summary>
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
       /// <summary>
       /// 页面名称
       /// </summary>
        public string PageName
        {
            get
            {
                return _PageName;
            }
            set
            {
                _PageName = value;
            }
        }
        /// <summary>
        /// 父亲页面的ID
        /// </summary>
        public Guid ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                _ParentID = value;
            }
        }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }
        /// <summary>
        /// 获取一个菜单的连接路径
        /// </summary>
        /// <returns></returns>
        public string GetRealUrl()
        {
            string sAspx = this.ParentUrl;
            if(Equals(this.ParentID,Guid.Empty))
            {
                sAspx = this.FileName;
                //ModuleMenu mm = new ModuleMenu(this.ModuleID);
                //List<ModulePageInfo> lstSubPages = mm.GetSubMenu(this.id);
                //if(lstSubPages.Count>0)
                //{
                //    sAspx = lstSubPages[0].p;
                //}
            }
            return string.Format("{0}?muid={2}&mid={1}", sAspx, this.ModuleID, this.id);
        }

        private bool _EnableTagLink = true;
        public bool EnableTagLink
        {
            get
            {
                return _EnableTagLink;
            }
            set
            {
                _EnableTagLink = value;
            }
        }

        ///// <summary>
        ///// 获取重写路径
        ///// </summary>
        ///// <returns></returns>
        //public  string GetReWriteUrl()
        //{
        //    return string.Format("/md{0}/{1}.ashx", this.ModuleID, this.id);
        //}
        #region 实现比较接口的CompareTo方法 按 OrderID 降序排序
        public int CompareTo(ModulePageInfo obj)
        {
            return this.OrderID.CompareTo(obj.OrderID);
        }
        #endregion


    }
}
