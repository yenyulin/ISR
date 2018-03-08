<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="Marquee.aspx.cs" Inherits="Manage_Marquee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
        bgcolor="#666600" class="mtable">
        <tr bgcolor="#A2CAD2" height="57">
            <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                <img src="image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absmiddle">
                <span class="form_title1">跑馬燈</span></td>
        </tr>
        <tr bgcolor="#E4F1E9" height="37">
            <td width="162" bgcolor="#f1e4ec" class="table_title1">
                <span class="style1">※</span> 跑馬燈訊息</td>
            <td width="555" bgcolor="#f1e4ec" class="font1213-1">
                <asp:TextBox ID="Msg" runat="server" Rows="5" TextMode="MultiLine" Columns="70"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="Msg" ErrorMessage="必須提供跑馬燈訊息。"
                    ToolTip="必須提供跑馬燈訊息。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator></td>
        </tr>
    </table>
    <table width="100%" border="0">
        <tr>
            <td style="text-align: center">
                <asp:Button ID="SaveBtn" runat="server" Text="儲  存" ValidationGroup="ValidationGroup1"
                    OnClick="SaveBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
