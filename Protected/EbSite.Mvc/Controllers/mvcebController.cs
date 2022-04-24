using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using EbSite.Base;
using EbSite.BLL;
using EbSite.Core;

namespace EbSite.Mvc.Controllers
{
    [RoutePrefix("mvceb/{SiteId}")]
    public class mvcebController : CtlBase
    {
        //private string[] sqlFileds = new string[] { "SmallPic", "NewsTitle", "TitleStyle", " ClassID", "hits", "IsGood", "ContentInfo", "dayHits","weekHits", "monthhits", "lasthitstime", "TagIDs", "OrderID", "AddTime", "IsAuditing", "Annex1", "Annex2", "Annex3", "Annex4","Annex5", "Annex6", "Annex7", "Annex8", "Annex9", "Annex10", "Annex11", "Annex12", "Annex13", "Annex14", "Annex15", "Annex16","Annex17", "Annex18", "Annex19", "Annex20", "Annex21", "Annex22", "Annex23", "Annex24", "Annex25", "TagIDs" };
        [Route("img/{iwidth}/{iheight}/")]
        [HttpGet]
        public ActionResult DycImg(int iwidth, int iheight)
        {
            string sPath = Request["p"];
            Image i = null;
            if (!string.IsNullOrEmpty(sPath))
            {
               
                try
                {
                    string sRealP = Server.MapPath(sPath);
                    i = Image.FromFile(sRealP);
                    return new ImageResult(i, iwidth, iheight);
                }
                catch (Exception ex)
                {
                    EbSite.Log.Factory.GetInstance().ErrorLog("动态生成缩略图出错：" + ex.Message);
                   
                }
                finally
                {
                    if (i != null) i.Dispose();
                }
            }
            i = new Bitmap(1, 1);
            return new ImageResult(i, 1, 1);
        }

