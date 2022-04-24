using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using EbSite.Base.CusttomTable;

namespace EbSite.BLL.ModelBll
{
    public abstract class  ICusttomFiledsBLL<ITYPE>
    {
        private ISettingsBehavior<ITYPE> _settingsBehavior;
        
        protected ISettingsBehavior<ITYPE> SettingsBehavior
        {
            get
            {
                return _settingsBehavior;
            }
            set
            {
                _settingsBehavior = value;
            }
        }
    } 
}
