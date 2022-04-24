using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Core.Resource;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Menus 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Menus : Base.Entity.EntityBase<Menus, Guid>
    {
        public Menus()
        {
            base.CurrentModel = this;
        }
        public Menus(Guid ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }

        protected override EbSite.Base.BLL.BllBase<Menus, Guid> Bll()
        {
             
                return BLL.Menus.Instance;
           

        }
        #region Model
        private Guid _id;
        private string _menuname;
        private string _imageurl;
        private int? _orderid;
        private Guid _parentid;
        private string _permissionid;
        private string _target;
        private string _ctrpath;
        private string _pageurl;
        private DateTime? _addtime;
    
        private bool _isleftparent;
        private Guid _modulesid;
        private string _help;
        private int _siteid;

        public  int SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MenuName
        {
            set { _menuname = value; }
            get
            {
                return _menuname;
            }
        }
        public string MenuNameResource
        {
            set { _menuname = value; }
            get
            {

                string sN = Exchanger.ResourceExchanger.GetResource(ResoureKey);
                if (!string.IsNullOrEmpty(sN))
                    return sN;
                return _menuname;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageUrl
        {
            set { _imageurl = value; }
            get { return _imageurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PermissionID
        {
            set { _permissionid = value; }
            get { return _permissionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Target
        {
            set { _target = value; }
            get { return _target; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CtrPath
        {
            set { _ctrpath = value; }
            get { return _ctrpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PageUrl
        {
            set { _pageurl = value; }
            get { return _pageurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public bool IsLeftParent
        {
            set { _isleftparent = value; }
            get { return _isleftparent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ModulesID
        {
            set { _modulesid = value; }
            get { return _modulesid; }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public string help
        {
            set { _help = value; }
            get { return _help; }
        }

        

        #endregion Model
        public string ResoureKey
        {
            get
            {
                
                string[] ids = id.ToString().Split('-');
                if (ids.Length > 0) return string.Concat("Menu",ids[0]);
                return OrderID.ToString();
            }
        }
        public string Url// GetFullUrl
        {
            get
            {
                if (!this.PageUrl.StartsWith("http://"))
                {
                    if (this.ModulesID == Guid.Empty)
                    {
                        if (this.PageUrl.IndexOf("?") > -1)
                        {
                            return string.Concat(Base.AppStartInit.AdminPath, this.PageUrl, "&mpid=", this.ParentID, "&msid=", this.id);
                        }
                        else
                        {
                            return string.Concat(Base.AppStartInit.AdminPath, this.PageUrl, "?mpid=", this.ParentID, "&msid=", this.id);
                        }
                    }
                    else  //模块url
                    {
                        return this.PageUrl;
                    }
                }
                else
                {
                    return this.PageUrl;
                }
                


            }
        }

        public string ImageurlShow
        {
            get
            {
                if (EbSite.Base.Host.Instance.IISPath.Equals("/"))
                    return ImageUrl;
                else
                {
                    return string.Format("{0}{1}", EbSite.Base.Host.Instance.IISPath, ImageUrl.Remove(0,1));
                }
            }
        }
        public override bool Equals(object obj)
        {
            Menus m = obj as Menus;
            if (this.id == m.id)
            {
                return true;
            }
            return false;
        }

    }
}
