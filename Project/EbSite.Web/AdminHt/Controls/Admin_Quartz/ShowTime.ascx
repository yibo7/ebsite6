<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowTime.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Quartz.ShowTime" %> 
 
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>任务:<%=Model.TaskName %></h3>
            </div>
            <div class="content">
				 <div>
               创建时间:<%=Model.CreatedTime %>
            </div>
           
            <div>
               最后执行时间:<%=Model.RecentRunTime %>
            </div>
             
            <div>
               最后执行结果:<%=Model.LastRezult %>
            </div>
            <div>
               下次执行时间:<%=Model.NextFireTime %>
            </div>
              <div>
               备注:<%=Model.Remark %>
            </div>
             <div>
               Cron表达式:<%=Model.CronExpressionString %>
            </div>
             <div>
               未来10次运行时间预算:
            </div>
            <div>
               <%=GetRunTime %>
            </div>
            </div>
    </div>
</div>