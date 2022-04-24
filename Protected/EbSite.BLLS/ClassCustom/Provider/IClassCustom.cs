using System;
using System.Collections.Generic;
using System.Data;
namespace EbSite.BLL.ClassCustom.Provider
{
	/// <summary>
	/// 业务逻辑类CountData 的摘要说明。
	/// </summary>
    public abstract class IClassCustom
	{
	    protected string LogsFolder
	    {
	        get
	        {
                return EbSite.Base.Host.Instance.CurrentSite.GetPathClassCustom(1);

                //string p = "datastore/ClassCustom";
                //return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, p);
	        }
	    }
        /// <summary>
        ///查询一个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Entity.ClassCustom Select(Guid id);
        /// <summary>
        /// 写入一个
        /// </summary>
        /// <param name="model"></param>
        public abstract void Insert(EbSite.Entity.ClassCustom model);
        /// <summary>
        /// 更新一个
        /// </summary>
        /// <param name="model"></param>
        public abstract void Update(EbSite.Entity.ClassCustom model);
        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="model"></param>
        public abstract void Delete(EbSite.Entity.ClassCustom model);
        public abstract void Delete(string gid);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public abstract List<EbSite.Entity.ClassCustom> Fills();
		
	}
}

