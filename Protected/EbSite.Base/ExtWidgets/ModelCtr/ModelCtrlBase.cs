using System;
using System.Collections.Specialized;
using System.Web.UI;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets.ModelCtr
{
    public abstract class ModelCtrlBase : ShowBase
    {
        public ModelCtrlBase()
        {
            base.Extensiontype = ExtensionType.Ctrl;
        }
        //public override ExtensionType ExtensionTp
        //{
        //    get
        //    {
        //        return ExtensionType.Ctrl;
        //    }
        //}
        
        private bool _IsOutLoad = false;
        /// <summary>
        /// 是否外部调用
        /// </summary>
        public bool IsOutLoad
        {
            get { return _IsOutLoad; }
            set { _IsOutLoad = value; }
        }
        protected override void  OnInit(EventArgs e)
        {
            if (!IsOutLoad) LoadData(); //这里默认内容调用，如外部调用，要将IsOutLoad设置为True,否则调用两次
 	         base.OnInit(e);
        }

        /// <summary>
        /// 获取控件的值
        /// </summary>
        /// <returns></returns>
        public abstract string GetValue();
        /// <sumMmary b bv
        /// 设置控件的值
        /// </summary>
        /// <returns></returns>
        public abstract void SetValue(string sValue);
    }
}
