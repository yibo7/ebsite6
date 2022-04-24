<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="EbSite.Modules.Shop.Setting" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div id="tg1">
    <style>
        H2
        {
            font-size: 14px;
            border-bottom: #ccc 1px solid;
            margin: 5px 0px;
            line-height: 30px;
        }
    </style>
    <table cellpadding="0" cellspacing="0">
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    ���ﳵ����</h2>
            </td>
        </tr>
        <tr class="FFtr">
            <td align="right" style="width: 20%; height: 15px">
                ���湺�ﳵ��
            </td>
            <td align="left" style="height: 15px">
                <span style="float: left;">
                    <XS:RadioButtonList ID="IsSaveShopCar" runat="server">
                        <asp:ListItem Value="True" Selected="True" Text="����">
                        </asp:ListItem>
                        <asp:ListItem Value="False" Text="������">
                        </asp:ListItem>
                    </XS:RadioButtonList>
                </span><span style="float: left;">
                    <XS:Notes ID="NoteA" runat="server" Text="��½��Ա�µ�δ���ʱ�����ﳵ��Ʒ�Ƿ���." />
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    ��Ʊ����</h2>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 30px;">
                �ܷ񿪷�Ʊ��
            </td>
            <td align="left" style="height: 30px">
                <span style="float: left;">
                    <XS:RadioButtonList ID="IsOpenInvoice" runat="server">
                        <asp:ListItem Value="True" Selected="True" Text="��">
                        </asp:ListItem>
                        <asp:ListItem Value="False" Text="����">
                        </asp:ListItem>
                    </XS:RadioButtonList>
                </span><span style="float: left;">
                    <XS:Notes ID="Notes0" Text="�ɷ��ṩ���ͻ�����Ʊ����������������ö���˰�㣬˰�����԰ٷֱ����á�10����10%" runat="server" />
                </span>
            </td>
        </tr>
        <tr class="FFtr">
            <td style="width: 20%" align="right">
                ����˰�㣺
            </td>
            <td align="left" style="height: 45px">
                <XS:TextBoxVl ID="OrderTaxPoint" Text="0" runat="server" ValidateType="����"   HintInfo="����˰��" />
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%;">
                ����֧��������
            </td>
            <td align="left" style="height: 45px">
              <span style="float: left;">  <XS:TextBoxVl ID="ScorePayPoint" Text="0" runat="server"  ValidateType="����" HintInfo="ÿ100Ԫ��Ʒ������ʹ�ö���Ԫ���֡�ע��˴����õ��ǰٷֱȡ���10������10%" />
                </span><span style="float: left;"> <XS:Notes ID="Notes6" Text="ÿ100Ԫ��Ʒ������ʹ�ö���Ԫ���֡�ע��˴����õ��ǰٷֱȡ���10������10%" runat="server" />
          </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    ȱ������</h2>
            </td>
        </tr>
        <tr class="FFtr">
            <td align="right" style="height: 30px">
                �Ƿ�ʹ��ȱ������
            </td>
            <td align="left" style="height: 30px">
                <span style="float: left;">
                    <XS:RadioButtonList ID="IsNoGood" runat="server">
                        <asp:ListItem Value="True" Selected="True" Text="ʹ��">
                        </asp:ListItem>
                        <asp:ListItem Value="False" Text="��ʹ��">
                        </asp:ListItem>
                    </XS:RadioButtonList>
                </span><span style="float: left;">
                    <XS:Notes ID="Notes1" Text="ʹ��ȱ������ʱǰ̨����ȷ��ҳ�������û�ѡ��ȱ��ʱ������" runat="server" />
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td style="width: 20%; height: 30px;" align="right">
                ���ȱ���Ǽ�������
            </td>
            <td align="left" style="height: 30px">
                <span style="float: left; margin-top: 5px;">
                    <XS:DropDownList ID="UserGroup" runat="server">
                        <asp:ListItem Value="0" Selected="True" Text="�����û�"></asp:ListItem>
                        <asp:ListItem Value="1" Text="ע���û�"></asp:ListItem>
                    </XS:DropDownList>
                </span><span style="float: left;">
                    <XS:Notes ID="Notes2" Text="��������Ʒ��ʾ��治��ʱ�������Ƿ����Ϊ��Ա���ܼ�ȱ���Ǽ�" runat="server"></XS:Notes>
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    �ʼ���������</h2>
            </td>
        </tr>
        <tr class="FFtr">
            <td align="right" style="width: 20%">
                �û��µ����ʱ��
            </td>
            <td align="left">
                <span style="float: left;">
                    <XS:RadioButtonList ID="IsOkEmail" runat="server">
                        <asp:ListItem Value="True" Selected="True" Text="���ʼ�">
                        </asp:ListItem>
                        <asp:ListItem Value="False" Text="�������ʼ�">
                        </asp:ListItem>
                    </XS:RadioButtonList>
                </span><span style="float: left;">
                    <XS:Notes ID="Notes3" Text="�ͻ��µ����ʱ�Ƿ��ʼ�֪ͨ�ͻ�����ͬ" runat="server"></XS:Notes>
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%">
                ����ʱ��
            </td>
            <td align="left">
                <XS:RadioButtonList ID="IsSendEmail" runat="server">
                    <asp:ListItem Value="True" Selected="True" Text="�����ʼ�">
                    </asp:ListItem>
                    <asp:ListItem Value="False" Text="�������ʼ�">
                    </asp:ListItem>
                </XS:RadioButtonList>
            </td>
        </tr>
        <tr class="FFtr">
            <td align="right" style="width: 20%">
                ȡ������ʱ:
            </td>
            <td align="left">
                <XS:RadioButtonList ID="IsCancelEmail" runat="server">
                    <asp:ListItem Value="True" Selected="True" Text="�����ʼ�">
                    </asp:ListItem>
                    <asp:ListItem Value="False" Text="�������ʼ�">
                    </asp:ListItem>
                </XS:RadioButtonList>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                ��С�����
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBox ID="LessMoney" runat="server" Text="0" Width="56px" HintInfo="�ﵽ�˹���������ύ����" />
            </td>
        </tr>
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    ��������</h2>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                ���ڼ����Զ��رն�����
            </td>
            <td align="left" style="height: 40px">
                <span style="float: left;">
                    <XS:TextBoxVl ID="AutoCloseOrderDays"  ValidateType="����" runat="server" Text="0" Width="56px" />
                </span><span style="float: left;">
                    <XS:Notes ID="Notes4" Text="�µ�����ڼ���ϵͳ�Զ��ر�δ�����" runat="server"></XS:Notes>
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                ���������Զ���ɶ�����
            </td>
            <td align="left" style="height: 40px">
                <span style="float: left;">
                    <XS:TextBoxVl ID="AutoFinishOrderDays" runat="server" Text="0" ValidateType="����" Width="56px"  />
                </span><span style="float: left;">
                    <XS:Notes ID="Notes5" Text="�������ϵͳ�Զ��Ѷ����ĳ������״̬��" runat="server"></XS:Notes>
                </span>
            </td>
        </tr>
         <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    ��ӡ����</h2>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                ��ӡ���۵��Ƿ��ӡ��Ʒ��
            </td>
            <td align="left" style="height: 40px">
                 <XS:DropDownList ID="IsPrintGift"   runat="server">
                        <asp:ListItem Text="����ӡ"  Value="False"/>
                         <asp:ListItem Text="��ӡ" Value="True" />
                    </XS:DropDownList>   
                
            </td>
        </tr>
         <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    ����֪ͨ�����Ź�����ģ��</h2>
            </td>
        </tr>
         <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                ����֪ͨ�ֻ�����ģ�壺
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBoxVl ID="txtDownNoticeMsgTemp" runat="server" TextMode="MultiLine" Width="500px" Height="80px"  />(#��Ʒ����#)
             </td>
         </tr>
         <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                ����֪ͨ�ʼ�ģ�壺
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBoxVl ID="txtDownNoticeEmailTemp" runat="server" TextMode="MultiLine" Width="500px" Height="80px"  />(#��Ʒ����#)
             </td>
         </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                ���Ź��ֻ�����ģ�壺
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBoxVl ID="txtRequestGroupMsgTemp" runat="server" TextMode="MultiLine" Width="500px" Height="80px"  />(#��Ʒ����#)
             </td>
         </tr>
         <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                ���Ź��ʼ�ģ�壺
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBoxVl ID="txtRequestGroupEmailTemp" runat="server" TextMode="MultiLine" Width="500px" Height="80px"  />(#��Ʒ����#)
             </td>
         </tr>
    </table>
</div>
<div id="tg2">
    ͨetao
</div>
