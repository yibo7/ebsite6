<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PoolState.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.PoolState" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>线程池运行状态</h3>
            目前EbSite线程池只应用在静态页生成,邮件发送当中
            </div>
            <div class="eb-content">
				 
                    最大线程数:<%=EbSite.Base.ThreadPoolManager.GetMaxThreadCount()%>
                     &nbsp;&nbsp;&nbsp;&nbsp;
                重置最大线程数:<XS:TextBoxVl ID="txtMaxThread" ValidationGroup="vg1" ValidateType="匹配正整数" Width="50" Text="5" runat="server"></XS:TextBoxVl> 
                <br />
                <XS:Button  ValidationGroup="vg1" ID="bntSave" Confirm="true" runat="server" Text="确认保存"  />

                    <br /> <br />
                    等待的任务数量:<%=EbSite.Base.ThreadPoolManager.GetWaitingCallbacks()%><br />
                    最小线程数:<%=EbSite.Base.ThreadPoolManager.GetMinThreadCount()%><br />
                    活动线程数:<%=EbSite.Base.ThreadPoolManager.GetActiveThreadCount()%><br />
                    使用中线程数:<%=EbSite.Base.ThreadPoolManager.GetInUseThreadCount()%><br /><br />        
              <XS:Button  ID="bntStopAllThread" Confirm="true" runat="server" Text="终止所有任务" onclick="bntStopAllThread_Click"  />
            </div>
    </div>
</div>