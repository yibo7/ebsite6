using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using EbSite.BLL;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.DataProfile;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.EntityAPI;
using EbSite.Base.EntityCustom;
using EbSite.Base.Json;
using EbSite.Core;
using EbSite.Entity;
using Favorite = EbSite.Entity.Favorite;
using NewsClass = EbSite.Entity.NewsClass;
using PsAreaPrice = EbSite.Entity.PsAreaPrice;
using PsFreight = EbSite.Entity.PsFreight;
using SpecialClass = EbSite.Entity.SpecialClass;
using System.Web.Security;

namespace EbSite.Base
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class MainWebServiceBase : WebServiceBase
    {
        [WebMethod(EnableSession = true)]
        public JsonResponse FindPassMobile(string mbnumber, string code)
        {
            
                if (Core.Strings.Validate.IsMobile(mbnumber))
                {
                    if (EbSite.BLL.User.MembershipUserEb.Instance.ExistsMobile(mbnumber))
                    {
                        //获取手机验证码
                        string sSafeCode = code;
                        bool isok = EbSite.BLL.User.UserIdentity.ValidateSafeCodeMobile(sSafeCode, false);

                        if (isok)
                        {
                            MembershipUser mu = Membership.GetUser(mbnumber);
                            if (!Equals(mu, null))
                            {
                                //string iisPath = Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath;

                                string ActivateCorde = EbSite.BLL.User.MembershipUserEb.Instance.GetActivateEncode(mbnumber, mu.GetPassword(), 0, 0);

                                string sUrlFull = string.Format("{0}?act={1}&mc={2}",  Host.Instance.LostpasswordRw, ActivateCorde,  Host.Instance.EncodeByKey(mbnumber));

                                //用这个时间来代替
                                mu.LastActivityDate = DateTime.Now;
                                Membership.UpdateUser(mu);
                                TimeOutExecutePost.Instance.UpdateTime();
                            HttpContext.Current.Session["ChangePassMobileValCode"] = sSafeCode;
                                return new JsonResponse() { Success = true, Message = sUrlFull };
                            }
                            else
                            {
                                return new JsonResponse() { Success = false, Message = "不存在用户！" };
                            }

                        }
                        else
                        {
                            return new JsonResponse() { Success = false, Message = "输入的验证码不正确！" };
                        }

                    }
                    else
                    {
                        return new JsonResponse() { Success = false, Message = "输入的手机号不正确！" };
                    }                    
                    
                }
                else
                {
                    return new JsonResponse() { Success = false, Message = "输入的手机号不正确！" };
                }
           
        }
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="mbnumber"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public JsonResponse SendMobileValCode(string mbnumber,string yzm)
        {
            bool isok =EbSite.BLL.User.UserIdentity.ValidateSafeCode(yzm, true);
            if (isok)
            {
                if (TimeOutExecutePost.Instance.IsAllow)
                {
                    if (Core.Strings.Validate.IsMobile(mbnumber))
                    {
                        string sN = Core.ValidateCode.Number(4);
                        Session["MobileValCode"] = sN;
                        Host.Instance.SendMobileMsg(string.Concat("您的验证码是:", sN), mbnumber, "");
                        TimeOutExecutePost.Instance.UpdateTime();
                        return new JsonResponse() {Success = true, Message = "发送成功"};
                    }
                    else
                    {
                        return new JsonResponse() {Success = false, Message = "输入的手机号不正确！"};
                    }
                }
                else
                {
                    return new JsonResponse() {Success = false, Message = "请过一分钟后再发送！"};
                }
            }
            else
            {
                return new JsonResponse() { Success = false, Message = "验证码错误！" };
            }
            
            

             
        }
        [WebMethod]
        public string GetSqlRun()
        {
#if DEBUG
 
              return DbHelperBase.QueryDetail;
#endif
            return "";
        }
        #region 检查密码是否为空,为空时 用短信随机码来登录   YHL 2014-4-25
        /// <summary>
        /// true 密码为空，用随机码
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse CheckUserPass(string username)
        {
            JsonResponse iJson = new JsonResponse();
            EbSite.Base.EntityAPI.MembershipUserEb m = EbSite.BLL.User.MembershipUserEb.Instance.GetUserMobile(username);
            if (m != null)
            {
                if (!string.IsNullOrEmpty(m.Password))
                {
                    iJson.Success = false;
                    iJson.Message = "存在密码";
                }
                else
                {
                    iJson.Success = true;
                    iJson.Message = "密码为空";
                }
            }
            else
            {
                iJson.Success = false;
                iJson.Message = "不存在此账户";
            }
           return iJson;
        }
            #endregion

            #region 用户登录-用短信随机码
        /// <summary>
        /// 用户登录-用短信随机码
        /// </summary>
        /// <param name="login_username"></param>
        /// <param name="login_yzm"></param>
        /// <param name="login_formurl"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse LoginNoPassUser(string login_username, string login_yzm, string login_formurl)
        {
            JsonResponse jr = new JsonResponse();
            if (IsAllow(false))
            {
                LoginStatus ls;
                string sReturnUrl;
                EbSite.Base.EntityAPI.MembershipUserEb md = EbSite.Base.Host.Instance.LoginNoPass(login_username,  login_yzm,  out ls);
                if (LoginStatus.登录成功 == ls)
                {
                    jr.Message = Server.UrlDecode(login_formurl); 
                    jr.Success = true;
                    jr.Data = md.id.ToString();
                }
                else
                { 
                     if (LoginStatus.不存在此帐号或密码错误 == ls)
                    {
                        jr.Message = "不存在此帐号或密码错误";
                        jr.Success = false;
                    }
                    else if (LoginStatus.验证码不正确 == ls)
                    {
                        jr.Message = "验证码不正确或已经过期";
                        jr.Success = false;
                    }          
                    else
                    {
                        jr.Message = "登录失败";
                        jr.Success = false;
                    }
                }
            }
            else
            {
                jr.Message = base.NoAllowTips;
                jr.Success = false;
            }
            return jr;
        }

            #endregion

            #region 注册用户
        /// <summary>
        /// 注册用户-将email当作用户帐号使用(用户帐号与email相同)
        /// </summary>
        /// <param name="reg_email">email</param>
        /// <param name="reg_pwd">密码</param>
        /// <param name="reg_yzm">验证码</param>
        /// <param name="reg_glkey">用户组加密标记</param>
        /// <param name="reg_vuid">邀请用户ID</param>
        /// <param name="reg_formurl">来源地址</param>
        /// <param name="Mobile">手机号</param>
        /// <param name="RegType">注册类别，0为email 1为帐号 2为手机号</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse RegUser(string reg_username, string reg_email, string reg_pwd, string reg_yzm, string reg_glkey, int reg_vuid, string reg_formurl, string reg_mobile, int reg_type,string reg_yzmmobile)
        {

            JsonResponse jr = new JsonResponse();
            if (IsAllow(false))
            {

                string yzm = "";
                bool isValidateSafeCodeOk = false;
                if (reg_type == 2) //如果是手机号注册，要进行手机短信验证
                {
                    yzm = reg_yzmmobile;
                    isValidateSafeCodeOk = EbSite.BLL.User.UserIdentity.ValidateSafeCodeMobile(yzm, true);

                }
                else //否则图片验证
                {
                    yzm = reg_yzm;
                    isValidateSafeCodeOk = EbSite.BLL.User.UserIdentity.ValidateSafeCode(yzm);

                }
                 

                if (isValidateSafeCodeOk)
                {
                    RegStatus ms;
                    string sReturnUrl = string.Empty;
                    string Ip =  EbSite.Core.Utils.GetClientIP();
                   
                    EbSite.Base.Host.Instance.RegUserByGroupKey(reg_username, reg_pwd, reg_email, out ms, false, reg_glkey, out sReturnUrl, reg_vuid, reg_formurl, reg_mobile, reg_type, Ip, "来自web服务的RegUser");
                  
                    if (RegStatus.注册成功 == ms)
                    {
                        jr.Message = sReturnUrl;
                        jr.Success = true;
                    }
                    else
                    {

                        if (RegStatus.已经存在此帐号 == ms)
                        {
                            jr.Message = "已经存在此用户名,请换一个用户名再注册!";
                            jr.Success = false;
                        }
                        else if (RegStatus.已经存在此Email == ms)
                        {
                            jr.Message = "已经存在此Email,请换一个Email再注册!";
                            jr.Success = false;
                        }
                        else if (RegStatus.已经存在此手机号码 == ms)
                        {
                            jr.Message = "已经存在此手机号码!";
                            jr.Success = false;
                        }
                        else if (RegStatus.帐号不能为空 == ms)
                        {
                            jr.Message = "帐号不能为空!";
                            jr.Success = false;
                        }
                        else
                        {
                            jr.Message = "注册失败，原因不明!";
                            jr.Success = false;
                        }
                    }
                }
                else
                {
                    jr.Message = "注册失败，验证码不正确!";
                    jr.Success = false;
                }

                
            }
            else
            {
                jr.Message = base.NoAllowTips;
                jr.Success = false;
            }


            return jr;
        }
        /// <summary>
        /// 快速注册
        /// </summary>
        /// <param name="username">用户名，可以是email,帐号，手机号,视regtype而定</param>
        /// <param name="pwd">密码</param>
        /// <param name="yzm">验证码</param>
        /// <param name="formurl">来源页面url</param>
        /// <param name="regtype">注册类别，0为email,1为帐号,2为手机号</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse FastReg(string username, string pwd, string yzm, string formurl, int regtype)
        {
            JsonResponse jr = new JsonResponse();
            if (IsAllow(false))
            {
                RegStatus ms;
                string sReturnUrl = string.Empty;
                string Ip = EbSite.Core.Utils.GetClientIP();
                int uid = EbSite.Base.Host.Instance.RegUserByGroupKey(username, pwd, username, out ms, false, "", out sReturnUrl, 0, formurl, username, regtype, Ip, "来自web服务的快速注册FastReg");
                if (RegStatus.注册成功 == ms)
                {
                    //要模拟用户登录
                    string err;
                    EbSite.BLL.User.MembershipUserEb.Instance.ValidateUser(username, pwd, -1, out err);

                    jr.Message = sReturnUrl;
                    jr.Success = true;
                    jr.Data = uid.ToString();


                }
                else
                {

                    if (RegStatus.已经存在此帐号 == ms)
                    {
                        jr.Message = "已经存在此用户名,请换一个用户名再注册!";
                        jr.Success = false;
                    }
                    else if (RegStatus.已经存在此Email == ms)
                    {
                        jr.Message = "已经存在此Email,请换一个Email再注册!";
                        jr.Success = false;
                    }
                    else if (RegStatus.已经存在此手机号码 == ms)
                    {
                        jr.Message = "已经存在此手机号码!";
                        jr.Success = false;
                    }
                    else if (RegStatus.帐号不能为空 == ms)
                    {
                        jr.Message = "帐号不能为空!";
                        jr.Success = false;
                    }
                    else
                    {
                        jr.Message = "注册失败，原因不明!";
                        jr.Success = false;
                    }
                }
                
            }
            else
            {
                jr.Message = base.NoAllowTips;
                jr.Success = false;
            }

            return jr;
        }



            #endregion

            #region 用户登录

            #region 不用密码，只使用手机验证码登录
        /// <summary>
        /// 验证手机验证码是否正确
        /// </summary>
        /// <param name="Mobile">手机号</param>
        /// <param name="SafeCoder">用户输入的验证码</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse ValLoginFastMobile(string SafeCoder)
        {
            JsonResponse rz = new JsonResponse() { Success = false };
            string AdminerC = Session["FastMobileC"] as string;
            string sAdminerCTime = Session["FastMobileCTime"] as string;
            if (!string.IsNullOrEmpty(AdminerC) && !string.IsNullOrEmpty(sAdminerCTime))
            {
                long s = Core.Strings.cConvert.DateDiff("s", DateTime.Parse(sAdminerCTime), DateTime.Now);
                if (s > 60)
                {

                    rz.Message = "验证码已经过期";
                    return rz;
                }
                else
                {
                    if (!Equals(SafeCoder, AdminerC))
                    {

                        rz.Message = "输入的验证码不正确";
                        return rz;
                    }
                    else
                    {
                        rz.Success = true;
                        rz.Message = "验证码验证成功,正在获取用户信息";

                    }
                }
            }
            else
            {

                rz.Message = "未能正确获取验证码";
                return rz;
            }

            if (rz.Success) //写入cookie
            {


                int CookieExpiresTime = 1440; //1440分钟后过期 一天时间24小时 

                string LoginFastMobileUserId = Session["LoginFastMobileUserId"] as string;
                if (!string.IsNullOrEmpty(LoginFastMobileUserId))
                {
                    var ucf = EbSite.BLL.User.MembershipUserEb.Instance.GetShortUserInfo(int.Parse(LoginFastMobileUserId));
                    EbSite.BLL.User.UserIdentity.WriteUserIdentity(ucf.UserID.ToString(), ucf.UserName, ucf.UserNiName, ucf.Password, CookieExpiresTime, ucf.GroupID.ToString());//ucf.Password这里为空
                    rz.Success = true;
                    rz.Message = "登录成功";
                }

            }


            return rz;
        }
        /// <summary>
        /// 重新发送手机验证码
        /// </summary>
        /// <param name="mobile">手机码</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse ReSendLoginFastMobile(string mobile)
        {
            JsonResponse rz = new JsonResponse();
            bool isOK = false;
            string sMessage = SendLoginFastMobile(mobile, out isOK);

            rz.Success = isOK;
            if (isOK)
            {
                rz.Data = sMessage;
                rz.Message = string.Format("验证码已经发送到{0}", mobile);
            }
            else
            {
                rz.Message = sMessage;
            }
            return rz;
        }
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="isOK">是否发送成功</param>
        /// <returns></returns>
        private string SendLoginFastMobile(string mobile, out bool isOK)
        {
            string sC = Core.Strings.GetString.RandomNUM(5);
            isOK = false;

            string sAdminerCTime = Session["FastMobileCTime"] as string;
            if (string.IsNullOrEmpty(sAdminerCTime))
            {

                Session["FastMobileC"] = sC;
                Session["FastMobileCTime"] = DateTime.Now.ToString();
                Host.Instance.SendMobileMsg(string.Format("您此次登录的验证码为:{0},有效期为60秒，发送于:{1}", sC, DateTime.Now), mobile, "ebsiteadmin");

                isOK = true;
            }
            else
            {
                long s = Core.Strings.cConvert.DateDiff("s", DateTime.Parse(sAdminerCTime), DateTime.Now);
                if (s > 60)
                {
                    Session["FastMobileC"] = sC;
                    Session["FastMobileCTime"] = DateTime.Now.ToString();

                    Host.Instance.SendMobileMsg(string.Format("您此次登录的验证码为:{0},有效期为60秒，发送于:{1}", sC, DateTime.Now), mobile, "ebsiteadmin");
                    isOK = true;
                }
                else
                {
                    //isOK = false;
                    sC = "请60秒后再偿试！";

                }
            }

            return sC;
        }
        /// <summary>
        /// 快速手机登录
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse LoginFastMobile(string mobile)
        {
            JsonResponse rz = new JsonResponse() { Success = false, Message = "手机号不能为空，格式不对！" };

            if (!string.IsNullOrEmpty(mobile) && Core.Strings.Validate.IsMobile(mobile))
            {

                //bool isHave;
                //string sPass = EbSite.BLL.User.MembershipUserEb.Instance.GetUserPass(mobile, out isHave);
                var UserInfo = EbSite.BLL.User.MembershipUserEb.Instance.GetShortUserInfo(mobile);
                if (!Equals(UserInfo, null))
                {
                    rz.Success = true;
                    bool isOK = false;
                    string rzMessage = SendLoginFastMobile(mobile, out isOK);
                    if (isOK)
                    {
                        Session["LoginFastMobileUserId"] = UserInfo.UserID.ToString();
                        rz.Message = string.Format("验证码已经发送到{0}", mobile);
                        rz.Success = true;
                    }
                    else
                    {
                        rz.Message = rzMessage;
                        rz.Success = false;
                    }
                    //if (string.IsNullOrEmpty(UserInfo.Password))
                    //{
                    //    bool isOK = false;
                    //    string rzMessage = SendLoginFastMobile(mobile, out isOK);
                    //    if (isOK)
                    //    {
                    //        Session["LoginFastMobileUserId"] = UserInfo.UserID.ToString();
                    //        rz.Message = string.Format("验证码已经发送到{0}", mobile);
                    //    }
                    //    else
                    //    {
                    //        rz.Message = rzMessage;
                    //    }

                    //}
                    //else
                    //{
                    //    rz.Message = "用户已经设置密码！";
                    //    rz.Data = "密码不为空";
                    //}
                }
                else
                {
                    rz.Message = "不存此在用户";
                    rz.Success = false;
                }

            }

            return rz;
        }
            #endregion


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login_username">用户帐号，或用户email或手机号码，视login_type 而定，0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="login_pwd">密码,未加密</param>
        /// <param name="login_yzm">验证码</param>
        /// <param name="iscookie">是否记住</param>
        /// <param name="login_type">0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="login_formurl">请求来源地址，用户返回</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse LoginUser(string login_username, string login_pwd, string login_yzm, bool isremember, int login_type, string login_formurl)
        {
            JsonResponse jr = new JsonResponse();
            if (IsAllow(false))
            {
                LoginStatus ls;
                string sReturnUrl;
                EbSite.Base.EntityAPI.MembershipUserEb md = EbSite.Base.Host.Instance.Login(login_username, login_pwd, login_yzm, isremember, login_type, out ls, out sReturnUrl, login_formurl);

                if (LoginStatus.登录成功 == ls)
                {
                    jr.Message = Server.UrlDecode( sReturnUrl); //yhl 2013-10-09 加
                    jr.Success = true;
                    jr.Data = md.id.ToString();
                }
                else
                {
                    if (LoginStatus.IP禁止登录 == ls)
                    {
                        jr.Message = "IP禁止登录";
                        jr.Success = false;
                    }
                    else if (LoginStatus.不存在此Email或密码错误 == ls)
                    {
                        jr.Message = "不存在此Email或密码错误";
                        jr.Success = false;
                    }
                    else if (LoginStatus.不存在此手机号码或密码错误 == ls)
                    {
                        jr.Message = "不存在此手机号码或密码错误";
                        jr.Success = false;
                    }
                    else if (LoginStatus.不存在此帐号或密码错误 == ls)
                    {
                        jr.Message = "不存在此帐号或密码错误";
                        jr.Success = false;
                    }
                    else if (LoginStatus.错误登录次数超出规定 == ls)
                    {
                        jr.Message = "对不起，你错误登录了" + EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.ErrLoginNum + "次，系统登录锁定！!";
                        jr.Success = false;
                    }

                    else if (LoginStatus.验证码不正确 == ls)
                    {
                        jr.Message = "验证码不正确或已经过期";
                        jr.Success = false;
                    }
                    else if (LoginStatus.帐号没有激活 == ls)
                    {
                        jr.Message = "帐号没有激活";
                        jr.Success = false;
                    }
                    else
                    {
                        jr.Message = "登录失败";
                        jr.Success = false;
                    }


                }

            }
            else
            {
                jr.Message = base.NoAllowTips;
                jr.Success = false;
            }


            return jr;
        }

            #endregion

            #region  评论与收藏

        [WebMethod]
        public void AddToFav(int ctid, int cid, int sid)
        {
            List<EbSite.Entity.Favorite> ls = EbSite.BLL.Favorite.GetListArr(1, string.Format("ContentID={0} and ContentClassId={1}", ctid, cid), "");
            if (ls.Count == 0)
            {
                EbSite.Entity.NewsContent mdContent = EbSite.Base.AppStartInit.GetNewsContentInst(ctid).GetModel(ctid, sid);
                if (!Equals(mdContent, null))
                {
                    EbSite.Entity.Favorite md = new EbSite.Entity.Favorite();
                    md.Title = mdContent.NewsTitle;
                    md.ContentID = ctid;
                    md.ContentClassId = cid;
                    md.FavType = 0; //0为内容 
                    md.AddDateTime = DateTime.Now;
                    md.UserID = Host.Instance.UserID;
                    md.UserNiName = Host.Instance.UserNiName;
                    md.UserName = Host.Instance.UserName;
                    md.ClassID = 0;
                    md.LinkUrl = Host.Instance.GetContentLink(ctid, cid);
                    EbSite.BLL.Favorite.Add(md);
                }

            }

            //return new JsonResponse() { Data = "", Message = ":", Success = true };
        }


            #region 评论代码，如果你的网站不用评论，也可以删除掉

        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse ReplyRemark(int postid, string msg)
        {

            JsonResponse rz = new JsonResponse();
            if (TimeOutPost.Instance.IsAllow)
            {
                if (msg.Length < 300)
                {
                    EbSite.Entity.RemarkSublist model = new EbSite.Entity.RemarkSublist();
                    model.Body = msg;
                    model.DateAndTime = DateTime.Now;
                    model.Ip = EbSite.Core.Utils.GetClientIP();
                    model.IsNiName = Host.Instance.UserID < 1;
                    model.UserID = Host.Instance.UserID;
                    model.UserName = Host.Instance.UserName;
                    model.UserNiName = Host.Instance.UserNiName;
                    model.ParentID = postid;

                    EbSite.BLL.RemarkSublist.Add(model);

                    rz.Message = "提交成功";
                    rz.Success = true;
                    TimeOutPost.Instance.UpdateTime();
                }
                else
                {
                    rz.Message = "对不起，你输入的字数太多，请限制在300字以内！";
                    rz.Success = false;
                }
            }
            else
            {
                rz.Message = string.Format("对不起，请过{0}分钟后再发表！", TimeOutPost.Instance.TimeSpan);
                rz.Success = false;
            }


            return rz;
        }

        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse ReplyRemarkSub(int subid, string msg)
        {
            JsonResponse rz = new JsonResponse();
            if (TimeOutPost.Instance.IsAllow)
            {
                if (msg.Length < 300)
                {
                    EbSite.Entity.RemarkSublist modelTemp = EbSite.BLL.RemarkSublist.GetModel(subid);

                    EbSite.Entity.RemarkSublist model = new EbSite.Entity.RemarkSublist();
                    model.Body = msg;
                    model.DateAndTime = DateTime.Now;
                    model.Ip = EbSite.Core.Utils.GetClientIP();
                    model.IsNiName = Host.Instance.UserID < 1;
                    model.UserID = Host.Instance.UserID;
                    model.UserName = Host.Instance.UserName;
                    model.UserNiName = Host.Instance.UserNiName;
                    model.ParentID = modelTemp.ParentID;
                    model.Quote = modelTemp.Body;

                    EbSite.BLL.RemarkSublist.Add(model);

                    rz.Message = "提交成功";
                    rz.Success = true;
                    TimeOutPost.Instance.UpdateTime();
                }
                else
                {
                    rz.Message = "对不起，你输入的字数太多，请限制在300字以内！";
                    rz.Success = false;
                }

            }
            else
            {
                rz.Message = string.Format("对不起，请过{0}分钟后再发表！", TimeOutPost.Instance.TimeSpan);
                rz.Success = false;
            }


            return rz;
        }

        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse ExecutePost(int postid, int flag)
        {
            JsonResponse rz = new JsonResponse();
            if (TimeOutExecutePost.Instance.IsAllow)
            {

                EbSite.BLL.Remark.ExecutePost(postid, flag);
                TimeOutExecutePost.Instance.UpdateTime();
                rz.Success = true;
            }
            else
            {
                rz.Message = string.Format("对不起，请过{0}分钟后再操作！", TimeOutExecutePost.Instance.TimeSpan);
                rz.Success = false;
            }

            return rz;
        }
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse ExecutePostSub(int postid, int flag)
        {
            JsonResponse rz = new JsonResponse();
            if (TimeOutExecutePost.Instance.IsAllow)
            {

                EbSite.BLL.RemarkSublist.ExecutePost(postid, flag);
                TimeOutExecutePost.Instance.UpdateTime();
                rz.Success = true;
            }
            else
            {
                rz.Message = string.Format("对不起，请过{0}分钟后再操作！", TimeOutExecutePost.Instance.TimeSpan);
                rz.Success = false;
            }

            return rz;
        }

        /// <summary>
        /// 发表一个评论
        /// </summary>
        /// <param name="msg">评论内容.</param>
        /// <param name="niname">是否匿名发表</param>
        /// <param name="rmcid">评论分类Id</param>
        /// <param name="classid">当前内容分类Id.</param>
        /// <param name="contentid">当前内容Id.</param>
        /// <param name="score">评分.</param>
        /// <returns>JsonResponse.</returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public JsonResponse SaveRemark(string msg, bool niname, int rmcid, int classid, int contentid, int score)
        {
            JsonResponse rz = new JsonResponse();

            if (TimeOutPost.Instance.IsAllow)
            {
                EbSite.Entity.Remark Model = new EbSite.Entity.Remark();
                Model.Body = msg;
                if (!string.IsNullOrEmpty(Model.Body))
                {
                    //Model.Mark = this.MK;
                    Model.DateAndTime = DateTime.Now;
                    Model.Discourage = 0;
                    Model.Information = 0;
                    Model.Ip = Utils.GetClientIP();
                    Model.Support = 0;
                    Model.UserName = AppStartInit.UserName;
                    Model.UserNiName = AppStartInit.UserNiName;
                    Model.UserID = AppStartInit.UserID;
                    Model.IsNiName = niname;
                    Model.RemarkClassID = rmcid;
                    Model.ClassID = classid;
                    Model.ContentID = contentid;
                    Model.EvaluationScore = score;


                    EbSite.BLL.Remark.Add(Model, true);

                    TimeOutPost.Instance.UpdateTime();
                    rz.Success = true;
                    if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingComment)
                    {
                        rz.Message = "发表成功,但还在审核中...";

                    }



                }
            }
            else
            {
                rz.Success = false;
                rz.Message = string.Format("请过{0}分钟后再发表！", TimeOutPost.Instance.TimeSpan);
            }

            return rz;
        }
            #endregion

            #endregion

        /// <summary>
        /// 获取地区名称
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
         
        public string GetAreaName(int id)
        {
            
            string name = "";
            if (IsAllow(false))
            {
                EbSite.Entity.AreaInfo md = EbSite.BLL.AreaInfo.Instance.GetEntity(id);
                if (!Equals(md, null))
                {
                    name = md.Name;
                }
            }
            else
            {
                name = base.NoAllowTips;
            }
            
            return name;
        }
        /// <summary>
        /// 添加 配送--运费模板
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="startWeight"></param>
        /// <param name="addWeight"></param>
        /// <param name="startPrice"></param>
        /// <param name="addPrice"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public int AddPeiSongTem(int strFlag, string templateName, int startWeight, int addWeight, decimal startPrice, decimal addPrice)
        {
            if (IsAllow(false))
            {
                EbSite.Entity.PsFreight md = new PsFreight();
                md.TemplateName = templateName;
                md.StartWeight = startWeight;
                md.AddWeight = addWeight;
                md.StartPrice = startPrice;
                md.AddPrice = addPrice;
                if (strFlag > 0)
                {
                    md.id = strFlag;
                    EbSite.BLL.PsFreight.Instance.Update(md);
                    return strFlag;
                }
                else
                {
                    int pid = EbSite.BLL.PsFreight.Instance.Add(md);
                    return pid;
                }
            }
            else
            {
                return 0;
            }
        }
        //添加 配送-运费 对应地区的价格
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public int AddPeiSongAreaPrice(int strFlag, int pid, string Region, string RegionIDS, decimal RegionPrice, decimal AddRegionPrice, decimal FullMoney)
        {
            if (IsAllow(false))
            {
                int i = 0;
                EbSite.Entity.PsAreaPrice md = new PsAreaPrice();
                md.ParentID = pid;
                md.Region = Region;
                md.RegionPrice = RegionPrice;
                md.AddRegionPrice = AddRegionPrice;
                md.FullMoney = FullMoney;
                md.RegionIDS = RegionIDS;
                if (strFlag > 0)
                {
                    //修改
                    md.id = strFlag;
                    EbSite.BLL.PsAreaPrice.Instance.Update(md);
                }
                else
                {
                    i = EbSite.BLL.PsAreaPrice.Instance.Add(md);
                }
                return i;
            }
            else
            {
                return 0;
            }

        }
        //删除  配送-运费 对应地区的价格
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public void DelPeiSongAreaPrice(int id)
        {
            if (IsAllow(false))
            {
                if (id > 0)
                {

                    EbSite.BLL.PsAreaPrice.Instance.Delete(id);
                }
            }


        }
            #region wcf 迁移代码
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public bool IsMobile()
        {

            bool flag = false;
            if (IsAllow(false))
            {
                string str = (HttpContext.Current.Request.UserAgent ?? "").ToLower().Trim();
                if (!string.IsNullOrEmpty(str) && (str.IndexOf("mobile") > -1))
                {
                    flag = true;
                }
            }
            return flag;
        }
        //[WebMethod]
        //public JsonResponse UserName()
        //{
        //    if (IsAllow)
        //    {
        //    }
        //    else
        //    return new JsonResponse() { Success = true, Message = EbSite.Base.Host.Instance.UserName };
        //    //return Base.Host.Instance.UserName;
        //}
        //[WebMethod]
        //public int UserID()
        //{
        //    return EbSite.Base.Host.Instance.UserID;
        //}
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public EbSite.Base.EntityAPI.MembershipUserEb CurrentUser()
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.CurrentUser;
            }
            else
            {
                return null;
            }


        }
        //[WebMethod]
        //public JsonResponse HelloString(string str)
        //{
        //    return new JsonResponse() { Data = "", Message = "您请求了HelloString:" + str, Success = true };
        //}



            #region IServiceAPI Members



        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string IISPath()
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.IISPath;
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string Domain()
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.Domain;
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string MapPath()
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.sMapPath;
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetAvatarPath(int UserID)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetAvatarPath(UserID);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string UserSiteUrl()
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.CurrentSiteUrl;
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        //[WebMethod]
        //[SoapHeader("SecurityKey")]
        //public string UserGroupNames()
        //{
        //    if (IsAllow(false))
        //    {
        //        return EbSite.Base.Host.Instance.UserGroupNames;
        //    }
        //    else
        //    {
        //        return base.NoAllowTips;
        //    }

        //}
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public void SendEmail(string email, string title, string body)
        {
            if (IsAllow(false))
            {
                EbSite.Base.Host.Instance.SendEmailPool(email, title, body);
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public void InsertLog(string Title, string Msg)
        {
            if (IsAllow(false))
            {
                EbSite.Base.Host.Instance.InsertLog(Title, Msg);
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetClassHref3(object iID, object HtmlPath, int pIndex)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetClassHref(iID, HtmlPath, pIndex);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetClassHref2(object iID, object HtmlPath, int pIndex, string OutLink)
        {
            if (IsAllow(false))
            {
                return Host.Instance.GetClassHref(iID, HtmlPath, pIndex, OutLink);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetClassHref(int iID, int Index)
        {
            if (IsAllow(false))
            {
                return Host.Instance.GetClassHref(iID, Index);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetContentLink2(object iID, object HtmlPath)
        {
            if (IsAllow(false))
            {
                return Host.Instance.GetContentLink(iID, HtmlPath);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetContentLink(object iID,object cid)
        {
            if (IsAllow(false))
            {
                return Host.Instance.GetContentLink(iID, cid);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetClassHref_OrderBy(int iID, int Index, int OrderBy)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetClassHref_OrderBy(iID, Index, OrderBy);
            }
            else
            {
                return base.NoAllowTips;
            }


        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetSpecialHref(int iID, int Index)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetSpecialHref(iID, Index);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string TagsList(int p)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.TagsList(p);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string TagsSearchList(object id, int p)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.TagsSearchList(id, p);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetUserHomePage2(string sUserName)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetUserHomePage(sUserName);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetUserHomePage()
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetUserHomePage();
            }
            else
            {
                return base.NoAllowTips;
            }

        }

        //public string GetUserHomePageHref(string sUserName, string sUserNiName, string target)
        //{
        //    return Base.Host.Instance.GetUserHomePageHref(sUserNiName, sUserNiName, target);
        //}
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetUserHomePageHref(string target)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetUserHomePage(target);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        //[WebMethod]
        //[SoapHeader("SecurityKey")]
        //public string IsOnlineImg(string UserName)
        //{
        //    if (IsAllow(false))
        //    {
        //        return EbSite.Base.Host.Instance.IsOnlineImg(UserName);
        //    }
        //    else
        //    {
        //        return base.NoAllowTips;
        //    }

        //}
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public int GetProfileUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetProfileUniqueID(userName, isAuthenticated, ignoreAuthenticationType, appName);
            }
            else
            {
                return 0;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.CreateProfileForUser(userName, isAuthenticated, appName);
            }
            else
            {
                return 0;
            }

        }

        //public IList<Entity.CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, string appName, out int totalRecords)
        //{
        //    return Base.Host.Instance.GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate,
        //                                             appName, out totalRecords);
        //}
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public bool DeleteProfile(int iUid)
        {
            if (IsAllow(false))
            {
                if (EbSite.Base.Host.Instance.UserID > 0)
                    return EbSite.Base.Host.Instance.DeleteProfile(iUid);
            }
            return false;
        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetInactiveProfiles(authenticationOption, userInactiveSinceDate, appName).ToList();
            }
            else
            {
                return null;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public void UpdateActivityDates(string userName, bool activityOnly, string appName)
        {
            if (IsAllow(false))
            {
                EbSite.Base.Host.Instance.UpdateActivityDates(userName, activityOnly, appName);
            }

        }

            #endregion

            #region
        //是否登录成功
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public JsonResponse Login(string u, string p)
        {
            string err = "ok";
            if (IsAllow(false))
            {
                EbSite.BLL.User.MembershipUserEb.Instance.ValidateUser(u, p, -1, out err);
                return new JsonResponse() { Success = true, Message = err };
            }
            else
            {
                return new JsonResponse() { Success = false, Message = base.NoAllowTips };
            }

        }
            #endregion
        /// <summary>
        /// 获取某个模块的安装路径
        /// </summary>
        /// <param name="mid">模块ID</param>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public JsonResponse GetModulePath(string mid, int siteid)
        {
            if (IsAllow(false))
            {
                //EbSite.BLL.ModulesBll.Modules modulesBll = new EbSite.BLL.ModulesBll.Modules(siteid);
                string sPath = EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(new Guid(mid));

                return new JsonResponse() { Success = true, Message = sPath };
            }
            else
            {
                return new JsonResponse() { Success = false, Message = base.NoAllowTips };
            }

        }

        /// <summary>
        /// 获取地区
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public List<TreeItem> GetAlear(int pid)
        {
            if (IsAllow(false))
            {
                List<TreeItem> lstOK = new List<TreeItem>();

                List<EbSite.Entity.AreaInfo> lst = EbSite.BLL.AreaInfo.Instance.GetListByParentID(pid);
                foreach (EbSite.Entity.AreaInfo info in lst)
                {

                    lstOK.Add(new TreeItem(info.id, info.Name, info.Level));
                }


                return lstOK;
            }
            else
            {
                return null;
            }


        }


        /// <summary>
        /// 获取分类列表，从父ID
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<TreeItem> GetNewClassList(int pid)
        {
            if (IsAllow(false))
            {
                string strSql = "parentid=" + pid;
                List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetListArr(strSql, 1);
                if (pid > 1 && pid < 10)
                {
                    //List<EbSite.Entity.NewsClass> tmpLst = EbSite.BLL.NewsClass.GetListArr(strSql, 1);
                    //strSql = "parentid in(select ID from eb_newsclass where ParentID=)" + pid + ")";
                    string IDs = "";
                    foreach (EbSite.Entity.NewsClass info in lst)
                    {
                        IDs += info.ID + ",";
                    }
                    if (!string.IsNullOrEmpty(IDs))
                    {
                        strSql = string.Format(" parentid in({0})", IDs.Substring(0, IDs.Length - 1));
                        lst = EbSite.BLL.NewsClass.GetListArr(strSql, 1);
                    }

                }

                List<TreeItem> lstOK = new List<TreeItem>();

                foreach (EbSite.Entity.NewsClass info in lst)
                {
                    //lstOK.Add(new TreeItem(info.ID, info.ClassName, int.Parse(info.Annex9)));
                    string carNum = "0";
                    if (info.Annex9.Equals("3") || info.Annex9.Equals("4") || info.Annex9.Equals("6"))
                    {
                        carNum = info.Annex1;
                    }
                    else if (info.Annex9.Equals("5"))
                    {
                        carNum = info.Annex6;
                    }
                    else
                    {
                        carNum = info.ID.ToString();
                    }
                    lstOK.Add(new TreeItem(info.ID, info.ClassName, int.Parse(carNum)));
                }

                return lstOK;
            }
            else
            {
                return null;
            }

        }


        [WebMethod]
        [SoapHeader("SecurityKey")]
        public TreeItem GetAlearInfo(int id)
        {
            if (IsAllow(false))
            {
                EbSite.Entity.AreaInfo info = EbSite.BLL.AreaInfo.Instance.GetEntity(id);
                return new TreeItem(info.id, info.Name, info.Level);
            }
            else
            {
                return null;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public EbSite.Entity.VersionInfo GetVersion(string ip, string dm)
        {

            EbSite.Entity.VersionInfo md = new EbSite.Entity.VersionInfo();
            string sVersion = EbSite.Core.Utils.GetAssemblyVersion();
            md.Version = sVersion;
            md.PathUrl = "http://www.ebsite.net/update2.0.zip";
            md.WebUrl = "http://www.ebsite.net";
            md.UpdateTime = DateTime.Now;
            //为了方便官方做统计，对外开发事件
            //EBSiteEvents.OnGetVersion(null, new GetVersionEventArgs(md.Version, md.WebUrl, md.PathUrl, md.UpdateTime));

            return md;
        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string ServerInfo()
        {
            return "<a target=_blank href='http://www.ebsite.net'>官方电子平台上线啦</a>";
        }
        /// <summary>
        /// 获取模块菜单地址
        /// </summary>
        /// <param name="pid">父ID</param>
        /// <param name="sid">子ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetModuleUrl(Guid pid, Guid sid)
        {
            if (IsAllow(false))
            {
                return EbSite.Base.Host.Instance.GetModuleUrl(pid, sid);
            }
            else
            {
                return base.NoAllowTips;
            }

        }
        /// <summary>
        /// 返回当前登录的用户ID,没有登录为-1
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public int GetUserID()
        {
            if (IsAllow(false))
            {
                if (EbSite.Base.Host.Instance.UserID > 0)
                {
                    return EbSite.Base.Host.Instance.UserID;
                }
            }

            return -1;
        }
        /// <summary>
        /// 调个人的收藏分类
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetFavClassList()
        {
            if (IsAllow(false))
            {
                string str = "";

                List<EbSite.Entity.FavoriteClass> ls = EbSite.BLL.FavoriteClass.GetListByUserID(EbSite.Base.Host.Instance.UserID);// GetListArr(0, "UserID=" + EbSite.Base.Host.Instance.UserID + "", "id asc");
                foreach (EbSite.Entity.FavoriteClass li in ls)
                {
                    str += li.ClassName + "," + li.ID + "|";
                }
                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1, 1);
                }
                return str;
            }
            else
            {
                return base.NoAllowTips;
            }

        }

            #region 添加喜爱收藏的分类
        /// <summary>
        /// 添加喜爱收藏的分类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public bool AddFavClass(string name)
        {
            if (IsAllow(true))
            {
                bool k = false;
                if (EbSite.Base.Host.Instance.UserID > 0)
                {

                    EbSite.Entity.FavoriteClass md = new EbSite.Entity.FavoriteClass();
                    md.ClassName = name;

                    md.Adddatetime = DateTime.Now;
                    EbSite.BLL.FavoriteClass.Add(md);
                    k = true;

                }
                return k;
            }
            else
            {
                return false;
            }

        }

            #endregion

            #region  添加喜爱收藏
        /// <summary>
        /// 添加喜爱收藏
        /// </summary>
        /// <param name="contentId">内容id</param>
        /// <param name="classId">收藏分类ID</param>
        /// <param name="favType">收藏类别，0为内容，1为分类</param>
        /// <param name="userId">用户ID</param>
        /// <param name="CID">内容的分类id</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public bool AddFavorite(int contentId, int classId, int favType, int userId,int CID)
        {
            if (IsAllow(true))
            {
                bool key = false;
                EbSite.Entity.Favorite md = new Favorite();
                md.ContentID = contentId;
                md.ContentClassId = CID;
                md.ClassID = classId;
                md.FavType = favType;
                md.UserID = userId;
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(CID);
                md.Title = NewsContentInst.GetModel(contentId, 1).NewsTitle;//站点不能写死
                md.UserName = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(userId).UserName;
                md.UserNiName = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(userId).NiName;
                md.AddDateTime = DateTime.Now;
                int i = EbSite.BLL.Favorite.Add(md);
                if (i > 0)
                {
                    key = true;
                }
                return key;
            }
            else
            {
                return false;
            }

        }
            #endregion

            #region 判断是否已添加喜爱收藏
        /// <summary>
        /// 判断是否已添加喜爱收藏
        /// </summary>
        /// <param name="contentId">内容id</param>
        /// <param name="classId">收藏分类ID</param>
        /// <param name="favType">收藏类别，0为内容，1为分类</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public bool IfAddFavorite(int contentId, int classId, int favType, int userId)
        {
            if (IsAllow(false))
            {
                bool key = false;
                string strsql = "ContentID =" + contentId + " and ClassID=" + classId + " and FavType=" + favType + " and userId=" + userId;
                List<EbSite.Entity.Favorite> ls = EbSite.BLL.Favorite.GetListArr(0, strsql, "id asc");
                if (ls.Count == 0)
                {
                    key = true;
                }
                return key;
            }
            else
            {
                return false;
            }

        }
            #endregion

            #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="uname">用户名</param>
        /// <param name="upwd">明名密码</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public int LoginClick(string sUserName, string sPass)
        {
            if (IsAllow(false))
            {
                int key = 0;
                string sErr = "";
                EbSite.Base.EntityAPI.MembershipUserEb ucf = EbSite.BLL.User.MembershipUserEb.Instance.ValidateUser(sUserName, sPass, -1, out sErr);
                if (!Equals(ucf, null) && string.IsNullOrEmpty(sErr)) //登录成功
                {

                    key = ucf.id;
                }
                return key;
            }
            else
            {
                return 0;
            }

        }
            #endregion

            #region 删除喜爱收藏的分类
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public void DelFavClass(int id)
        {
            if (IsAllow(true))
            {
                EbSite.BLL.FavoriteClass.Delete(id, EbSite.Base.Host.Instance.UserName);
                //同时删除 对应分类下的收藏内容
                EbSite.BLL.Favorite.DeleteOfClass(id, EbSite.Base.Host.Instance.UserName);
            }

        }
            #endregion

            #region  修改喜爱收藏分类
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public void UpdateFavClass(string name, int id)
        {
            if (IsAllow(true))
            {
                EbSite.Entity.FavoriteClass md = EbSite.BLL.FavoriteClass.GetModel(id);
                md.ClassName = name;
                EbSite.BLL.FavoriteClass.Update(md);
            }


        }
            #endregion

            #region 调收藏的分类
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<ClassInfo> GetFavClass(int uid)
        {
            if (IsAllow(true))
            {
                List<EbSite.Entity.FavoriteClass> ls = EbSite.BLL.FavoriteClass.GetListArr(0, " UserName='" + EbSite.Base.Host.Instance.UserName + "' and UserID=" + uid, "id desc");
                List<ClassInfo> lstOK = new List<ClassInfo>();
                foreach (EbSite.Entity.FavoriteClass newsClass in ls)
                {
                    lstOK.Add(new ClassInfo(newsClass.ID, newsClass.ClassName));
                }

                return lstOK;
            }
            else
            {
                return null;
            }

        }
            #endregion

            #region 调主站的分类
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<ClassInfo> GetClassTree(int siteid)
        {
            if (IsAllow(false))
            {
                List<EbSite.Entity.NewsClass> ls = EbSite.BLL.NewsClass.GetContentClassesTree(siteid);
                List<ClassInfo> lstOK = new List<ClassInfo>();
                foreach (EbSite.Entity.NewsClass newsClass in ls)
                {
                    lstOK.Add(new ClassInfo(newsClass.ID, newsClass.ClassName));
                }

                return lstOK;
            }
            else
            {
                return null;
            }

        }

            #endregion

            #region  喜欢某个内容
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public JsonResponse LikeOrNo(int id,int cid)
        {
            NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(cid);//yhl 2014-2-11
            NewsContentInst.LikeOrNo(id, 1);
            return new JsonResponse() { Success = true, Message = id.ToString() };
        }
            #endregion
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<TreeItem> GetSubClassForAdd(int pid, int sid)
        {
            if (IsAllow(false))
            {
                List<TreeItem> lstOK = new List<TreeItem>();
                List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetSubClassNoCache(pid, 0, sid);
                foreach (NewsClass newClass in lst)
                {
                    lstOK.Add(new TreeItem(newClass.ID, newClass.ClassName, 0, newClass.IsCanAddContent ? "1" : "0"));
                    //if (newClass.IsCanAddContent)
                    //{
                    //    lstOK.Add(new TreeItem(newClass.ID, newClass.ClassName, 0, newClass.IsCanAddContent ? "1" : "0"));
                    //}
                    //else
                    //{
                    //    List<EbSite.Entity.NewsClass> lstSub = EbSite.BLL.NewsClass.GetSubClass(newClass.ID, 0, sid);
                    //    if(lstSub.Count>0)
                    //    {
                    //        lstOK.Add(new TreeItem(newClass.ID, newClass.ClassName, 0, newClass.IsCanAddContent?"1":"0"));
                    //    }
                    //}

                }
                return lstOK;
            }
            else
            {
                return null;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<TreeItem> GetSubClassForAddClass(int pid, int sid)
        {
            if (IsAllow(false))
            {
                List<TreeItem> lstOK = new List<TreeItem>();
                List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetSubClassNoCache(pid, 0, sid);
                foreach (NewsClass newClass in lst)
                {
                    lstOK.Add(new TreeItem(newClass.ID, newClass.ClassName, 0, newClass.IsCanAddSub ? "1" : "0"));


                }
                return lstOK;
            }
            else
            {
                return null;
            }

        }
            #region 调当前站点下主站的专题分类
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<TreeItem> GetSubSpecial(int pid, int sid)
        {
            if (IsAllow(false))
            {
                List<TreeItem> lstOK = new List<TreeItem>();
                List<EbSite.Entity.SpecialClass> lst = EbSite.BLL.SpecialClass.GetSub(pid, sid);
                List<EbSite.Entity.SpecialClass> nlst = (from i in lst orderby i.Orderid ascending select i).ToList();
                foreach (SpecialClass specialClass in nlst)
                {
                    lstOK.Add(new TreeItem(specialClass.id, specialClass.SpecialName, 0));
                }
                return lstOK;
            }
            else
            {
                return null;
            }

        }

        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<TreeItem> GetSpecialClass(int pid, int sid)
        {
            if (IsAllow(false))
            {
                string lst = EbSite.BLL.SpecialClass.GetSubIDs(pid, sid);
                string[] arry = lst.Split(',');
                List<TreeItem> lstOK = new List<TreeItem>();
                for (int i = 0; i < arry.Length; i++)
                {
                    int level = 1;
                    if (!string.IsNullOrEmpty(arry[i]))
                    {
                        EbSite.Entity.SpecialClass md = EbSite.BLL.SpecialClass.GetModel(int.Parse(arry[i]));
                        GetSubItem_channels(md.id, pid, ref level);
                        lstOK.Add(new TreeItem(md.id, md.SpecialName, level));
                    }

                }
                return lstOK;
            }
            else
            {
                return null;
            }

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        private void GetSubItem_channels(int id, int pid, ref int level)
        {
            if (IsAllow(false))
            {
                EbSite.Entity.SpecialClass md = EbSite.BLL.SpecialClass.GetModel(id);
                if (md.ParentID != pid)
                {
                    level += 1;
                    GetSubItem_channels(md.ParentID, pid, ref level);
                }
            }

        }
            #endregion

            #region 添加专题内容
        /// <summary>
        /// 添加专题内容
        /// </summary>
        /// <param name="newsId">内容ID</param>
        /// <param name="specialClassId">分类ID</param>
        /// <returns></returns>
        //[WebMethod]
        //[SoapHeader("SecurityKey")]
        //public bool AddSpecialNews(int newsId, int specialClassId)
        //{
        //    if (IsAllow(true))
        //    {
        //        bool key = false;
        //        EbSite.Entity.SpecialNews md = new SpecialNews();
        //        md.NewsID = newsId;
        //        md.SpecialClassID = specialClassId;
        //        md.orderid = 1;
        //        md.ClassID = 0;
        //        int idd = EbSite.BLL.SpecialNews.Add(md);
        //        if (idd > 0)
        //        {
        //            key = true;
        //        }
        //        return key;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
            #endregion

            #region 决断是否已添加到专题
        //[WebMethod]
        //[SoapHeader("SecurityKey")]
        //public bool IfSpecialNews(int newsId, string specialClassId)
        //{
        //    if (IsAllow(false))
        //    {
        //        int it = 0;
        //        bool key = true;
        //        if (!int.TryParse(specialClassId, out it))
        //        {
        //            key = false;
        //        }
        //        else
        //        {
        //            List<EbSite.Entity.SpecialNews> ls =
        //                EbSite.BLL.SpecialNews.GetListArry("newsid=" + newsId + " and SpecialClassID=" + specialClassId);
        //            if (ls.Count > 0)
        //            {
        //                key = false;
        //            }
        //        }
        //        return key;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
            #endregion

            #region  评价 暂同
        /// <summary>
        /// 评价 暂同 反对
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key">1：暂同 2 ：反对</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public int RemarkSupport(int id, int key)
        {
            if (IsAllow(false))
            {
                EbSite.Entity.Remark md = EbSite.BLL.Remark.GetModel(id);
                if (key == 1)
                {
                    md.Support += 1;
                }
                if (key == 2)
                {
                    md.Discourage += 1;
                }
                EbSite.BLL.Remark.Update(md);
                if (key == 1)
                {
                    return md.Support;
                }
                if (key == 2)
                {
                    return md.Discourage;
                }
                return 0;
            }
            else
            {
                return 0;
            }

        }
            #endregion

        [WebMethod]
        [SoapHeader("SecurityKey")]
        public List<ShortUserInfo> GetUsers(int gid, string k)
        {
            if (IsAllow(false))
            {
                string swhere = "";
                List<ShortUserInfo> ulst = new List<ShortUserInfo>();
                int iCount = 0;
                if (!string.IsNullOrEmpty(k))
                {
                    swhere = string.Format(" NiName like '%{0}%'", k);
                }
                List<EbSite.Base.EntityAPI.MembershipUserEb> lst = EbSite.BLL.User.MembershipUserEb.Instance.GetListPages(1, 300, true, out iCount, gid, swhere);
                foreach (MembershipUserEb userEb in lst)
                {
                    ulst.Add(new ShortUserInfo(userEb.id, userEb.UserName, userEb.NiName, gid, ""));//不外不开放pass
                }
                return ulst;
            }
            else
            {
                return null;
            }

        }

            #region  添加评价
        /// <summary>
        /// 添加评价
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="mk">动态标记</param>
        /// <param name="txtExperience">使用心得</param>
        /// <param name="cid">分类id</param>
        /// <param name="RdScore">评价分数</param>
        /// <param name="iPage">0：一问一答 （不用管）。1：代表分类 2 :代表内容</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public bool RemarkOp(string txtExperience,int cid, int classid,int contentid, string RdScore)
        {
            if (IsAllow(false))
            {
                EbSite.Entity.Remark Model = new EbSite.Entity.Remark();
                
                if (!string.IsNullOrEmpty(txtExperience))
                {
                   
                    Model.DateAndTime = DateTime.Now;
                    Model.Discourage = 0;
                    Model.Information = 0;
                    Model.Ip = EbSite.Core.Utils.GetClientIP();
                   
                    Model.Quote = txtExperience.Trim();
                    Model.Support = 0;
                    Model.UserName = AppStartInit.UserName;
                    Model.UserNiName = AppStartInit.UserNiName;
                    Model.UserID = AppStartInit.UserID;
                    Model.IsNiName = false;
                    Model.RemarkClassID = cid;
                    Model.EvaluationScore = Core.Utils.StrToInt(RdScore, 0);

                    Model.ClassID = classid;
                    Model.ContentID = contentid;

                    EbSite.BLL.Remark.Add(Model, true);
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }
            #endregion

            #region 回复一个评价
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public bool RemarkHfOp(string body, int parentid)
        {
            if (IsAllow(false))
            {
                EbSite.Entity.RemarkSublist Model = new EbSite.Entity.RemarkSublist();
                Model.Body = body.Trim();
                if (!string.IsNullOrEmpty(Model.Body))
                {
                    Model.DateAndTime = DateTime.Now;
                    Model.Discourage = 0;
                    Model.Information = 0;
                    Model.Ip = Utils.GetClientIP();
                    Model.Support = 0;
                    Model.UserName = AppStartInit.UserName;
                    Model.UserNiName = AppStartInit.UserNiName;
                    Model.UserID = AppStartInit.UserID;
                    Model.IsNiName = false;
                    Model.ParentID = parentid;
                    EbSite.BLL.RemarkSublist.Add(Model);
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }
            #endregion

            #endregion


            #region 检测是否 已发过评价
        
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public bool CheckSendRemark(string contentid, int userid)
        {

            if (IsAllow(false))
            {
                List<EbSite.Entity.Remark> ls = EbSite.BLL.Remark.GetListArray(string.Concat("UserID=", userid, " and contentid='", contentid, "'"), 0, "");
                if (ls.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
            #endregion




        [WebMethod(Description = "查找短信的内容")]
        [SoapHeader("SecurityKey")]
        public string GetMsgModel(int id)
        {
            if (IsAllow(false))
            {
                EbSite.BLL.Msg mds = EbSite.BLL.Msg.GetMsg(id);

                EbSite.BLL.Msg.Msg_SetToRead(id);

                return mds.MsgContent;
            }
            else
            {
                return base.NoAllowTips;
            }

        }

        [WebMethod(Description = "获取支付的url地址")]
        [SoapHeader("SecurityKey")]
        public string GetPaymentUrl(int payID, string strInfo)
        {
            if (IsAllow(false))
            {
                EbSite.Entity.Payment pInfo = EbSite.BLL.Payment.Instance.GetEntity(payID);
                if (pInfo != null)
                {
                    string strSource = EbSite.Core.AES.Decode(strInfo, "bm");
                    if (!string.IsNullOrEmpty(strSource) && strSource.IndexOf("|") > 0)
                    {
                        string[] strArr = strSource.Split('|');
                        string orderNum = strArr[0];
                        decimal payMoney = decimal.Parse(strArr[1]);
                        string strDesc = strArr[2];
                        string strUrl = pInfo.GetPayLink(payMoney, orderNum, strDesc);
                        return strUrl;
                    }
                }
                return "";
            }
            else
            {
                return base.NoAllowTips;
            }

        }

        [WebMethod(Description = "添加一个常用地址")]
        [SoapHeader("SecurityKey")]
        public JsonResponse SaveAddress(string UserRealName, string Phone, string Mobile, string PostCode, int AreaID, string AreaName, string AddressInfo, string Email, int Modyfiyid)
        {
            if (IsAllow(false))
            {
                int id = EbSite.BLL.Address.Instance.Add(UserRealName, Phone, Mobile, PostCode, AreaID, AreaName, AddressInfo, Email, Modyfiyid);
                return new JsonResponse { Data = id.ToString(), Message = "调用成功", Success = true };
            }
            else
            {
                return new JsonResponse { Message = base.NoAllowTips, Success = false };
            }

        }

        [WebMethod(Description = "获取一个常用地址")]
        [SoapHeader("SecurityKey")]
        public JsonResponse<AddressJson> GetAddress(int id)
        {
            if (IsAllow(false))
            {

                EbSite.Entity.Address md = EbSite.BLL.Address.Instance.GetEntity(id);
                if (md != null)
                    return new JsonResponse<AddressJson> { Data = new AddressJson(md), Message = "调用成功", Success = true };
                return new JsonResponse<AddressJson> { Data = null, Message = "调用失败", Success = false };
            }
            else
            {
                return new JsonResponse<AddressJson> { Data = null, Message = base.NoAllowTips, Success = false };
            }

        }
        /// <summary>
        /// 获取运费
        /// </summary>
        /// <param name="deliveryid">配送方式ID</param>
        /// <param name="TotalWeight">总重量ID</param>
        /// <param name="id">地址ID</param>
        /// <param name="money">购物车中商品的原始价格</param>
        [WebMethod(Description = "获取运费")]
        [SoapHeader("SecurityKey")]
        public JsonResponse GetFreeByWeight(int deliveryid, decimal w, int id, decimal money)
        {
            if (IsAllow(false))
            {
                decimal CODTotalFree = 0;
                decimal dRree = EbSite.BLL.PsDelivery.Instance.GetFreeByWeight(deliveryid, w, id, money, out CODTotalFree);

                return new JsonResponse() { Data = dRree.ToString("#0.00"), Message = CODTotalFree.ToString("#0.00"), Success = true };
            }
            else
            {
                return new JsonResponse() { Message = base.NoAllowTips, Success = false };
            }

        }


        /// <summary>
        /// 验证优惠券
        /// </summary>
        /// <param name="number">号码 15位</param>
        /// <param name="money">总金额</param>
        /// <returns></returns>
        [WebMethod(Description = "验证优惠券")]
        [SoapHeader("SecurityKey")]
        public JsonResponse CheckTicket(string number, decimal imoney)
        {
            if (IsAllow(false))
            {
                int ilength = number.Length;
                if (ilength == 15)
                {
                    List<EbSite.Entity.CouponItems> ls = EbSite.BLL.CouponItems.Instance.GetListArray(1, "ClaimCode='" + number + "'", "");
                    if (ls.Count > 0)
                    {
                        EbSite.Entity.Coupons model = EbSite.BLL.Coupons.Instance.GetEntity(Convert.ToInt32(ls[0].CouponId));
                        if (imoney >= model.Amount)//要满足金额 
                        {
                            return new JsonResponse() { Data = "-" + model.DiscountPrice.ToString(), Message = "", Success = true };
                        }
                    }
                }
                return new JsonResponse() { Data = "0", Message = "0", Success = false };
            }
            else
            {
                return new JsonResponse() { Message = base.NoAllowTips, Success = false };
            }

        }


        /// <summary>
        /// 获取 整合用户中心域名
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string GetUserCenter()
        {
            string info = "";
            if (IsAllow(false))
            {
                info = EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.UserCenter;
            }
            return info;
        }

        [WebMethod]
        [SoapHeader("SecurityKey")]
        public JsonResponse PostVoteSingle(int vid, int itemid,int siteid)
        {
            EbSite.BLL.vote.Instance.PostVoteSingle(vid, itemid);
            string vurl = EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(siteid).GetVoteView(vid);
            return new JsonResponse() { Message = vurl, Success = true };

        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public JsonResponse PostVoteMore(int vid, string itemids, int siteid)//itemids逗号分开
        {
            EbSite.BLL.vote.Instance.PostVoteMore(vid, itemids);
            string vurl = EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(siteid).GetVoteView(vid);
            return new JsonResponse() { Message = vurl, Success = true };

        }

        [WebMethod(Description = "手机版问答获取分类")]
        [SoapHeader("SecurityKey")]
        public string GetClassMobile(int pid,int siteid)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendFormat("<h2 style=\"color: white; padding-left: 20px;padding-top:10px;\"><a href=\"{0}\">{1}</a></h2>", EbSite.Base.Host.Instance.MGetClassHref(pid, 1, 0, siteid), EbSite.BLL.NewsClass.GetModel(pid).ClassName);
            strHtml.AppendFormat("<div class=\"duanxian\"><div class=\"changxian\"></div></div><ul>");
            List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetSubClass(pid, 0, siteid);
            if (lst != null && lst.Count > 0)
            {
                foreach (EbSite.Entity.NewsClass m in lst)
                {
                    strHtml.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", EbSite.Base.Host.Instance.MGetClassHref(m.ID, 1, 0, siteid), m.ClassName);
                }
            }
            return strHtml.ToString() + "</ul>";
        }

         
    }
}
