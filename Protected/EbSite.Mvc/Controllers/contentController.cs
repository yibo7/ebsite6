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
    编写api要注意：就算方法名一样，但参数变量的命名也不能一样，否则出错
    如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
        */
    //[RoutePrefix("content")]
    public class contentController : ApiBaseController
    {
        
        public ApiMessage<int> ebtest(string msg)
        {
            return new ApiMessage<int>() { Success = true, Data = 11111, Message = "ebtest成功返回：" + msg };

        } 
        [HttpPost]
        [Token]
        public ApiMessage<int> testtoken(string data)
        {
            
            return new ApiMessage<int>() { Success = true, Data = 11111, Message = string.Format("ebtest成功返回:消息:{0},用户ID:{1},用户账号：{2},用户昵称：{3}",data,UserToken.UserID,UserToken.UserName,UserToken.UserNiName) };

        }

        [HttpPost]
        [Token]
        public string getmaxid(int t)
        {
            NewsContentSplitTable bll = EbSite.Base.AppStartInit.GetNewsContentInst("newscontent");
            if (t == 1)
            {
               
                return bll.GetMaxId().ToString();
            }

            return "没有此参数";
        }
         

       
        [HttpPost]
        [Token]
        public ApiMessage<long> AddModel(ApiEntity.Content model)
        {
            
            return UpdateAddContent(model);

        }
        [HttpPost]
        [Token]
        public ApiEntity.Content GetContent(int siteid,  long id)
        {
             

            Entity.NewsContent md = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelByCache(id, siteid);

            return ToApiContent(md);

        }


        [HttpPost]
        [Token]
        public ApiEntity.Content GetContent(int siteid,int classid,long id)
        {
             

            NewsContentSplitTable bll = EbSite.Base.AppStartInit.GetNewsContentInst(classid);

            Entity.NewsContent md = bll.GetModelByCache(id, siteid);

            return ToApiContent(md);

        }

        [HttpPost]
        [Token]
        public ApiMessage<long> AddContent(int siteid, int classid,string title,string content)
        {
             

            ApiEntity.Content ThisModel = new ApiEntity.Content();
            ThisModel.SiteID = siteid;
            ThisModel.ClassID = classid;
            ThisModel.NewsTitle = title;
            ThisModel.ContentInfo = content;

            

            return UpdateAddContent(ThisModel);
            //return UpdateAddContent(siteid, classid, title, content, -1);

        }

        [NonAction]
        private ApiMessage<long> UpdateAddContent(ApiEntity.Content model)
        {
            long iId = 0;
            string sMsg = string.Empty;
            if (!Equals(UserToken, null) && model.SiteID > 0 && model.ClassID > 0)
            {
                if (IsHaveLimit("61"))
                {
                    NewsContentSplitTable bll = EbSite.Base.AppStartInit.GetNewsContentInst(model.ClassID);
                    Entity.NewsClass mdClass = BLL.NewsClass.GetModelByCache(model.ClassID);
                    Entity.NewsContent newmodel;

                    if (model.ID > 0)//修改
                    {
                        #region 
                        newmodel = bll.GetModelByCache(model.ID, model.SiteID);
                        if (model.NumberTime > 0)
                            newmodel.NumberTime = model.NumberTime;
                        if (model.RandNum > 0)
                            newmodel.RandNum = model.RandNum;
                        if (model.Advs > 0)
                            newmodel.Advs = model.Advs;
                        if (model.IsAuditing != null)
                            newmodel.IsAuditing = (bool)model.IsAuditing;
                        if (!string.IsNullOrEmpty(model.ClassName))
                            newmodel.ClassName = model.ClassName;

                        if (!string.IsNullOrEmpty(model.SmallPic))
                            newmodel.SmallPic = model.SmallPic;
                        if (!string.IsNullOrEmpty(model.NewsTitle))
                            newmodel.NewsTitle = model.NewsTitle;
                        if (!string.IsNullOrEmpty(model.TitleStyle))
                            newmodel.TitleStyle = model.TitleStyle;
                        if (model.Advs > 0)
                            newmodel.hits = model.hits;
                        if (model.IsGood != null)
                            newmodel.IsGood = (bool)model.IsGood;
                        if (!string.IsNullOrEmpty(model.ContentInfo))
                            newmodel.ContentInfo = model.ContentInfo;
                        if (model.dayHits > 0)
                            newmodel.dayHits = model.dayHits;
                        if (model.weekHits > 0)
                            newmodel.weekHits = model.weekHits;
                        if (model.monthhits > 0)
                            newmodel.monthhits = model.monthhits;
                        if (model.lasthitstime != null)
                            newmodel.lasthitstime = (DateTime)model.lasthitstime;
                        if (!string.IsNullOrEmpty(model.TagIDs))
                            newmodel.TagIDs = model.TagIDs;
                        if (model.OrderID > 0)
                            newmodel.OrderID = model.OrderID;
                        if (!string.IsNullOrEmpty(model.HtmlName))
                            newmodel.HtmlName = model.HtmlName;
                        if (!string.IsNullOrEmpty(model.ContentHtmlNameRule))
                            newmodel.ContentHtmlNameRule = model.ContentHtmlNameRule;
                        if (!string.IsNullOrEmpty(model.Annex1))
                            newmodel.Annex1 = model.Annex1;
                        if (!string.IsNullOrEmpty(model.Annex2))
                            newmodel.Annex2 = model.Annex2;
                        if (!string.IsNullOrEmpty(model.Annex3))
                            newmodel.Annex3 = model.Annex3;
                        if (!string.IsNullOrEmpty(model.Annex4))
                            newmodel.Annex4 = model.Annex4;
                        if (!string.IsNullOrEmpty(model.Annex5))
                            newmodel.Annex5 = model.Annex5;
                        if (!string.IsNullOrEmpty(model.Annex6))
                            newmodel.Annex6 = model.Annex6;
                        if (!string.IsNullOrEmpty(model.Annex7))
                            newmodel.Annex7 = model.Annex7;
                        if (!string.IsNullOrEmpty(model.Annex8))
                            newmodel.Annex8 = model.Annex8;
                        if (!string.IsNullOrEmpty(model.Annex9))
                            newmodel.Annex9 = model.Annex9;
                        if (!string.IsNullOrEmpty(model.Annex10))
                            newmodel.Annex10 = model.Annex10;
                        if (model.Annex11 > 0)
                            newmodel.Annex11 = model.Annex11;
                        if (model.Annex12 > 0)
                            newmodel.Annex12 = model.Annex12;
                        if (model.Annex13 > 0)
                            newmodel.Annex13 = model.Annex13;
                        if (model.Annex14 > 0)
                            newmodel.Annex14 = model.Annex14;
                        if (model.Annex15 > 0)
                            newmodel.Annex15 = model.Annex15;
                        if (model.Annex16 > 0)
                            newmodel.Annex16 = model.Annex16;
                        if (model.Annex17 > 0)
                            newmodel.Annex17 = model.Annex17;
                        if (model.Annex18 > 0)
                            newmodel.Annex18 = model.Annex18;
                        if (model.Annex19 > 0)
                            newmodel.Annex19 = model.Annex19;
                        if (model.Annex20 > 0)
                            newmodel.Annex20 = model.Annex20;
                        if (model.Annex21 > 0)
                            newmodel.Annex21 = model.Annex21;
                        if (model.Annex22 > 0)
                            newmodel.Annex22 = model.Annex22;
                        if (model.Annex23 > 0)
                            newmodel.Annex23 = model.Annex23;
                        if (model.Annex24 > 0)
                            newmodel.Annex24 = model.Annex24;
                        if (model.Annex25 > 0)
                            newmodel.Annex25 = model.Annex25;
                        if (model.CommentNum > 0)
                            newmodel.CommentNum = model.CommentNum;
                        if (model.FavorableNum > 0)
                            newmodel.FavorableNum = model.FavorableNum;
                        #endregion

                    }
                    else //添加
                    {
                        newmodel = ToNewsContent(model);
                       
                        newmodel.ClassName = mdClass.ClassName;
                    }

                    newmodel.UserID = UserToken.UserID;
                    newmodel.UserName = UserToken.UserName;
                    newmodel.UserNiName = UserToken.UserNiName;


                    iId = bll.AddBLL(newmodel, newmodel.ID, true, newmodel.SiteID, mdClass.ContentModelID);


                    sMsg = "操作成功!";
                }
                else
                {
                    sMsg = "没有添加或修改内容权限!";
                }

            }
            else
            {
                if (string.IsNullOrEmpty(sMsg))
                {
                    if (model.SiteID < 1)
                        sMsg = "站点ID不能小于0!";
                    if (model.ClassID < 1)
                        sMsg = "分类ID不能小于0!";
                    if (string.IsNullOrEmpty(model.NewsTitle))
                        sMsg = "标题不能为空!";
                    if (string.IsNullOrEmpty(model.ContentInfo))
                        sMsg = "内容不能为空!";
                    if (Equals(UserToken, null))
                        sMsg = "UserToken无效!";

                }

            }

            return new ApiMessage<long>() { Success = iId > 0, Data = iId, Message = sMsg };
        }

        [HttpPost]
        [Token]
        public ApiMessage<long> UpdateContent(int siteid, int classid, string title, string content, long id)
        {
            ApiEntity.Content ThisModel = new ApiEntity.Content();
            ThisModel.ID = id;
            ThisModel.SiteID = siteid;
            ThisModel.ClassID = classid;
            ThisModel.NewsTitle = title;
            ThisModel.ContentInfo = content;
            return UpdateAddContent(ThisModel);
            //return UpdateAddContent(siteid, classid, title, content, id);
        }


    }
}
