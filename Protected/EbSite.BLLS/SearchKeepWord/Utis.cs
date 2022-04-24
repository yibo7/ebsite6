
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Data;
//using System.Text;
//using System.Web.UI.WebControls;
//using EbSite.BLL.ModelBll;

//namespace EbSite.BLL.SearchKeepWord
//{
//    public class Utis : ModelBase<DataRow> 
//    {
//        public static readonly Utis Instance = new Utis(); 
       
//        public override List<EbSite.Entity.ModelClass> ModelClassList
//        {
//            get
//            {
//                return null;
//            }
//        }
//        public override string[] aColums
//        {

//            get { return null; }
//        }
//        public override void InitModifyCtr(PlaceHolder ph, DataRow ModifyModel)
//        {
//            foreach (System.Web.UI.Control uc in ph.Controls)
//            {
//                if (Equals(uc.ID, null)) continue;
//                string sValue = ModifyModel[uc.ID].ToString();
//                SetValueFromControl(uc, sValue);
//            }
            
//        }
       
//        public override void Save()
//        {
            
//        }
//        /// <summary>
//        /// 获取重写搜索地址
//        /// </summary>
//        /// <param name="sGuidID"></param>
//        /// <param name="sShortId"></param>
//        /// <param name="PageIndex"></param>
//        /// <param name="sSoPage"></param>
//        /// <returns></returns>
//        public static string GetReWriteUrl(string sGuidID, string sShortId, int PageIndex,string sReWritePath)
//        {
//            return string.Format("{0}/{1}-{2}-{3}/{4}", Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName, sGuidID, sShortId, PageIndex, sReWritePath);
//        }
//        /// <summary>
//        /// 获取搜索定向url
//        /// </summary>
//        /// <param name="sGuidID">部件ID</param>
//        /// <param name="sShortId">记录唯一ID</param>
//        /// <param name="PageIndex">当前页码</param>
//        /// <returns></returns>
//        public static string GetSearchUrl(string sGuidID,string sShortId, int PageIndex)
//        {
//            string sUrl = string.Concat(Base.AppStartInit.IISPath, "{0}");
//            Guid gId = new Guid(sGuidID);

//            if(!Equals(gId,Guid.Empty))
//            {
//                EbSite.Widgets.SearchKeepWord.edit md = new EbSite.Widgets.SearchKeepWord.edit();
//                md.DataID = new Guid(sGuidID);
//              List<string> lst = md.InitColumns();
              

//              if(lst.Count>0)
//              {
//                  DataTable dt = md.GetSettingsTable();
//                  DataRow drFind = null;
//                  foreach (DataRow dr in dt.Rows)
//                  {
//                      if(Equals(dr["ShortId"],sShortId))
//                      {
//                          drFind = dr;
//                          break;
//                      }
//                  }

//                  if(!Equals(drFind,null))
//                  {
//                      StringBuilder sb = new StringBuilder();

//                      foreach (string sColumName in lst)
//                      {
//                          //排队非表单字段
//                          if(!Equals(sColumName,"ShortId")&&!Equals(sColumName,"ReWritePath")&&!Equals(sColumName,"Title"))
//                          {
//                              string sValue = drFind[sColumName].ToString();

//                              sb.AppendFormat("{0}={1}&", sColumName, sValue);
//                          }
                          
//                      }

//                     if(sb.Length>0)
//                     {
//                         StringDictionary settings = md.GetSettings();
//                      if (!Equals(settings,null))
//                      {
//                          if (settings.ContainsKey("SoPage") && settings.ContainsKey("Widget"))
//                          {
//                              if (sb.Length > 0)
//                              {
//                                  string sSoPage = settings["SoPage"];
//                                  string vgId = settings["Widget"];
//                                  sb.AppendFormat("cid={0}", vgId);

//                                  sUrl = string.Format(sUrl, string.Concat(sSoPage, "?t=1&p=",PageIndex,"&", sb));//t=1标记此为重写
//                              }
                              
//                          }
//                      }
//                     }
                      
                      
//                  }
//              }

//            }
//            else
//            {
//                sUrl = "";
//            }
//            return sUrl;
//        }
//        public override void InitSaveCtr(PlaceHolder ph, ref DataRow ModifyModel)
//        {
//            foreach (System.Web.UI.Control uc in ph.Controls)
//            {
//                if (Equals(uc.ID, null)) continue;
//                string sValue = "";
                
//                sValue = GetValueFromControl(uc);

//                ModifyModel[uc.ID] = sValue;

//            }
//        }
//    }
//}
