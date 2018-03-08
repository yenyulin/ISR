<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="TechList.aspx.cs" Inherits="Manage_TechList" %>

<asp:Content ID="ContentTechList" ContentPlaceHolderID="Content" runat="Server">
    <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">再生技術管理</font></b></p>
            </td>
        </tr>
        <tr>
            <td align="center" class="font1213-1">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="BackBtn_Click">返回主畫面</asp:LinkButton></td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="Panel3" runat="server" visile="fasle">
        <table width="600px" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td align="center" class="font1213-1" width="35%">
                    筆數：<font color="#FF0000"><b><asp:Label ID="cntTotal" runat="server" /></b></font>
                </td>
                <td align="center" width="30%">
                    <asp:Repeater ID="rptPages" runat="server">
                        <HeaderTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
                                <tr>
                                    <td align="center" class="font1213-1">
                            【
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%#Container.DataItem %>"
                                runat="server"><%# Container.DataItem %>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            】 </td> </tr> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td align="right" class="font1213-1" width="35%">
                    頁次：第 <font color="#0000FF"><b>
                        <asp:Label ID="pageNow" runat="server" /></b></font> 頁 / 共 <font color="#0000FF"><b>
                            <asp:Label ID="pageTotal" runat="server" /></b></font> 頁
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="95%" border="0" align="center" cellpadding="5" cellspacing="1" class="mtable">
        <tr>
            <td colspan="8" align="center" bgcolor="#d2aaa2" class="title2">
                資源再生技術研發現況</td>
        </tr>
        <tr>
            <td height="65" colspan="8" align="center">
                <table width="100%" border="0">
                    <tr>
                        <td style="text-align: center; width: 20%">
                            廢棄物種類
                        </td>
                        <td style="text-align: center; width: 20%">
                            廢棄物名稱
                        </td>
                        <td style="text-align: center; width: 20%">
                            再生技術名稱
                        </td>
                        <td style="text-align: center; width: 20%">
                            再生技術方法
                        </td>
                        <td style="text-align: center; width: 20%">
                            再生產品名稱
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:DropDownList ID="WasteItem1" runat="server" OnSelectedIndexChanged="WasteItem1_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="Z">請選擇...</asp:ListItem>
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
                        <td style="text-align: center">
                            關鍵字：<asp:TextBox ID="WasteName1" runat="server" Width="40px"></asp:TextBox>
                            <asp:Button ID="QryBtn1A" runat="server" Text="查詢" OnClick="QryBtn1A_Click" />
                        </td>
                        <td style="text-align: center">
                            關鍵字：<asp:TextBox ID="TechName1" runat="server" Width="40px"></asp:TextBox>
                            <asp:Button ID="QryBtn2A" runat="server" Text="查詢" OnClick="QryBtn2A_Click" />
                        </td>
                        <td style="text-align: center">
                            <asp:DropDownList ID="TechItem1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="TechItem1_SelectedIndexChanged">
                                <asp:ListItem Value="Z">請選擇...</asp:ListItem>
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
                        <td style="text-align: center">
                            關鍵字：<asp:TextBox ID="ReuseName1" runat="server" Width="40px"></asp:TextBox>
                            <asp:Button ID="QryBtn3A" runat="server" Text="查詢" OnClick="QryBtn3A_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div align="center">
                    <asp:Panel ID="Panel1" runat="server" visile="fasle">
                        <asp:Label ID="lblMessage" runat="server" Text="尚無資源再生技術研發現況資料" />
                    </asp:Panel>
                </div>
                <asp:Panel ID="Panel2" runat="server" visile="fasle">
                    <asp:Repeater ID="TechGrid1" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="1" cellspacing="1" class="mtable">
                                <tr>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        序號</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        廢棄物種類</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        廢棄物名稱</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        再生技術名稱</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        再生技術方法</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        再生產品名稱</td>
                                    <td width="20%" align="center" bgcolor="#d2aaa2" class="title3">
                                        單位名稱</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        會員</td>
                                    <!--<td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        再生技術簡介</td>-->
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <div align="center">
                                        <%# Container.ItemIndex + 1%>
                                    </div>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="WasteOther" runat="server" Text='<%#Eval("WasteOther")%>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="WasteName" runat="server" Text='<%#Eval("WasteName") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <a href='TechView1.aspx?type=view&id=<%#Eval("Id")%>&username=<%#Eval("Username")%>'
                                        target="_blank">
                                        <%# Eval("TechName")%>
                                    </a>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="TechOther" runat="server" Text='<%# Eval("TechOther") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="ReuseName" runat="server" Text='<%# Eval("ReuseName") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Corp" runat="server" Text='<%# Eval("Corp") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="center">
                                    <asp:Label ID="Name" runat="server" Text='<%# Eval("Name") %>'>
                                    </asp:Label>
                                </td>
                                <!--<td bgcolor="#f1e4ec" class="font1213-1" align="center">
                                    <a href='TechInfo.aspx?type=<%#(Eval("id2")== DBNull.Value)?"new":"edit"%>&id2=<%#Eval("Id2")%>&id=<%#Eval("Id")%>&username=<%#Eval("Username")%>'
                                        target="_blank">維護 </a>
                                </td>-->
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="Panel6" runat="server" visile="fasle">
        <table width="600px" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td align="center" class="font1213-1" width="35%">
                    筆數：<font color="#FF0000"><b><asp:Label ID="cntTotal2" runat="server" /></b></font>
                </td>
                <td align="center" width="30%">
                    <asp:Repeater ID="rptPages2" runat="server">
                        <HeaderTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
                                <tr>
                                    <td align="center" class="font1213-1">
                            【
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnPage2" CommandName="Page" CommandArgument="<%#Container.DataItem %>"
                                runat="server"><%# Container.DataItem %>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            】 </td> </tr> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td align="right" class="font1213-1" width="35%">
                    頁次：第 <font color="#0000FF"><b>
                        <asp:Label ID="pageNow2" runat="server" /></b></font> 頁 / 共 <font color="#0000FF"><b>
                            <asp:Label ID="pageTotal2" runat="server" /></b></font> 頁
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="95%" border="0" align="center" cellpadding="5" cellspacing="1" class="mtable">
        <tr>
            <td colspan="8" align="center" bgcolor="#d2aaa2" class="title2">
                資源再生技術需求現況</td>
        </tr>
        <tr>
            <td height="65" colspan="8" align="center">
                <table width="100%" border="0">
                    <tr>
                        <td style="text-align: center; width: 20%">
                            廢棄物種類
                        </td>
                        <td style="text-align: center; width: 20%">
                            廢棄物名稱
                        </td>
                        <td style="text-align: center; width: 20%">
                            再生技術名稱
                        </td>
                        <td style="text-align: center; width: 20%">
                            再生技術方法
                        </td>
                        <td style="text-align: center; width: 20%">
                            再生產品名稱
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:DropDownList ID="WasteItem2" runat="server" OnSelectedIndexChanged="WasteItem2_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="Z">請選擇...</asp:ListItem>
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
                        <td style="text-align: center">
                            關鍵字：<asp:TextBox ID="WasteName2" runat="server" Width="40px"></asp:TextBox>
                            <asp:Button ID="QryBtn1B" runat="server" Text="查詢" OnClick="QryBtn1B_Click" />
                        </td>
                        <td style="text-align: center">
                            關鍵字：<asp:TextBox ID="TechName2" runat="server" Width="40px"></asp:TextBox>
                            <asp:Button ID="QryBtn2B" runat="server" Text="查詢" OnClick="QryBtn2B_Click" />
                        </td>
                        <td style="text-align: center">
                            <asp:DropDownList ID="TechItem2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="TechItem2_SelectedIndexChanged">
                                <asp:ListItem Value="Z">請選擇...</asp:ListItem>
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
                        <td style="text-align: center">
                            關鍵字：<asp:TextBox ID="ReuseName2" runat="server" Width="40px"></asp:TextBox>
                            <asp:Button ID="QryBtn3B" runat="server" Text="查詢" OnClick="QryBtn3B_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div align="center">
                    <asp:Panel ID="Panel4" runat="server" visile="fasle">
                        <asp:Label ID="Label2" runat="server" Text="尚無業者廠商資料" />
                    </asp:Panel>
                </div>
                <asp:Panel ID="Panel5" runat="server" visile="fasle">
                    <asp:Repeater ID="TechGrid2" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="1" cellspacing="1" class="mtable">
                                <tr>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        序號</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        廢棄物種類</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        廢棄物名稱</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        再生技術名稱</td>
                                    <td width="15%" align="center" bgcolor="#d2aaa2" class="title3">
                                        再生技術方法</td>
                                    <td width="15%" align="center" bgcolor="#d2aaa2" class="title3">
                                        再生產品名稱</td>
                                    <td width="20%" align="center" bgcolor="#d2aaa2" class="title3">
                                        單位名稱</td>
                                    <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                        會員</td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <div align="center">
                                        <%# Container.ItemIndex + 1%>
                                    </div>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="WasteOther2" runat="server" Text='<%#Eval("WasteOther")%>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="WasteName2" runat="server" Text='<%#Eval("WasteName") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("TechName") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="TechOther2" runat="server" Text='<%# Eval("TechOther") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="ReuseName2" runat="server" Text='<%# Eval("ReuseName") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Corp2" runat="server" Text='<%# Eval("Corp") %>'>
                                    </asp:Label>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="center">
                                    <asp:Label ID="Name2" runat="server" Text='<%# Eval("Name") %>'>
                                    </asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="type1" runat="server" />
    <asp:HiddenField ID="keyword1" runat="server" />
    <asp:HiddenField ID="type2" runat="server" />
    <asp:HiddenField ID="keyword2" runat="server" />
</asp:Content>
