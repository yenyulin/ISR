<%@ Page Language="C#" MasterPageFile="~/Template/member.master" AutoEventWireup="true"
    CodeFile="page6C2.aspx.cs" Inherits="Member_page6C3" %>

<asp:Content ID="ContentCreateUser2" ContentPlaceHolderID="Content" runat="Server">
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
                            <a href="../free.aspx" title="�����ϰ�" accesskey="C"><font class="free_r">:::</font></a><div
                                align="center">
                            </div>
                        </td>
                        <td width="20">
                            <img src="../image/icon/icon2.jpg" alt="*" width="13" height="10"></td>
                        <td class="qLink_font">
                            �{�b��m�G<a href="Default.aspx">����</a> &gt;&gt; <a href="page6C2.aspx">�|���M�� &gt;&gt; �|�����
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
                                            | <a href="page6A2.aspx">��o�X�@��H</a> | <a href="page6B2.aspx">�ѻݸ�T</a> | <a href="page6C2.aspx">
                                                �|�����</a> |
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
                                                    �~�̼t��</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="50" class="font1213-1">
                                                <%ProfileCommon p = Profile.GetProfile(Page.User.Identity.Name);%>
                                                <%=p.UserProfile.Name%>
                                                &nbsp;�z�n
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="font1213-1">
                                                <label>
                                                    <asp:Button ID="LogoutBtn" runat="server" Text="�n�X" OnClick="LogoutBtn_Click" />
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td height="25" colspan="2" bgcolor="#d2aaa2" class="title2">
                                    <div align="center">
                                        �| �� �� ��</div>
                                </td>
                            </tr>
                            <tr>
                                <td width="537" height="35" class="font1213-1">
                                    <div align="center" class="table_title1">
                                        <strong>�귽�A�ͧ޳N��o�ݨD�{�p</strong></div>
                                </td>
                                <td width="55" class="title2">
                                    <div align="center">
                                        <asp:LinkButton ID="NewLinkBtn" runat="server" OnClick="NewLinkBtn_Click" Font-Underline="True"
                                            Font-Size="12px">�s�W</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="font1213-1">
                                    <asp:GridView ID="ReuseGrid" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Double" BorderColor="#663366"
                                        BorderWidth="1" OnPageIndexChanging="Reuse_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="�o�󪫺���">
                                                <ItemTemplate>
                                                    <asp:Label ID="WasteOther" runat="server" Text='<%# Eval("WasteOther")  %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="�o�󪫦W��">
                                                <ItemTemplate>
                                                    <asp:Label ID="WasteName" runat="server" Text='<%# Eval("WasteName")  %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="�A�ͧ޳N�W��">
                                                <ItemTemplate>
                                                    <asp:Label ID="TechName" runat="server" Text='<%# Eval("TechName")  %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="�A�ͧ޳N��k">
                                                <ItemTemplate>
                                                    <asp:Label ID="TechOther" runat="server" Text='<%# Eval("TechOther")  %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="�A�Ͳ��~�W��">
                                                <ItemTemplate>
                                                    <asp:Label ID="ReuseName" runat="server" Text='<%# Eval("ReuseName")  %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" ">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Edit" runat="server" OnCommand="EditBtn1_Command" CommandArgument='<%#Eval("Id")%>'>�s��</asp:LinkButton>
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
                                        �򥻸��</div>
                                </td>
                                <td width="55" bgcolor="#d2aaa2" class="title2">
                                    <div align="center">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="EditLinkBtn_Click" Font-Underline="True"
                                            Font-Size="12px">�s��</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="font1213-1">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1" class="mtable2">
                                        <tr>
                                            <td width="50%" colspan="2" bgcolor="#eeeeee" class="font1213-1" align="left" style="height: 25px">
                                                1�D�K�X�G��������&nbsp;<asp:LinkButton ID="PwdBtn" runat="server" OnClick="PwdBtn_Click">�ק�K�X</asp:LinkButton></td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" class="font1213-1" align="left">
                                                2�D���q / �Ʒ~�W�١G<asp:Label ID="CorpView" runat="server"> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" bgcolor="#EEEEEE" class="font1213-1" align="left">
                                                3�D�t�d�H�m�W�G<asp:Label ID="OwnerView" runat="server"> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" class="font1213-1" align="left">
                                                4�D�a�}�G<asp:Label ID="AddressView" runat="server"> </asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" bgcolor="#EEEEEE" class="font1213-1" align="left">
                                                5�D�|���m�W�G<asp:Label ID="NameView" runat="server"> </asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="font1213-1" style="height: 14px" align="left">
                                                6�D�p���q�ܡG<asp:Label ID="TelView" runat="server"> </asp:Label></td>
                                            <td class="font1213-1" style="height: 14px" align="left">
                                                7�D�ǯu�G<asp:Label ID="FaxView" runat="server"> </asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" bgcolor="#EEEEEE" class="font1213-1" align="left">
                                                8�D�q�l�H�c�G<asp:Label ID="EmailView" runat="server"> </asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="2" class="font1213-1" align="left">
                                                9�D����ݩʡG<asp:Label ID="KindView" runat="server"> </asp:Label></td>
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
                                                    <img src="../image/icon/page_edit.png" alt="��g�������" width="16" height="16" align="absmiddle">
                                                    <span class="form_title1">�귽�A�ͧ޳N�ݨD�{�p&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �� ���������</span></td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">��</span> �o�󪫺���
                                                </td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="WasteItem" runat="server" OnSelectedIndexChanged="WasteItem_SelectedIndexChanged"
                                                        SelectedValue='<%# Bind("WasteItem") %>' AutoPostBack="true">
                                                        <asp:ListItem Value="A">�ʪ��ʼo��</asp:ListItem>
                                                        <asp:ListItem Value="B">�Ӫ��ʼo��</asp:ListItem>
                                                        <asp:ListItem Value="C">�o�콦</asp:ListItem>
                                                        <asp:ListItem Value="D">�o��</asp:ListItem>
                                                        <asp:ListItem Value="E">�o����</asp:ListItem>
                                                        <asp:ListItem Value="F">�o�V���g</asp:ListItem>
                                                        <asp:ListItem Value="G">�ۧ��o��</asp:ListItem>
                                                        <asp:ListItem Value="H">�o��</asp:ListItem>
                                                        <asp:ListItem Value="I">�o���</asp:ListItem>
                                                        <asp:ListItem Value="J">�����êd</asp:ListItem>
                                                        <asp:ListItem Value="K">�L�����d</asp:ListItem>
                                                        <asp:ListItem Value="L">�Ǵ�</asp:ListItem>
                                                        <asp:ListItem Value="M">�l��</asp:ListItem>
                                                        <asp:ListItem Value="N">���ݼo��</asp:ListItem>
                                                        <asp:ListItem Value="O">�o�o</asp:ListItem>
                                                        <asp:ListItem Value="P">�o��</asp:ListItem>
                                                        <asp:ListItem Value="Q">�o�P</asp:ListItem>
                                                        <asp:ListItem Value="R">�o�G</asp:ListItem>
                                                        <asp:ListItem Value="S">�o����</asp:ListItem>
                                                        <asp:ListItem Value="T">�o�q��</asp:ListItem>
                                                        <asp:ListItem Value="U">��L</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="WasteOther" runat="server" Visible='<%#(Eval("WasteItem").ToString().Equals("U"))? true:false%>'
                                                        Width="90px" Text='<%#(Eval("WasteItem").ToString().Equals("U"))? Eval("WasteOther") : ""%>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#F2F9F4">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">��</span> �o�󪫦W��</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:TextBox ID="WasteName" runat="server" Text='<%# Bind("WasteName") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="WasteNameRequired" runat="server" ControlToValidate="WasteName"
                                                        ErrorMessage="�������Ѽo�󪫦W�١C" ToolTip="�������Ѽo�󪫦W�١C" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">��</span> �A�ͧ޳N�W��</td>
                                                <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="TechName" runat="server" Text='<%# Bind("TechName") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="TechNameRequired" runat="server" ControlToValidate="TechName"
                                                        ErrorMessage="�������ѦA�ͧ޳N�W�١C" ToolTip="�������ѦA�ͧ޳N�W�١C" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#F2F9F4">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">��</span> �A�ͧ޳N��k</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="TechItem" runat="server" OnSelectedIndexChanged="TechItem_SelectedIndexChanged"
                                                        AutoPostBack="true" SelectedValue='<%# Bind("TechItem") %>'>
                                                        <asp:ListItem Value="A">�����B����k</asp:ListItem>
                                                        <asp:ListItem Value="B">�q�ߪk</asp:ListItem>
                                                        <asp:ListItem Value="C">�Ѩ��k</asp:ListItem>
                                                        <asp:ListItem Value="D">�T�ƪk</asp:ListItem>
                                                        <asp:ListItem Value="E">���Ѫk</asp:ListItem>
                                                        <asp:ListItem Value="F">���B�z�k</asp:ListItem>
                                                        <asp:ListItem Value="G">�����k</asp:ListItem>
                                                        <asp:ListItem Value="H">�q�Ѫk</asp:ListItem>
                                                        <asp:ListItem Value="I">�l���k</asp:ListItem>
                                                        <asp:ListItem Value="J">���Īk</asp:ListItem>
                                                        <asp:ListItem Value="K">�E�X�k</asp:ListItem>
                                                        <asp:ListItem Value="L">�}�H�k</asp:ListItem>
                                                        <asp:ListItem Value="M">����B�B��k</asp:ListItem>
                                                        <asp:ListItem Value="N">�]�H�k</asp:ListItem>
                                                        <asp:ListItem Value="O">�𴣡B�l���k</asp:ListItem>
                                                        <asp:ListItem Value="P">���X�B�����k</asp:ListItem>
                                                        <asp:ListItem Value="Q">�M�ҡB����k</asp:ListItem>
                                                        <asp:ListItem Value="R">��Ϊk</asp:ListItem>
                                                        <asp:ListItem Value="S">�I���k</asp:ListItem>
                                                        <asp:ListItem Value="T">��ơB�٭�k</asp:ListItem>
                                                        <asp:ListItem Value="U">���ѡB�m���k</asp:ListItem>
                                                        <asp:ListItem Value="V">��L</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="TechOther" runat="server" Visible='<%#(Eval("TechItem").ToString().Equals("V"))? true:false%>'
                                                        Text='<%#(Eval("TechItem").ToString().Equals("V"))? Eval("TechOther") : ""%>'
                                                        Width="90px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">��</span> �A�Ͳ��~�W��</td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="ReuseName" runat="server" Text='<%# Bind("ReuseName") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ReuseName"
                                                        ErrorMessage="�������ѦA�Ͳ��~�W�١C" ToolTip="�������ѦA�Ͳ��~�W�١C" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                                                    <asp:HiddenField ID="Id" runat="server" Value='<%# Bind("Id") %>' />
                                                    <asp:Button ID="BtnUpdate1" runat="server" Text="�T�w�ק�" CommandName="update" ValidationGroup="ValidationGroup1" />
                                                    <asp:Button ID="BtnDelete1" runat="server" Text="�R�����" CommandName="delete" OnClientClick="return confirm('�T�w�R�����?');" />
                                                    <asp:Button ID="BtnCancel1" runat="server" Text="��^�D�e��" OnClick="BtnCancel_Click"
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
                                            <tr bgcolor="#A2CAD2" height="57">
                                                <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                                                    <img src="../image/icon/page_edit.png" alt="��g�������" width="16" height="16" align="absmiddle">
                                                    <span class="form_title1">�귽�A�ͧ޳N��o�ݨD�{�p&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �� ���������</span></td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">��</span> �o�󪫺���
                                                </td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="WasteItem2" runat="server" OnSelectedIndexChanged="WasteItem2_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Value="A">�ʪ��ʼo��</asp:ListItem>
                                                        <asp:ListItem Value="B">�Ӫ��ʼo��</asp:ListItem>
                                                        <asp:ListItem Value="C">�o�콦</asp:ListItem>
                                                        <asp:ListItem Value="D">�o��</asp:ListItem>
                                                        <asp:ListItem Value="E">�o����</asp:ListItem>
                                                        <asp:ListItem Value="F">�o�V���g</asp:ListItem>
                                                        <asp:ListItem Value="G">�ۧ��o��</asp:ListItem>
                                                        <asp:ListItem Value="H">�o��</asp:ListItem>
                                                        <asp:ListItem Value="I">�o���</asp:ListItem>
                                                        <asp:ListItem Value="J">�����êd</asp:ListItem>
                                                        <asp:ListItem Value="K">�L�����d</asp:ListItem>
                                                        <asp:ListItem Value="L">�Ǵ�</asp:ListItem>
                                                        <asp:ListItem Value="M">�l��</asp:ListItem>
                                                        <asp:ListItem Value="N">���ݼo��</asp:ListItem>
                                                        <asp:ListItem Value="O">�o�o</asp:ListItem>
                                                        <asp:ListItem Value="P">�o��</asp:ListItem>
                                                        <asp:ListItem Value="Q">�o�P</asp:ListItem>
                                                        <asp:ListItem Value="R">�o�G</asp:ListItem>
                                                        <asp:ListItem Value="S">�o����</asp:ListItem>
                                                        <asp:ListItem Value="T">�o�q��</asp:ListItem>
                                                        <asp:ListItem Value="U">��L</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="WasteOther2" runat="server" Visible="false" Width="90px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#F2F9F4">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">��</span> �o�󪫦W��</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:TextBox ID="WasteName2" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="WasteNameRequired" runat="server" ControlToValidate="WasteName2"
                                                        ErrorMessage="�������Ѽo�󪫦W�١C" ToolTip="�������Ѽo�󪫦W�١C" ValidationGroup="ValidationGroup2">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">��</span> �A�ͧ޳N�W��</td>
                                                <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="TechName2" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="TechNameRequired" runat="server" ControlToValidate="TechName2"
                                                        ErrorMessage="�������ѦA�ͧ޳N�W�١C" ToolTip="�������ѦA�ͧ޳N�W�١C" ValidationGroup="ValidationGroup2">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#F2F9F4">
                                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                    <span class="style1">��</span> �A�ͧ޳N��k</td>
                                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                    <asp:DropDownList ID="TechItem2" runat="server" OnSelectedIndexChanged="TechItem2_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Value="A">�����B����k</asp:ListItem>
                                                        <asp:ListItem Value="B">�q�ߪk</asp:ListItem>
                                                        <asp:ListItem Value="C">�Ѩ��k</asp:ListItem>
                                                        <asp:ListItem Value="D">�T�ƪk</asp:ListItem>
                                                        <asp:ListItem Value="E">���Ѫk</asp:ListItem>
                                                        <asp:ListItem Value="F">���B�z�k</asp:ListItem>
                                                        <asp:ListItem Value="G">�����k</asp:ListItem>
                                                        <asp:ListItem Value="H">�q�Ѫk</asp:ListItem>
                                                        <asp:ListItem Value="I">�l���k</asp:ListItem>
                                                        <asp:ListItem Value="J">���Īk</asp:ListItem>
                                                        <asp:ListItem Value="K">�E�X�k</asp:ListItem>
                                                        <asp:ListItem Value="L">�}�H�k</asp:ListItem>
                                                        <asp:ListItem Value="M">����B�B��k</asp:ListItem>
                                                        <asp:ListItem Value="N">�]�H�k</asp:ListItem>
                                                        <asp:ListItem Value="O">�𴣡B�l���k</asp:ListItem>
                                                        <asp:ListItem Value="P">���X�B�����k</asp:ListItem>
                                                        <asp:ListItem Value="Q">�M�ҡB����k</asp:ListItem>
                                                        <asp:ListItem Value="R">��Ϊk</asp:ListItem>
                                                        <asp:ListItem Value="S">�I���k</asp:ListItem>
                                                        <asp:ListItem Value="T">��ơB�٭�k</asp:ListItem>
                                                        <asp:ListItem Value="U">���ѡB�m���k</asp:ListItem>
                                                        <asp:ListItem Value="V">��L</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="TechOther2" runat="server" Visible="false" Width="90px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                    <span class="style1">��</span> �A�Ͳ��~�W��</td>
                                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                    <asp:TextBox ID="ReuseName2" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ReuseName2"
                                                        ErrorMessage="�������ѦA�Ͳ��~�W�١C" ToolTip="�������ѦA�Ͳ��~�W�١C" ValidationGroup="ValidationGroup2">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#E4F1E9">
                                                <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                                                    <asp:Button ID="BtnAppend1" runat="server" Text="�T�w�x�s" ValidationGroup="ValidationGroup2"
                                                        CommandName="insert" />
                                                    <asp:Button ID="BtnCancel1" runat="server" Text="��^�D�e��" OnClick="BtnCancel_Click"
                                                        CausesValidation="false" />
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="ValidationGroup2" />
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
                                    <img src="../image/icon/page_edit.png" alt="��g�������" width="16" height="16" align="absmiddle">
                                    <span class="form_title1">�򥻸��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �� ���������</span></td>
                            </tr>
                            <tr bgcolor="#E4F1E9" height="37">
                                <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">��</span> �b��</td>
                                <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <asp:Label ID="Username" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">��</span> ���q / �Ʒ~�W��
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <asp:TextBox ID="Corp" runat="server" Columns="25"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="CorpRequired" runat="server" ControlToValidate="Corp" ErrorMessage="�������ѳ��W�١C"
                                        ToolTip="�������ѳ��W�١C" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td bgcolor="#F9F2F7" class="table_title1" align="left">
                                    <span class="style1">��</span> �t�d�H�m�W
                                </td>
                                <td bgcolor="#F9F2F7" class="font1213-1" align="left">
                                    <asp:TextBox ID="Owner" runat="server" Columns="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="OwnerRequired" runat="server" ControlToValidate="Owner"
                                        ErrorMessage="�������ѭt�d�H�m�W�C" ToolTip="�������ѭt�d�H�m�W�C" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    <span class="style1">��</span> �a�}</td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <span style="height: 27px">
                                        <asp:DropDownList ID="cityList" runat="server" OnSelectedIndexChanged="cityList_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Value="01">�O�_��</asp:ListItem>
                                            <asp:ListItem Value="02">�򶩥�</asp:ListItem>
                                            <asp:ListItem Value="03">�O�_��</asp:ListItem>
                                            <asp:ListItem Value="04">�y����</asp:ListItem>
                                            <asp:ListItem Value="05">�s�˥�</asp:ListItem>
                                            <asp:ListItem Value="06">�s�˿�</asp:ListItem>
                                            <asp:ListItem Value="07">��鿤</asp:ListItem>
                                            <asp:ListItem Value="08">�]�߿�</asp:ListItem>
                                            <asp:ListItem Value="09">�O����</asp:ListItem>
                                            <asp:ListItem Value="10">�O����</asp:ListItem>
                                            <asp:ListItem Value="11">���ƿ�</asp:ListItem>
                                            <asp:ListItem Value="12">�n�뿤</asp:ListItem>
                                            <asp:ListItem Value="13">�Ÿq��</asp:ListItem>
                                            <asp:ListItem Value="14">�Ÿq��</asp:ListItem>
                                            <asp:ListItem Value="15">���L��</asp:ListItem>
                                            <asp:ListItem Value="16">�O�n��</asp:ListItem>
                                            <asp:ListItem Value="17">�O�n��</asp:ListItem>
                                            <asp:ListItem Value="18">������</asp:ListItem>
                                            <asp:ListItem Value="19">�n���Ѯq</asp:ListItem>
                                            <asp:ListItem Value="20">������</asp:ListItem>
                                            <asp:ListItem Value="21">���</asp:ListItem>
                                            <asp:ListItem Value="22">�̪F��</asp:ListItem>
                                            <asp:ListItem Value="23">�O�F��</asp:ListItem>
                                            <asp:ListItem Value="24">�Ὤ��</asp:ListItem>
                                            <asp:ListItem Value="25">������</asp:ListItem>
                                            <asp:ListItem Value="26">�s����</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="zipList" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="Address" runat="server" Columns="34" MaxLength="150"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="Address"
                                            ErrorMessage="�������Ѧa�}�C" ToolTip="�������Ѧa�}�C" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                    </span>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">��</span> �|���m�W</td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <asp:TextBox ID="Name" runat="server" Columns="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name"
                                        ErrorMessage="�������ѷ|���m�W�C" ToolTip="�������ѷ|���m�W�C" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    <span class="style1">��</span> �s���q��</td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <asp:TextBox ID="Tel" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TelRequired" runat="server" ControlToValidate="Tel"
                                        ErrorMessage="�������ѳs���q�ܡC" ToolTip="�������ѳs���q�ܡC" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9">
                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">��</span> �ǯu</td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <asp:TextBox ID="Fax" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="FaxRequired" runat="server" ControlToValidate="Fax"
                                        ErrorMessage="�������ѷ|���m�W�C" ToolTip="�������ѷ|���m�W�C" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                    <span class="style1">��</span> �q�l�H�c
                                </td>
                                <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="�������ѹq�l�l��C" ToolTip="�������ѹq�l�l��C" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="Email"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server"
                                        ErrorMessage="�q�l�l��榡�����T�C" ToolTip="�q�l�l��榡�����T�C" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr bgcolor="#E4F1E9" height="37">
                                <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                    <span class="style1">��</span> ����ݩ�
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                    <label>
                                        <asp:DropDownList ID="Kind" runat="server">
                                            <asp:ListItem Value="">�п��...</asp:ListItem>
                                            <asp:ListItem Value="A">������B(�M)�z���c</asp:ListItem>
                                            <asp:ListItem Value="B">�\�i�A�Q�ξ��c</asp:ListItem>
                                            <asp:ListItem Value="C">���i�A�Q�ξ��c</asp:ListItem>
                                            <asp:ListItem Value="D">���^���o�󪫳B�z���c</asp:ListItem>
                                            <asp:ListItem Value="E">��L</asp:ListItem>
                                        </asp:DropDownList>
                                    </label>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F9F4">
                                <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                    <asp:Button ID="BtnUpdate2" runat="server" Text="�T�w�ק�" OnClick="BtnUpdate2_Click"
                                        ValidationGroup="ValidationGroup3" />
                                    <asp:Button ID="BtnCancel2" runat="server" Text="��^�D�e��" OnClick="BtnCancel2_Click" />
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
                                            <img src="../image/icon/page_edit.png" alt="��g�������" width="16" height="16" align="absmiddle">
                                            <span class="form_title1">�ק�K�X&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �� ���������</span></td>
                                    </tr>
                                    <tr bgcolor="#E4F1E9" height="37">
                                        <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                            <span class="style1">��</span> �K�X:</td>
                                        <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" MaxLength="8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                ErrorMessage="�������ѱK�X�C" ToolTip="�������ѱK�X�C" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#F2F9F4">
                                        <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                            <span class="style1">��</span> �s�K�X:
                                        </td>
                                        <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" MaxLength="8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                ErrorMessage="�������ѷs�K�X�C" ToolTip="�������ѷs�K�X�C" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="NewPassword"
                                                ValidationExpression="^[0-9]{8}$" runat="server" ErrorMessage="�s�K�X�ݬ�8�X�Ʀr�C" ToolTip="�s�K�X�ݬ�8�X�Ʀr�C"
                                                SetFocusOnError="True" ValidationGroup="ChangePassword1">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#E4F1E9" height="37">
                                        <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                            <span class="style1">��</span> �T�{�s�K�X:</td>
                                        <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" MaxLength="8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                ErrorMessage="�������ѽT�{�s�K�X�C" ToolTip="�������ѽT�{�s�K�X�C" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
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
                                                Text="�T�w�ק�" ValidationGroup="ChangePassword1" />
                                            <asp:Button ID="BackBtn" runat="server" Text="��^�D�e��" OnClick="BackBtn_Click" />
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
                                            <img src="../image/icon/page_edit.png" alt="��g�������" width="16" height="16" align="absMiddle">
                                            <span class="form_title1">�ܧ�K�X����</span></td>
                                    </tr>
                                    <tr bgcolor="#e4f1e9" height="77">
                                        <td bgcolor="#ffffff" align="center">
                                            �z���K�X�w�ܧ�!
                                        </td>
                                    </tr>
                                    <tr bgcolor="#f2f9f4">
                                        <td bgcolor="#f9f2f7" class="table_title1" align="center">
                                            <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CommandName="Continue"
                                                Text="�~ ��" OnCommand="ContinuePushButton_Command" />
                                        </td>
                                    </tr>
                                </table>
                            </SuccessTemplate>
                        </asp:ChangePassword>
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
