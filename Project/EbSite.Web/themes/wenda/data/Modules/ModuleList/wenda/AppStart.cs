using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using EbSite.BLL;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Modules;
using EbSite.Base.Modules.Configs;
using EbSite.BLL.GetLink;
using EbSite.BLL.User;
using EbSite.Base.Static;
using EbSite.Core.Strings;
using EbSite.Entity;
using EbSite.Modules.Wenda.ModuleCore.BLL;
//using System.ServiceModel.Syndication;
using System.Text;
using System.Data;
using EbSite.Modules.Wenda.ModuleCore.Entity;


namespace EbSite.Modules.Wenda
{
    public class AppStart : ModuleStartInit
    {
        static private int SiteID = 0;
        private static bool _startWasCalled;

        public void Start()
        {
            if (_startWasCalled) return;
            _startWasCalled = true;

            //��ȡ��ǰģ�����ڵ�վ��Id,���������Է�ֹ���վ�����¼�ִ�е�����§
            //Ҳ����˵�������ǰ���ʷǵ�ǰվ��ʱ�����Բ������¼�(��������õ�)
            SiteID = SettingInfo.Instance.GetSiteID;

            EBSiteEvents.ApplicationBeginRequest += new EventHandler<EventArgs>(Application_BeginRequest);
        }

        /// <summary>
        /// Ҫʵ�ֵķ��� ģ�鰲װʱִ��(��װ��) ��̬��������¼�������  ִ�а�װsql�ű�
        /// </summary>
        /// <param name="ModuleID">�����Ѿ���װ�õ�ģ��ID</param>
        /// <param name="SetupPath">�����Ѿ���װ�õ�ģ��Ŀ¼ ��ʽ������:/Modules/Order/</param>
        public void __Module_Setuped(Guid ModuleID, string SetupPath)
        {

        }
        /// <summary>
        /// Ҫʵ�ֵķ��� ģ��׼��ж��ǰִ�� ɾ����̬��������¼��� ִ��ɾ��sql�ű�
        /// </summary>
        /// <param name="ModuleID">�����Ѿ���װ�õ�ģ��ID</param>
        /// <param name="SetupPath">�����Ѿ���װ�õ�ģ��Ŀ¼ ��ʽ������:/Modules/Order/</param>
        public void __Module_Uninstalling(Guid ModuleID, string SetupPath)
        {

        }

        private static string StartupOK = null;
        private static object _SyncRoot = new object();
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            if (StartupOK == null)
            {
                lock (_SyncRoot)
                {
                    if (StartupOK == null)
                    {
                        // EbSite.Base.EBSiteEvents.Searching += new EventHandler<SearchEventArgs>(On_Searching);
                        EbSite.Base.EBSiteEvents.ClassListLoading += new EventHandler<ClassListLaodingEventArgs>(On_ClassListLoading);

                        //EbSite.Base.EBSiteEvents.RssGetting += new EventHandler<RssArgs>(On_Rss);

                        // EbSite.Base.EBSiteEvents.ContentAdded += new EventHandler<AddedContentEventArgs>(On_ContentAdded);
                        EbSite.Base.EBSiteEvents.HttpModuleRuning += new EventHandler<HttpModuleRuningEventArgs>(On_HttpModuleRuning);

                        EbSite.Base.EBSiteEvents.ContentPageLoadEvent += new EventHandler<ContentPageLoadEventArgs>(On_ContentPageLoadEvent);

                        //EbSite.Base.EBSiteEvents.ClassMeta += new EventHandler<ClassMetaEventArgs>(On_ClassMeta);

                        EbSite.Base.EBSiteEvents.ContentDeleteing+=new EventHandler<DeleteingContentEventArgs>(On_DeleteingWenda);//ɾ������ʱ����չ�¼�

                       // EbSite.Base.EBSiteEvents.AllowContentEvent +=  new EventHandler<AllowContentEventArgs>(On_AllowContentWenda);//ͨ����˺� ����չ�¼�


                        StartupOK = "OK";
                    }
                }
            }

        }
        /// <summary>
        /// 2014-3-20 ͨ����˺� ͬʱ��class_article �����������
        /// ask_class_article �Ĵ���ԭ�ɣ�ǰ����û�� �ֱ�newscontent ������ ���ҡ�
        ///                     �� ������Ҳ�浽 ask_class_article�С�Ч������ˡ� 
        ///Ȼ������ ʵ���˷ֱ� ���Ͳ������� ask_class_article �ˡ�

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void On_AllowContentWenda(object sender, AllowContentEventArgs e)
        {
            if (e.SiteID == SiteID)
            {
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(e.ClassID);

               
            }
        }


