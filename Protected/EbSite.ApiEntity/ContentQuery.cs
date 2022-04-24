using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbSite.ApiEntity
{
    [Serializable]
    public class QueryModel
    {
        private int _SiteId = 0;

        public int SiteId
        {
            get { return _SiteId; }
            set { _SiteId = value; }
        }

        private int _PageIndex = 1;

        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        private int _PageSize = 10;

        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        private string _OrderBy;
        public string OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }

        private string _Fields;

        public string Fields
        {
            get { return _Fields; }
            set { _Fields = value; }
        }

        public List<ContentQuery> Wheres { get; set; }
    }

    [Serializable]
    public class ContentQuery
    {
        public string ColumName { get; set; }
        /// <summary>
        /// 注意，当条件为【区间】查询，这里要填写两个值，用逗号分开，当条件为【是否为空IsNull】,这里不用填写值
        /// </summary>
        /// <value>The colum value.</value>
        public object ColumValue { get; set; }

        public ContentQueryType QueryType { get; set; }

        public ContentQueryLinkType LinkType { get; set; }
    }
    [Serializable]
    public enum ContentQueryType : int
    {
        精确=0,
        模糊=1,
        区间 = 2,
        是否为空IsNull,
        不等于,
        大于,
        小于



    }

    [Serializable]
    public enum ContentQueryLinkType : int
    {

        AND = 0,
        OR = 1
    }
}
