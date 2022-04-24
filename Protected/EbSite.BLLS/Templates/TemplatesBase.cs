using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Web;
using EbSite.BLL.Tem;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;
using System.Linq;
namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类Templates 的摘要说明。
    /// </summary>
   abstract public class TemplatesBase 
    {
       const double cachetime = 3000.0;
        //private static CacheManager bllCache;
        public string _ThemeName;
        private Tem.XMLProvider bllTemplates;
        public TemplateInc IncBll;
       virtual public ThemeType eThemeType
        {
            get { return ThemeType.PC; }
        }
        public TemplatesBase(string ThemeName)
        {
            //if (string.IsNullOrEmpty(ThemeName))
            //    throw new Exception("皮肤目录不能为空！");

            _ThemeName = ThemeName;
            bllTemplates = new XMLProvider(ThemeName, eThemeType);
    
            IncBll = new TemplateInc(ThemeName, eThemeType);
        }
        #region  成员方法

        protected abstract string MasterCacheKeyArray { get; }

        protected  string sDefault_TemPath 
        { 
            get
            {
                return string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "\\", ThemesFolder, "\\", _ThemeName, "\\pages");
            } 
        }

        public  string ThemesFolder 
        { 
            get { return ThemesUtils.GetThemesFolder(eThemeType); } 
        }

       //abstract protected  string sDefault_TemPath
       // {
       //     get
       //     {
       //         return string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "\\themes\\", _ThemeName, "\\pages");
       //     }
       // }
        /// <summary>
        /// 获取默认首页模板代码
        /// </summary>
        public  string sDefault_IndexHTML()
        {
           
                
                return Core.FSO.FObject.ReadFile(string.Concat(sDefault_TemPath, "\\index.aspx"));
            
        }
        /// <summary>
        /// 获取默认列表页模板代码
        /// </summary>
        public  string sDefault_ListHTML()
        {
           
                return Core.FSO.FObject.ReadFile(string.Concat(sDefault_TemPath, "\\list.aspx"));
          
        }
        /// <summary>
        /// 获取默认专题页模板代码
        /// </summary>
        public  string sDefault_SpecialHTML()
        {
            
                return Core.FSO.FObject.ReadFile(string.Concat(sDefault_TemPath, "\\special.aspx"));
          
        }
        /// <summary>
        /// 获取默认表单页模板代码
        /// </summary>
        public  string sDefault_FormHTML()
        {
           
                return Core.FSO.FObject.ReadFile(string.Concat(sDefault_TemPath, "\\customform.aspx"));
       
        }
        /// <summary>
        /// 获取默认内容页模板代码
        /// </summary>
        public  string sDefault_ContentHTML()
        {
            
                return Core.FSO.FObject.ReadFile(string.Concat(sDefault_TemPath, "\\content.aspx"));
            
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public  void Add(EbSite.Entity.Templates model)
        {
            Host.CacheApp.InvalidateCache(MasterCacheKeyArray);//bllCache.InvalidateCache();
            bllTemplates.InsertTemp(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public  void Update(EbSite.Entity.Templates model)
        {
            bllTemplates.UpdateTemp(model);
            Host.CacheApp.InvalidateCache(MasterCacheKeyArray);// bllCache.InvalidateCache();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public  void Delete(Guid ID)
        {
            bllTemplates.DeleteTemp(ID);
            Host.CacheApp.InvalidateCache(MasterCacheKeyArray); //bllCache.InvalidateCache();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  EbSite.Entity.Templates GetModel(Guid ID)
        {

            return bllTemplates.SelectTemp(ID);
        }
        public  EbSite.Entity.TemClass GetTemClass(int ID)
        {
            EbSite.Entity.TemClass md = null;
            List<EbSite.Entity.TemClass> lst = GetTemClass();
            foreach (TemClass temClass in lst)
            {
                if (temClass.ClassID == ID)
                {
                    md = temClass;
                    break;
                }
            }

            return md;
        }

        public  List<EbSite.Entity.TemClass> GetTemClass()
        {
            List<EbSite.Entity.TemClass> lst = new List<TemClass>();
            Entity.TemClass Index = new TemClass();
            Index.ClassID = 0;
            Index.ClassName = "首页";
            Index.PrefixName = "index_";
            lst.Add(Index);

            Index = new TemClass();
            Index.ClassID = 1;
            Index.ClassName = "分类页";
            Index.PrefixName = "list_";
            lst.Add(Index);


            Index = new TemClass();
            Index.ClassID = 2;
            Index.ClassName = "内容页";
            Index.PrefixName = "content_";
            lst.Add(Index);


            Index = new TemClass();
            Index.ClassID = 3;
            Index.ClassName = "专题页";
            Index.PrefixName = "special_";
            lst.Add(Index);


            Index = new TemClass();
            Index.ClassID = 4;
            Index.ClassName = "其他";
            Index.PrefixName = "orther_";
            lst.Add(Index);

            //Index = new TemClass();
            //Index.ClassID = 4;
            //Index.ClassName = "表单（提交类，如订单，留言，报名系统等）";
            //Index.PrefixName = "form_";
            //lst.Add(Index);

            return lst;

        }
        //private static List<EbSite.Entity.Templates> _TemplatesList;
        //private static object _SyncRoot = new object();

        //public static List<EbSite.Entity.Templates> TemplatesList(string themeName)
        /// <summary>
        /// 有的时候复制过来的模板，数据还保留着原来的themename,所以这个方法用来检查是否包含不是当前皮肤下载模板数据
        /// </summary>
        /// <returns></returns>
        public int GetCountNoInCurrent()
        {
            int i = 0;
            List<EbSite.Entity.Templates> lst = TemplatesList();
            foreach (EbSite.Entity.Templates templates in lst)
            {
                if (templates.Themes != _ThemeName)
                {
                    i++;
                }
            }
            return i;
        }
        public void ResetNoInCurrent()
        {
           
            List<EbSite.Entity.Templates> lst = TemplatesList();
            foreach (EbSite.Entity.Templates templates in lst)
            {
                if (templates.Themes != _ThemeName)
                {
                    templates.Themes = _ThemeName;
                    Update(templates);
                }
            }
            
        }
        public void RefeshTemp()
        {

            //string p = string.Concat(Base.AppStartInit.IISPath, "themes/", EbSite.Base.Host.Instance.CurrentSite.PageTheme, "/pages/");
            string p = string.Concat(Base.AppStartInit.IISPath, ThemesFolder, "/", _ThemeName, "/pages/");

            string sPath = HttpContext.Current.Server.MapPath(p);
            List<Entity.Templates> lstTem =  bllTemplates.FillTemps();
            foreach (EbSite.Entity.Templates Inc in lstTem)
            {
                if (!Core.FSO.FObject.IsExist(string.Concat(sPath, "\\", Inc.TempFileName), FsoMethod.File))
                {
                    Inc.TemName = "<font color=red>已经不存在</font>";
                    Update(Inc);
                }
            }


            FileInfo[] lst = Core.FSO.FObject.GetFileListByType(sPath, "aspx", true);


            foreach (FileInfo info in lst)
            {
                if (!IsHaveTem(info.Name))
                {


                    Entity.Templates mdNC = new Entity.Templates(ThemesFolder);

                    mdNC.TemName = "未命名";
                    mdNC.TemType = 4;//归类为其他
                    mdNC.IsNoSysTem = true;
                    mdNC.Themes = _ThemeName;// EbSite.Base.Host.Instance.CurrentSite.PageTheme;
                    mdNC.TempFileName = info.Name;
                    mdNC.ID = Guid.NewGuid();
                    Add(mdNC);

                }
            }

        }
        public  bool IsHaveTem(string TempName)
        {
            List<Entity.Templates> lstTem = bllTemplates.FillTemps();
            bool IsOK = false;
            foreach (EbSite.Entity.Templates Incs in lstTem)
            {
                if (Incs.TempFileName == TempName)
                {
                    IsOK = true;
                    break;
                }
            }
            return IsOK;
        }
        public  List<EbSite.Entity.Templates> TemplatesList()
        {

            string CacheKey = string.Concat("TemplatesList-", _ThemeName,"-", ThemesFolder);
            List<EbSite.Entity.Templates> _TemplatesList = Host.CacheRawApp.GetCacheItem<List<EbSite.Entity.Templates>>(CacheKey, MasterCacheKeyArray);//bllCache.GetCacheItem(CacheKey) as List<EbSite.Entity.Templates>;
                if (_TemplatesList == null)
                {
                    _TemplatesList = bllTemplates.FillTemps();
                    if (!Equals(_TemplatesList, null))
                    {
                        Host.CacheRawApp.AddCacheItem(CacheKey, _TemplatesList, cachetime, ETimeSpanModel.M, MasterCacheKeyArray);//bllCache.AddCacheItem(CacheKey, _TemplatesList);
                    }

                }

                if (_TemplatesList == null)
                    _TemplatesList = new List<Entity.Templates>();

                return _TemplatesList.OrderByDescending(d => d.AddDate).ToList();
         
        }
        public string GetTemPathByCache(Guid ID)
        {
            string CacheKey = string.Concat("GetTemPath-", ID, "-", EbSite.Base.Host.Instance.GetSiteID);
            //string CacheKey = string.Concat("GetTemPath-", ID);
            string TemPath = Host.CacheRawApp.GetCacheItem<string>(CacheKey, MasterCacheKeyArray);//bllCache.GetCacheItem(CacheKey) as string;
            if (string.IsNullOrEmpty(TemPath))
            {
                EbSite.Entity.Templates md = bllTemplates.SelectTemp(ID);
                if (!Equals(md, null))
                {
                    TemPath = md.TemPath;
                    Host.CacheRawApp.AddCacheItem(CacheKey, TemPath, cachetime, ETimeSpanModel.M, MasterCacheKeyArray);// bllCache.AddCacheItem(CacheKey, TemPath);
                }
                else
                {
                    throw new Exception("找不到相应的模板文件,请在后台修改相应分类(选择你想要的模板)");
                }

            }

            return TemPath;
        }
        private static object _SyncRoot = new object();
        private Dictionary<string, Templates> Templates = new Dictionary<string, Templates>();//所有站点连接对象
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public  EbSite.Entity.Templates GetModelByCache(Guid ID,int siteid)
        {
            string key = string.Concat("tm_", ID, "_", siteid);

            Entity.Templates model;

            if (Templates.ContainsKey(key))
                model = Templates[key];
            else
            {
                lock (_SyncRoot)
                {
                    if (!Templates.ContainsKey(key))
                    {
                        model = bllTemplates.SelectTemp(ID);
                        Templates.Add(key, model);
                    }
                    else
                    {
                        model = Templates[key];
                    }
                }

            }
            return model;

            //string CacheKey = string.Concat("tm_", ID, "_", siteid);
            //Entity.Templates model = Host.CacheApp.GetCacheItem<Entity.Templates>(CacheKey, MasterCacheKeyArray);// bllCache.GetCacheItem(CacheKey) as Entity.Templates;
            //if (model == null)
            //{
            //    model = bllTemplates.SelectTemp(ID);
            //    if (!Equals(model, null))
            //    {
            //        Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.秒, MasterCacheKeyArray);// bllCache.AddCacheItem(CacheKey, model);
            //    }
            //    else
            //    {
            //        throw new Exception("找不到相应的模板文件,请在后台修改相应分类(选择你想要的模板)");
            //    }

            //}

            //return model;
        }
        //public static bool IsHaveTem(Guid ID,string themeName)
        public  bool IsHaveTem(Guid ID)
        {
            bool IsOK = false;
            foreach (EbSite.Entity.Templates templates in TemplatesList())
            {
                if (templates.ID == ID)
                {
                    IsOK = true;
                    break;
                }
            }
            return IsOK;
        }


        /// <summary>
        /// 获取模板
        /// </summary>
        /// <param name="Type">0为首页类，1不分类页类，2为内容页类，3为专题面页类</param>
        /// <returns></returns>
         //public static List<EbSite.Entity.Templates> GetListByType(int Type, string themesName)
        public  List<EbSite.Entity.Templates> GetListByType(int Type)
        {
            List<EbSite.Entity.Templates> lst = TemplatesList();//themesName
            List<EbSite.Entity.Templates> lstNew = new List<EbSite.Entity.Templates>();
            foreach (EbSite.Entity.Templates templates in lst)
            {
                if (templates.TemType == Type)
                {
                    lstNew.Add(templates);
                }
            }

            return lstNew;
        }

       //public string NewTempFileName(int TemType)
       //{

       //    //生成模板文件
       //    string sfName = Path.GetRandomFileName();
       //    string sPre = GetTemClass(TemType).PrefixName;


       //    string sFileName = string.Concat(sPre, sfName, ".aspx");
       //    return string.Concat(Base.AppStartInit.IISPath,ThemesFolder, "/", _ThemeName, "/pages/", sFileName);
       //}


        #region 插入模板标签



         public List<Entity.ListItemModel> GetAllColumns()
        {
            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            Entity.ListItemModel md;

            md = new ListItemModel();
            md.Text = "网站域名";
            md.Value = "<%=DomainName%>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "网站名称";
            md.Value = "<%=SiteName%>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "底部版权信息";
            md.Value = "<%=EbSite.Configs.SysConfigs.ConfigsControl.Instance.Copyright %>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "用户状态探测(放在底部)";
            md.Value = "<%=KeepUserState()%>";
            lst.Add(md);

            //md = new ListItemModel();
            //md.Text = "网站留言板";
            //md.Value = string.Format("<iframe id=\"xscomment\" style=\"width:100%;\" src=\"{0}?cid=3&mk=none\" frameBorder=0  scrolling=no ></iframe>", BLL.RemarkClass.GetNewPath(3));
            //lst.Add(md);

            return lst;
        }
         public List<Entity.ListItemModel> GetContentColumnsForList()
        {
            return GetContentColumnsForList(Guid.Empty);
        }

         public List<Entity.ListItemModel> GetContentColumnsForList(Guid ModelID)
        {

            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            Entity.ListItemModel md;

            md = new ListItemModel();
            md.Text = "内容标题(带连接)";
            md.Value = "<a href=\"<%#EbSite.Base.Host.Instance.GetContentLink(Eval(\"id\"),Eval(\"HtmlName\"),Eval(\"classid\"))%>\"><%#Eval(\"newstitle\")%></a>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "内容标题连接地址";
            md.Value = "<%#EbSite.Base.Host.Instance.GetContentLink(Eval(\"id\"),Eval(\"HtmlName\"),Eval(\"classid\"))%>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "发表日期";
            md.Value = string.Format("<%#Eval(\"{0}\")%>", "AddTime");
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "发表人昵称";
            md.Value = string.Format("<%#Eval(\"{0}\")%>", "UserNiName");
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "发表人主页";
            md.Value = string.Format("<a href=\"<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval(\"{0}\")) %>\"><font color=\"red\"><%#Eval(\"{1}\")%></font></a> ", "UserName", "UserNiName");
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "发表人帐号";
            md.Value = string.Format("<%#Eval(\"{0}\")%>", "UserName");
            lst.Add(md);


            if (ModelID != Guid.Empty)
            {
                ModelClass mc = BLL.WebModel.Instance.GeModelByID(ModelID);

                foreach (ColumFiledConfigs configs in mc.GetUsedFileds())
                {
                    md = new ListItemModel();
                    md.Text = configs.ColumShowName;
                    md.Value = configs.BindCoreForPageTemAdv2;
                    lst.Add(md);
                }
            }
            else
            {
                string[] aC = BLL.WebModel.Instance.aColums;

                foreach (string s in aC)
                {
                    string[] aCs = s.Split('|');

                    string sText = aCs[1];
                    string sValue = aCs[0];

                    md = new ListItemModel();
                    md.Text = string.Format("{0}({1})", sText, sValue);
                    md.Value = string.Format("<%#Eval(\"{0}\")%>", sValue);
                    lst.Add(md);
                }

            }


            return lst;
        }
         public List<Entity.ListItemModel> GetContentColumns()
        {
            return GetContentColumns(Guid.Empty);
        }

         public List<Entity.ListItemModel> GetContentColumns(Guid ModelID)
        {

            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            Entity.ListItemModel md = new ListItemModel();


            md = new ListItemModel();
            md.Text = "当前分类名称(带连接)";
            md.Value = "<a href=\"<%= EbSite.Base.Host.Instance.GetClassHref(Model.ClassID,0)%>\" ><%=Model.ClassName %></a>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "当前分类连接";
            md.Value = "<%= EbSite.Base.Host.Instance.GetClassHref(Model.ClassID,0)%>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "当前分类ID";
            md.Value = "<%= Model.ClassID %>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "点击收藏内容";
            md.Value = "<a href=\"#2\" onClick=\"FavContent('<%=Model.ID %>')\" >收藏</a>";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "收藏统计";
            md.Value = "<script src=\"<%=IISPath%>ajaxget/GetCount.ashx?id=<%=Model.ID %>&t=5\" type='text/javascript' language=\"javascript\"></script>";
            lst.Add(md);


            //md = new ListItemModel();
            //md.Text = "内容留言评论";
            //md.Value = string.Format("<iframe name=\"pliframe\" id=\"xscomment\" style=\"width:100%;\" src=\"{0}?cid=1&mk=<%=Model.ID %>\" frameBorder=0  scrolling=no ></iframe>", BLL.RemarkClass.GetNewPath(1));
            //lst.Add(md);

            md = new ListItemModel();
            md.Text = "留言评论统计";
            md.Value = "<script src=\"<%=IISPath%>ajaxget/GetCount.ashx?id=<%=Model.ID %>&t=6\" type='text/javascript' language=\"javascript\"></script>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "内容标题(带连接)";
            md.Value = "<a href='<%=EbSite.Base.Host.Instance.GetContentLink(Model.ID,Model.HtmlName,Model.Classid) %>'><%=Model.NewsTitle%></a> ";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "内容连接地址";
            md.Value = "<%=EbSite.Base.Host.Instance.GetContentLink(Model.ID,Model.HtmlName,Model.Classid) %> ";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "上一条记录标题(带连接)";
            md.Value = "<a href='<%=EbSite.Base.Host.Instance.GetContentLink(UpModel.ID,UpModel.HtmlName,UpModel.Classid) %>'><%=UpModel.NewsTitle%></a> ";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "上一条记录连接";
            md.Value = "<%=EbSite.Base.Host.Instance.GetContentLink(UpModel.ID,UpModel.HtmlName,UpModel.Classid) %>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "下一条记录标题(带连接)";
            md.Value = "<a href='<%=EbSite.Base.Host.Instance.GetContentLink(NextModel.ID,NextModel.HtmlName,NextModel.ClassID) %>'><%=NextModel.NewsTitle%></a>  ";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "下一条记录连接";
            md.Value = "<%=EbSite.Base.Host.Instance.GetContentLink(NextModel.ID,NextModel.HtmlName) %>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "发表日期";
            md.Value = "<%=Model.AddTime %>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "发表人昵称";
            md.Value = "<%=Model.UserNiName %>";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "发表人主页";
            md.Value = "<a href=\"<%=EbSite.Base.Host.Instance.GetUserSiteUrl(Model.UserName) %>\"><font color=\"red\"><%=Model.UserNiName %></font></a> ";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "发表人帐号";
            md.Value = "<%=Model.UserName %>";
            lst.Add(md);
            if (ModelID != Guid.Empty)
            {
                ModelClass mc = BLL.WebModel.Instance.GeModelByID(ModelID);

                foreach (ColumFiledConfigs configs in mc.GetUsedFileds())
                {
                    md = new ListItemModel();
                    md.Text = configs.ColumShowName;
                    md.Value = configs.BindCoreForPageTemAdv2;
                    lst.Add(md);
                }
            }
            else
            {
                string[] aC = BLL.WebModel.Instance.aColums;
                foreach (string s in aC)
                {
                    string[] aCs = s.Split('|');

                    string sText = aCs[1];
                    string sValue = aCs[0];

                    md = new ListItemModel();
                    md.Text = string.Format("{0}({1})", sText, sValue);
                    md.Value = string.Format("<%=Model.{0}%>", sValue.Trim());
                   
                    lst.Add(md);
                }
            }


            return lst;
        }

         public List<Entity.ListItemModel> GetClassColumns()
        {
            return GetClassColumns(Guid.Empty);
        }

         public List<Entity.ListItemModel> GetClassColumns(Guid ModelID)
        {

            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            Entity.ListItemModel md = new ListItemModel();


            md = new ListItemModel();
            md.Text = "分类名称(带连接)";
            md.Value = "<a href=\"<%= EbSite.Base.Host.Instance.GetClassHref(Model.ID,0)%>\" target=\"_self\"><%=Model.ClassName %></a> ";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "分类连接地址";
            md.Value = "<%= EbSite.Base.Host.Instance.GetClassHref(Model.ID,0)%>";
            lst.Add(md);

            //md = new ListItemModel();
            //md.Text = "分类留言评论";
            //md.Value = string.Format("<iframe id=\"xscomment\" style=\"width:100%;\" src=\"{0}?cid=4&mk=<%=Model.ID %>\" frameBorder=0  scrolling=no ></iframe>", BLL.RemarkClass.GetNewPath(4));
            //lst.Add(md);

            md = new ListItemModel();
            md.Text = "排序连接-发布时间";
            md.Value = "<li class='<%=GetOrbderByClass(0) %>'><a href=\"<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,0) %>\"><span>发布时间</span></a></li>";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "排序连接-点击次数";
            md.Value = "<li class='<%=GetOrbderByClass(1) %>' ><a href=\"<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,1) %>\"><span>点击次数</span></a></li>";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "排序连接-收藏";
            md.Value = "<li class='<%=GetOrbderByClass(2) %>' ><a href=\"<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,2) %>\"><span>收藏</span></a></li>";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "排序连接-评论";
            md.Value = "<li class='<%=GetOrbderByClass(3) %>' ><a href=\"<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,3) %>\"><span>评论</span></a></li>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "排序连接-好评";
            md.Value = "<li class='<%=GetOrbderByClass(4) %>' ><a href=\"<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,4) %>\"><span>好评</span></a></li>";
            lst.Add(md);

            if (ModelID == Guid.Empty)
            {
                string[] aC = BLL.ClassModel.Instance.aColums;
                foreach (string s in aC)
                {
                    string[] aCs = s.Split('|');

                    string sText = aCs[1];
                    string sValue = aCs[0];

                    md = new ListItemModel();
                    md.Text = string.Format("{0}({1})", sText, sValue);
                    md.Value = string.Format("<%=Model.{0}%>", sValue.Trim());
                    lst.Add(md);
                }
            }
            else
            {
                ModelClass mc = BLL.ClassModel.Instance.GeModelByID(ModelID);
                foreach (ColumFiledConfigs configs in mc.GetUsedFileds())
                {
                    md = new ListItemModel();
                    md.Text = configs.ColumShowName;
                    md.Value = configs.BindCoreForPageTemAdv2;
                    lst.Add(md);
                }
            }
           
            return lst;
        }

         public List<Entity.ListItemModel> GetClassColumnsForList()
        {

            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            Entity.ListItemModel md = new ListItemModel();


            md = new ListItemModel();
            md.Text = "分类名称(带连接)";
            md.Value = string.Format("<a href=\"<%#EbSite.Base.Host.Instance.GetClassHref(Eval(\"{0}\"),0)%>\" target=\"_self\"><%# Eval(\"{1}\") %></a> ", "ID", "ClassName");
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "分类连接地址";
            md.Value = string.Format("<%#EbSite.Base.Host.Instance.GetClassHref(Eval(\"{0}\"),0)%>", "ID");
            lst.Add(md);

            string[] aC = BLL.ClassModel.Instance.aColums;

            foreach (string s in aC)
            {
                string[] aCs = s.Split('|');

                string sText = aCs[1];
                string sValue = aCs[0];

                md = new ListItemModel();
                md.Text = string.Format("{0}({1})", sText, sValue);
                md.Value = string.Format("<%#Eval(\"{0}\")%>", sValue);
                lst.Add(md);
            }

            return lst;
        }

         public List<Entity.ListItemModel> GetSpecialColumns()
        {

            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            Entity.ListItemModel md = new ListItemModel();

            md.Text = "专题ID";
            md.Value = "<%=Model.ID%>";
            lst.Add(md);



            md = new ListItemModel();
            md.Text = "专题名称";
            md.Value = "<%=Model.SpecialName%>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "专题名称(带连接)";
            md.Value = "<a href=\"<%= EbSite.Base.Host.Instance.GetSpecialHref(Model.id,0)%>\" target=\"_self\"><%=Model.SpecialName%> </a>   ";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "当前专题连接";
            md.Value = "<%= EbSite.Base.Host.Instance.GetSpecialHref(Model.id,0)%>";
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "排序ID";
            md.Value = "<%=Model.Orderid%>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "标题样式";
            md.Value = "<%=Model.Titletype%>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "外部连接";
            md.Value = "<%=Model.Outlink%>";
            lst.Add(md);


            return lst;

        }
         public List<Entity.ListItemModel> GetSpecialColumnsForList()
        {

            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            Entity.ListItemModel md = new ListItemModel();

            md.Text = "专题ID";
            md.Value = string.Format("<%#Eval(\"{0}\")%>", "ID");
            lst.Add(md);


            md = new ListItemModel();
            md.Text = "专题名称";
            md.Value = string.Format("<%#Eval(\"{0}\")%>", "SpecialName");
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "专题名称(带连接)";
            md.Value = string.Format("<a href=\"<%# EbSite.Base.Host.Instance.GetSpecialHref(Eval(\"{0}\"),0)%>\" target=\"_self\"><%# Eval(\"{1}\")%> </a>   ", "ID", "SpecialName");
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "专题连接";
            md.Value = string.Format("<%# EbSite.Base.Host.Instance.GetSpecialHref(Eval(\"{0}\"),0)%>", "ID");
            lst.Add(md);
            md = new ListItemModel();
            md.Text = "排序ID";
            md.Value = string.Format("<%#Eval(\"{0}\")%>", "Orderid");
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "标题样式";
            md.Value = string.Format("<%#Eval(\"{0}\")%>", "Titletype"); //"<%=Model.Titletype%>";
            lst.Add(md);

            md = new ListItemModel();
            md.Text = "外部连接";
            md.Value = string.Format("<%#Eval(\"{0}\")%>", "Outlink"); //"<%=Model.Outlink%>";
            lst.Add(md);


            return lst;

        }

        #endregion


        #endregion  成员方法
    }
}

