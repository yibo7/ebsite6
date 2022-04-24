using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Entity
{
    /// <summary>
    /// YHL 2014-2-12 辅助标签 对象转成 NewsContent
    /// </summary>
  [Serializable]
    public  class ContentTbName
    {
      public ContentTbName()
        { }
      public string TbName { get; set; }
      public string Newsid { get; set; }
    }
}
