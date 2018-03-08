<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileView1.aspx.cs" Inherits="Manage_ProfileView1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>資源化技術研發供需資訊平台</title>
    <link href="../style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
                <tr>
                    <td align="center">
                        <p align="center">
                            <b><font face="標楷體" size="5" color="#990000">會員資料查詢</font></b></p>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="BackBtn_Click">關閉視窗</asp:LinkButton></td>
                </tr>
            </table>
            <br />
            <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                bgcolor="#666600" class="mtable">
                <tr bgcolor="#A2CAD2" height="57">
                    <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1" align="center">
                        基本資料</td>
                </tr>
                <tr bgcolor="#E4F1E9">
                    <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                        帳號</td>
                    <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                        <asp:Label ID="UsernameView" runat="server">
                        </asp:Label>
                    </td>
                </tr>
                <tr bgcolor="#F2F9F4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="left">
                        學校系所 / 研究單位名稱</td>
                    <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                        <asp:Label ID="CorpView" runat="server">
                        </asp:Label>
                    </td>
                </tr>
                <tr bgcolor="#E4F1E9">
                    <td bgcolor="#f1e4ec" class="table_title1" align="left">
                        地址:
                    </td>
                    <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                        <asp:Label ID="AddressView" runat="server">
                        </asp:Label>
                    </td>
                </tr>
                <tr bgcolor="#F2F9F4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="left">
                        會員姓名:
                    </td>
                    <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                        <asp:Label ID="NameView" runat="server">
                        </asp:Label>
                    </td>
                </tr>
                <tr bgcolor="#E4F1E9">
                    <td bgcolor="#f1e4ec" class="table_title1" align="left">
                        連絡電話:
                    </td>
                    <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                        <asp:Label ID="TelView" runat="server">
                        </asp:Label>
                    </td>
                </tr>
                <tr bgcolor="#F2F9F4">
                    <td bgcolor="#f9f2f7" class="table_title1" align="left">
                        傳真:
                    </td>
                    <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                        <asp:Label ID="FaxView" runat="server"> </asp:Label>
                    </td>
                </tr>
                <tr bgcolor="#E4F1E9">
                    <td bgcolor="#f1e4ec" class="table_title1" align="left">
                        電子郵件:</td>
                    <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                        <asp:Label ID="EmailView" runat="server"> </asp:Label>
                    </td>
                </tr>
                <tr bgcolor="#E4F1E9">
                    <td bgcolor="#f9f2f7" class="table_title1" align="left">
                        單位屬性:
                    </td>
                    <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                        <asp:Label ID="KindView" runat="server"> </asp:Label>
                </tr>
            </table>
            <br />
            <div align="center">
                <asp:DataList ID="TechDataList" runat="server">
                    <ItemTemplate>
                        <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                            bgcolor="#666600" class="mtable">
                            <tr bgcolor="#A2CAD2" height="57">
                                <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                                    <span class="form_title1">資源再生技術研發現況【<%# Container.ItemIndex + 1 %>】</span></td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                    廢棄物種類:</td>
                                <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <!--<asp:Label ID="pn1" runat="server" Text='<%# Bind("pn1") %>'> </asp:Label>-->
                                    <asp:Label ID="WasteOther" runat="server" Text='<%# Bind("WasteOther") %>'> </asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
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
                                    <!-- <asp:Label ID="pn2" runat="server" Text='<%# Bind("pn2") %>'> </asp:Label>-->
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
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    研究情形</td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <asp:Label ID="ResearchItem" runat="server" Text='<%# Bind("pn3") %>'> </asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    再生技術特點:</td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <asp:Label ID="TechAdv" runat="server" Text='<%# Bind("TechAdv") %>'> </asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                    再生技術簡介:
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <asp:Label ID="TechDesc" runat="server" Text='<%# Bind("TechDesc") %>'> </asp:Label>
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
