using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.EntityAPI
{
    /// <summary>
    /// 快递查询返回数据对像
    /// </summary>
   [Serializable]
    public class KuaiDi
    {
        public KuaiDi()
        {
            Data =new List<KuaiDiData>();
        }
        /// <summary>
        /// 物流公司编号
        /// </summary>
        public string Com { get; set; }
        /// <summary>
        /// 物流单号
        /// </summary>
        public string Number { get; set; }
       
        /// <summary>
        /// 快递单当前的状态,0：在途中, 1：已发货， 2：疑难件， 3：已签收， 4：已退货。 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 查询结果状态：0：物流单暂无结果， 1：查询成功， 2：接口出现异常。
        /// </summary>
        public string QStatus { get; set; }

        public List<KuaiDiData> Data;

    }

    public class KuaiDiData
    {
        /// <summary>
        /// 每条跟踪信息的时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 每条跟综信息的描述
        /// </summary>
        public string Context { get; set; }
    }
}
