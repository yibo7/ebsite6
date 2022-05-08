<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassManageSel.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.ClassManageSel" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<style>
    #OpMenuList li {
        list-style: none;
    }
</style>
 
<div style="background:#FAFAFA" class="container-fluid main-title">
    <div  class="row">
    <div class="col-sm-12">
        <h3 class="page-title">管理分类-列表模式</h3>
        <p class="text-muted page-title-alt">提示：您也可以切换到<a href="admin_Class.aspx?mpid=bb33d5ce-094a-420c-8bf7-dccb77524a6a&msid=eac8e169-ead9-485a-9dd3-e4ce31508fc4">表格模式来管理分类</a></p>
    </div>
</div>
</div>

 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul id="tagModels" class="nav nav-tabs">

            <asp:Repeater ID="repWebModel" runat="server">
                <ItemTemplate>
                    <li class="nav-item">
                        <a class="<%#Equals(Guid.Parse(Eval("id").ToString()),ModelID)?"active":"" %> nav-link" href="<%#GetUrl %>&modelid=<%#Eval("id") %>">
                            <span class="visible-xs"><i class="fa fa-tag"></i></span>
                            <span class="hidden-xs"><%#Eval("ModelName")%></span>
                        </a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" style="height:380px;" class="tab-pane active">
               
                <div style="margin-bottom: 5px;" id="OpMenuList" >
                </div>
                <div class="mainbox">
                    <div class="selbox">
                        <XSD:SelectClass ID="selClass" Height="200" ApiFunctionName="GetSubClassForAddClass" BackFun="onselcomp" runat="server"></XSD:SelectClass>
                    </div>
                </div>
               
            </div> 
        </div>
    </div>
</div> 

<div class="modal fade" id="iflModal" tabindex="-1" role="dialog"  aria-hidden="true">
  <div class="modal-dialog" >
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" >复制链接代码</h5>
        <button type="button" class="close" data-dismiss="modal" >
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div style="height:100px;" class="modal-body">
                连接引用代码（可以在模板适当位置引用此页面连接）：<br>
                        <textarea onclick="oCopy(this)" id="selbox" title="点击复制代码" style="width: 390px; height: 50px;"></textarea>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">关闭</button> 
      </div>
    </div>
  </div>
</div>


<script>
    $(function() {
        var objTags = $("#tagModels li");
        if (objTags.length == 1) {
            objTags.remove();
        }

    });
    function onselcomp() {
        var selID = $("#<%=selClass.hfValue.ClientID%>").val();
        GetClassSel(selID);
    }
    function GetClassSel(ClassID) {
        if (ClassID > 0) {
            var pram = { "cid": ClassID };

            runadminws("GetClassManageSel", pram, function (msg) {
                $("#OpMenuList").html("");

                var aMenus = msg.d;
                if (aMenus == null || aMenus == undefined) {
                    return;
                }

                var ulTag = $("<div class=\"btn-group\"><\/div>");

                ulTag.append($(String.format("<a class='btn btn-primary' href='{0}'  target=\"_blank\">前台页面</a>", aMenus.Url)));
                ulTag.append($(String.format("<a class='btn btn-primary' href='{1}'>查看内容(<font color=\"#ff0000\">{0}</font>)</a>", aMenus.CtCount, aMenus.CtUrl)));
                ulTag.append($(String.format("<a class='btn btn-primary' onclick='delclass({0})'>删 除</a>", aMenus.id)));
                ulTag.append($(String.format("<a class='btn btn-primary' onclick='copyclass({0})'>复 制</a>", aMenus.id)));
                ulTag.append($(String.format("<a class='btn btn-primary' href='{0}'> 编 辑 </a>", aMenus.UrlEdit)));
                ulTag.append($(String.format("<a class='btn btn-primary' onclick='configs({0})'>分类设置</a>", aMenus.id)));
                //ulTag.append($(String.format("<a class='btn btn-default' data-toggle=\"modal\" data-target=\"#iflModal\">链接代码</a>", aMenus.id)));
       
                
                var ulTagMore = $("<div class=\"btn-group\"><button type=\"button\" class=\"btn btn-primary dropdown-toggle\" data-toggle=\"dropdown\">更多<span class=\"caret\"></span></button><ul class=\"dropdown-menu\"></ul><\/div>");

                var subObj = ulTagMore.find(".dropdown-menu");// $(ulTagMore, ".dropdown-menu");
                subObj.append($(String.format("<li><a data-toggle=\"modal\" data-target=\"#iflModal\">{0}</a></li>", "链接代码")));
                subObj.append($(String.format("<li><a  onclick='makehtml({0})'>生成静态页</a></li>", aMenus.id)));
                subObj.append($(String.format("<li><a  onclick='makehtmlsub({1})'>生成子类页(<font color=\"#ff0000\">{0}</font>)</a></li>", aMenus.ChildCount,aMenus.id)));
                subObj.append($(String.format("<li><a  onclick='makehtmlcontent({1})'>生成内容页(<font color=\"#ff0000\">{0}</font>)</a></li>", aMenus.CtCount,aMenus.id)));                
                

                ulTag.append(ulTagMore);
                $("#OpMenuList").append(ulTag);
 
                $("#selbox").val(aMenus.UrlCode);

            });
        }
    }
    function makehtml(cid)
    {
        if(confirm("比较占用资源请慎用,确认要生成当前记录静态页(包括所有分页)吗？"))
        {
            location.href = "MakeProgressClass.aspx?cid="+cid;
        }
    }
    function makehtmlsub(cid)
    {
        if(confirm("比较占用资源请慎用,确认要生成当前记录所有子分类静态页吗？"))
        {
            location.href = "MakeProgressClass.aspx?pcid="+cid;
        }
    }
    function makehtmlcontent(cid)
    {
        if(confirm("比较占用资源请慎用,确认要生成当前记录所有内容页吗？"))
        {
            location.href = "MakeProgressContent.aspx?cid="+cid;
        }
    }
    function delclass(cid) {
        if(confirm("确认要删除记录吗？"))
        {
            var pram = {"cid":cid,"sid":<%=base.GetSiteID %>}
            runadminws("DelClass", pram, function (msg) {
                location.href = location.href;
            });
        }
        
        

    }
    function copyclass(cid) {
        if(confirm("确认要复制记录吗,复制完成后将进入编辑页面？"))
        {
            var pram = {"cid":cid,"sid":<%=base.GetSiteID %>}
            runadminws("CopyClass", pram, function (msg) {
                var d = msg.d;
                location.href = d.Data;
            });
        }
       

    }

    function configs(cid) {
        OpenIframe("?t=6&id=" + cid,"请选择分类设置后保存","保存设置")
    }
</script>
