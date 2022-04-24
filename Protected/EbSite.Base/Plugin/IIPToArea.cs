using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Plugin.Base;
using EbSite.Entity;

namespace EbSite.Base.Plugin
{
    public interface IIPToArea : IProvider
    {
        /// <summary>
        /// 查询一个IP对应的详细信息，包含国家，地区，城市等
        /// </summary>
        /// <param name="IP">要查询的Ip</param>
        /// <returns></returns>
        ClientIpInfo Query(string IP);
    }
}
