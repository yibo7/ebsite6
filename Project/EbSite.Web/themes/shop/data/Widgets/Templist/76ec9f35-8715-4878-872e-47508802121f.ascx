<div class="pr_info">
                    <div class="pr_left">
                    <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GroupShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id"),Eval("productid"))%>">
                    <img src="<%#Eval("smallimg") %>" width="114" height="114" /></a></div>
                    <div class="pr_right">
                        <li style="height:3em;line-height:1.5em;overflow:hidden;"><%#Eval("Title")%></li>
                        <li><span>原价:</span><%#Eval("Price")%></li>
                        <li><span>优惠价:</span><%#Eval("BuyPrice")%></li>
                        <div class="clear"></div>
                         <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GroupShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id"),Eval("productid"))%>"><div class="pr_btn2 all"></div></a>
                    </div>
                </div>