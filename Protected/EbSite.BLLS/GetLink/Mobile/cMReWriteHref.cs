using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.Mobile
{
    public class cMReWriteHref : EbSite.Base.PageLink.IMobileHref
    {
        public cMReWriteHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
       override public string GetIndexHref()
        {
            return string.Concat(Folder, SiteID, MIndexLinkRw);
        }
       public override string GetClassHref()
       {
           return string.Concat(Folder,SiteID, MClassLinkRw);
       }
       override public string GetClassHref(object iId, int PageIndex, int OrderBy)
        {
            return string.Concat(Folder, iId, "-", PageIndex, "-", OrderBy, "-", SiteID, MClassLinkRw);
        }
       override public string GetClassHref(object iId, int PageIndex)
        {
            return GetClassHref(iId, PageIndex,0);
        }

       //override public string GetContentLink(object iId)
       // {
       //     return string.Concat(Folder, iId, "-", SiteID,MContentLinkRw);
       // }
       override  public string GetContentLink(object iId, object ClassID,object PageIndex)
       {
           return string.Concat(Folder, ClassID, "-", iId, "-", SiteID, "-", PageIndex, MContentLinkRw);
       }

       override public string GetSpecialHref(object iId, int PageIndex)
       {
           return string.Concat(Folder, iId, "-", PageIndex, "-", SiteID, MSpecialLinkRw);
       }
       override public string GetSpecialHref()
       {
           return string.Concat(Folder,SiteID, MSpecialLinkRw);
       }
       override public string GetTagsHref(int PageIndex)
       {
           return string.Concat(Folder, SiteID, "-", PageIndex, Base.Configs.ContentSet.ConfigsControl.Instance.MTaglistRw);
       }

       override public string GetTagvHref(object iId, int PageIndex)
       {
           return string.Concat(Folder, SiteID, "-", iId, "-", PageIndex, Base.Configs.ContentSet.ConfigsControl.Instance.MTagSearchRw);
       }
    }
}
