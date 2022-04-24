<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BalanceDetails.ascx.cs"
    Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney.BalanceDetails" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div class="gdList_title">
    <div style="width: 50px;">
        流水号</div>
    <div style="width: 120px;">
        时间</div>
    <div style="width: 100px;">
        类型
    </div>
    <div style="width: 130px;">
        收入
    </div>
    <div style="width: 100px;">
        支出
    </div>
    <div style="width: 130px;">
        账户余额
    </div>
    <div style="width: 130px;">
        备注
    </div>
</div>
<XS:Repeater ID="gdList" runat="server">
    <itemtemplate> 
                <div class="gdListContent" >
                  <div style="width:50px;"> <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.ItemIndex + 1%></div> 
                  <div   style="width:120px;">   <%#Eval("TradeDate")%></div>
                    <div   style="width:100px;">   <%#EbSite.BLL.AccountMoneyType.GetAccountMoneyTypeName(Eval("TradeType").ToString())%></div>
                      <div   style="width:130px;text-align:right;"> 
                       <%# string.Format("{0:N}", Convert.ToDecimal(Eval("Income")))%>
                      </div>
                        <div   style="width:100px; text-align:right;"> 
                         <%# string.Format("{0:N}", Convert.ToDecimal(Eval("Expenses")))%>
                         </div>
                          <div   style="width:130px;text-align:right;">   
                           <%# string.Format("{0:N}", Convert.ToDecimal(Eval("Balance")))%>
                         </div> 
                           <div   style="width:130px;">   <%#Eval("Remark")%></div>
                  
                
                </div>           
               
            </itemtemplate>
</XS:Repeater>
<XS:PagesContrl ID="pcPage" runat="server" />
