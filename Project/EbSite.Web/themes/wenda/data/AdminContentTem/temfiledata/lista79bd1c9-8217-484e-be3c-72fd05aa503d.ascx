<tr>
			    <td style="width:50px;"><%#Eval("ID")%></td>
<td class="gvfisrtTD"> <a href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("htmlname"),Eval("classid"))%>'target="_blank"><%#Eval("newstitle")%></a>
                    </td>
                    <td style="width:90px;“><%#Eval("classname")%></td>
                    <td><%#Eval("Annex6")%></td>
                                     <td><%#Eval("Annex11")%></td>
                    <td><%#Eval("Annex22")%></td>
                   
                    <td>
 <%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetAskStatu(Convert.ToInt32( Eval("Annex21").ToString()))%>
                 </td>
                    <td>

 <span> <a href='<%#string.Format("?t=4&id={0}",Eval("id"))%>'>修改</a></span>
                        <span>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('您确定要删除该项么?')"  CommandName="DeleteModel"  Text="删除"></asp:LinkButton>
                        </span>
                          <a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "d2c3ecc0-e645-443f-ba5b-3ad4e627ab90") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">管理回答</a>
                                        </td>
                    <td> <input name="ebcheckboxname" value="<%#Eval("ID")%>" type="checkbox" /></td>

		    </tr>