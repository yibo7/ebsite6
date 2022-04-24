using System;
using System.IO;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Comment
{
    /*2014-3-5 YHL
     * 原来 Remark 表中 启用 Mark标实 时 ，在分类和内容 统计 评价 总数时 不能区分 后加 页面分类 用Ipage来 承载
     * 现在 扩展字段了 加了 classid contentid ，这样 就可以方便的 知道 是分类 还是内容了。如 contentid =0时 ，必定为分类
     */
    public partial class AddClass : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "126";
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
            Entity.RemarkClass md = BLL.RemarkClass.Instance.GetModel(ID);
            txtClassName.Text = md.ClassName;
            itype.SelectedValue = md.Itype.ToString();
           
            itype.Enabled = false;
           

        }

        override protected void SaveModel()
        {
            Entity.RemarkClass model = new RemarkClass();
            model.ClassName = txtClassName.Text;
            model.Itype = int.Parse(itype.SelectedValue);
            
            if (ID ==0)
            {
                int iNewId = BLL.RemarkClass.Instance.Add(model);
                if (model.Itype == 1) //盖楼式评论
                {
                    
                    string sfName = BLL.RemarkClass.GetNewPath(iNewId);
                    string sTemHtml = Core.FSO.FObject.ReadFile(Server.MapPath(BLL.RemarkClass.GetTemPath));
                    Core.FSO.FObject.WriteFile(Server.MapPath(sfName), sTemHtml);
                }
                else if (model.Itype == 2)//好评系统
                {
                  
                    string sfName = BLL.RemarkClass.GetNewPath(iNewId,2);
                    string sTemHtml = Core.FSO.FObject.ReadFile(Server.MapPath(BLL.RemarkClass.GetTemPathPJ));
                    Core.FSO.FObject.WriteFile(Server.MapPath(sfName), sTemHtml);
                }
                else if (model.Itype == 3)//一问一答,商家问答
                {

                    string sfName = BLL.RemarkClass.GetNewPath(iNewId, 3);
                    string sTemHtml = Core.FSO.FObject.ReadFile(Server.MapPath(BLL.RemarkClass.GetTemPathAskRemark));
                    Core.FSO.FObject.WriteFile(Server.MapPath(sfName), sTemHtml);
                }
              

            }
            else
            {
                model.id = ID;
                BLL.RemarkClass.Instance.Update(model);
            }
        }

        private int ID
        {
            get
            {
                if(!string.IsNullOrEmpty(SID))
                {
                    return int.Parse(SID);
                }
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    if(ID>0)
            //    {
            //        this.btnAdd.Text = "修改分类";

            //        txtClassName.Text = BLL.RemarkClass.GetModel(ID).ClassName;
            //    }
            //}
        }
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    Entity.RemarkClass model = new RemarkClass();
        //    model.ClassName = txtClassName.Text;

        //    if (ID<1)
        //    {
        //       int iNewId = BLL.RemarkClass.Add(model);
        //       string sfName = BLL.RemarkClass.GetNewPath(iNewId);
        //       string sTemHtml = Core.FSO.FObject.ReadFile(Server.MapPath(BLL.RemarkClass.GetTemPath));
        //        Core.FSO.FObject.WriteFile(Server.MapPath(sfName), sTemHtml);
                
        //    }
        //    else
        //    {
        //        model.id = ID;
        //        BLL.RemarkClass.Update(model);
        //    }

            
        //}
    }
}