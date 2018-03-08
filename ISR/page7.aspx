<%@ Page Language="C#" MasterPageFile="~/Template/default.master" AutoEventWireup="true"
    CodeFile="page7.aspx.cs" Inherits="page7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <img src="image/frame/top3.jpg" alt="*" width="800" height="10"></td>
        </tr>
        <tr>
            <td height="25">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="font1213-1">
                    <tr>
                        <td width="10">
                            <a href="free.aspx" title="中央區域" accesskey="C" class="free_r">:::</a><div align="center">
                            </div>
                        </td>
                        <td width="20">
                            <img src="image/icon/icon2.jpg" alt="*" width="13" height="10"></td>
                        <td class="qLink_font">
                            現在位置：<a href="Default.aspx">首頁</a> &gt;&gt; <a href="page7.aspx">案例介紹</a></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="330">
                            <img src="image/frame/sub_title4.jpg" alt="*" width="330" height="55"></td>
                        <td width="431" background="image/frame/sub_2.jpg">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="GridView" runat="server">
                <tr>
                    <td align="center">
                        <table width="760" border="0" align="center" cellpadding="1" cellspacing="1">
                            <tr>
                                <td height="50">
                                    <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="title2">
                                        <tr>
                                            <td colspan="4">
                                                <div align="center">
                                                    請選擇廢棄物種類或再生技術方法後，按查詢鈕進行查詢</div>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center">
                                                    廢棄物種類</div>
                                            </td>
                                            <td>
                                                <label>
                                                    <asp:DropDownList ID="WasteItem" runat="server">
                                                        <asp:ListItem Value="Z">請選擇......</asp:ListItem>
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
                                                        <asp:ListItem Value="9">全部列出</asp:ListItem>
                                                    </asp:DropDownList>
                                                </label>
                                            </td>
                                            <td>
                                                <div align="center">
                                                    再生技術方法</div>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="TechItem" runat="server">
                                                    <asp:ListItem Value="Z">請選擇......</asp:ListItem>
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
                                                    <asp:ListItem Value="9">全部列出</asp:ListItem>
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
                                    <asp:GridView ID="CaseGrid1" runat="server" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="true" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Double"
                                        BorderColor="#663366" BorderWidth="1" OnPageIndexChanging="CaseGrid1_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="序號" ShowHeader="False" HeaderStyle-Width="35">
                                                <ItemTemplate>
                                                    <div align="center">
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="廢棄物種類" ShowHeader="False" HeaderStyle-Width="88">
                                                <ItemTemplate>
                                                    <div align="center">
                                                        <asp:Label ID="WasteOther" runat="server" Text='<%#Eval("Wasteother") %>'>
                                                        </asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="案例名稱" ShowHeader="False" HeaderStyle-Width="529">
                                                <ItemTemplate>
                                                    <div align="center">
                                                        <a href='page7.aspx?t1=<%=WasteItem.SelectedValue%>&t2=<%=TechItem.SelectedValue%>&id=<%#Eval("Id")%>'>
                                                            <%# Eval("Name")%>
                                                        </a>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="案例類型" ShowHeader="False" HeaderStyle-Width="87">
                                                <ItemTemplate>
                                                    <div align="center">
                                                        <asp:Label ID="Type" runat="server" Text='<%#(Eval("Type").ToString().Equals("A"))?"研發補助案例":"再生實廠案例" %>'>
                                                        </asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#f1e4ec" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#d2aaa2" ForeColor="Black" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#d2aaa2" Font-Bold="True" />
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <AlternatingRowStyle BackColor="#f9f2f7" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="CaseGrid2" runat="server" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="true" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Double"
                                        BorderColor="#663366" BorderWidth="1" OnPageIndexChanging="CaseGrid2_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="序號" ShowHeader="False" HeaderStyle-Width="35">
                                                <ItemTemplate>
                                                    <div align="center">
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="再生技術方法" ShowHeader="False" HeaderStyle-Width="88">
                                                <ItemTemplate>
                                                    <div align="center">
                                                        <asp:Label ID="TechOther" runat="server" Text='<%#Eval("Techother") %>'>
                                                        </asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="案例名稱" ShowHeader="False" HeaderStyle-Width="529">
                                                <ItemTemplate>
                                                    <div align="center">
                                                        <a href='page7.aspx?t1=<%=WasteItem.SelectedValue%>&t2=<%=TechItem.SelectedValue%>&id=<%#Eval("Id")%>'>
                                                            <%# Eval("Name")%>
                                                        </a>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="案例類型" ShowHeader="False" HeaderStyle-Width="87">
                                                <ItemTemplate>
                                                    <div align="center">
                                                        <asp:Label ID="Type" runat="server" Text='<%#(Eval("Type").ToString().Equals("A"))?"研發補助案例":"再生實廠案例" %>'>
                                                        </asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#f1e4ec" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#d2aaa2" ForeColor="Black" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#d2aaa2" Font-Bold="True" />
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <AlternatingRowStyle BackColor="#f9f2f7" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </asp:View>
            <asp:View ID="ResultView" runat="server">
                <tr>
                    <td>
                        <table width="760" border="0" cellpadding="1" cellspacing="1" class="mtable" align="center">
                            <tr>
                                <td height="30" colspan="2" class="title3" align="left">
                                    案例名稱：</td>
                                <td width="27%" height="30" class="title3" align="left">
                                    案例類別：</td>
                            </tr>
                            <tr>
                                <td height="30" colspan="2" class="font1213-1" align="left">
                                    <asp:Label ID="Name2" runat="server">
                                    </asp:Label></td>
                                <td height="30" class="font1213-1" align="left">
                                    <asp:Label ID="Type2" runat="server">
                                    </asp:Label></td>
                            </tr>
                            <tr>
                                <td width="41%" height="30" class="title3" align="left">
                                    廢棄物種類：
                                </td>
                                <td height="30" colspan="2" class="title3" align="left">
                                    再生技術名稱：</td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    <asp:Label ID="WasteItem2" runat="server">
                                    </asp:Label></td>
                                <td height="30" colspan="2" class="font1213-1" align="left">
                                    <asp:Label ID="TechName2" runat="server">
                                    </asp:Label></td>
                            </tr>
                            <tr>
                                <td height="30" class="title3" align="left">
                                    廢棄物名稱：</td>
                                <td height="30" colspan="2" class="title3" align="left">
                                    再生技術方法：</td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    <asp:Label ID="WasteName2" runat="server">
                                    </asp:Label></td>
                                <td height="30" colspan="2" class="font1213-1" align="left">
                                    <asp:Label ID="TechItem2" runat="server">
                                    </asp:Label></td>
                            </tr>
                            <tr>
                                <td height="30" colspan="3" class="title3" align="left">
                                    案例簡介：</td>
                            </tr>
                            <tr>
                                <td height="30" colspan="3" class="font1213-1" align="left">
                                    <asp:Label ID="CaseDesc2" runat="server">
                                    </asp:Label></td>
                            </tr>
                            <asp:Panel ID="Panel2" runat="server" visile="fasle">
                                <tr>
                                    <td height="30" colspan="3" class="font1213-1" align="left">
                                        <span class="title3">申請補助項目：</span></td>
                                </tr>
                                <tr>
                                    <td height="30" colspan="3" class="font1213-1" align="left">
                                        <asp:Label ID="HelpDesc2" runat="server">
                                        </asp:Label></td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td height="30" colspan="3" class="font1213-1" align="left">
                                    <span class="title3">資料來源：</span></td>
                            </tr>
                            <tr>
                                <td height="30" colspan="3" class="font1213-1" align="left">
                                    <asp:Label ID="Datasource2" runat="server">
                                    </asp:Label></td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="BackBtn" runat="server" Text="回查詢頁" OnClick="BackBtn_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </asp:View>
        </asp:MultiView>
    </table>
    <br />
    <br />
</asp:Content>
