using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Wenda.ModuleCore.Pages;

namespace EbSite.Modules.Wenda.AdminPages.Controls.ImitatePost
{
    public partial class AddPost : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("82fa4686-66a7-4731-b5a1-e4ca71fb7a7e");
            }
        }
        public override string PageName
        {
            get
            {
                return "模拟发帖管理目录重写";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override string Permission
        {
            get
            {
                return "31";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //ModuleCore.Pages.mfastTopics model = new mfastTopics();
            //string[] arry = new string[] {"测试1|10","测试2|7","测试3|5"};
            //model.DataImportList("11",12738,"22",arry);

            //#region  2013-03-27 yhl

            //List<EbSite.Entity.NewsClass> ls = EbSite.BLL.NewsClass.GetListArr("annex10=1", 1);
            //foreach (var newsClass in ls)
            //{
            //    List<EbSite.Entity.NewsClass> slist = EbSite.BLL.NewsClass.GetListArr("parentid=" + newsClass.ID, 1);
            //    foreach (var i in slist)
            //    {
            //        i.ClassName = i.ClassName.Replace(newsClass.ClassName, "");
            //        EbSite.BLL.NewsClass.Update(i);
            //    }
            //}


            //#endregion

            this.DrpPostUser.DataSource = ModuleCore.BLL.PostUserControl.Instance.FillList();
            this.DrpPostUser.DataValueField = "id";
            this.DrpPostUser.DataTextField = "UserName";

            this.DrpPostUser.DataBind();
            this.DrpPostUser.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        override protected void InitModifyCtr()
        {


        }


        override protected void SaveModel()
        {

        }


        //protected void DrpPostUser_SelectedIndexChanged(Object sender, EventArgs e)
        //{
        //    string ikey = this.DrpPostUser.SelectedValue;

        //    if (ikey == "-1")
        //    {
        //        txtSend.Text = "";
        //        txtAnswer.Text = "";
        //        txtSendID.Text = "";
        //        txtAnswerID.Text = "";

        //    }
        //    else
        //    {
        //        ModuleCore.Entity.PostUser md = ModuleCore.BLL.PostUserControl.Instance.GetEntity(int.Parse(ikey));
        //        int seate = 0;

        //        txtSendID.Text = GetRandomCode(md.UserIdField, 1, ref seate);
        //        txtSend.Text = md.UserNameField.Split(',')[seate];

        //        int seate2 = 0;
        //        txtAnswerID.Text = GetRandomCode(md.UserIdField, 1, ref seate2);// md.UserNameField.Split(',')[1];
        //        txtAnswer.Text = md.UserNameField.Split(',')[seate2]; //md.UserIdField.Split(',')[1];
        //    }

        //}
        /// <summary>
        /// 随机数
        /// </summary>
        /// <param name="allChar">数据源</param>
        /// <param name="CodeCount"></param>
        /// <param name="seate">返回 索引</param>
        /// <returns></returns>
        private string GetRandomCode(string allChar, int CodeCount, ref int seate)
        {
            //string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(allCharArray.Length);

                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }
            seate = temp;
            return RandomCode;
        }

    }
}