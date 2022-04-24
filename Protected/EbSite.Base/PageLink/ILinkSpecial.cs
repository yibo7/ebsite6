using System;
using System.Collections.Generic;

using System.Text;
using EbSite.Entity;

namespace EbSite.Base.PageLink
{
    public interface ILinkSpecial
    {
        /// <summary>
        /// 获取专题连接
        /// </summary>
        /// <param name="iID">专题ID</param>
        /// <param name="Index">分页码</param>
        /// <returns></returns>
        string GetSpecialHref(int iID, int Index);

        string GetSpecialHref(int iID, int Index, int ClassId);

    }
}