        //ɾ������ʱ����չ�¼�
        /// <summary>
        /// 2014-3-20 ɾ������ʱ ͬʱɾ����ר�����ʵ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void On_DeleteingWenda(object sender, DeleteingContentEventArgs e)
        {
            if (string.IsNullOrEmpty( e.TableName )&&e.SiteID>0)
            {
                if (e.SiteID == SiteID)
                {
                    NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(e.TableName);

                    EbSite.Entity.NewsContent mdwenda = NewsContentInst.GetModel(e.ID, e.SiteID);

                    if (!Equals(mdwenda, null))
                    {
                        if (mdwenda.Annex11 > 0) //Annex11:    �ش�������ܸ���  
                        {
                            e.StopDelete = true;
                           //����ɾ��,�����������˻ش�
                        }
                        else
                        {
                            e.StopDelete = false;
                            List<ModuleCore.Entity.expertAsk> exls = ModuleCore.BLL.expertAsk.Instance.GetListArray(0, " qid=" + e.ID, "");

                            if (exls.Count > 0)
                            {
                                foreach (var expertAsk in exls)
                                {
                                    ModuleCore.BLL.expertAsk.Instance.Delete(expertAsk.id);
                                }
                            } 
                        }
                    }
                }
            }
        }

        private  void On_ContentPageLoadEvent(object sender, ContentPageLoadEventArgs e)
        {
            #region �ֻ����ʴ�ظ��б�

            EbSite.Entity.NewsContent mContent = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(e.ContentID);
            //�жϴ������Ƿ��Ѿ��в��ɴ�
            if (mContent != null && mContent.Annex21 == 2)
            {
                DataSet ds = ModuleCore.BLL.Answers.Instance.GetDataArticle(e.ContentID, mContent.Annex21);
                if (ds != null && ds.Tables.Count > 3)
                {
                    //��ѯ����Ѵ�
                    DataTable dt1 = ds.Tables[2];
                    Control.Repeater rptBest = e.Page.FindControl("rptBestAnswer") as Control.Repeater;
                    if (!Equals(rptBest, null))
                    {
                        rptBest.ItemDataBound +=
                            new System.Web.UI.WebControls.RepeaterItemEventHandler(rptBest_ItemDataBound);
                        rptBest.DataSource = dt1;
                        rptBest.DataBind();
                    }
                    //�����ش��б�
                    DataTable dt2 = ds.Tables[3];
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        Control.Repeater rptOtherList = e.Page.FindControl("rptOtherAnswer") as Control.Repeater;
                        rptOtherList.DataSource = dt2;
                        rptOtherList.DataBind();
                    }
                }
            }
            else
            {
                Control.Repeater rptRefList = e.Page.FindControl("rptRefList") as Control.Repeater;
                List<ModuleCore.Entity.Answers> answersList = ModuleCore.BLL.Answers.Instance.GetListArray("qid=" + e.ContentID);
                if (answersList != null && answersList.Count > 0)
                {
                    rptRefList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(rptRefList_ItemDataBound);
                    rptRefList.DataSource = answersList;
                    rptRefList.DataBind();
                }
                else
                {

                }
            }

