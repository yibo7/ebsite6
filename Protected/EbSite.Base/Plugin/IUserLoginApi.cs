using System;
using System.Collections.Generic;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    /// <summary>
    /// 用户登录插件，集成如 qq空间，qq微薄，新浪微薄，开心网，支付宝等的登录困绑,要实现
    /// </summary>
    public interface IUserLoginApi : IProvider
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        string ShowName{ get;}
        /// <summary>
        /// 发送一条微薄信息
        /// </summary>
        /// <param name="sContent"></param>
        void SendMsg(string sContent, string code);

       /// <summary>
        /// 关注一个用户
       /// </summary>
       /// <param name="name">用户名称</param>
       /// <param name="fopenIds">用户ID</param>
        void GuanZhu(string name, string fopenIds, string code);
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetToken(string code);
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetUserIco(string code);
        /// <summary>
        /// 获取用户昵称，真实姓名
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetUserNickName(string code);
      

        /// <summary>
        /// 获取一个用户的信息
        /// </summary>
        /// <returns></returns>
        MembershipUserEb GetUserInfo(string code);

        List<MembershipUserEb> GetFanslist(string code, int pagesize, int pageindex, out int iCount);

        List<MembershipUserEb> GetIdollist(string code, int pagesize, int pageindex, out int iCount);
        /// <summary>
        /// 登录
        /// </summary>
        void Login();
       
        /// <summary>
        /// 登录成功后的返回地址
        /// </summary>
        string BackUrl { get; }

        /// <summary>
        /// 登录接口的名称,前方可能通过这个名称获取相应的实例
        /// </summary>
        string ApiName { get; }

        /// <summary>
        /// 获取相关操作-由于各个网站接口的不确定性，所以采用itype来区分操作
        /// </summary>
        /// <param name="itype">操作类别，在客户端可以输入相关标记来执行相关操作</param>
        void OrtherAction(int itype, string code);
        /// <summary>
        /// 获取其他对象-由于各个网站接口的不确定性，所以采用itype来区分操作
        /// </summary>
        /// <param name="itype">操作类别，在客户端可以输入相关标记来执行相关操作</param>
        /// <returns></returns>
        object GetOrther(int itype, string code);
        /// <summary>
        /// 获取其他对象列表-由于各个网站接口的不确定性，所以采用itype来区分操作
        /// </summary>
        /// <param name="itype">操作类别，在客户端可以输入相关标记来执行相关操作</param>
        /// <returns></returns>
        List<object> GetOrtherList(int itype, string code);
 
       
    }
}

