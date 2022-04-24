<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberToGroup.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.MemberToGroup" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>设置会员组</b></h4>
            <div>
                <XS:Repeater ID="rpList" runat="server">
                    <ItemTemplate>
                        <label class="checkbox-inline">
                            <input type="radio" name="rdUserGroup" id="rdUserGroup<%#Eval("id") %>" value="<%#Eval("id") %>"><%#Eval("GroupName") %>
                        </label>
                    </ItemTemplate>
                </XS:Repeater>
            </div>
            
        </div>
    </div>
</div>
<script>
    $(function() {
        $('#rdUserGroup<%=GetUserGroupID%>').attr('checked', 'true');
    });
    function SaveFrame() {
        tips("正在处理中...", 1, 10);
        var id = $('input:radio:checked').val();
        if (id) {

            runadminws("SaveUserToGroup", { gid: id,u:'<%=sUserName%>' },function(msg) {
                RefeshParent1();
            });
           
        } else {
            tips("请选择一个用户组", 3, 3);
        }
    }
</script>