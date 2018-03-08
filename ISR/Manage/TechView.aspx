<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TechView.aspx.cs" Inherits="Manage_TechView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>資源化技術研發供需資訊平台</title>
    <link href="../style.css" rel="stylesheet" type="text/css">
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
        <div>
        <br />
            <div align="center">
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
            </div>
            <br />
        </div>
    </form>
</body>
</html>
