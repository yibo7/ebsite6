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
                    <td><a target="_blank" href="<%#EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(EbSite.Base.Host.Instance.GetSiteID).GetVoteView(Eval("id"))%> ">���뿼��</a>
                 </td>
                    <td>

 <span> <a href='<%#string.Format("?t=4&id={0}",Eval("id"))%>'>�޸�</a></span>
                        <span>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('��ȷ��Ҫɾ������ô?')"  CommandName="DeleteModel"  Text="ɾ��"></asp:LinkButton>
                        </span>
                        <span>
                        <asp:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyModel" Text="����"></asp:LinkButton>
                        </span>
    <a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("5a2d821b-586c-4ac4-bdac-1567d5d1a515", "1ee7395c-252e-4f32-97bd-b34ca0c1cc7a") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">���������</a>
                                        <a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("5a2d821b-586c-4ac4-bdac-1567d5d1a515", "75a5534f-e3be-4adb-a697-4978dccf5c53") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">������</a>
                                       

</td>
                    <td> <input name="ebcheckboxname" value="<%#Eval("ID")%>" type="checkbox" /></td>

		    </tr>