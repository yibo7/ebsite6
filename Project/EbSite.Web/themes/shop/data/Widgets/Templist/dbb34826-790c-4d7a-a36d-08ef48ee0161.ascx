<div class="pr_info">
                    <div class="pr_left">
                    <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Convert.ToInt32(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                    <img src="<%#Eval("SmallPic") %>" width="114" height="114" /></a></div>
                    <div class="pr_right">
                        <li style="height:3em;line-height:1.5em;overflow:hidden;"><%#Eval("newstitle")%></li>
                        <li><span>原价:</span><%#Eval("Annex2")%></li>
                        <li><span>优惠价:</span><%#Eval("Annex16")%></li>
                        <div class="clear"></div>
                         <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Convert.ToInt64(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>"><div class="pr_btn3 all"></div></a>
                    </div>
                </div>