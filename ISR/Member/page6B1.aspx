<%@ Page Language="C#" MasterPageFile="~/Template/member.master" AutoEventWireup="true"
    CodeFile="page6B1.aspx.cs" Inherits="Member_page6B1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <img src="../image/frame/top3.jpg" alt="*" width="800" height="10"></td>
        </tr>
        <tr>
            <td height="25">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="font1213-1">
                    <tr>
                        <td width="10">
                            <a href="../free.aspx" title="中央區域" accesskey="C"><font class="free_r">:::</font></a><div
                                align="center">
                            </div>
                        </td>
                        <td width="20">
                            <img src="../image/icon/icon2.jpg" alt="*" width="13" height="10"></td>
                        <td class="qLink_font">
                            現在位置：<a href="Default.aspx">首頁</a> &gt;&gt; <a href="page6B1.aspx">會員專區 &gt;&gt; 供需資料
                                &gt;&gt; 資源再生技術需求現況查詢 </a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="330">
                            <img src="../image/frame/sub_title9.jpg" alt="*" width="330" height="55"></td>
                        <td width="431" background="../image/frame/sub_2.jpg">
                            <table width="375" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="28%">
                                        <div align="center">
                                        </div>
                                    </td>
                                    <td width="9%">
                                        <div align="center">
                                            <img src="../image/icon/arrow.gif" alt="*" width="19" height="20"></div>
                                    </td>
                                    <td width="63%" class="table_title1">
                                        <div align="right" class="subfunction_font">
                                            | <a href="page6A1.aspx">研發合作對象</a> | <a href="page6B1.aspx">供需資訊</a> | <a href="page6C1.aspx">
                                                會員資料</a> |
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <table width="760" border="0" align="center" cellpadding="1" cellspacing="1">
                    <tr>
                        <td height="25" bgcolor="#d2aaa2">
                            <div align="center" class="title2">
                                資源再生技術需求現況</div>
                        </td>
                    </tr>
                    <tr>
                        <td height="50">
                            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="title2">
                                <tr>
                                    <td>
                                        <div align="center">
                                            廢棄物種類</div>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="WasteItem" runat="server">
                                            <asp:ListItem Value="Z">全部</asp:ListItem>
                                            <asp:ListItem Value="A">動物性廢棄物</asp:ListItem>
                                            <asp:ListItem Value="B">植物性廢棄物</asp:ListItem>
                                            <asp:ListItem Value="C">廢塑膠</asp:ListItem>
                                            <asp:ListItem Value="D">廢橡膠</asp:ListItem>
                                            <asp:ListItem Value="E">廢玻璃</asp:ListItem>
                                            <asp:ListItem Value="F">廢混凝土</asp:ListItem>
                                            <asp:ListItem Value="G">石材廢料</asp:ListItem>
                                            <asp:ListItem Value="H">廢紙</asp:ListItem>
                                            <asp:ListItem Value="I">廢木質</asp:ListItem>
                                            <asp:ListItem Value="J">有機污泥</asp:ListItem>
                                            <asp:ListItem Value="K">無機汙泥</asp:ListItem>
                                            <asp:ListItem Value="L">灰渣</asp:ListItem>
                                            <asp:ListItem Value="M">爐渣</asp:ListItem>
                                            <asp:ListItem Value="N">金屬廢料</asp:ListItem>
                                            <asp:ListItem Value="O">廢油</asp:ListItem>
                                            <asp:ListItem Value="P">廢酸</asp:ListItem>
                                            <asp:ListItem Value="Q">廢鹼</asp:ListItem>
                                            <asp:ListItem Value="R">廢液</asp:ListItem>
                                            <asp:ListItem Value="S">廢溶劑</asp:ListItem>
                                            <asp:ListItem Value="T">廢電池</asp:ListItem>
                                            <asp:ListItem Value="U">其他</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <div align="center">
                                            再生技術方法</div>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="TechItem" runat="server">
                                            <asp:ListItem Value="Z">全部</asp:ListItem>
                                            <asp:ListItem Value="A">結晶、乾燥法</asp:ListItem>
                                            <asp:ListItem Value="B">電漿法</asp:ListItem>
                                            <asp:ListItem Value="C">萃取法</asp:ListItem>
                                            <asp:ListItem Value="D">固化法</asp:ListItem>
                                            <asp:ListItem Value="E">水解法</asp:ListItem>
                                            <asp:ListItem Value="F">熱處理法</asp:ListItem>
                                            <asp:ListItem Value="G">薄膜法</asp:ListItem>
                                            <asp:ListItem Value="H">電解法</asp:ListItem>
                                            <asp:ListItem Value="I">吸附法</asp:ListItem>
                                            <asp:ListItem Value="J">熔融法</asp:ListItem>
                                            <asp:ListItem Value="K">聚合法</asp:ListItem>
                                            <asp:ListItem Value="L">破碎法</asp:ListItem>
                                            <asp:ListItem Value="M">分選、浮選法</asp:ListItem>
                                            <asp:ListItem Value="N">蒸餾法</asp:ListItem>
                                            <asp:ListItem Value="O">氣提、吸收法</asp:ListItem>
                                            <asp:ListItem Value="P">壓合、成型法</asp:ListItem>
                                            <asp:ListItem Value="Q">冶煉、熔鍊法</asp:ListItem>
                                            <asp:ListItem Value="R">堆肥法</asp:ListItem>
                                            <asp:ListItem Value="S">沉降法</asp:ListItem>
                                            <asp:ListItem Value="T">氧化、還原法</asp:ListItem>
                                            <asp:ListItem Value="U">溶解、置換法</asp:ListItem>
                                            <asp:ListItem Value="V">其他</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center">
                                        <label>
                                            <asp:Button ID="QryBtn" runat="server" Text="查詢" OnClick="QryBtn_Click" />
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" visile="fasle">
                                <asp:Label ID="lblMessage" runat="server" Text="檢索結果，目前尚無資料" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="ReuseGrid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="true"
                                CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Double" BorderColor="#663366"
                                BorderWidth="1" OnPageIndexChanging="ReuseGrid_PageIndexChanging" >
                                <Columns>
                                    <asp:TemplateField HeaderText="序號" ShowHeader="False" HeaderStyle-Width="44">
                                        <ItemTemplate>
                                            <div align="center">
                                                <%# Container.DataItemIndex + 1 %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="廢棄物種類">
                                        <ItemTemplate>
                                            <asp:Label ID="WasteOther" runat="server" Text='<%# Eval("WasteOther")  %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="廢棄物名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="WasteName" runat="server" Text='<%# Eval("WasteName")  %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="再生技術名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="TechName" runat="server" Text='<%# Eval("TechName")  %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="再生技術方法">
                                        <ItemTemplate>
                                            <asp:Label ID="TechOther" runat="server" Text='<%# Eval("TechOther")  %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="再生產品名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="ReuseName" runat="server" Text='<%# Eval("ReuseName")  %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#F1E4EC" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#A996AF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#A996AF" ForeColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <AlternatingRowStyle BackColor="#F9F2F7" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
