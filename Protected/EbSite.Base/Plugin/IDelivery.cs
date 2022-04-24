using System;
using System.Collections.Generic;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    /// <summary>
    /// 快递查询
    /// </summary>
    public interface IDelivery : IProvider
    {

        /// <summary>
        /// 查询快递返回状态
        /// </summary>
        /// <param name="com">要查询的快递公司代码，不支持中文，对应的公司代码见</param>
        /// <param name="number">要查询的快递单号，请勿带特殊符号，不支持中文（大小写不敏感）</param>
        /// <param name="datatype">返回类型：0：返回json字符串， 1：返回xml对象， 2：返回html对象， 3：返回text文本。 </param>
        /// <param name="muti">返回信息数量：1:返回多行完整的信息， 0:只返回一行信息。 不填默认返回多行。</param>
        /// <param name="orderby">排序方式:0 按时间由新到旧排列，1 按时间由旧到新排列</param>
        /// <returns></returns>
        string GetStatusStr(string com, string number, int datatype, int muti, int orderby);
        KuaiDi GetStatusList(string com, string number,  int orderby);
        /// <summary>
        /// 配送方网址
        /// </summary>
        string Url { get; }

    }
}

