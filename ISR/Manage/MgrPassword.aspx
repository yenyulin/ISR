<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="MgrPassword.aspx.cs" Inherits="Manage_Pwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
<table width="500px" border="0" align="center" cellpadding="5" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">密碼變更</font></b></p>
            </td>
        </tr>
    </table>
    <asp:ChangePassword ID="ChangePassword1" runat="server" BorderWidth="0px" Width="100%">
        <ChangePasswordTemplate>
            <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                bgcolor="#666600" class="mtable">
                <tr bgcolor="#A2CAD2" height="57">
                    <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                        <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absmiddle">
                        <span class="form_title1">修改密碼&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ※ 為必填欄位</span></td>
                </tr>
                <tr bgcolor="#E4F1E9" height="37">
                    <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                        <span class="style1">※</span> 密碼:</td>
                    <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                        <asp:TextBox ID="CurrentPassword" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                            ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="ChangePassword1"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr bgcolor="#F2F9F4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="left">
                        <span class="style1">※</span> 新密碼:
                    </td>
                    <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                        <asp:TextBox ID="NewPassword" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                            ErrorMessage="必須提供新密碼。" ToolTip="必須提供新密碼。" ValidationGroup="ChangePassword1"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr bgcolor="#E4F1E9" height="37">
                    <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                        <span class="style1">※</span> 確認新密碼:</td>
                    <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                            ErrorMessage="必須確認新密碼。" ToolTip="必須確認新密碼。" ValidationGroup="ChangePassword1"> </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                            ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="確認新密碼必須與新密碼項目相符。"
                            ValidationGroup="ChangePassword1"></asp:CompareValidator>
                    </td>
                </tr>
                <tr bgcolor="#F2F9F4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="center" colspan="2">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                    </td>
                </tr>
                <tr bgcolor="#F2F9F4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="center" colspan="2">
                        <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                            Text="確定修改" ValidationGroup="ChangePassword1" Height="30px"/>
                            <asp:Button ID="BtnCancel2" runat="server" Text="放棄,返回主畫面" OnClick="BtnCancel2_Click" Height="30px"/>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
        <SuccessTemplate>
            <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                bgcolor="#666600" class="mtable">
                <tr bgcolor="#a2cad2" height="57">
                    <td height="30" bgcolor="#d2aaa2" class="font1213-1">
                        <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absMiddle">
                        <span class="form_title1">變更密碼完成</span></td>
                </tr>
                <tr bgcolor="#e4f1e9" height="77">
                    <td bgcolor="#ffffff" class="table_title1" align="center">
                        您的密碼已變更!
                    </td>
                </tr>
                <tr bgcolor="#f2f9f4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="center">
                        <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CommandName="Continue"
                            Text="返回主畫面" OnCommand="ContinuePushButton_Command" />
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
    </asp:ChangePassword>
</asp:Content>
