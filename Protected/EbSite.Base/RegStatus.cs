using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace EbSite.Base
{
    public enum RegStatus
    {
        注册成功,
        注册失败,
        已经存在此帐号,
        已经存在此Email,
        已经存在此手机号码,
        帐号不能为空,
        Email不能为空,
        手机号码不能为空,
        用户名称不能为空
        


    }
}
