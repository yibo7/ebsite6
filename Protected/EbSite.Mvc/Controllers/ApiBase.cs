using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.SessionState;
using EbSite.ApiEntity;
using EbSite.Base;
using EbSite.BLL;
using EbSite.Entity;
using EbSite.Mvc.Token;

namespace EbSite.Mvc.Controllers
{
    /// <summary>
    /// 所有继承了此类实现的api在不自定义roue的情况下，都应该加上/api/类名前缀来访问
    /// </summary>
    public class ApiBaseController : ApiController, IRequiresSessionState
    {
       
        public ApiBaseController()
        {
            
        }

        protected List<ApiEntity.Content>  ToApiContentList(List<Entity.NewsContent> models)
        {
            List<ApiEntity.Content> newlist = new List<Content>();
            foreach (var m in models)
            {
                newlist.Add(ToApiContent(m));
            }
            return newlist;
        }

        protected ApiEntity.Content ToApiContent(Entity.NewsContent model)
        {

            ApiEntity.Content newmodel = new Content();
            if (!Equals(model, null))
            {
                newmodel.ID = model.ID;
                newmodel.NumberTime = model.NumberTime;
                newmodel.RandNum = model.RandNum;
                newmodel.SiteID = model.SiteID;
                newmodel.UserID = model.UserID;
                newmodel.Advs = model.Advs;
                newmodel.IsAuditing = model.IsAuditing;
                newmodel.ClassName = model.ClassName;
                newmodel.SmallPic = model.SmallPic;
                newmodel.NewsTitle = model.NewsTitle;
                newmodel.TitleStyle = model.TitleStyle;
                newmodel.ClassID = model.ClassID;
                newmodel.hits = model.hits;
                newmodel.IsGood = model.IsGood;
                newmodel.ContentInfo = model.ContentInfo;
                newmodel.dayHits = model.dayHits;
                newmodel.weekHits = model.weekHits;
                newmodel.monthhits = model.monthhits;
                newmodel.lasthitstime = model.lasthitstime;
                newmodel.TagIDs = model.TagIDs;
                newmodel.OrderID = model.OrderID;
                newmodel.HtmlName = model.HtmlName;
                newmodel.ContentHtmlNameRule = model.ContentHtmlNameRule;
                newmodel.MarkIsMakeHtml = model.MarkIsMakeHtml;
                newmodel.IsComment = model.IsComment;
                newmodel.UserName = model.UserName;
                newmodel.Annex1 = model.Annex1;
                newmodel.Annex2 = model.Annex2;
                newmodel.Annex3 = model.Annex3;
                newmodel.Annex4 = model.Annex4;
                newmodel.Annex5 = model.Annex5;
                newmodel.Annex6 = model.Annex6;
                newmodel.Annex7 = model.Annex7;
                newmodel.Annex8 = model.Annex8;
                newmodel.Annex9 = model.Annex9;
                newmodel.Annex10 = model.Annex10;
                newmodel.Annex11 = model.Annex11;
                newmodel.Annex12 = model.Annex12;
                newmodel.Annex13 = model.Annex13;
                newmodel.Annex14 = model.Annex14;
                newmodel.Annex15 = model.Annex15;
                newmodel.Annex16 = model.Annex16;
                newmodel.Annex17 = model.Annex17;
                newmodel.Annex18 = model.Annex18;
                newmodel.Annex19 = model.Annex19;
                newmodel.Annex20 = model.Annex20;
                newmodel.Annex21 = model.Annex21;
                newmodel.Annex22 = model.Annex22;
                newmodel.Annex23 = model.Annex23;
                newmodel.Annex24 = model.Annex24;
                newmodel.Annex25 = model.Annex25;
                newmodel.CommentNum = model.CommentNum;
                newmodel.FavorableNum = model.FavorableNum;
            }
            

            return newmodel;
        }

         

