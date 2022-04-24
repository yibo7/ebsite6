<tr>
			    <td style="width:50px;"><%#Eval("ID")%></td>
<td class="gvfisrtTD"> <a href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("htmlname"),Eval("classid"))%>'target="_blank"><%#Eval("newstitle")%></a>
                    </td>
                    <td><%#Eval("classname")%></td>
                    <td><%#Eval("Annex11")%></td>
                    <td><%#Eval("Annex16")%></td>
                    <td><%#Eval("Annex17")%></td>
                    <td><%#Eval("Annex18")%></td>
                    <td><%#Eval("Annex12")%></td>
                   <td><%#Eval("Annex13")%></td>
                   <td><%#Eval("Annex14")%></td>
                    <td><a target="_blank" href="<%#EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(EbSite.Base.Host.Instance.GetSiteID).GetVoteView(Eval("id"))%> ">进入考试</a>
                 </td>
                    <td>

 <span> <a href='<%#string.Format("?t=4&id={0}",Eval("id"))%>'>修改</a></span>
                        <span>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('您确定要删除该项么?')"  CommandName="DeleteModel"  Text="删除"></asp:LinkButton>
                        </span>
                        <span>
                        <asp:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyModel" Text="复制"></asp:LinkButton>
                        </span>
    <a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("5a2d821b-586c-4ac4-bdac-1567d5d1a515", "1ee7395c-252e-4f32-97bd-b34ca0c1cc7a") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">管理考题类别</a>
                                        <a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("5a2d821b-586c-4ac4-bdac-1567d5d1a515", "75a5534f-e3be-4adb-a697-4978dccf5c53") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">管理考题</a>
                                       

</td>
                    <td> <input name="ebcheckboxname" value="<%#Eval("ID")%>" type="checkbox" /></td>

		    </tr>