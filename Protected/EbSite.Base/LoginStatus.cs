using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace EbSite.Base
{
    public enum LoginStatus
    {
        登录成功,
        登录失败,
        不存在此帐号或密码错误,
        不存在此Email或密码错误,
        不存在此手机号码或密码错误,
        帐号不能为空,
        Email不能为空,
        手机号码不能为空,
        验证码不正确,
        错误登录次数超出规定,
        IP禁止登录,
        帐号没有激活


    }
}