        [Route("addcontent/{ClassId}/{UserId}/{key}")]
        [HttpPost]
        public string AddContent(int ClassId,int UserId,string key)
        {
            if (Equals(key, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey))
            { 
                Entity.NewsContent ThisModel = new Entity.NewsContent();
                string[] requestKeys = Request.Params.AllKeys; //取所有参数的键名,放到数组中中记录

                ThisModel.UserID = UserId;
                ThisModel.IsAuditing = true;

                foreach (String skey in requestKeys)
                {
                    InitContentModel(ref ThisModel, skey, Request[skey]);

                }

                Entity.NewsClass mdClass = BLL.NewsClass.GetModelByCache(ClassId);

                ThisModel.ClassName = mdClass.ClassName;
                ThisModel.ClassID = ClassId;
                ThisModel.SiteID = SiteId;
                

                if (ThisModel.ClassID > 0 && ThisModel.SiteID > 0 && !string.IsNullOrEmpty(ThisModel.NewsTitle))
                {

                    if (!string.IsNullOrEmpty(Request["tnum"]))
                    {
                        int iTnum = Core.Utils.StrToInt(Request["tnum"], 0);
                        if (iTnum > 0)
                        {
                            string vt = ThisModel.NewsTitle.Trim().Replace(",", "").Replace("，", "").Replace("\r", "").Replace("\n", "").Replace("—","");
                            if (vt.Length < iTnum)
                            {
                                return  string.Format("文章添加失败,标题字数至少是{0}个字符", iTnum);
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(Request["cnum"]))
                    {
                        int iCnum = Core.Utils.StrToInt(Request["cnum"], 0);
                        if (iCnum > 0)
                        {
                            string vc = ThisModel.ContentInfo.Trim().Replace(",", "").Replace("，", "").Replace("\r", "").Replace("\n", "").Replace("—", ""); ;
                            if (vc.Length < iCnum)
                            {
                                return string.Format("文章添加失败,内容字数至少是{0}个字符", iCnum);
                            }
                        }
                    }

                    NewsContentSplitTable bll = EbSite.Base.AppStartInit.GetNewsContentInst(ClassId);



                    long contentid = bll.AddBLL(ThisModel, -1, true, SiteId, mdClass.ContentModelID);
                    if (contentid > 0)
                    {
                        return string.Format("文章添加成功,文章ID{0}", contentid);
                    }
                    else
                    {
                        return string.Format("文章添加失败,返回的文章ID小于1");
                    }
                }
                else
                {
                    return "文章添加失败,ClassID,SiteID,NewsTitle其中至少有一项为空";
                }
            }
            else
            {
                return "文章添加失败,密钥不对！";
            }

           
        }
        [NonAction]
        private void InitContentModel(ref Entity.NewsContent Model,string Key,string Value)
        {
            switch (Key)
            {
                case "SmallPic":
                    Model.SmallPic = Value;
                    break;
                case "NewsTitle":
                    Model.NewsTitle = Value;
                    break;
                case "TitleStyle":
                    Model.TitleStyle = Value;
                    break;
                case "hits":
                    Model.hits = Core.Utils.StrToInt(Value,0);
                    break;
                case "ContentInfo":
                    Model.ContentInfo = Value;
                    break;
                case "dayHits":
                    Model.dayHits = Core.Utils.StrToInt(Value, 0); 
                    break;
                case "weekHits":
                    Model.dayHits = Core.Utils.StrToInt(Value, 0);
                    break;
                case "monthhits":
                    Model.dayHits = Core.Utils.StrToInt(Value, 0);
                    break;
                case "AddTime":
                    Model.AddTime = Core.Utils.StrToDate(Value);
                    break;
                case "IsAuditing":
                    Model.IsAuditing = Core.Utils.StrToBool(Value,true);
                    break;
                case "Annex1":
                    Model.Annex1 = Value;
                    break;
                case "Annex2":
                    Model.Annex2 = Value;
                    break;
                case "Annex3":
                    Model.Annex3 = Value;
                    break;
                case "Annex4":
                    Model.Annex4 = Value;
                    break;
                case "Annex5":
                    Model.Annex5 = Value;
                    break;
                case "Annex6":
                    Model.Annex6 = Value;
                    break;
                case "Annex7":
                    Model.Annex7 = Value;
                    break;
                case "Annex8":
                    Model.Annex8 = Value;
                    break;
                case "Annex9":
                    Model.Annex9 = Value;
                    break;
                case "Annex10":
                    Model.Annex10 = Value;
                    break;
                case "Annex11":
                    Model.Annex11 = Core.Utils.StrToInt(Value) ;
                    break;
                case "Annex12":
                    Model.Annex12 = Core.Utils.StrToInt(Value);
                    break;
                case "Annex13":
                    Model.Annex13 = Core.Utils.StrToInt(Value);
                    break;
                case "Annex14":
                    Model.Annex14 = Core.Utils.StrToInt(Value);
                    break;
                case "Annex15":
                    Model.Annex15 = Core.Utils.StrToInt(Value);
                    break;
                case "Annex16":
                    Model.Annex16 = Core.Utils.StrToDecimal(Value, 0);
                    break;
                case "Annex17":
                    Model.Annex17 = Core.Utils.StrToDecimal(Value,0); 
                    break;
                case "Annex18":
                    Model.Annex18 = Core.Utils.StrToDecimal(Value, 0); 
                    break;
                case "Annex19":
                    Model.Annex19 = Core.Utils.StrToFloat(Value);
                    break;
                case "Annex20":
                    Model.Annex20 = Core.Utils.StrToFloat(Value);
                    break;
                case "Annex21":
                    Model.Annex21 = Core.Utils.StrToInt(Value);
                    break;
                case "Annex22":
                    Model.Annex22 = Core.Utils.StrToInt(Value);
                    break;
                case "Annex23":
                    Model.Annex23 = Core.Utils.StrToInt(Value);
                    break;
                case "Annex24":
                    Model.Annex24 = Core.Utils.StrToInt(Value);
                    break;
                case "Annex25":
                    Model.Annex25 = Core.Utils.StrToInt(Value);
                    break;
                case "TagIDs":
                    Model.TagIDs = Value;
                    break;
            }
        }
         
    }
}
