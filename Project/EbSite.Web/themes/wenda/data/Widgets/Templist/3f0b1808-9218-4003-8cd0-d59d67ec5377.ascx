<!--请在这里输入模板内容!-->
 <tr>
                                <td width="120">
                                  <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("niname").ToString())%>" target="_blank" > <%# Eval("niname")%></a>  
                                </td>
                                <td width="80">
                                    <%# EbSite.BLL.UserLevel.Instance.GetUserLevelForScore( Eval("Credits").ToString()).LevelName%>
                                </td>
                                <td  width="60">
                                    <%# Eval("Credits")%> 
                                </td>
                            </tr>