<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeWidgets.aspx.cs" Inherits="EbSite.Web.home.ChangeWidgets" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background: #ffffff">
    <form id="form1" runat="server">
  

  <style>
	#gallery { float: left; width: 65%; min-height: 12em; } * html #gallery { height: 12em; } /* IE6 */
	.gallery.custom-state-active { background: #eee; }
	.gallery li { float: left; width: 96px; padding: 0.4em; margin: 0 0.4em 0.4em 0; text-align: center; }
	.gallery li h5 { margin: 0 0 0.4em; cursor: move; }
	.gallery li a { float: right; }
	.gallery li a.ui-icon-zoomin { float: left; }
	.gallery li img { width: 100%; cursor: move; }

	#trash { float: right; width: 32%; min-height: 18em; padding: 1%;} * html #trash { height: 18em; } /* IE6 */
	#trash h4 { line-height: 16px; margin: 0 0 0.4em; }
	#trash h4 .ui-icon { float: left; }
	#trash .gallery h5 { display: none; }
	</style>
	<script>
	    $(function () {
	        // there's the gallery and the trash
	        var $gallery = $("#gallery"),
			$trash = $("#trash");

	        // let the gallery items be draggable
	        $("li", $gallery).draggable({
	            cancel: "a.ui-icon", // clicking an icon won't initiate dragging
	            revert: "invalid", // when not dropped, the item will revert back to its initial position
	            containment: $("#demo-frame").length ? "#demo-frame" : "document", // stick to demo-frame if present
	            helper: "clone",
	            cursor: "move"
	        });

	        // let the trash be droppable, accepting the gallery items
	        $trash.droppable({
	            accept: "#gallery > li",
	            activeClass: "ui-state-highlight",
	            drop: function (event, ui) {
	                deleteImage(ui.draggable);
	            }
	        });

	        // let the gallery be droppable as well, accepting items from the trash
	        $gallery.droppable({
	            accept: "#trash li",
	            activeClass: "custom-state-active",
	            drop: function (event, ui) {
	                recycleImage(ui.draggable);
	            }
	        });

	        // image deletion function
	        var recycle_icon = "<a href='link/to/recycle/script/when/we/have/js/off' title='还原部件' class='ui-icon ui-icon-refresh'>Recycle image</a>";
	        function deleteImage($item) {
	            $item.fadeOut(function () {
	                var $list = $("ul", $trash).length ?
					$("ul", $trash) :
					$("<ul class='gallery ui-helper-reset'/>").appendTo($trash);

	                $item.find("a.ui-icon-cart").remove();
	                $item.append(recycle_icon).appendTo($list).fadeIn(function () {
	                    $item
						.animate({ width: "48px" })
						.find("img")
							.animate({ height: "36px" });
	                });
	            });
	        }

	        // image recycle function
	        var trash_icon = "<a href='link/to/trash/script/when/we/have/js/off' title='选择部件' class='ui-icon ui-icon-cart'>Delete image</a>";
	        function recycleImage($item) {
	            $item.fadeOut(function () {
	                $item
					.find("a.ui-icon-refresh")
						.remove()
					.end()
//					.css("width", "96px")
//					.append(trash_icon)
//					.find("img")
//						.css("height", "72px")
//					.end()
//					.appendTo($gallery)
//					.fadeIn();
	            });
	        }

	        // image preview function, demonstrating the ui.dialog used as a modal window
	        function viewLargerImage($link) {
	            var src = $link.attr("href"),
				title = $link.siblings("img").attr("alt"),
				$modal = $("img[src$='" + src + "']");

	            if ($modal.length) {
	                $modal.dialog("open");
	            } else {
	                var img = $("<img alt='" + title + "' width='384' height='288' style='display: none; padding: 8px;' />")
					.attr("src", src).appendTo("body");
	                setTimeout(function () {
	                    img.dialog({
	                        title: title,
	                        width: 400,
	                        modal: true
	                    });
	                }, 1);
	            }
	        }

	        // resolve the icons behavior with event delegation
	        $("ul.gallery > li").click(function (event) {
	            var $item = $(this),
				$target = $(event.target);

	            if ($target.is("a.ui-icon-cart")) {
	                deleteImage($item);
	            } else if ($target.is("a.ui-icon-zoomin")) {
	                viewLargerImage($target);
	            } else if ($target.is("a.ui-icon-refresh")) {
	                recycleImage($item);
	            }

	            return false;
	        });
	    });
	</script>

<XS:Notes ID="Notes7" Text="拖放部件或点击右下图标可完成操作,调整完成后点击'保存设置'"   runat=server></XS:Notes>
<br/>

<div class="demo ui-widget ui-helper-clearfix">
<ul id="gallery" class="gallery ui-helper-reset ui-helper-clearfix">
     <asp:Repeater ID="rpWidgets" runat="server"  >
            <ItemTemplate>        
            <li title="<%#Eval("WidgetName")%>" class="ui-widget-content ui-corner-tr">
		    <h5 class="ui-widget-header"><%#Eval("WidgetName")%></h5>
		    <img wid="<%#Eval("id")%>" src="<%#Eval("ImgUrl")%>"  width="96" height="72" />
		    <a  href=" <%#Eval("ImgUrl")%> "  title="放大部件" class="ui-icon ui-icon-zoomin">放大</a>
		    <a id="<%#Eval("id")%>" href="images/ok.png" title="选择部件" class="ui-icon ui-icon-cart">选择部件</a>
	       </li>   
            </ItemTemplate>
        </asp:Repeater>
</ul>

<div id="trash" class="ui-widget-content ui-state-default">
	<h4 class="ui-widget-header">
        <span class="ui-icon ui-icon-cart">Trash</span> 
        已选部件
    </h4>
</div>

</div>
<br/>
<div>
 <input type="button"  value=" 保存设置 "  onclick="SaveWidgets()"   class="AdminButton" />
</div>

    </form>

    <script>
    var SelWidgetsID = [<%=GetWidgetsID %>];
//        $(function () {

//            
//            for (var i = 0; i < SelWidgetsID.length; i++) {
//                $("#" + SelWidgetsID[i]).click();
//            }
//        
//        });
        var sss = [];
        
        function SaveWidgets() {
            var AddIDs = [];
             var DelIDs = [];
            $("#trash").find("img").each(
		    function (i) {
		        var wid = $(this).attr("wid");
                if(jQuery.inArray(wid,SelWidgetsID)==-1) {
                    AddIDs.push(wid);
                }
		    }
		    );
            $("#gallery").find("img").each(
		    function (i) {
		        var wid = $(this).attr("wid");
                if(jQuery.inArray(wid,SelWidgetsID)>-1) {
                    DelIDs.push(wid);
                }
		    }
		    );
            var tid = <%=CurrentTabID %>;
            var Url = IISPath + "home/ajaxget/WidgetPosChange.ashx?tid="+tid+"&delid="+DelIDs.join(",")+ "&addid=" + AddIDs.join(",")+"&time="+Math.random();
                run_ajax_async(Url, "", SaveWidgetsCom);
            
        }
        function SaveWidgetsCom(msg) {
            if(msg=="ok") {
                RefeshParent();
            }
            else {
                alert("保存失败！");
            }
        }
    </script>
</body>
</html>
