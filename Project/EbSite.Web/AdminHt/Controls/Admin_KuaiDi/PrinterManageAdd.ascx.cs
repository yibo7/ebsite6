using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_KuaiDi
{
    public partial class PrinterManageAdd : UserControlBaseSave
    {
        public string ItemContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SID))
                ItemContent = "data=%253Cprinter%2520picposition%253D%25220%253A0%2522%253E%253Citem%253E%253Cname%253E%25u53D1%25u8D27%25u4EBA-%25u59D3%25u540D%253C%2Fname%253E%253Cucode%253Edly_name%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E14%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E1%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E61%253A127%253A91%253A24%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u7F51%25u5E97%25u540D%25u79F0%253C%2Fname%253E%253Cucode%253Eshop_name%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E189%253A154%253A219%253A23%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u53D1%25u8D27%25u4EBA-%25u5730%25u5740%253C%2Fname%253E%253Cucode%253Edly_address%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E143%253A180%253A266%253A68%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u53D1%25u8D27%25u4EBA-%25u90AE%25u7F16%253C%2Fname%253E%253Cucode%253Edly_zip%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E8%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E323%253A249%253A91%253A20%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u221A%253C%2Fname%253E%253Cucode%253Etick%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E181%253A270%253A26%253A21%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u6536%25u8D27%25u4EBA-%25u59D3%25u540D%253C%2Fname%253E%253Cucode%253Eship_name%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E14%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E1%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E488%253A126%253A101%253A24%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u6536%25u8D27%25u4EBA-%25u5730%25u5740%253C%2Fname%253E%253Cucode%253Eship_addr%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E14%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E1%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E490%253A181%253A293%253A68%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u6536%25u8D27%25u4EBA-%25u7535%25u8BDD%253C%2Fname%253E%253Cucode%253Eship_tel%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E14%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E1%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E658%253A124%253A122%253A20%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u8BA2%25u5355-%25u7269%25u54C1%25u6570%25u91CF%253C%2Fname%253E%253Cucode%253Eorder_count%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E339%253A316%253A75%253A54%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u6D4B%25u8BD5%25u5185%25u5BB9-%25u7269%25u54C1%25u540D%25u79F0%253C%2Fname%253E%253Cucode%253Etext%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Ecenter%253C%2Falign%253E%253Cposition%253E75%253A330%253A207%253A21%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u8BA2%25u5355-%25u5907%25u6CE8%253C%2Fname%253E%253Cucode%253Eorder_memo%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E483%253A393%253A289%253A32%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u6536%25u8D27%25u4EBA-%25u5730%25u533A2%25u7EA7%253C%2Fname%253E%253Cucode%253Eship_area_2%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E1%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E480%253A251%253A73%253A21%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u5F53%25u65E5%25u65E5%25u671F-%25u5E74%253C%2Fname%253E%253Cucode%253Edate_y%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E474%253A371%253A42%253A22%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u5F53%25u65E5%25u65E5%25u671F-%25u6708%253C%2Fname%253E%253Cucode%253Edate_m%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E532%253A371%253A29%253A20%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u5F53%25u65E5%25u65E5%25u671F-%25u65E5%253C%2Fname%253E%253Cucode%253Edate_d%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E584%253A371%253A26%253A21%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u6536%25u8D27%25u4EBA-%25u90AE%25u7F16%253C%2Fname%253E%253Cucode%253Eship_zip%253C%2Fucode%253E%253Cfont%253E%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E8%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E672%253A251%253A112%253A21%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u53D1%25u8D27%25u4EBA-%25u7535%25u8BDD%253C%2Fname%253E%253Cucode%253Edly_tel%253C%2Fucode%253E%253Cfont%253Eundefined%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E289%253A122%253A120%253A20%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u53D1%25u8D27%25u4EBA-%25u624B%25u673A%253C%2Fname%253E%253Cucode%253Edly_mobile%253C%2Fucode%253E%253Cfont%253Eundefined%253C%2Ffont%253E%253Cfontsize%253E12%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E0%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E289%253A138%253A120%253A20%253C%2Fposition%253E%253C%2Fitem%253E%253Citem%253E%253Cname%253E%25u6536%25u8D27%25u4EBA-%25u624B%25u673A%253C%2Fname%253E%253Cucode%253Eship_mobile%253C%2Fucode%253E%253Cfont%253Eundefined%253C%2Ffont%253E%253Cfontsize%253E14%253C%2Ffontsize%253E%253Cfontspace%253E0%253C%2Ffontspace%253E%253Cborder%253E1%253C%2Fborder%253E%253Citalic%253E0%253C%2Fitalic%253E%253Calign%253Eleft%253C%2Falign%253E%253Cposition%253E658%253A144%253A124%253A20%253C%2Fposition%253E%253C%2Fitem%253E%253C%2Fprinter%253E&bg={bg}&copyright=shopex";

            else
            {
                Entity.Express md = EbSite.BLL.Express.Instance.GetEntity(int.Parse(SID));
                this.txtName.Text = md.Name;
                this.txtWidth.Text = md.BackGroundWidth.ToString();
                this.txtHeight.Text = md.BackGroundHeight.ToString();
                this.txtIsAct.Checked = md.IsAct;
                ItemContent = md.ItemContent;
                this.sLogo.ValSavePath = md.BackGround;
            }
           
        }
        public override string PageName
        {
            get
            {
                return " 快递单打印添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "301";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }


        protected override void InitModifyCtr()
        {
            
        }
        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(SID))
            {
                EbSite.Entity.Express md = new Express();
                md.Name = txtName.Text.Trim();
                md.IsAct = txtIsAct.Checked;
                md.BackGround = sLogo.ValSavePath;
                md.ItemContent = HbflashData.Value;
                EbSite.BLL.Express.Instance.Add(md);
            }
            else
            {
                Entity.Express md = EbSite.BLL.Express.Instance.GetEntity(int.Parse(SID));
                md.Name = txtName.Text.Trim();
                md.IsAct = txtIsAct.Checked;
                md.BackGround = sLogo.ValSavePath;
                md.ItemContent = HbflashData.Value;
                EbSite.BLL.Express.Instance.Update(md);
            }
        }

    }
}