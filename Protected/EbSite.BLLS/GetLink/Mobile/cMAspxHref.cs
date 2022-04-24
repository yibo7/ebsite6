using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.Mobile
{
    public class cMAspxHref : EbSite.Base.PageLink.IMobileHref
    {
        public cMAspxHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
      override  public string GetIndexHref()
        {
            if (SiteID > 1)
            {
                return string.Concat(MIndexLink, "?site=", SiteID);

            }
            else
            {
                return MIndexLink;
            }

        }

        public override string GetClassHref()
        {
            return string.Concat(MClassLink, "?site=", SiteID);
        }

        override public string GetClassHref(object iId, int PageIndex, int OrderBy)
        {
            return string.Concat(MClassLink, "?cid=", iId, "&p=", PageIndex, "&odb=", OrderBy, "&site=", SiteID);
        }
      override public string GetClassHref(object iId, int PageIndex)
        {
            return GetClassHref(iId, PageIndex,0);
        }

      //override public string GetContentLink(object iId)
      //  {
      //      return string.Concat(MContentLink, "?id=", iId, "&site=", SiteID, "&pi=0");
      //  }
      override public string GetContentLink(object iId, object ClassID,object PageIndex)
      {
          return string.Concat(MContentLink, "?id=", iId, "&site=", SiteID, "&cid=", ClassID, "&pi=", PageIndex);
      }
      override public string GetSpecialHref(object iId, int PageIndex)
      {
          return string.Concat(MSpecialLink, "?sid=", iId, "&site=", SiteID,"&p=", PageIndex);
      }
      override public string GetSpecialHref()
      {
          return string.Concat(MSpecialLink, "?site=", SiteID);
      }
        override public string GetTagsHref(int PageIndex)
        {
            return string.Concat(MTaglistLink, "?site=", SiteID, "&p=", PageIndex);
        }

        override public string GetTagvHref(object iId, int PageIndex)
        {
            return string.Concat(MTagsSearchListLink, "?site=", SiteID, "&tid=", iId, "&p=", PageIndex);
        }

    }
}
