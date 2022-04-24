using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.GetLink;
using EbSite.BLL.Jobs;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Quartz
{
    public partial class List : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "317";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 添加数据的权限ID
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 修改数据权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "163";
            }
        }
        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }

         
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.JobTask.Instance.FillList();


        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.JobTask.Instance.Delete(new Guid(iID.ToString()));

        }

        protected override void CopyData(object ID)
        {
            var model =BLL.JobTask.Instance.GetEntity(new Guid(ID.ToString()));
            model.id = Guid.NewGuid();
            model.CreatedTime = DateTime.Now;
            model.Status = 0;
            model.TaskName = "复制-" + model.TaskName;
            model.IsNoSys = true;

            BLL.JobTask.Instance.Add(model);

            //BLL.JobTask.Instance.CopyData(new Guid(ID.ToString()));

        }

        protected override void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "stop"))
            {
                string id = e.CommandArgument.ToString();
                var model = BLL.JobTask.Instance.GetEntity(new Guid(id));
                if (model.Status == 1)//如果任务是开户状态，执行停止操作
                {
                    model.Status = 0;
                    QuartzHelper.PauseJob(id);
                }
                else //执行开启操作
                {
                    model.Status = 1;
                    QuartzHelper.ResumeJob(id);
                }

                BLL.JobTask.Instance.Update(model);//记录状态，以备下次网站收回重启的时候排除这些暂停过的任务

                base.gdList_Bind();
            }
        }

  
    }
}