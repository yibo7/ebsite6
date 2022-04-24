using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.BrandManage
{
    public partial class BrandAdd : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "品牌添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "37";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.GoodsBrand.Instance.InitModifyCtr(SID, phCtrList);
            ModuleCore.Entity.GoodsBrand md = ModuleCore.BLL.GoodsBrand.Instance.GetEntity(int.Parse(SID));
            BrandName.Text = md.BrandName;
            Description.Text = md.Description;
            OrderID.Text = md.OrderID.ToString();
            sLogo.ValSavePath = md.Logo;

            cbMore.Visible = false;
        }


        override protected void SaveModel()
        {
            //if (string.IsNullOrEmpty(SID))
            //{
            //    ModuleCore.Entity.GoodsBrand md = new GoodsBrand();
            //    md.BrandName = BrandName.Text;
            //    md.Description = Description.Text;
            //    md.Logo = sLogo.ValSavePath;
            //    ModuleCore.BLL.GoodsBrand.Instance.Add(md);
            //}

            if (cbMore.Checked)//批量添加
            {
                string ClassNames = txtClassNames.Text.Trim();
                if (!string.IsNullOrEmpty(ClassNames))
                {
                    string[] aClassName = ClassNames.Split('#');
                    foreach (string sClassName in aClassName)
                    {
                        if (!string.IsNullOrEmpty(sClassName))
                        {
                            ModuleCore.Entity.GoodsBrand md = new GoodsBrand();
                            md.BrandName = sClassName;

                            ModuleCore.BLL.GoodsBrand.Instance.Add(md);
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(BrandName.Text.Trim()))
                {
                    TipsAlert("名称必添！");
                }
                else
                {
                    OtherColumn other = new OtherColumn("Logo", sLogo.ValSavePath);
                    lstOtherColumn.Add(other);
                    ModuleCore.BLL.GoodsBrand.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
                }
            }

        }
    }
}