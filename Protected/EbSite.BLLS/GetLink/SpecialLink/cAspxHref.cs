using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.SpecialLink
{
    public class cAspxHref : IBase, ILinkSpecial
    {
        public cAspxHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public  string GetSpecialHref(int iid, int index)
        {
            return string.Concat(IISPath, SpecialLink, "?sid=", iid, "&p=", index, "&site=", SiteID);
        }

        public string GetSpecialHref(int iid, int index, int ClassId)
        {

            return string.Concat(IISPath, SpecialLink, "?sid=", iid, "&p=", index, "&site=", SiteID, "&classid=", ClassId);
        }
    }
}
