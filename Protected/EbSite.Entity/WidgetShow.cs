using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using EbSite.Core.DataStore;

namespace EbSite.Entity
{
    /// <summary>
    /// 此类只数据传递用，没有实际操作的wiget实体
    /// </summary>
    [Serializable]
    public class WidgetShow : EbSite.Base.ExtWidgets.ShowBase
    {
        //private string _CacheKey;
        //new  public string CacheKey
        //{
        //    get
        //    {
        //        return _CacheKey;
        //    }
        //    set
        //    {
        //        _CacheKey = value;
        //    }
        //}
       
        private string _TypeWidget;
        public string TypeWidget
        {
            get
            {
                return _TypeWidget;
            }
            set
            {
                _TypeWidget = value;
            }
        }
        public override string Name
        {
            get { return TypeWidget; }
        }

        public override void LoadData()
        {
            throw new AbandonedMutexException();
        }
       

        private bool _IsNoSysTem = true;
        public bool IsNoSysTem
        {
            get
            {
                return _IsNoSysTem;
            }
            set
            {
                _IsNoSysTem = value;
            }
        } 

       
       
    }
}
