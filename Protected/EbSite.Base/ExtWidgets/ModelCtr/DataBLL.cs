using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets.ModelCtr
{
    public class DataBLL : DataBLLBase
    {
        public static readonly DataBLL Instance = new DataBLL();

        public override ExtensionType ExtensionTp
        {
            get
            {
                return ExtensionType.Ctrl;
            }
        }

        /// <summary>
        /// 用来保存数据列表的文件名称,不带后缀
        /// </summary>
        override public string DefualtZoneName
        {
            get
            {
                return "ModelCtrlList";
            }
        }

        /// <summary>
        /// 显示控件的名称
        /// </summary>
        override public string AscxName_Show
        {
            get
            {
                return "Ctrl.ascx";
            }
        }
        /// <summary>
        /// 编辑控件的名称
        /// </summary>
        override public string AscxName_Edit
        {
            get
            {
                return "edit.ascx";
            }
        }
        /// <summary>
        /// 控件的存放目录
        /// </summary>
        override public string AscxFilePath
        {
            get
            {
                //return "ExtensionsCtrls";
                return EbSite.Base.Host.Instance.CurrentSite.GetPathCtrlTempList(0);
            }
        }
        override public string FilePath
        {
            get
            {

                return "ExtensionsCtrls";
            }
        }
       


    }
}
