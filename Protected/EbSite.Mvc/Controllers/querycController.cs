using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using EbSite.ApiEntity;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Entity;
using EbSite.Mvc.Filters;
namespace EbSite.Mvc.Controllers
{
    /*
    编写api要注意：就算方法名一名，但参数变量的命名也不能一样，否则出错
    如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
    方法名称前如果包含get将只能使用get调用，默认post
        */
    [RoutePrefix("queryc")]
    public class querycController : ApiBaseController
    {
        public ApiMessage<int> ebbb(string msguu)
        {
            return new ApiMessage<int>() { Success = true, Data = 11111, Message = "accccc：" + msguu };

        }



        [HttpPost]
        public ContentQueryRezult loadlist(QueryModel qs)
        {

           

            //return new ApiMessage<int>() { Success = true, Data = 11111, Message = "ebtest成功返回" };

            NewsContentSplitTable bll = EbSite.Base.AppStartInit.NewsContentInstDefault;

            StringBuilder sbWhere = new StringBuilder();
            if (!Equals(qs.Wheres, null))
            {
                int iIndex = 0;
                foreach (ContentQuery q in qs.Wheres)
                {
                    iIndex++;
                    if (q.QueryType == ContentQueryType.精确)
                    {
                        Type t = q.ColumValue.GetType();

                        if (Equals(t, typeof(string)) || Equals(t, typeof(Guid)))
                        {
                            sbWhere.AppendFormat("{0}='{1}'", q.ColumName, q.ColumValue);
                        }
                        else
                        {
                            sbWhere.AppendFormat("{0}={1}", q.ColumName, q.ColumValue);
                        }


                    }
                    else if (q.QueryType == ContentQueryType.模糊)
                    {
                        sbWhere.AppendFormat("{0} LIKE '%{1}%'", q.ColumName, q.ColumValue);
                    }
                    else if (q.QueryType == ContentQueryType.区间)
                    {
                        string[] vls = q.ColumValue.ToString().Split(',');
                        if (vls.Length == 2)
                            sbWhere.AppendFormat("{0} BETWEEN '{1}' and '{2}'", q.ColumName, vls[0], vls[1]);
                    }
                    else if (q.QueryType == ContentQueryType.不等于)
                    {
                        Type t = q.ColumValue.GetType();

                        if (Equals(t, typeof(string)) || Equals(t, typeof(Guid)))
                        {
                            sbWhere.AppendFormat("{0}<>'{1}'", q.ColumName, q.ColumValue);
                        }
                        else
                        {
                            sbWhere.AppendFormat("{0}<>{1}", q.ColumName, q.ColumValue);
                        }


                    }
                    else if (q.QueryType == ContentQueryType.是否为空IsNull)
                    {
                        sbWhere.AppendFormat("{0} is NULL", q.ColumName);

                    }
                    else if (q.QueryType == ContentQueryType.大于)
                    {
                        Type t = q.ColumValue.GetType();
                        if (Equals(t, typeof(string)))
                        {
                            sbWhere.AppendFormat("{0}>'{1}'", q.ColumName, q.ColumValue);
                        }
                        else
                        {
                            sbWhere.AppendFormat("{0}>{1}", q.ColumName, q.ColumValue);
                        }

                    }
                    else if (q.QueryType == ContentQueryType.小于)
                    {
                        Type t = q.ColumValue.GetType();
                        if (Equals(t, typeof(string)))
                        {
                            sbWhere.AppendFormat("{0}<'{1}'", q.ColumName, q.ColumValue);
                        }
                        else
                        {
                            sbWhere.AppendFormat("{0}<{1}", q.ColumName, q.ColumValue);
                        }

                    }

                    if (iIndex < qs.Wheres.Count)
                    {
                        if (q.LinkType == ContentQueryLinkType.AND)
                        {
                            sbWhere.Append(" AND ");
                        }
                        else if (q.LinkType == ContentQueryLinkType.OR)
                        {
                            sbWhere.Append(" OR ");
                        }
                    }


                }
            }
             

            int iCount = 0;
            List<ApiEntity.Content> rzData = ToApiContentList(bll.GetListPages(qs.PageIndex,qs.PageSize, sbWhere.ToString(), qs.OrderBy,out iCount,null, qs.SiteId));

            //List<ApiEntity.Content> rz = ToApiContentList(bll.GetListArray(sbWhere.ToString(), qs.PageSize, qs.OrderBy, qs.Fields, qs.SiteId));
            ContentQueryRezult rz = new ContentQueryRezult();
            rz.Count = iCount;
            rz.Data = rzData;
            return rz;




        }

         


    }
}
