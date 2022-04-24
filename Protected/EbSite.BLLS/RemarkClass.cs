using System;
using System.Data;
using System.Collections.Generic;
using EbSite.Core.FSO;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类RemarkClass 的摘要说明。
    /// </summary>
    public class RemarkClass : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.RemarkClass>
    {
        //static private readonly DbProviderCms.GetInstance().RemarkClass_RemarkClass dal = new DbProviderCms.GetInstance().RemarkClass_RemarkClass();
       public static readonly RemarkClass Instance = new RemarkClass();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return EbSite.Base.Host.Instance.CurrentSite.GetPathRemarkClass(1);
                //return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/ErrInfo/"));
            }
        }
        private RemarkClass()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        #region  成员方法

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //static public int GetMaxId()
        //{
        //    return DbProviderCms.GetInstance().RemarkClass_GetMaxId();
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //static public bool Exists(int id)
        //{
        //    return DbProviderCms.GetInstance().RemarkClass_Exists(id);
        //}
        static public string GetTemPath
        {
            get
            {
                string sThemes = Base.Host.Instance.CurrentSite.PageTheme;// EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.PageStyle;
                return string.Concat(Base.AppStartInit.IISPath, "themes/", sThemes, "/pages/discusstem.aspx");
            }
        }
        static public string GetTemPathPJ
        {
            get
            {
                string sThemes = Base.Host.Instance.CurrentSite.PageTheme;
                return string.Concat(Base.AppStartInit.IISPath, "themes/", sThemes, "/pages/EvaluatePg.aspx");
            }
        }
        static public string GetTemPathAskRemark
        {
            get
            {
                string sThemes = Base.Host.Instance.CurrentSite.PageTheme;
                return string.Concat(Base.AppStartInit.IISPath, "themes/", sThemes, "/pages/AskRemark.aspx");
            }
        }

        static public string GetNewPath(int ID)
        {
            return GetNewPath(ID,1);
        }
        static public string GetNewPath(int ID,int itype)
        {
            if(itype==1)
            {
                string sThemes = Base.Host.Instance.CurrentSite.PageTheme;// EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.PageStyle;
                string sfName = string.Concat(Base.AppStartInit.IISPath, "themes/", sThemes, "/pages/discuss_", ID, ".aspx");

                return sfName;
            }
            else if (itype == 2)
            {
                string sThemes = Base.Host.Instance.CurrentSite.PageTheme;// EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.PageStyle;
                string sfName = string.Concat(Base.AppStartInit.IISPath, "themes/", sThemes, "/pages/pj_", ID, ".aspx");
                return sfName;
            }
            else
            {
                string sThemes = Base.Host.Instance.CurrentSite.PageTheme;
                string sfName = string.Concat(Base.AppStartInit.IISPath, "themes/", sThemes, "/pages/ask_", ID, ".aspx");

                return sfName;
            }
           
        }
        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        // public int Add(EbSite.Entity.RemarkClass model)
        //{
        //    return base.Add(model);
        //    //model.Themes = Base.Host.Instance.CurrentSite.PageTheme;
            
        //    //return DbProviderCms.GetInstance().RemarkClass_Add(model);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        // public void Update(EbSite.Entity.RemarkClass model)
        //{
        //    base.Update(model);
        //    //model.Themes = Base.Host.Instance.CurrentSite.PageTheme;
        //    //DbProviderCms.GetInstance().RemarkClass_Update(model);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public void Delete(int id)
        //{
        //    base.Delete(id);
        //    //DbProviderCms.GetInstance().RemarkClass_Delete(id);
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.RemarkClass GetModel(int id)
        {
            return base.GetEntity(id);
            //return DbProviderCms.GetInstance().RemarkClass_GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EbSite.Entity.RemarkClass> GetModelList()
        {
            return base.FillList();
        }


        #endregion  成员方法

        
    }
}

