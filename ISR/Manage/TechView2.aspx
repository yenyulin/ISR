<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TechView2.aspx.cs" Inherits="Manage_TechView2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>資源再生技術需求現況</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <br />
    <table width="95%" border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#F9F2F7"
        class="mtable">
        <tr>
            <td width="6%" align="center" bgcolor="#F9F2F7">
                &nbsp;</td>
            <td width="81%" align="center" bgcolor="#F9F2F7">
                <div align="center" class="title2">
                    資源再生技術需求現況查詢  
                </div>
            </td>
            <td width="13%" align="center" bgcolor="#F9F2F7">
                <asp:LinkButton ID="BackBtn" runat="server" OnClick="BackBtn_Click" >關閉視窗</asp:LinkButton></td>
        </tr>
    </table>
    <br />
    <div align="center">
            <asp:DataList ID="TechData" runat="server">
                <ItemTemplate>
                    <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                        bgcolor="#666600" class="mtable">
                        <tr bgcolor="#A2CAD2" height="57">
                            <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                                <span class="form_title1">【資源再生技術需求現況】</span></td>
                        </tr>
                        <tr bgcolor="#E4F1E9" height="37">
                            <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                廢棄物種類:</td>
                            <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                <!--<asp:Label ID="pn1" runat="server" Text='<%# Bind("pn1") %>'> </asp:Label>-->
                                <asp:Label ID="WasteOther" runat="server" Text='<%# Bind("WasteOther") %>'> </asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F9F4" height="37">
                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                廢棄物名稱:</td>
                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                <asp:Label ID="WasteName" runat="server" Text='<%# Bind("WasteName") %>'> </asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#E4F1E9">
                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                再利用技術名稱:</td>
                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                <asp:Label ID="TechName" runat="server" Text='<%# Bind("TechName") %>'> </asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F9F4">
                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                再生技術方法:
                            </td>
                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                <!--<asp:Label ID="pn2" runat="server" Text='<%# Bind("pn2") %>'> </asp:Label>-->
                                <asp:Label ID="TechOther" runat="server" Text='<%# Bind("TechOther") %>'> </asp:Label>
                            </td>
                        </tr>
                        
                        <tr bgcolor="#E4F1E9">
                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                再生產品名稱:
                            </td>
                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                <asp:Label ID="ReuseName" runat="server" Text='<%# Bind("ReuseName") %>'> </asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            </div>
        </div>
    </form>
</body>
</html>
