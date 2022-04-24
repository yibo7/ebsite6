<FORM  onsubmit="return ChkSo(this);"  method="get" action="<%=EbSite.Base.Host.Instance.SearchRw %>" target="_so">

<style>
    /** 积分达人人榜 **/
    .initcolor
    {
        color:#a9a8a7;
    }
    </style>

<div style="margin-bottom: 10px; margin-top: 20px; float: left; width: 100%;display:inline">
  <div class="logo2">
  </div>
  <ul class="askinput">
    <input type="text"  name="k" onclick="javascript:this.value=''"   class="initcolor" value="请输入关键词" id="k" />
  </ul>
  <div class="askbtn">
    <input type="text" style="display:none;" name="site" value="<%=CurrentSite.id%>" />
    <input type="submit" id="selectAsk" class="searchask" onclick="Clicked()" value="搜索答案"/>
    <input type="button" class="addask" onclick="location.href='/ask/9040-1-0c.ashx'" value="我要提问"/>
  </div>
</div>
<div class="menusask" sizcache="9" sizset="2">
	  <XS:Widget WidgetName="导航一级分类"  WidgetID="2f701d33-c7e2-4d42-8638-189daeb00e82" runat="server"/>                                                                                                                                              
</div>

<script>
    $(function () {
        $("#k").focus(
            function () {            
                $("#k").removeClass('initcolor');
            }
        );
            //$("#selectAsk").bind("onclick", "Clicked()");

        function Clicked() {
//            var c = $.trim($('#k').val());
//            $("#k").val(c);
//            alert("a");
        }

    });
</script>
</FORM>