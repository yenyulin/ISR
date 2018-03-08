<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="Controls_master_menu" %>
<asp:LoginView ID="LoginViewMenu" runat="server">
    <AnonymousTemplate>
        <table cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <asp:HyperLink ID="HeadLink0" runat="server" NavigateUrl="~/register.aspx">會員註冊</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/login.aspx">會員登入</asp:HyperLink>
                </td>
            </tr>
        </table>
    </AnonymousTemplate>
    <LoggedInTemplate>
    </LoggedInTemplate>
    <RoleGroups>
        <asp:RoleGroup Roles="user">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <% ProfileCommon p = Profile.GetProfile(Page.User.Identity.Name);
                                           if (p.UserProfile.Type.Equals("1"))
                                           {%>
                                        學研機構：
                                        <%}
                                          else
                                          { %>
                                        業者廠商：
                                        <%}  %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%=p.UserProfile.Name%>
                                        &nbsp;您好
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <% if (p.UserProfile.Type.Equals("1"))
                               {%>
                            <asp:HyperLink ID="ProfileLink1" runat="server" NavigateUrl="~/User/Profile1.aspx">會員資料</asp:HyperLink>
                            <%}
                              else
                              { %>
                            <asp:HyperLink ID="ProfileLink2" runat="server" NavigateUrl="~/User/Profile2.aspx">會員資料</asp:HyperLink>
                            <%}  %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="SupportLink" runat="server" NavigateUrl="~/User/MatchList.aspx">供需資訊</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="ParnetLink" runat="server" NavigateUrl="~/login.aspx">研發合作對象</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:RoleGroup>
        <asp:RoleGroup Roles="admin">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        管理員：
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <% ProfileCommon p = Profile.GetProfile(Page.User.Identity.Name);%>
                                        <%=p.UserProfile.Name%>
                                        &nbsp;您好
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Manager/MemberList.aspx">會員資料維護</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Manager/ApproveList.aspx">審核會員申請資料</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Manager/Marquee.aspx">跑馬燈管理程式</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Manager/MatchList.aspx">研發合作對象名單</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/login.aspx">再生技術管理</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Manager/Case.aspx">案例介紹管理</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:RoleGroup>
    </RoleGroups>
</asp:LoginView>
