using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using EbSite.Core;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetCount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int iID = Utils.GetInt("id", -1);

            int cID = Utils.GetInt("cid", -1);//YHL 2014-2-11

            //it为0时，表示获取hits,1时表示获取dayhits,2时表示获取weekhits,3时表示获取mothhits,4FavorableNum,5时表示获取Advs,6CommentNum
            int it = Utils.GetInt("t", -1);

            if (iID > 0 && it > -1 && cID > 0)
            {
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(cID);

                EbSite.Entity.NewsContent model = NewsContentInst.GetModel(iID, 1); //这里的站点ID不能写死

                int num = 0;

                if (it == 0)  //总点击
                {
                    num = model.hits;
                }
                else if (it == 1) //天点击
                {
                    num = model.dayHits;
                }
                else if (it == 2) //周点击
                {
                    num = model.weekHits;
                }
                else if (it == 3) //月点击
                {
                    num = model.weekHits;
                }
                else if (it == 4) //好评
                {
                    num = model.FavorableNum;
                }
                else if (it == 5) //收藏数
                {
                    num = model.Advs;
                }
                else if (it == 6) //评论数
                {
                    num = model.CommentNum;
                }

                context.Response.Write(string.Format("document.write('{0}');", num));
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
