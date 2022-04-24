using System;
using EbSite.BLL.Ctrtem;

namespace EbSite.Base.ExtWidgets
{
    public abstract class ShowBase : Base
    {

        //virtual public string CacheKey
        //{
        //    get
        //    {
        //        return base.DataID.ToString();
        //    }
        //}
        /// <summary>
        /// Gets the name. It must be exactly the same as the folder that contains the widget.
        /// </summary>
        public abstract string Name { get; }
       
        
    }
}
