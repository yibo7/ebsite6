<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.BannerPic.widget" %>
  <link href="<%=sIIsPath %>data/Widgets/WidgetList/BannerPic/js/slideshow.css" rel="stylesheet" />
    <script src="<%=sIIsPath %>data/Widgets/WidgetList/BannerPic/js/slideshow.js" type="text/javascript"></script>

    <div class="comiis_wrapad" id="slideContainer" <%=sStyle %>>
        <div id="frameHlicAe" class="frame cl">
            <div class="temp"></div>
            <div class="block">
                <div class="cl">
                    <ul class="slideshow" id="slidesImgs"> 
                          <%=GetFlashInfo() %>
                    </ul>
                </div>
                <div class="slidebar" id="slideBar">
                    <ul>
                        <%=GetFlashNum %>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
      <%=SpeedStr()%>
    </script>
