<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="MgrPassword.aspx.cs" Inherits="Manage_Pwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
<table width="500px" border="0" align="center" cellpadding="5" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="�з���" size="5" color="#990000">�K�X�ܧ�</font></b></p>
            </td>
        </tr>
    </table>
    <asp:ChangePassword ID="ChangePassword1" runat="server" BorderWidth="0px" Width="100%">
        <ChangePasswordTemplate>
            <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                bgcolor="#666600" class="mtable">
                <tr bgcolor="#A2CAD2" height="57">
                    <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                        <img src="../image/icon/page_edit.png" alt="��g�������" width="16" height="16" align="absmiddle">
                        <span class="form_title1">�ק�K�X&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �� ���������</span></td>
                </tr>
                <tr bgcolor="#E4F1E9" height="37">
                    <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                        <span class="style1">��</span> �K�X:</td>
                    <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                        <asp:TextBox ID="CurrentPassword" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                            ErrorMessage="�������ѱK�X�C" ToolTip="�������ѱK�X�C" ValidationGroup="ChangePassword1"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr bgcolor="#F2F9F4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="left">
                        <span class="style1">��</span> �s�K�X:
                    </td>
                    <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                        <asp:TextBox ID="NewPassword" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                            ErrorMessage="�������ѷs�K�X�C" ToolTip="�������ѷs�K�X�C" ValidationGroup="ChangePassword1"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr bgcolor="#E4F1E9" height="37">
                    <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                        <span class="style1">��</span> �T�{�s�K�X:</td>
                    <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                            ErrorMessage="�����T�{�s�K�X�C" ToolTip="�����T�{�s�K�X�C" ValidationGroup="ChangePassword1"> </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                            ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="�T�{�s�K�X�����P�s�K�X���ج۲šC"
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
                            Text="�T�w�ק�" ValidationGroup="ChangePassword1" Height="30px"/>
                            <asp:Button ID="BtnCancel2" runat="server" Text="���,��^�D�e��" OnClick="BtnCancel2_Click" Height="30px"/>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
        <SuccessTemplate>
            <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                bgcolor="#666600" class="mtable">
                <tr bgcolor="#a2cad2" height="57">
                    <td height="30" bgcolor="#d2aaa2" class="font1213-1">
                        <img src="../image/icon/page_edit.png" alt="��g�������" width="16" height="16" align="absMiddle">
                        <span class="form_title1">�ܧ�K�X����</span></td>
                </tr>
                <tr bgcolor="#e4f1e9" height="77">
                    <td bgcolor="#ffffff" class="table_title1" align="center">
                        �z���K�X�w�ܧ�!
                    </td>
                </tr>
                <tr bgcolor="#f2f9f4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="center">
                        <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CommandName="Continue"
                            Text="��^�D�e��" OnCommand="ContinuePushButton_Command" />
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
    </asp:ChangePassword>
</asp:Content>
