using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ
{
    /// <summary>
    /// ��SettingInfo:ϵͳ����ʵ�壬����������������������ԣ����÷���(�ɲο�Setting.ascx):SettingInfo.Instance.CF
    /// ����ModuleAttribute:��ģ�����Ҫ��Ϣ����������д
    /// </summary>
    [ModuleAttribute("������CQ", Version = "1.0.0", Author = "С�˲�", AuthorUrl = "http://www.ebsite.net")]
    public class SettingInfo : EbSite.Base.Modules.Configs.Configs<SettingInfo>
    {
        override public Guid CurrentModelID
        {
            get
            {
                return new Guid("b456beef-6b3e-4caf-b282-fd17fc4c8684");
            }
        }
        public static readonly SettingInfo Instance = new SettingInfo();
        public SettingInfo()
        {
            //���ݿ����Ӽ���ǰԵ��ϵͳ��ͬ
            //base.IsUserSysConn = true;
        }

		#region ��չ����
		//������д�Զ�����������

	    #endregion

    }
}