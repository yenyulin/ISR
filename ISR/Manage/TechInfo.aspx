<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TechInfo.aspx.cs" Inherits="Manage_TechInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>資源化技術研發供需資訊平台</title>
    <link href="../style.css" rel="stylesheet" type="text/css">
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="AppendView" runat="server">
                
                    <table width="550" border="0" align="center" cellpadding="1" cellspacing="1" class="mtable">
                        <tr>
                            <td bgcolor="#F1E4EC">
                                <div align="center" class="title1">
                                    <font color="#990000">裂解</font>再利用技術簡介及特點</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="title2">
                                技術特點：</td>
                        </tr>
                        <tr>
                            <td class="font1213-1">
                                <asp:TextBox ID="TechAdv1" runat="server" Rows="5" TextMode="MultiLine" Width="428px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="TechAdvRequired" runat="server" ControlToValidate="TechAdv1"
                                    ErrorMessage="必須提供再生技術特點。" ToolTip="必須提供再生技術特點。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="font1213-1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="title2">
                                技術簡介：</td>
                        </tr>
                        <tr>
                            <td class="font1213-1">
                                <asp:TextBox ID="TechDesc1" runat="server" Rows="5" TextMode="MultiLine" Width="428px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="TechDescRequired" runat="server" ControlToValidate="TechDesc1"
                                    ErrorMessage="必須提供再生技術簡介。" ToolTip="必須提供再生技術簡介。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                <asp:HiddenField ID="TechItem1" runat="server" />
                                <asp:HiddenField ID="TechName1" runat="server" />
                                <asp:HiddenField ID="TechOther1" runat="server" />
                                <asp:HiddenField ID="WasteItem1" runat="server" />
                                <asp:HiddenField ID="WasteName1" runat="server" />
                                <asp:HiddenField ID="WasteOther1" runat="server" />
                                <asp:HiddenField ID="ReuseName1" runat="server" />
                                <asp:HiddenField ID="Type1" runat="server" />
                                <asp:HiddenField ID="Rid1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="font1213-1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td bgcolor="#A996AF">
                                <div align="center">
                                    <asp:Button ID="SaveBtn1" runat="server" Text="儲存離開" OnClick="SaveBtn1_Click" ValidationGroup="ValidationGroup1" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="ExitBtn1" runat="server" Text="放棄離開" OnClick="ExitBtn_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    
                </asp:View>
                <asp:View ID="EditView" runat="server">
                <div align="center">
                    <asp:DataList ID="TechData" runat="server">
                        <ItemTemplate>
                            <table width="550" border="0" align="center" cellpadding="1" cellspacing="1" class="mtable">
                                <tr>
                                    <td bgcolor="#F1E4EC">
                                        <div align="center" class="title1">
                                            <font color="#990000">裂解</font>再利用技術簡介及特點</div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title2">
                                        技術特點：</td>
                                </tr>
                                <tr>
                                    <td class="font1213-1">
                                        <asp:TextBox ID="TechAdv2" runat="server" Rows="5" TextMode="MultiLine" Width="428px"
                                            Text='<%# Bind("Techadv") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TechAdv2"
                                            ErrorMessage="必須提供再生技術特點。" ToolTip="必須提供再生技術特點。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="font1213-1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="title2">
                                        技術簡介：</td>
                                </tr>
                                <tr>
                                    <td class="font1213-1">
                                        <asp:TextBox ID="TechDesc2" runat="server" Rows="5" TextMode="MultiLine" Width="428px"
                                            Text='<%# Bind("Techdesc") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TechDesc2"
                                            ErrorMessage="必須提供再生技術簡介。" ToolTip="必須提供再生技術簡介。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="Id" runat="server" Value='<%# Bind("Id") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="font1213-1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#A996AF">
                                        <div align="center">
                                            <asp:Button ID="SaveBtn2" runat="server" Text="儲存離開" OnClick="SaveBtn2_Click" ValidationGroup="ValidationGroup1" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="ExitBtn2" runat="server" Text="放棄離開" OnClick="ExitBtn_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
