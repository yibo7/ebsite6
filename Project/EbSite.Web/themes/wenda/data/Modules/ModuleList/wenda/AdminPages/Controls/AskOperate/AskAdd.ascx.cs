using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskOperate
{
    public partial class AskAdd : MPUCBaseSave
    {
        public override string Permission
        {
            get
            {
                return "7";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            //ModuleCore.BLL.Answers.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            base.CloseWinBox();
            //ModuleCore.BLL.Answers.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            //base.ShowTipsPop("添加成功");
        }
    }
}