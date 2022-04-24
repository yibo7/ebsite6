using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.PageLink
{
    public abstract class IMobileHref : IBase
    {
       abstract public string GetIndexHref();
       abstract public  string GetClassHref(object iId, int PageIndex,int OrderBy);
       abstract public string GetClassHref(object iId, int PageIndex);

       //abstract public  string GetContentLink(object iId);
       abstract public string GetContentLink(object iId, object ClassID, object PageIndex);
       abstract public string GetClassHref();

       abstract public string GetSpecialHref(object iId, int PageIndex);
       abstract public string GetSpecialHref();

       public abstract string GetTagsHref(int PageIndex);
       public abstract string GetTagvHref(object iId, int PageIndex);

       //abstract public string GetUccHref();

        protected string Folder
        {
            get { return AppStartInit.MPathUrl; }
        }

        ///// <summary>
        ///// 获取分类页相对路径(不带参)
        ///// </summary>
        //public string ClassLinkRw
        //{
        //    get
        //    {
        //        return Base.Configs.ContentSet.ConfigsControl.Instance.MListPathRw;
        //    }
        //}
        ///// <summary>
        ///// 获取内容页相对路径(不带参)
        ///// </summary>
        //public string ContentLinkRw
        //{
        //    get
        //    {
        //        return Base.Configs.ContentSet.ConfigsControl.Instance.MContentPathRw;
        //    }
        //}
        ///// <summary>
        ///// 获取专题页相对路径(不带参)
        ///// </summary>
        //public string SpecialLinkRw
        //{
        //    get
        //    {
        //        return Base.Configs.ContentSet.ConfigsControl.Instance.MSpecialPathRw;
        //    }
        //}
    }
}
