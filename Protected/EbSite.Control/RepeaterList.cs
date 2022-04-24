using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace EbSite.Control
{
    public enum EContentOrderBy:int
    {
        默认排序=0,
        HitsDESC=1,
        AdvsDESC=2,
        CommentNumDESC=3,
        FavorableNumDESC=4,
        AddTimeDESC = 5
    }
    
    /// <summary>
    /// Repeater 控件。
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:RepeaterList runat=server></{0}:RepeaterList>")]
    public class RepeaterList : System.Web.UI.WebControls.Repeater
    { /// <summary>
        /// 父分类ID,如果不设置，将默认使用当前分类ID
        /// </summary>
        public int ParentClassID { get; set; }
        /// <summary>
        /// 是否只载入分类，列表为分类
        /// </summary>
        public bool IsDataFromClass { get; set; }
        /// <summary>
        /// 模型ID，如果转入模型ID，将会只调用这个模型下的分类数据,目前只对rpGetSubClassList控件起作用
        /// </summary>
        public Guid ModelID { get; set; }

        private EContentOrderBy _OrderBy = EContentOrderBy.默认排序;
        public EContentOrderBy OrderBy 
        { 
            get
            {
                return _OrderBy;
            } 
            set
            {
                _OrderBy = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public RepeaterList()
            : base()
        {

        }

        

    }
}