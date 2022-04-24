using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using EbSite.BLL.TempInc;
using EbSite.Base;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类Incs 的摘要说明。
	/// </summary>
	public  class TemplateInc
	{
        //const double CacheDuration = 60.0;
        ////private  readonly string[] MasterCacheKeyArray = { "BllTemplateInc" };
        //private static CacheManager bllCache;
	    private TempInc.XMLProvider BllXml;
	    private string _ThemeName = string.Empty;
        private ThemeType _ThemeType = ThemeType.PC;
        public TemplateInc(string ThemeName, ThemeType tt)
		{
            //if (Equals(bllCache,null))
            //{
            //    bllCache = new CacheManager(CacheDuration, new string[] { string.Concat("BllTemplateInc", ThemeName) });
            //}

            _ThemeName = ThemeName;

            _ThemeType = tt;

            BllXml = new XMLProvider(ThemeName,tt);
            
		}

        private string ThemesFolder
        {
            get { return ThemesUtils.GetThemesFolder(_ThemeType); }
        }

		#region  成员方法
       

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public  void Add(EbSite.Entity.Templates model)
		{
            //_IncsList = null;
            BllXml.InsertTemp(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public  void Update(EbSite.Entity.Templates model)
		{
            BllXml.UpdateTemp(model);
            //_IncsList = null;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public  void Delete(Guid ID)
		{
            BllXml.DeleteTemp(ID);
            //_IncsList = null;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public  EbSite.Entity.Templates GetModel(Guid ID)
		{

            return BllXml.SelectTemp(ID);
		}

        //private static List<EbSite.Entity.Templates> _IncsList;
        //private static object _SyncRoot = new object();
        public  List<EbSite.Entity.Templates> IncsList
        {
            get
            {
                return BllXml.FillTemps();
            }
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        public  EbSite.Entity.Templates GetModelByCache(Guid ID)
		{
           return BllXml.SelectTemp(ID);
            //string CacheKey = "IncsModel-" + ID;
            //Entity.Templates model = bllCache.GetCacheItem(CacheKey) as Entity.Templates;
            //if (model == null)
            //{
            //    model = BllXml.SelectTemp(ID);
            //    if (!Equals(model,null))
            //    {
            //        bllCache.AddCacheItem(CacheKey, model);
            //    }
            //    else
            //    {
            //        throw new Exception("找不到相应的模板文件,请在后台修改相应分类(选择你想要的模板)");
            //    }
                 
            //}

            //return model;
		}

        public void RefeshInc()
        {
            //string p = string.Concat(Base.AppStartInit.IISPath,"themes/", EbSite.Base.Host.Instance.CurrentSite.PageTheme, "/pages/");

            string p = string.Empty;

            if (_ThemeType == ThemeType.PC)
            {
                p = string.Concat(Base.AppStartInit.IISPath, "themes/", _ThemeName, "/pages/");
            }
            else
            {
                p = string.Concat(Base.AppStartInit.IISPath, "themesm/", _ThemeName, "/pages/");
            }


            string sPath = HttpContext.Current.Server.MapPath(p);

            foreach (EbSite.Entity.Templates Inc in IncsList)
            {
                if (!Core.FSO.FObject.IsExist(string.Concat(sPath, "\\", Inc.TempFileName), FsoMethod.File))
                {
                    Inc.TemName = "<font color=red>已经不存在</font>";
                    Update(Inc);
                }
            }


            FileInfo[] lst =   Core.FSO.FObject.GetFileListByType(sPath, "inc",true);
            

            foreach (FileInfo info in lst)
            {
                if (!IsHaveTem(info.Name))
                {
                    Entity.Templates mdNC = new Entity.Templates(ThemesFolder);
                    mdNC.TemName = "未命名";
                    mdNC.TempFileName = info.Name;
                    mdNC.Themes = _ThemeName;
                    mdNC.ID = Guid.NewGuid();
                    Add(mdNC);
                }
            }

        }

        public  bool IsHaveTem(string IncName)
        {
            bool IsOK = false;
            foreach (EbSite.Entity.Templates Incs in IncsList)
            {
                if (Incs.TempFileName == IncName)
                {
                    IsOK = true;
                    break;
                }
            }
            return IsOK;
        }


        public  bool IsHaveTem(Guid ID)
        {
            bool IsOK = false;
            foreach (EbSite.Entity.Templates Incs in IncsList)
            {
                if (Incs.ID == ID)
                {
                    IsOK = true;
                    break;
                }
            }
            return IsOK;
        }


		#endregion  成员方法
	}
}

