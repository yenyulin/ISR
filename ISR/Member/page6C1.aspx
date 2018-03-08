﻿<%@ Page Language="C#" MasterPageFile="~/Template/member.master" AutoEventWireup="true"
    CodeFile="page6C1.aspx.cs" Inherits="Member_page6" %>

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
                            現在位置：<a href="Default.aspx">首頁</a> &gt;&gt; <a href="page6B1.aspx">會員專區 &gt;&gt; 會員資料
                            </a>
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
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="GridView" runat="server">
                        <table width="760" border="0" cellpadding="1" cellspacing="1" class="mtable">
                            <tr>
                                <td width="150" rowspan="5" align="center" valign="top">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1" class="mtable2">
                                        <tr>
                                            <td valign="middle" bgcolor="#A996AF" class="title2">
                                                <div align="center">
                                                    學研機構</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="50" class="font1213-1">
                                                <%ProfileCommon p = Profile.GetProfile(Page.User.Identity.Name);%>
                                                <%=p.UserProfile.Name%>
                                                &nbsp;您好
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="font1213-1">
                                                <label>
                                                    <asp:Button ID="LogoutBtn" runat="server" Text="登出" OnClick="LogoutBtn_Click" />
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td height="25" colspan="2" bgcolor="#d2aaa2" class="title2">
                                    <div align="center">
                                        會 員 資 料</div>
                                </td>
                            </tr>
                            <tr>
                                <td width="537" height="35" class="font1213-1">
                                    <div align="center" class="table_title1">
                                        <strong>資源再生技術研發供給現況</strong></div>
                                </td>
                                <td width="55" class="title2">
                                    <div align="center">
                                        <asp:LinkButton ID="NewLinkBtn" runat="server" OnClick="NewLinkBtn_Click" Font-Underline="True"
                                            Font-Size="12px">新增</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="font1213-1">
                                    <asp:GridView ID="ReuseGrid" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" BorderStyle="Double" BorderColor="#663366" 
                                        BorderWidth="1" OnPageIndexChanging="Reuse_PageIndexChanging">
                                        <Columns>
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
                                                <asp:LinkButton ID="TechName" runat="server" OnCommand="TechNameBtn1_Command" CommandArgument='<%#Eval("Id")%>'><%# Eval("TechName")%></asp:LinkButton>
                                                     
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
                                            <asp:TemplateField HeaderText="研發情形">
                                                <ItemTemplate>
                                                    <asp:Label ID="ParamName" runat="server" Text='<%# Eval("ParamName")  %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="申請之相關專利">
                                                <ItemTemplate>
                                                    <asp:Label ID="Patent" runat="server" Text='<%# Eval("Patent")  %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" ">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Edit" runat="server" OnCommand="EditBtn1_Command" CommandArgument='<%#Eval("Id")%>'>編輯</asp:LinkButton>
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
                            <tr>
                                <td width="537" bgcolor="#d2aaa2" class="font1213-1">
                                    <div align="center">
                                        基本資料</div>
                                </td>
                                <td width="55" bgcolor="#d2aaa2" class="title2">
                                    <div align="center">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="EditLinkBtn_Click" Font-Underline="True"
                                            Font-Size="12px">編輯</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="font1213-1">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1" class="mtable2">
                                        <tr>
                                            <td width="50%" colspan="2" bgcolor="#eeeeee" class="font1213-1" align="left" style="height: 25px">
                                                1．密碼：●●●●&nbsp;<asp:LinkButton ID="PwdBtn" runat="server" OnClick="PwdBtn_Click">修改密碼</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" class="font1213-1" align="left">
                                                2．學校系所 / 研究單位名稱：<asp:Label ID="CorpView" runat="server"> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" bgcolor="#EEEEEE" class="font1213-1" align="left">
                                                3．地址：<asp:Label ID="AddressView" runat="server"> </asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" class="font1213-1" align="left">
                                                4．會員姓名：<asp:Label ID="NameView" runat="server"> </asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#EEEEEE" class="font1213-1" style="height: 14px" align="left">
                                                5．聯絡電話：<asp:Label ID="TelView" runat="server"> </asp:Label></td>
                                            <td bgcolor="#EEEEEE" class="font1213-1" style="height: 14px" align="left">
                                                6．傳真：<asp:Label ID="FaxView" runat="server"> </asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" class="font1213-1" align="left">
                                                7．電子信箱：<asp:Label ID="EmailView" runat="server"> </asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" bgcolor="#EEEEEE" class="font1213-1" align="left">
                                                8．單位屬性：<asp:Label ID="KindView" runat="server"> </asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="EditView1" runat="server">
                        <asp:DetailsView ID="DetailsView1" runat="server" Width="100%" AutoGenerateRows="False"
                            BorderWidth="0px" OnItemDeleting="DetailsView1_ItemDeleting" OnItemUpdating="DetailsView1_ItemUpdating"
                            OnItemInserting="DetailsView1_ItemInserting">
                            <Fields>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                                            bgcolor="#666600" class="mtable">
                                            <tr bgcolor="#A2CAD2" height="57">
                                                <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                                                    <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absmiddle">
                                                    <span class="form_title1">資源再生技術研發現況&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ※ 為必填欄位</span></td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">※</span> 廢棄物種類
                                                </td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="WasteItem" runat="server" OnSelectedIndexChanged="WasteItem_SelectedIndexChanged"
                                                        SelectedValue='<%# Bind("WasteItem") %>' AutoPostBack="true">
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
                                                    <asp:TextBox ID="WasteOther" runat="server" Visible='<%#(Eval("WasteItem").ToString().Equals("U"))? true:false%>'
                                                        Width="90px" Text='<%#(Eval("WasteItem").ToString().Equals("U"))? Eval("WasteOther") : ""%>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#F2F9F4">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">※</span> 廢棄物名稱</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:TextBox ID="WasteName" runat="server" Text='<%# Bind("WasteName") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="WasteNameRequired" runat="server" ControlToValidate="WasteName"
                                                        ErrorMessage="必須提供廢棄物名稱。" ToolTip="必須提供廢棄物名稱。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9"  > 
                                                <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">※</span> 再生技術名稱</td>
                                                <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="TechName" runat="server" Text='<%# Bind("TechName") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="TechNameRequired" runat="server" ControlToValidate="TechName"
                                                        ErrorMessage="必須提供再生技術名稱。" ToolTip="必須提供再生技術名稱。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#F2F9F4"  >
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">※</span> 再生技術方法</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="TechItem" runat="server" OnSelectedIndexChanged="TechItem_SelectedIndexChanged"
                                                        AutoPostBack="true" SelectedValue='<%# Bind("TechItem") %>'>
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
                                                    <asp:TextBox ID="TechOther" runat="server" Visible='<%#(Eval("TechItem").ToString().Equals("V"))? true:false%>'
                                                        Text='<%#(Eval("TechItem").ToString().Equals("V"))? Eval("TechOther") : ""%>'
                                                        Width="90px"></asp:TextBox>
                                                </td>
                                            </tr>
                                           
                                            <tr bgcolor="#E4F1E9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    再生產品名稱</td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="ReuseName" runat="server" Text='<%# Bind("ReuseName") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#F2F9F4">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">※</span> 研究情形</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="ResearchItem" runat="server" SelectedValue='<%# Bind("ResearchItem") %>'>
                                                        <asp:ListItem Value="A">已完成</asp:ListItem>
                                                        <asp:ListItem Value="B">研發中</asp:ListItem>
                                                        <asp:ListItem Value="C">擬新增</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    申請之相關專利</td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="Patent" runat="server" Text='<%# Bind("Patent") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">※</span> 再生技術特點
                                                </td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:TextBox ID="TechAdv" runat="server" Rows="5" Text='<%# Bind("TechAdv") %>' TextMode="MultiLine"
                                                        Width="428px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="TechAdvRequired" runat="server" ControlToValidate="TechAdv"
                                                        ErrorMessage="必須提供再生技術特點。" ToolTip="必須提供再生技術特點。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9" height="37">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">※</span> 再生技術簡介
                                                </td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="TechDesc" runat="server" Text='<%# Bind("TechDesc") %>' Rows="5"
                                                        TextMode="MultiLine" Width="428px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="TechDescRequired" runat="server" ControlToValidate="TechDesc"
                                                        ErrorMessage="必須提供再生技術簡介。" ToolTip="必須提供再生技術簡介。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                                                    <asp:HiddenField ID="Id" runat="server" Value='<%# Bind("Id") %>' />
                                                    <asp:Button ID="BtnUpdate1" runat="server" Text="確定修改" CommandName="update" ValidationGroup="ValidationGroup1" />
                                                    <asp:Button ID="BtnDelete1" runat="server" Text="刪除資料" CommandName="delete" OnClientClick="return confirm('確定刪除資料?');" />
                                                    <asp:Button ID="BtnCancel1" runat="server" Text="返回主畫面" OnClick="BtnCancel_Click"
                                                        CausesValidation="false" />
                                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="ValidationGroup1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                                            bgcolor="#666600" class="mtable">
                                            <tr bgcolor="#a2cad2" height="57">
                                                <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                                                    <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absMiddle">
                                                    <span class="form_title1">資源再生技術研發現況&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ※ 為必填欄位</span></td>
                                            </tr>
                                            <tr bgcolor="#e4f1e9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">※</span> 廢棄物種類
                                                </td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="WasteItem2" runat="server" OnSelectedIndexChanged="WasteItem2_SelectedIndexChanged"
                                                        AutoPostBack="true">
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
                                                    <asp:TextBox ID="WasteOther2" runat="server" Visible="false" Width="90px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#f2f9f4">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">※</span> 廢棄物名稱</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:TextBox ID="WasteName2" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="WasteNameRequired2" runat="server" ControlToValidate="WasteName2"
                                                        ErrorMessage="必須提供廢棄物名稱。" ToolTip="必須提供廢棄物名稱。" ValidationGroup="Validation2">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#e4f1e9"  >
                                                <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">※</span> 再生技術名稱</td>
                                                <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="TechName2" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="TechNameRequired2" runat="server" ControlToValidate="TechName2"
                                                        ErrorMessage="必須提供再生技術名稱。" ToolTip="必須提供再生技術名稱。" ValidationGroup="Validation2">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#f2f9f4"  >
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">※</span> 再生技術方法</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="TechItem2" runat="server" OnSelectedIndexChanged="TechItem2_SelectedIndexChanged"
                                                        AutoPostBack="true">
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
                                                    <asp:TextBox ID="TechOther2" runat="server" Visible="false" Width="90px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            <tr bgcolor="#e4f1e9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    再生產品名稱</td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="ReuseName2" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#f2f9f4">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">※</span> 研究情形</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="ResearchItem2" runat="server">
                                                        <asp:ListItem Value="A">已完成</asp:ListItem>
                                                        <asp:ListItem Value="B">研發中</asp:ListItem>
                                                        <asp:ListItem Value="C">擬新增</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#e4f1e9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    申請之相關專利</td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="Patent2" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#e4f1e9">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">※</span> 再生技術特點
                                                </td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:TextBox ID="TechAdv2" runat="server" Rows="5" TextMode="MultiLine" Width="428px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="TechAdvRequired2" runat="server" ControlToValidate="TechAdv2"
                                                        ErrorMessage="必須提供再生技術特點。" ToolTip="必須提供再生技術特點。" ValidationGroup="Validation2">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#e4f1e9" height="37">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">※</span> 再生技術簡介
                                                </td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="TechDesc2" runat="server" Rows="5" TextMode="MultiLine" Width="428px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="TechDescRequired2" runat="server" ControlToValidate="TechDesc2"
                                                        ErrorMessage="必須提供再生技術簡介。" ToolTip="必須提供再生技術簡介。" ValidationGroup="Validation2">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#e4f1e9">
                                                <td colspan="2" align="center" bgcolor="#f1e4ec" class="table_title1">
                                                    <asp:Button ID="BtnAppend1" runat="server" Text="確定儲存" ValidationGroup="Validation2"
                                                        CommandName="insert" />
                                                    <asp:Button ID="BtnCancel1" runat="server" Text="返回主畫面" OnClick="BtnCancel_Click"
                                                        CausesValidation="false" />
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="Validation2" />
                                                </td>
                                            </tr>
                                        </table>
                                    </InsertItemTemplate>
                                </asp:TemplateField>
                            </Fields>
                        </asp:DetailsView>
                    </asp:View>
                    <asp:View ID="EditView2" runat="server">
                        <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                            bgcolor="#666600" class="mtable">
                            <tr bgcolor="#A2CAD2" height="57">
                                <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                                    <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absmiddle">
                                    <span class="form_title1">基本資料&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ※ 為必填欄位</span></td>
                            </tr>
                            <tr bgcolor="#E4F1E9" height="37">
                                <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">※</span> 帳號</td>
                                <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <asp:Label ID="Username" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    <span class="style1">※</span> 學校系所 / 研究單位名稱
                                </td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <asp:TextBox ID="Corp" runat="server" Columns="25"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="CorpRequired" runat="server" ControlToValidate="Corp" ErrorMessage="必須提供單位名稱。"
                                        ToolTip="必須提供單位名稱。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">※</span> 地址</td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <span style="height: 27px">
                                        <asp:DropDownList ID="cityList" runat="server" OnSelectedIndexChanged="cityList_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Value="01">臺北市</asp:ListItem>
                                            <asp:ListItem Value="02">基隆市</asp:ListItem>
                                            <asp:ListItem Value="03">臺北縣</asp:ListItem>
                                            <asp:ListItem Value="04">宜蘭縣</asp:ListItem>
                                            <asp:ListItem Value="05">新竹市</asp:ListItem>
                                            <asp:ListItem Value="06">新竹縣</asp:ListItem>
                                            <asp:ListItem Value="07">桃園縣</asp:ListItem>
                                            <asp:ListItem Value="08">苗栗縣</asp:ListItem>
                                            <asp:ListItem Value="09">臺中市</asp:ListItem>
                                            <asp:ListItem Value="10">臺中縣</asp:ListItem>
                                            <asp:ListItem Value="11">彰化縣</asp:ListItem>
                                            <asp:ListItem Value="12">南投縣</asp:ListItem>
                                            <asp:ListItem Value="13">嘉義市</asp:ListItem>
                                            <asp:ListItem Value="14">嘉義縣</asp:ListItem>
                                            <asp:ListItem Value="15">雲林縣</asp:ListItem>
                                            <asp:ListItem Value="16">臺南市</asp:ListItem>
                                            <asp:ListItem Value="17">臺南縣</asp:ListItem>
                                            <asp:ListItem Value="18">高雄市</asp:ListItem>
                                            <asp:ListItem Value="19">南海諸島</asp:ListItem>
                                            <asp:ListItem Value="20">高雄縣</asp:ListItem>
                                            <asp:ListItem Value="21">澎湖縣</asp:ListItem>
                                            <asp:ListItem Value="22">屏東縣</asp:ListItem>
                                            <asp:ListItem Value="23">臺東縣</asp:ListItem>
                                            <asp:ListItem Value="24">花蓮縣</asp:ListItem>
                                            <asp:ListItem Value="25">金門縣</asp:ListItem>
                                            <asp:ListItem Value="26">連江縣</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="zipList" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="Address" runat="server" Columns="34" MaxLength="150"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="Address"
                                            ErrorMessage="必須提供地址。" ToolTip="必須提供地址。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                    </span>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    <span class="style1">※</span> 會員姓名</td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <asp:TextBox ID="Name" runat="server" Columns="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name"
                                        ErrorMessage="必須提供會員姓名。" ToolTip="必須提供會員姓名。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">※</span> 連絡電話</td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <asp:TextBox ID="Tel" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TelRequired" runat="server" ControlToValidate="Tel"
                                        ErrorMessage="必須提供連絡電話。" ToolTip="必須提供連絡電話。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    <span class="style1">※</span> 傳真</td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <asp:TextBox ID="Fax" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="FaxRequired" runat="server" ControlToValidate="Fax"
                                        ErrorMessage="必須提供會員姓名。" ToolTip="必須提供會員姓名。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">※</span> 電子信箱
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="必須提供電子郵件。" ToolTip="必須提供電子郵件。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="Email"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server"
                                        ErrorMessage="電子郵件格式不正確。" ToolTip="電子郵件格式不正確。" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4" height="37">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    <span class="style1">※</span> 單位屬性
                                </td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <label>
                                        <asp:DropDownList ID="Kind" runat="server">
                                            <asp:ListItem Value="A">學術單位</asp:ListItem>
                                            <asp:ListItem Value="B">研究單位</asp:ListItem>
                                            <asp:ListItem Value="C">其他</asp:ListItem>
                                        </asp:DropDownList>
                                    </label>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                    <asp:Button ID="BtnUpdate2" runat="server" Text="確定修改" OnClick="BtnUpdate2_Click"
                                        ValidationGroup="ValidationGroup3" />
                                    <asp:Button ID="BtnCancel2" runat="server" Text="返回主畫面" OnClick="BtnCancel2_Click" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="ValidationGroup3" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="EditView3" runat="server">
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
                                            <asp:TextBox ID="CurrentPassword" runat="server"  TextMode="Password" MaxLength="8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#F2F9F4">
                                        <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                            <span class="style1">※</span> 新密碼:
                                        </td>
                                        <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                            <asp:TextBox ID="NewPassword" runat="server"  TextMode="Password" MaxLength="8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                ErrorMessage="必須提供新密碼。" ToolTip="必須提供新密碼。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="NewPassword"
                                                ValidationExpression="^[0-9]{8}$" runat="server" ErrorMessage="新密碼需為8碼數字。" ToolTip="新密碼需為8碼數字。"
                                                SetFocusOnError="True" ValidationGroup="ChangePassword1">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#E4F1E9" height="37">
                                        <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                            <span class="style1">※</span> 確認新密碼:</td>
                                        <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <asp:TextBox ID="ConfirmNewPassword" runat="server"  TextMode="Password" MaxLength="8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                ErrorMessage="必須提供確認新密碼。" ToolTip="必須提供確認新密碼。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
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
                                                Text="確定修改" ValidationGroup="ChangePassword1" />
                                            <asp:Button ID="BackBtn" runat="server" Text="返回主畫面" OnClick="BackBtn_Click" />
                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="ChangePassword1" />
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
                                                Text="繼 續" OnCommand="ContinuePushButton_Command" />
                                        </td>
                                    </tr>
                                </table>
                            </SuccessTemplate>
                        </asp:ChangePassword>
                    </asp:View>
                    <asp:View ID="ResultView" runat="server">
                
                        <table width="760" border="0" cellpadding="1" cellspacing="1" class="mtable">
                            <tr>
                                <td height="50" class="title3">
                                    &nbsp;
                                    <div align="center">
                                        <asp:Label ID="TechItem3" runat="server"></asp:Label>再生技術簡介及特點&nbsp;</div>
                                </td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    &nbsp;<span class="title3">技術特點：</span></td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="TechAdv3" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    &nbsp;<span class="title3">技術簡介：</span></td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="TechDesc3" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="BackBtn" runat="server" Text="返回主畫面" OnClick="BackBtn_Click" />
                                </td>
                            </tr>
                        </table>
                    
                
            </asp:View>
                    
                    
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
