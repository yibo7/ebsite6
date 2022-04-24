using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using AreaInfo = EbSite.Entity.AreaInfo;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class AreaList : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "306";
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
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            IDictionaryEnumerator ide = HttpRuntime.Cache.GetEnumerator();

            while (ide.MoveNext())
            {
                HttpRuntime.Cache.Remove(ide.Key.ToString());
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CheckData();

                BindData1();
            }
        }
        /// <summary>
        /// 导数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddArea_Click(object sender, EventArgs e)
        {
           bool ikey=   EbSite.BLL.AreaInfo.Instance.AreaDataAllAdd(Server.MapPath(@"\install\sql\mysql\"));
            if (ikey)
            {
                CheckData();

                BindData1();
            }
        }

        private void CheckData()
        {
            int sCount = BLL.AreaInfo.Instance.GetCount("");
            if (sCount == 0)
            {
                this.PaneArea.Visible = true;
                this.PanelComplete.Visible = false;
            }
            else
            {
                this.PaneArea.Visible = false;
                this.PanelComplete.Visible = true;
            }
        }

        /// <summary>
        /// 一级地区更改选中触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Area_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //先要清空

            List<Entity.AreaInfo> ls = BLL.AreaInfo.Instance.GetListTree(int.Parse(Area_1.SelectedValue));

            this.LevelID.Text = "2";
            this.NowLevelID.Value = "2";
            this.HeadID.Text = Area_1.SelectedValue;

            this.Area_2.DataSource = ls;
            this.Area_2.DataTextField = "Name";
            this.Area_2.DataValueField = "id";
            this.Area_2.DataBind();

            ChangeButtonStatus(true);
            FormatAddStatus();

            Area_3.Items.Clear();


            Area_4.Items.Clear();

        }

        /// <summary>
        /// 二级地区更改选中触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Area_2_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Entity.AreaInfo> ls = BLL.AreaInfo.Instance.GetListTree(int.Parse(Area_2.SelectedValue));

            this.LevelID.Text = "3";
            this.NowLevelID.Value = "3";
            this.HeadID.Text = Area_2.SelectedValue;

            this.Area_3.DataSource = ls;
            this.Area_3.DataTextField = "Name";
            this.Area_3.DataValueField = "id";
            this.Area_3.DataBind();

            ChangeButtonStatus(true);
            FormatAddStatus();
            Area_4.Items.Clear();

        }

        /// <summary>
        /// 三级地区更改选中触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Area_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Entity.AreaInfo> ls = BLL.AreaInfo.Instance.GetListTree(int.Parse(Area_3.SelectedValue));

            this.LevelID.Text = "4";
            this.NowLevelID.Value = "4";
            this.HeadID.Text = Area_3.SelectedValue;

            this.Area_4.DataSource = ls;
            this.Area_4.DataTextField = "Name";
            this.Area_4.DataValueField = "id";
            this.Area_4.DataBind();

            ChangeButtonStatus(true);
            FormatAddStatus();

        }

        /// <summary>
        /// 四级地区更改选中触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Area_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LevelID.Text = "5";
            this.NowLevelID.Value = "5";
            this.btnEdit.Enabled = true;
            FormatAddStatus();
        }
        #region 数据绑定
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData1()
        {

            List<Entity.AreaInfo> ls = BLL.AreaInfo.Instance.GetListDataing(1);
            this.Area_1.DataSource = ls;
            this.Area_1.DataTextField = "Name";
            this.Area_1.DataValueField = "id";
            this.Area_1.DataBind();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData2()
        {

            List<Entity.AreaInfo> ls = BLL.AreaInfo.Instance.GetListDataing(2);
            this.Area_2.DataSource = ls;
            this.Area_2.DataTextField = "Name";
            this.Area_2.DataValueField = "id";
            this.Area_2.DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData3()
        {

            List<Entity.AreaInfo> ls = BLL.AreaInfo.Instance.GetListDataing(3);
            this.Area_3.DataSource = ls;
            this.Area_3.DataTextField = "Name";
            this.Area_3.DataValueField = "id";
            this.Area_3.DataBind();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData4()
        {

            List<Entity.AreaInfo> ls = BLL.AreaInfo.Instance.GetListDataing(4);
            this.Area_4.DataSource = ls;
            this.Area_4.DataTextField = "Name";
            this.Area_4.DataValueField = "id";
            this.Area_4.DataBind();
        }
        #endregion
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
        }



        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButAll_Click(object sender, EventArgs e)
        {
            string[] arry = this.AllAreaNames.Text.Trim().Split(',');
            foreach (var s in arry)
            {
                Entity.AreaInfo md = new AreaInfo();
                if (this.IsFirst.Checked == true)
                {
                    this.LevelID.Text = "1";
                    this.NowLevelID.Value = "1";
                    this.HeadID.Text = "0";


                    md.OrderID = BLL.AreaInfo.Instance.GetAreaOrderNums(int.Parse(this.LevelID.Text));//排序iD
                    md.HeadID = 0;//父类ID
                    md.Level = 1;//深度
                }
                else
                {

                    md.OrderID = BLL.AreaInfo.Instance.GetAreaOrderNums(int.Parse(this.LevelID.Text));//排序iD 得到某一深度的最大排序ID
                    // md.OrderID = 100;
                    md.HeadID = int.Parse(this.HeadID.Text);//父类ID
                    md.Level = int.Parse(this.LevelID.Text);//深度
                }
                md.Name = s;//地区名称

                BLL.AreaInfo.Instance.Add(md);

            }

            if (this.IsFirst.Checked == true)
            {
                BindData1();
            }
            else
            {
                if (int.Parse(this.LevelID.Text) == 2)
                {
                    BindData2();
                }
                if (int.Parse(this.LevelID.Text) == 3)
                {
                    BindData3();
                }
                if (int.Parse(this.LevelID.Text) == 4)
                {
                    BindData4();
                }
            }

            this.AllAreaNames.Text = "";
        }
        ///
        /// <summary>
        /// 添加地区事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddSubmit_Click(object sender, EventArgs e)
        {
            Entity.AreaInfo md = new AreaInfo();
            if (this.IsFirst.Checked == true)
            {
                this.LevelID.Text = "1";
                this.NowLevelID.Value = "1";
                this.HeadID.Text = "0";


                md.OrderID = BLL.AreaInfo.Instance.GetAreaOrderNums(int.Parse(this.LevelID.Text));//排序iD
                md.HeadID = 0;//父类ID
                md.Level = 1;//深度
            }
            else
            {

                md.OrderID = BLL.AreaInfo.Instance.GetAreaOrderNums(int.Parse(this.LevelID.Text));//排序iD 得到某一深度的最大排序ID
                // md.OrderID = 100;
                md.HeadID = int.Parse(this.HeadID.Text);//父类ID
                md.Level = int.Parse(this.LevelID.Text);//深度
            }
            md.Name = txtName.Text.Trim();//地区名称

            BLL.AreaInfo.Instance.Add(md);

            if (this.IsFirst.Checked == true)
            {
                BindData1();
            }
            else
            {
                if (int.Parse(this.LevelID.Text) == 2)
                {
                    BindData2();
                }
                if (int.Parse(this.LevelID.Text) == 3)
                {
                    BindData3();
                }
                if (int.Parse(this.LevelID.Text) == 4)
                {
                    BindData4();
                }
            }

            this.txtName.Text = "";
        }

        /// <summary>
        /// 修改地区事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditSubmit_Click(object sender, EventArgs e)
        {

            if (int.Parse(this.LevelID.Text) == 2)
            {
                Entity.AreaInfo md = BLL.AreaInfo.Instance.GetEntity(int.Parse(Area_1.SelectedValue));
                md.Name = this.txtName.Text;
                BLL.AreaInfo.Instance.Update(md);
                BindData1();
            }
            if (int.Parse(this.LevelID.Text) == 3)
            {
                Entity.AreaInfo md = BLL.AreaInfo.Instance.GetEntity(int.Parse(Area_2.SelectedValue));
                md.Name = this.txtName.Text;
                BLL.AreaInfo.Instance.Update(md);
                BindData2();
            }
            if (int.Parse(this.LevelID.Text) == 4)
            {
                Entity.AreaInfo md = BLL.AreaInfo.Instance.GetEntity(int.Parse(Area_3.SelectedValue));
                md.Name = this.txtName.Text;
                BLL.AreaInfo.Instance.Update(md);
                BindData3();
            }
            if (int.Parse(this.LevelID.Text) == 5)
            {
                Entity.AreaInfo md = BLL.AreaInfo.Instance.GetEntity(int.Parse(Area_4.SelectedValue));
                md.Name = this.txtName.Text;
                BLL.AreaInfo.Instance.Update(md);
                BindData4();
            }
            this.txtName.Text = "";
            this.btnAddSubmit.Visible = true;
            this.btnEditSubmit.Visible = false;
            this.IsFirst.Visible = true;
        }




        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string name = "";
            if (this.LevelID.Text != "1")
            {
                this.btnAddSubmit.Visible = false;
                this.btnEditSubmit.Visible = true;
                this.IsFirst.Visible = false;

                // ListBox lb = (ListBox)Page.PagesMain.FindControl("Area_" + (int.Parse(this.NowLevelID.Value) - 1).ToString());
                if (this.NowLevelID.Value == "2")
                {
                    if (Area_1.SelectedValue == "")
                    {
                        base.ShowTipsPop("没有选择对应的项");
                    }
                    else
                    {
                        name = Area_1.SelectedItem.Text;
                    }

                }
                if (this.NowLevelID.Value == "3")
                {
                    if (Area_2.SelectedValue == "")
                    {
                        base.ShowTipsPop("没有选择对应的项");
                    }
                    else
                    {
                        name = Area_2.SelectedItem.Text;
                    }
                }
                if (this.NowLevelID.Value == "4")
                {
                    if (Area_3.SelectedValue == "")
                    {
                        base.ShowTipsPop("没有选择对应的项");
                    }
                    else
                    {
                        name = Area_3.SelectedItem.Text;
                    }
                }
                if (this.NowLevelID.Value == "5")
                {
                    if (Area_4.SelectedValue == "")
                    {
                        base.ShowTipsPop("没有选择对应的项");
                    }
                    else
                    {
                        name = Area_4.SelectedItem.Text;
                    }
                }
                this.txtName.Text = name;
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (this.NowLevelID.Value == "2")
            {
                if (IsGetTree(int.Parse(Area_1.SelectedValue)))
                {
                    //base.Tips("提示","不对删除，因为有子内容。");
                    // TipsAlert("不对删除，因为有子内容。");
                    base.ShowTipsPop("不对删除，因为有子内容。");

                }
                else
                {
                    BLL.AreaInfo.Instance.Delete(int.Parse(Area_1.SelectedValue));
                    BindData1();
                }

            }
            if (this.NowLevelID.Value == "3")
            {
                if (IsGetTree(int.Parse(Area_2.SelectedValue)))
                {
                    base.ShowTipsPop("不对删除，因为有子内容。");
                }
                else
                {
                    BLL.AreaInfo.Instance.Delete(int.Parse(Area_2.SelectedValue));
                    BindData2();
                }
            }
            if (this.NowLevelID.Value == "4")
            {
                if (IsGetTree(int.Parse(Area_3.SelectedValue)))
                {
                    base.ShowTipsPop("不对删除，因为有子内容。");
                }
                else
                {
                    BLL.AreaInfo.Instance.Delete(int.Parse(Area_3.SelectedValue));
                    BindData3();
                }
            }
            if (this.NowLevelID.Value == "5")
            {
                BLL.AreaInfo.Instance.Delete(int.Parse(Area_4.SelectedValue));
                BindData4();
            }

        }
        /// <summary>
        /// 判断下面有没有子项内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool IsGetTree(int id)
        {
            bool tag = false;
            List<Entity.AreaInfo> md = BLL.AreaInfo.Instance.GetListTree(id);
            if (md.Count > 0)
            {
                tag = true;
            }
            return tag;
        }
        private void ChangeButtonStatus(bool Status)
        {
            this.btnEdit.Enabled = Status;
            this.btnDelete.Enabled = Status;
        }

        /// <summary>
        /// 默认成添加状态
        /// </summary>
        private void FormatAddStatus()
        {
            this.txtName.Text = "";
            this.btnAddSubmit.Visible = true;
            this.btnEditSubmit.Visible = false;
        }
    }

}