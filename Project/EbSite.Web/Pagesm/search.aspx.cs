using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.Pagesm
{
    public partial class search : Pages.Search
    {
        protected string MTitle
        {
            get
            {
                return "搜索";
            }
        }

        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();
        }

        protected override void InitStyle()
        {
            base.MobileInitStyle();
        }

        /// <summary>
        /// 每页显示多少条记录
        /// </summary>
        protected override int iPageSize
        {
            get
            {
                if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return 15;
                }

            }
        }



    }
}