            #endregion �ֻ����ʴ�ظ��б�
        }

        //��Ѵ� ׷���б���¼�
        public  void rptBest_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                DataRowView amd = (DataRowView)e.Item.DataItem;
                if (amd != null)
                {
                    List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray("answerid=" + amd["id"] + " and typeid=0");
                    if (ls != null && ls.Count > 0)
                    {
                        Control.Repeater rptGoOnList = e.Item.FindControl("rptGoOnList") as Control.Repeater;
                        rptGoOnList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(rptGoOnList_ItemDataBound);

                        rptGoOnList.DataSource = ls;
                        rptGoOnList.DataBind();
                    }
                }
            }
        }
        //׷���б���¼�
        public  void rptRefList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                ModuleCore.Entity.Answers amd = (ModuleCore.Entity.Answers)e.Item.DataItem;
                if (amd != null)
                {
                    List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray("answerid=" + amd.id + " and typeid=0");
                    if (ls != null && ls.Count > 0)
                    {
                        Control.Repeater rptGoOnList = e.Item.FindControl("rptGoOnList") as Control.Repeater;
                        rptGoOnList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(rptGoOnList_ItemDataBound);

                        rptGoOnList.DataSource = ls;
                        rptGoOnList.DataBind();
                    }
                }
            }
        }
        //�󶨻ش��б�
        public  void rptGoOnList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                ModuleCore.Entity.expandanswers eaMd = (ModuleCore.Entity.expandanswers)e.Item.DataItem;
                if (eaMd != null)
                {
                    List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray(1, "eid=" + eaMd.id + " and typeid=1", "");
                    if (ls != null && ls.Count > 0)
                    {
                        Control.Repeater rptAnswerList = e.Item.FindControl("rptAnswerList") as Control.Repeater;
                        rptAnswerList.DataSource = ls;
                        rptAnswerList.DataBind();
                    }
                    else
                    {
                        ModuleCore.Entity.Answers amd = ModuleCore.BLL.Answers.Instance.GetEntity(int.Parse(eaMd.AnswerId.ToString()));
                        if (EbSite.Base.Host.Instance.UserID == amd.AnswerUserID)
                        {
                            System.Web.UI.WebControls.Panel panel = e.Item.FindControl("panelanswer") as System.Web.UI.WebControls.Panel;
                            panel.Visible = true;
                        }
                    }
                }
            }
        }

        //private static void On_ClassMeta(object sender, EbSite.Base.EBSiteEventArgs.ClassMetaEventArgs e)
        //{
        //    if (e.SiteID == SiteDI && e.ClassID > 0)
        //    {
        //        EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel(e.ClassID);
        //        if (md.ParentID == 9223)
        //        {
        //            string sitename = EbSite.Base.Host.Instance.CurrentSite.SiteName;
        //            e.StopSytemMeta = true;
        //            e.SeoTitle = string.Format("{0}����ά�����ר�����߽��_{0}���������ѯ_{1}", md.ClassName, sitename);
        //            e.SeoKeyWord = string.Format("{0},{1}", md.ClassName, sitename);
        //            e.SeoDes = md.ClassName;

        //        }
        //    }
        //}

        ///// <summary>
        ///// �õ���վ���SiteID
        ///// </summary>
        //protected static int SiteDI
        //{
        //    get
        //    {

        //        return Configs.Instance.Model.GetSiteID;
        //    }
        //}
        /**/
        /// <summary>
        /// �ʴ���ҳ ���л�����
        /// </summary>
        private  void On_ClassListLoading(object sender, ClassListLaodingEventArgs e)
        {
            if (e.SiteID == SiteID)
            {
                if (e.ClassID > 0)
                {
                    //e.Context  ��ǰ������������        
                    //e.Where = ""; ��������
                    //listt=123
                    string strsql = " 1=1 and";
                    string sType = e.Context.Request["listt"];
                    string sClassId = e.Context.Request["cid"];

                    if (!string.IsNullOrEmpty(sType))
                    {
                        if (sType == "1") //���������
                        {
                            strsql = string.Concat(" Annex21= ", 1, " and");
                        }
                        else if (sType == "2") // �ѽ������
                        {
                            strsql = string.Concat(" Annex21= ", 2, " and");
                        }
                        else if (sType == "3") //��������
                        {
                            strsql = string.Concat(" Annex1> ", 1, " and");
                        }
                    }

                    // string SubIds = EbSite.BLL.NewsClass.GetSubIDs(Core.Utils.StrToInt(sClassId, 0), e.SiteID);
                    string SubIds = "";
                    List<EbSite.Entity.NewsClass> SubList = EbSite.BLL.NewsClass.GetSubIDs(Core.Utils.StrToInt(sClassId, 0), e.SiteID, out SubIds);
                    if (!string.IsNullOrEmpty(SubIds))
                    {
                        //�Ƿ����
                        if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent)
                        {
                            strsql = string.Concat(strsql, "  ClassID in(", SubIds, ") and isauditing=true and");
                            strsql = strsql.Remove(strsql.Length - 3, 3);
                            e.Where = strsql;
                        }
                        else
                        {
                            strsql = string.Concat(strsql, "  ClassID in(", SubIds, ") and");
                            strsql = strsql.Remove(strsql.Length - 3, 3);
                            e.Where = strsql;
                        }

                    }
                    else
                    {
                        strsql = string.Concat(strsql, " ClassID=", sClassId, " and");
                        strsql = strsql.Remove(strsql.Length - 3, 3);
                        e.Where = strsql;

                    }

                    //if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent)
                    //{
                    //    e.Where = strsql + "  isauditing=true and classid=" + sClassId;
                    //}
                    //else
                    //{
                    //    //e.Where = strsql + "   classid=" + sClassId;
                    //    e.Where = strsql;
                    //}

                }
                else
                {
                    string strsql = " 1=1 ";
                    string sType = e.Context.Request["listt"];
                    if (!string.IsNullOrEmpty(sType))
                    {
                        if (sType == "1") //���������
                        {
                            strsql = " Annex21= " + 1;
                        }
                        else if (sType == "2") // �ѽ������
                        {
                            strsql = " Annex21= " + 2;
                        }
                        else if (sType == "3") //��������
                        {

                            strsql = " Annex1>= " + 1;
                        }
                        e.Where = strsql;
                    }



                    //�ֻ���ҳ ҳ��
                    string sMType = e.Context.Request["t"];
                    if (!string.IsNullOrEmpty(sMType))
                    {
                        if (sMType == "1") //������
                        {
                            e.OrderBy = "dayhits  desc";
                        }
                        else if (sMType == "2") // ������
                        {
                            e.OrderBy = "weekhits  desc";
                        }

                    }
                }

            }
        }
        /// <summary>
        /// ����֮ǰ���Խ���һЩҵ����
        /// </summary>
        private  void On_Searching(object sender, SearchEventArgs e)
        {
            if (e.SiteID == SiteID)
            {
                if (!string.IsNullOrEmpty(e.KeyWord))
                {
                    //e.KeyWord ��ǰ�����Ĺؼ���
                    //e.Context  ��ǰ������������        
                    string strsql = "";
                    string sType = e.Context.Request["listt"];//���洫�����Ĳ��� //����0 ͼƬ1 GTP2 OVE3 TXT4 PDF5

                    if (!string.IsNullOrEmpty(sType))
                    {
                        if (sType == "1") //��������
                        {
                            strsql = " Annex1>= " + 1 + " and ";
                        }
                        if (sType == "2") //�����
                        {
                            strsql = " Annex21= " + 1 + " and ";
                        }
                        if (sType == "3") //�ѽ��
                        {
                            strsql = " Annex21= " + 2 + " and ";
                        }
                    }

                    if (!string.IsNullOrEmpty(strsql))
                    {
                        e.Where = strsql + "newstitle like '%" + e.KeyWord + "%'";
                    }
                }
            }
        }

        /// <summary>
        /// ���Url�Ƿ�����������
        /// </summary>
        /// <param name="sUrl">Ҫ����Url</param>
        /// <param name="rg">Ҫ��֤������</param>
        /// <returns></returns>
        private bool IsMatchReWrite(string sUrl, string rg)
        {
            Match mc = Regex.Match(sUrl, rg);
            return mc.Success;
        }


        private  void On_HttpModuleRuning(object sender, HttpModuleRuningEventArgs e)
        {
            HttpContext httpContext = e.App.Context;
            string requestPath = httpContext.Request.Path.ToLower();

            //Ŀǰֻ��ashx,htmҳ�洦��,������Ҫ�����
            if (requestPath.ToLower().IndexOf(".ashx") != -1 || requestPath.ToLower().IndexOf(".htm") != -1)
            {
                #region PC
                string strRuleAskClass = "askclasslist-([0-9]+).ashx";
                string strRuleAskPost = "askpost-([0-9]+).ashx";
                string strRuleAskHot = "askhot-([0-9]+).ashx";
                string strRuleAttractive = "attractive-([0-9]+).ashx";
                string strRuleAttractiveList = "tiwen-([0-9]+)-([0-9]+)-([0-9]+).ashx";

                string strRuleBuyList = "buy-([0-9]+)-([0-9]+)-([0-9]+).ashx";
                string strTongwen = "tongwen-([0-9]+)-([0-9]+)-([0-9]+).ashx";
                string strJieda = "jieda-([0-9]+)-([0-9]+)-([0-9]+).ashx";

                string strRuleCheckList = "tiwencheck-([0-9]+)-([0-9]+)-([0-9]+).ashx";

                string strRuleMyAsked = "myasked-([0-9]+)-([0-9]+)-([0-9]+).ashx";

                string fastTopicsRule = Configs.Instance.Model.txtCatalog;
                string qhtRule = Configs.Instance.Model.txtReplay;

                string IndexRule = string.Concat("/wenda/", "([0-9]+)-([0-9]+)", Configs.Instance.Model.ContentPath);
                string CacheFolder = "/askcachefile/";//����Ŀ¼
                string strRuleAnswerTop = "answer-([0-9]+).ashx"; //�ش����
                string strRuleNewReg = "newreg-([0-9]+).ashx";//����ע��

                string strRuleExpert = "expert-([0-9]+).ashx";//ר��

                #endregion

                #region Moblie
                string MstrRuleAskPost = "mobileask-([0-9]+).ashx";
                #endregion

                if (IsMatchReWrite(requestPath, strRuleAskClass))
                {
                    Match mc = Regex.Match(requestPath, strRuleAskClass);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("maskclasslist.aspx"), "?site=", iSiteID);
                        string CacheUrl = string.Concat(CacheFolder, "maskclasslist.htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, strRuleAskPost))
                {
                    Match mc = Regex.Match(requestPath, strRuleAskPost);
                    if (mc.Success)
                    {
                        //string query = httpContext.Request.QueryString.ToString().ToLower();
                        //if (!string.IsNullOrEmpty(query)) //�������� uid=1
                        //{
                        //    query = "&" + query;
                        //}
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("maskpost.aspx"), "?site=", iSiteID);
                        //string CacheUrl = string.Concat(CacheFolder, "maskpost", "-", httpContext.Request.QueryString.ToString().ToLower(), ".htm");
                        e.RealUrl = RealUrl;// EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, strRuleAskHot))
                {
                    Match mc = Regex.Match(requestPath, strRuleAskHot);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("maskhot.aspx"), "?site=", iSiteID);
                        string CacheUrl = string.Concat(CacheFolder, "maskhot.htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, strRuleAttractive))
                {
                    Match mc = Regex.Match(requestPath, strRuleAttractive);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mattractive.aspx"), "?site=", iSiteID);
                        string CacheUrl = string.Concat(CacheFolder, "mattractive.htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, strRuleAnswerTop))
                {
                    Match mc = Regex.Match(requestPath, strRuleAnswerTop);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("manswertop.aspx"), "?site=", iSiteID);
                        string CacheUrl = string.Concat(CacheFolder, "answer.htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, strRuleNewReg))
                {
                    Match mc = Regex.Match(requestPath, strRuleNewReg);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mreg.aspx"), "?site=", iSiteID);
                        string CacheUrl = string.Concat(CacheFolder, "newreg.htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, strRuleExpert))
                {
                    Match mc = Regex.Match(requestPath, strRuleExpert);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mexpert.aspx"), "?site=", iSiteID);
                        string CacheUrl = string.Concat(CacheFolder, "mexpert.htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }


                else if (IsMatchReWrite(requestPath, strRuleAttractiveList)) //����
                {
                    Match mc = Regex.Match(requestPath, strRuleAttractiveList);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        int iUserID = int.Parse(mc.Groups[2].Value);
                        int iPageIndex = int.Parse(mc.Groups[3].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mtiwen.aspx"), "?site=", iSiteID, "&uid=", iUserID, "&p=", iPageIndex);
                        string CacheUrl = string.Concat(CacheFolder, "tiwen/", iUserID, "/u", iUserID, "-", iPageIndex, ".htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, strRuleBuyList)) //����
                {
                    Match mc = Regex.Match(requestPath, strRuleBuyList);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        int iUserID = int.Parse(mc.Groups[2].Value);
                        int iPageIndex = int.Parse(mc.Groups[3].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mbuy.aspx"), "?site=", iSiteID, "&uid=", iUserID, "&p=", iPageIndex);
                        string CacheUrl = string.Concat(CacheFolder, "buy/", iUserID, "/u", iUserID, "-", iPageIndex, ".htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }

                else if (IsMatchReWrite(requestPath, strRuleCheckList)) //���������
                {
                    Match mc = Regex.Match(requestPath, strRuleCheckList);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        int iUserID = int.Parse(mc.Groups[2].Value);
                        int iPageIndex = int.Parse(mc.Groups[3].Value);
                        if (iUserID == EbSite.Base.Host.Instance.UserID)
                        {

                            EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                            string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mtiwencheck.aspx"), "?site=",
                                                           iSiteID, "&uid=", iUserID, "&p=", iPageIndex);
                            //string CacheUrl = string.Concat(CacheFolder, "tiwen/u", iUserID, "-", iPageIndex, ".htm");
                            e.RealUrl = RealUrl; // EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                            e.IsStop = true;
                        }
                        else
                        {
                            e.RealUrl = Base.PageLink.GetBaseLinks.Get(iSiteID).GetErrPage("9");
                            e.IsStop = true;
                        }
                    }
                }
                else if (IsMatchReWrite(requestPath, strRuleMyAsked)) //���ҵ�����
                {
                    Match mc = Regex.Match(requestPath, strRuleMyAsked);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        int iUserID = int.Parse(mc.Groups[2].Value);
                        int iPageIndex = int.Parse(mc.Groups[3].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        if (iUserID == EbSite.Base.Host.Instance.UserID)
                        {
                            string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mtmyasked.aspx"), "?site=", iSiteID,
                                                           "&uid=", iUserID, "&p=", iPageIndex);
                            //string CacheUrl = string.Concat(CacheFolder, "tiwen/u", iUserID, "-", iPageIndex, ".htm");
                            e.RealUrl = RealUrl; // EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                            e.IsStop = true;
                        }
                        else
                        {

                            e.RealUrl = Base.PageLink.GetBaseLinks.Get(iSiteID).GetErrPage("9");
                            e.IsStop = true;
                        }
                    }
                }
                else if (IsMatchReWrite(requestPath, strTongwen)) //ͬ��
                {
                    Match mc = Regex.Match(requestPath, strTongwen);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        int iUserID = int.Parse(mc.Groups[2].Value);
                        int iPageIndex = int.Parse(mc.Groups[3].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mtongwen.aspx"), "?site=", iSiteID, "&uid=", iUserID, "&p=", iPageIndex);
                        string CacheUrl = string.Concat(CacheFolder, "tongwen/", iUserID, "/u", iUserID, "-", iPageIndex, ".htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, strJieda)) //���
                {
                    Match mc = Regex.Match(requestPath, strJieda);
                    if (mc.Success)
                    {
                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        int iUserID = int.Parse(mc.Groups[2].Value);
                        int iPageIndex = int.Parse(mc.Groups[3].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mjieda.aspx"), "?site=", iSiteID, "&uid=", iUserID, "&p=", iPageIndex);
                        string CacheUrl = string.Concat(CacheFolder, "jieda/", iUserID, "/u", iUserID, "-", iPageIndex, ".htm");
                        e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, fastTopicsRule)) //���ٷ�����
                {
                    Match mc = Regex.Match(requestPath, fastTopicsRule);
                    if (mc.Success)
                    {
                        int iSiteID = SiteID;

                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mfastTopics.aspx"));
                        e.RealUrl = RealUrl;
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, qhtRule)) //���ٻظ�����
                {
                    Match mc = Regex.Match(requestPath, qhtRule);
                    if (mc.Success)
                    {
                        int iSiteID = SiteID;

                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mqht.aspx"));
                        e.RealUrl = RealUrl;
                        e.IsStop = true;
                    }
                }
                else if (IsMatchReWrite(requestPath, IndexRule)) //������ҳ
                {
                    string ContentId = "0";
                    int siteid = SiteID;

                    Match mc = Regex.Match(requestPath, IndexRule);
                    if (mc.Success)
                    {
                        ContentId = mc.Groups[2].Value;
                        // siteid =Convert.ToInt32( mc.Groups[2].Value);
                        //��֤�� �� �ѽ��=2 �ѹر�=3
                        EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelByFiledOfDefault("ClassID,siteid,annex21", "id=" + ContentId);//Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(ContentId));//�����Ż�һ�¡�ֻ��2 ���ֶ�
                        if (!Equals(md, null))
                        {


                            #region

                            int ContentIdX = Core.Utils.StrToInt(ContentId, 0);
                            bool isExists = ModuleCore.BLL.AskCache.Instance.Exists(ContentIdX, 1);
                            if (isExists)
                            {
                                bool isTimeOut =  ModuleCore.BLL.AskCache.Instance.IsTimeOut(ContentIdX, 1);

                                if (isTimeOut)// �Ҳ�� �����ȡ���� ���� ���ҳ�� �ʴ�û���˻ش� ���ڡ�
                                {

                                    #region �̶������

                                    int setsecond = 3;
                                    string cachkey = "realtedarticle-" + ContentIdX;
                                    string ids = EbSite.Base.Host.CacheApp.GetCacheItem<string>(cachkey,"wenda");// as string;
                                    if (Equals(ids, null))
                                    {
                                        Random ran = new Random();
                                        for (int i = 0; i < 10; i++)
                                        {
                                            int j = ran.Next(1, 100);
                                            ids += j + ",";

                                        }
                                        if (ids.Length > 0)
                                            ids = ids.Remove(ids.Length - 1, 1);
                                        EbSite.Base.Host.CacheApp.AddCacheItem(cachkey, ids, setsecond, ETimeSpanModel.M, "wenda");
                                    }

                                    #endregion
                                    #region yhl 2013-09-16 ע��
                                   ModuleCore.Entity.AskCache mdcache = new ModuleCore.Entity.AskCache();
                                   mdcache.dateline = EbSite.Core.SqlDateTimeInt.GetSecond(DateTime.Now.AddDays(3));//3�����
                                    mdcache.addtime = DateTime.Now.AddDays(3);
                                    mdcache.keyid = ContentIdX;
                                    mdcache.keytype = 1;
                                    mdcache.randomids = ids;

                                    ModuleCore.BLL.AskCache.Instance.UpdateEx(mdcache);
                                    #endregion
                                }

                            }
                            else
                            {
                                #region �̶������

                                int setsecond = 3;
                                string cachkey = "realtedarticle-" + ContentIdX;
                                string ids = EbSite.Base.Host.CacheApp.GetCacheItem<string>(cachkey,"wenda");// as string;
                                if (Equals(ids, null))
                                {
                                    Random ran = new Random();
                                    for (int i = 0; i < 10; i++)
                                    {
                                        int j = ran.Next(1, 100);
                                        ids += j + ",";

                                    }
                                    if (ids.Length > 0)
                                        ids = ids.Remove(ids.Length - 1, 1);
                                    EbSite.Base.Host.CacheApp.AddCacheItem(cachkey, ids, setsecond, ETimeSpanModel.M, "wenda");
                                }

                                #endregion

                                #region yhl 2013-09-16 ע��

                               ModuleCore.Entity.AskCache cachemd = new ModuleCore.Entity.AskCache();
                               DateTime a = DateTime.Now.AddDays(ConfigControl.Instance.CacheDays);
                                cachemd.dateline = EbSite.Core.SqlDateTimeInt.GetSecond(a);//3�����
                                cachemd.addtime = DateTime.Now.AddDays(3);
                                cachemd.keyid = ContentIdX;
                                cachemd.keytype = 1;
                                cachemd.randomids = ids;

                                ModuleCore.BLL.AskCache.Instance.Add(cachemd);
                                #endregion
                            }
                            #endregion

                            if (md.SiteID == siteid)
                            {
                                if (md.Annex21 != 1)//2.�ѽ�� 3.������  �����ɾ�̬ҳ�洢
                                {
                                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(siteid);
                                    string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mcontent.aspx"), "?site=",
                                                                   SiteID, "&id=", ContentId);
                                    
                                    string CacheUrl = string.Concat(CacheFolder, "content/", md.ClassID, "/", ContentId,
                                                                    ".htm");
                                    e.RealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                                    e.IsStop = true;
                                }
                                else
                                {
                                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(siteid);
                                    string RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mcontent.aspx"), "?site=",
                                                                   siteid, "&id=", ContentId);
                                  
                                    e.RealUrl = RealUrl;
                                    e.IsStop = true;
                                }
                            }
                        }
                    }
                }
                else if (IsMatchReWrite(requestPath, MstrRuleAskPost)) //�ֻ�
                {
                    Match mc = Regex.Match(requestPath, MstrRuleAskPost);
                    if (mc.Success)
                    {

                        int iSiteID = int.Parse(mc.Groups[1].Value);
                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                        string RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mobileaskpost.aspx"), "?site=", iSiteID);
                        e.RealUrl = RealUrl;// EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, RealUrl);
                        e.IsStop = true;
                    }
                }


            }
        }

    }
}