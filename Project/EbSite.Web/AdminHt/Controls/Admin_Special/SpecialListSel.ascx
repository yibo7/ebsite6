<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialListSel.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.SpecialListSel" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div  style="height: 58px !important" class="boxheader htips">
                <h3>管理专题</h3>
            提示：这里最多展示5000列表，如果专题过大可以切换到<a href="Admin_Special.aspx?mpid=ce45900d-f3cd-4f03-839d-cbbe456a0607&msid=aa9847a5-7258-40d1-8b73-40caa1670c9b">表格模式来管理专题</a>
            </div>
            <div class="eb-content">
				 
                <div class="classtoolbar"></div>
            
                <br/><br/>
                <XSD:SelectClass ID="selClass" ApiFunctionName="GetSubSpecial" BackFun="onselcomp" runat="server"></XSD:SelectClass>
            </div>
    </div>
</div>
 


<div class="modal fade" id="iflModal" tabindex="-1" role="dialog"  aria-hidden="true">
  <div class="modal-dialog" >
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" >复制链接代码</h5>
        <button type="button" class="close" data-bs-dismiss="modal" >
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div style="height:100px;" class="modal-body">
                连接引用代码（可以在模板适当位置引用这个专题连接）：<br>
                <textarea id="selbox" onclick="oCopy(this)" title="点击复制代码" style="width: 390px; height: 50px;"></textarea>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">关闭</button> 
      </div>
    </div>
  </div>
</div>


<script>
     
    function onselcomp() {
        
        var selID = $("#<%=selClass.hfValue.ClientID%>").val();
        GetClassSel(selID);
    }
    function GetClassSel(ClassID) {
        if (ClassID > 0) {
            var pram = { "cid": ClassID,"sid":<%=base.GetSiteID %> };

            runadminws("GetSpecialManageSel", pram, function (msg) {
                $(".classtoolbar").html("");

                var aMenus = msg.d;
                if (aMenus == null || aMenus == undefined) {
                    return;
                }

                var ulTag = $("<div class=\"btn-group\"><\/div>");

                ulTag.append($(String.format("<a class='btn btn-primary' href='{0}'  target=\"_blank\">前台页面</a>", aMenus.Url)));
                ulTag.append($(String.format("<a class='btn btn-primary' onclick='addcontent({0})'>添加内容</a>", aMenus.id)));
                ulTag.append($(String.format("<a class='btn btn-primary' href='{0}'>查看内容(<font color=\"#ff0000\">{1}</font>)</a>", aMenus.CtUrl,aMenus.CtCount)));
                //ulTag.append($(String.format("<a class='btn btn-default' onclick='makehtml({0})'>生成静态页</a>", aMenus.id)));
                //ulTag.append($(String.format("<a class='btn btn-primary' onclick='makehtmlsub({0})'>生成子专题页(<font color=\"#ff0000\">{1}</font>)</a>",  aMenus.id,aMenus.ChildCount)));
                ulTag.append($(String.format("<a class='btn btn-primary' onclick='delclass({0})'>删 除</a>", aMenus.id)));
                ulTag.append($(String.format("<a  class='btn btn-primary' onclick='copyclass({0})'>复 制</a>", aMenus.id)));
                ulTag.append($(String.format("<a class='btn btn-primary' href='{0}'> 编 辑 </a>", aMenus.UrlEdit)));

                var ulTagMore = $("<div class=\"btn-group\"><button type=\"button\" class=\"btn btn-primary dropdown-toggle\" data-toggle=\"dropdown\">更多<span class=\"caret\"></span></button><ul class=\"dropdown-menu\"></ul><\/div>");

                var subObj = ulTagMore.find(".dropdown-menu");// $(ulTagMore, ".dropdown-menu");
                subObj.append($(String.format("<li><a data-toggle=\"modal\" data-target=\"#iflModal\">{0}</a></li>", "链接代码")));
                subObj.append($(String.format("<li><a  onclick='makehtml({0})'>生成静态页</a></li>", aMenus.id)));
                subObj.append($(String.format("<li><a  onclick='makehtmlsub({1})'>生成子专题页(<font color=\"#ff0000\">{0}</font>)</a></li>", aMenus.ChildCount,aMenus.id)));             
                
                ulTag.append(ulTagMore);

                $(".classtoolbar").append(ulTag);

                $("#selbox").val(aMenus.UrlCode);

            });
        }
    }

    function addcontent(id)
    {
        location.href = "Admin_Content.aspx?t=1&asid="+id;
    }

    function makehtml(cid)
    {
        if(confirm("比较占用资源请慎用,确认要生成当前记录静态页(包括所有分页)吗？"))
        {
            location.href = "MakeProgressSpecial.aspx?cid="+cid;
        }
    }
    function makehtmlsub(cid)
    {
        if(confirm("比较占用资源请慎用,确认要生成当前记录所有子分类静态页吗？"))
        {
            location.href = "MakeProgressSpecial.aspx?pcid="+cid;
        }
    }

    function delclass(cid) {
        if(confirm("确认要删除记录吗？"))
        {
            var pram = {"cid":cid,"sid":<%=base.GetSiteID %>}
            runadminws("DelSPClass", pram, function (msg) {
                location.href = location.href;
            });
        }
    }
    function copyclass(cid) {
        if(confirm("确认要复制记录吗,复制完成后将进入编辑页面？"))
        {
            var pram = {"cid":cid,"sid":<%=base.GetSiteID %>}
            runadminws("CopySPClass", pram, function (msg) {
                var d = msg.d;
                location.href = d.Data;
            });
        }
       

    }
</script>
