<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Manager_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="500px" border="0" align="center" cellpadding="5" cellspacing="1">
        <tr>
            <td width="100%">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div align="center" class="title2">
                    待審核會員人數：
                    <asp:Label ID="CntView" runat="server" ForeColor="red">
                    </asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <table width="500" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#666666"
        class="mtable">
        <tr height="27">
            <td colspan="2" bgcolor="#d2aaa2">
                <div align="center" class="qLink_font">
                    <asp:LinkButton ID="LogoutBtn" runat="server" OnClick="LogoutBtn_Click">登出系統</asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td width="50%" bgcolor="#f1e4ec" class="qLink_font">
                1．<a href="MgrProfile.aspx">基本資料維護</a></td>
            <td width="50%" bgcolor="#f1e4ec" class="qLink_font">
                2．<a href="MgrPassword.aspx">密碼變更</a></td>
        </tr>
        <tr height="27">
            <td colspan="2" bgcolor="#d2aaa2">
                <div align="center">
                    管理員功能</div>
            </td>
        </tr>
        <tr>
            <td width="50%" bgcolor="#f1e4ec" class="qLink_font">
                1．<a href="MemberList.aspx">會員資料維護</a></td>
            <td width="50%" bgcolor="#f1e4ec" class="qLink_font">
                4．<a href="MatchList.aspx">研發合作對象名單</a></td>
        </tr>
        <tr>
            <td bgcolor="#f9f2f7" class="qLink_font">
                2．<a href="ApproveList.aspx">審核會員申請資料</a></td>
            <td bgcolor="#f9f2f7" class="qLink_font">
                5．<a href="TechList.aspx">再生技術管理</a></td>
        </tr>
        <tr>
            <td bgcolor="#f1e4ec" class="qLink_font">
                3．<a href="News.aspx">最新消息更新</a></td>
            <td bgcolor="#f1e4ec" class="qLink_font">
                6．<a href="Case.aspx">案例介紹管理</a></td>
        </tr>
    </table>
</asp:Content>
