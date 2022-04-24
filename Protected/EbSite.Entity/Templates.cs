using System;
namespace EbSite.Entity
{
    [Serializable]
    public class TemClass
    {
        private string _ClassName;
        private int _ClassID;
        private string _PrefixName;
        /// <summary>
        /// 生成模板时默认前缀
        /// </summary>
        public string PrefixName
        {
            get
            {
                return _PrefixName;
            }
            set
            {
                _PrefixName = value;
            }
        }
        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                _ClassName = value;
            }
        }
        public int ClassID
        {
            get
            {
                return _ClassID;
            }
            set
            {
                _ClassID = value;
            }
        }
    }
    public class Templates
    {
        private string _ThemesFolder;
        public Templates(string ThemesFolder)
        {
            _ThemesFolder = ThemesFolder;
            
        }
        #region Model
        private Guid _id = Guid.Empty;
        private string _temname;
        //private string _tempath;
        private int _temtype;
        private bool _IsNoSysTem;
        private string _themes;
        private string _tempfilename;

        //private Guid _modelclassid;
        public DateTime AddDate { get; set; }
        ///// <summary>
        ///// 小杨添加 模板对应的模型的ID
        ///// </summary>
        //public Guid ModelClassID
        //{
        //    get { return _modelclassid; }
        //    set { _modelclassid = value; }
        //}
        /// <summary>
        /// 当前模板所属性的皮肤目录
        /// </summary>
        public string Themes
        {
            set { _themes = value; }
            get { return _themes; }
        }
        /// <summary>
        /// 模板文件名称
        /// </summary>
        public string TempFileName
        {
            set { _tempfilename = value; }
            get { return _tempfilename; }
        }
        public bool IsNoSysTem
        {
            set { _IsNoSysTem = value; }
            get { return _IsNoSysTem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TemName
        {
            set { _temname = value; }
            get { return _temname; }
        }

         
        public string TemPath
        {
            get
            {
                return string.Concat(Base.AppStartInit.IISPath,_ThemesFolder, "/", Themes, "/pages/", TempFileName);
            }
        }

        public string  TemFullPath
        {
            get
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(_ThemesFolder, "/", Themes, "/pages/", TempFileName));
                //return string.Concat("./", _ThemesFolder, "/", Themes, "/pages/", TempFileName);
            }
        }

        /// <summary>
        /// 0为首页类，1不分类页类，2为内容页类，3为专题面页类
        /// </summary>
        public int TemType
        {
            set { _temtype = value; }
            get { return _temtype; }
        }
        #endregion Model

    }
}

