
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Base.Static.BatchCreatManager;

namespace EbSite.Base.Configs.HtmlConfigs
{
    /// <summary>
    /// 生成静态页面 配置文件实体类
    /// </summary>
    public class MakeHtmlInfo 
    {
        private HtmlMakeType _MakeType;
        /// <summary>
        /// 生成类别
        /// </summary>
        public HtmlMakeType MakeType
        {
            get
            {
                return _MakeType;
            }
            set
            {
                _MakeType = value;
            }
        }
        private int _StarID;
        /// <summary>
        /// 开始ID;
        /// </summary>
        public int StarID
        {
            get
            {
                return _StarID;
            }
            set
            {
                _StarID = value;
            }
        }
        private int _EndID;
        /// <summary>
        /// 开始ID;
        /// </summary>
        public int EndID
        {
            get
            {
                return _EndID;
            }
            set
            {
                _EndID = value;
            }
        }
        private int _CurrentPageIndex = 1;
        /// <summary>
        /// 获取当前页码 IIS回收时记录日志用 像内容页这样的没有分页用不到
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                return _CurrentPageIndex;
            }
            set
            {
                _CurrentPageIndex = value;
            }
        }
    }
}