        protected Entity.NewsContent ToNewsContent(ApiEntity.Content model)
        {
            Entity.NewsContent newmodel = new Entity.NewsContent();
            if (!Equals(model, null))
            {
                newmodel.ID = model.ID;
                newmodel.NumberTime = model.NumberTime;
                newmodel.RandNum = model.RandNum;
                newmodel.SiteID = model.SiteID;
                newmodel.UserID = model.UserID;
                newmodel.Advs = model.Advs;
                if(model.IsAuditing!=null)
                    newmodel.IsAuditing = (bool)model.IsAuditing;
                newmodel.ClassName = model.ClassName;
                newmodel.SmallPic = model.SmallPic;
                newmodel.NewsTitle = model.NewsTitle;
                newmodel.TitleStyle = model.TitleStyle;
                newmodel.ClassID = model.ClassID;
                newmodel.hits = model.hits;
                if (model.IsGood != null)
                    newmodel.IsGood =(bool) model.IsGood;
                newmodel.ContentInfo = model.ContentInfo;
                newmodel.dayHits = model.dayHits;
                newmodel.weekHits = model.weekHits;
                newmodel.monthhits = model.monthhits;
                if (model.lasthitstime != null)
                    newmodel.lasthitstime =(DateTime) model.lasthitstime;
                newmodel.TagIDs = model.TagIDs;
                newmodel.OrderID = model.OrderID;
                newmodel.HtmlName = model.HtmlName;
                newmodel.ContentHtmlNameRule = model.ContentHtmlNameRule;
                newmodel.MarkIsMakeHtml = model.MarkIsMakeHtml;
                newmodel.IsComment = model.IsComment;
                newmodel.UserName = model.UserName;
                newmodel.Annex1 = model.Annex1;
                newmodel.Annex2 = model.Annex2;
                newmodel.Annex3 = model.Annex3;
                newmodel.Annex4 = model.Annex4;
                newmodel.Annex5 = model.Annex5;
                newmodel.Annex6 = model.Annex6;
                newmodel.Annex7 = model.Annex7;
                newmodel.Annex8 = model.Annex8;
                newmodel.Annex9 = model.Annex9;
                newmodel.Annex10 = model.Annex10;
                newmodel.Annex11 = model.Annex11;
                newmodel.Annex12 = model.Annex12;
                newmodel.Annex13 = model.Annex13;
                newmodel.Annex14 = model.Annex14;
                newmodel.Annex15 = model.Annex15;
                newmodel.Annex16 = model.Annex16;
                newmodel.Annex17 = model.Annex17;
                newmodel.Annex18 = model.Annex18;
                newmodel.Annex19 = model.Annex19;
                newmodel.Annex20 = model.Annex20;
                newmodel.Annex21 = model.Annex21;
                newmodel.Annex22 = model.Annex22;
                newmodel.Annex23 = model.Annex23;
                newmodel.Annex24 = model.Annex24;
                newmodel.Annex25 = model.Annex25;
                newmodel.CommentNum = model.CommentNum;
                newmodel.FavorableNum = model.FavorableNum;
            }
            
            return newmodel;
        }
        
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        
        /// <summary>
        /// 站点域名
        /// </summary>
        protected string DomainName
        {
            get
            {
                return AppStartInit.DomainName;
            }
        }

        /// <summary>
        /// 网站安装目录
        /// </summary>
        protected static string IISPath
        {
            get
            {
                return EbSite.Base.AppStartInit.IISPath;
            }
        }

        protected EbIdentity UserToken
        {
            get
            {
                EbIdentity _BMUser;
                if (!Equals(User, null))
                {
                    //string u = User.Identity.Name;

                    _BMUser = User.Identity as EbIdentity;
                    if (Equals(_BMUser, null))
                        _BMUser = new EbIdentity();
                }
                else
                {
                    _BMUser = new EbIdentity();
                }
                return _BMUser;
            }
        }

        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id,暂时用字符串型,原本 int</param>
        /// <returns></returns>
        protected virtual bool IsHaveLimit(string LimitID)
        {
            if (!Equals(UserToken, null))
            {
                AdminPrincipal user = AdminPrincipal.ValidateLogin(UserToken.UserName);
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(LimitID) && user.HasPermissionID(int.Parse(LimitID)))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }


        /// <summary>
        /// 错误提示
        /// </summary>
        /// <param name="ErrMsg">提示信息</param>
        protected void CreateErrorResponse(string ErrMsg)
        {
            Request.CreateErrorResponse(HttpStatusCode.BadRequest, ErrMsg);
        }
        /// <summary>
        /// 错误提示
        /// </summary>
        protected void CreateErrorResponse()
        {
            CreateErrorResponse("访问出错了");
        }

    }
}
