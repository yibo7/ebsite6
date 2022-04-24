
  <%@ Import Namespace="EbSite.BLL.User" %>
  <div class="crtabtop">
                    专家在线</div>
                <div class="crtab3info">
                    <span><%# Eval("UserNiName")%></span>
                    <div class="cusinfo">
                        <div class="cusphoto">
                             <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserName").ToString())%>" target="_blank">
            <img id="Ag<%#Eval("id") %>" src='/themes/default/css/images/zj.jpg' width="70" />
            <script>
              document.getElementById("Ag<%#Eval("id") %>").src = "<%#MembershipUserEb.Instance.GetEntity(Convert.ToInt32(Eval("UserID").ToString())).AvatarBig%>? + Math.random()";
            </script>
            </a>
                            
                            </div>
                        <div class="cusdata">
                            <li>本周答疑: 5 </li>
                            <li>总答疑数: <%# Eval("SolveCount")%> </li>
                            <li>擅长领域：<%#Eval("Field") %></li>
                            <li>所在地区：<%#Eval("Area")%></li>
                        </div>
                    </div>
                      <a target="_blank" href="/bmask/12456-1-0c.ashx?uid=<%#Eval("UserID") %>"> <div class="crtab3btn">
                    </div></a>
                </div>