    <%@ Page Language="C#" MasterPageFile="~/Site1.Master" 
        AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentationLayer.Login" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 
            <table style="font-size:16px;padding-top:200px;padding-bottom:200px;padding-left:500px;padding-right:500px;background-color:white;">
                <tr>
                    <td colspan="2" style="background-color:darkcyan;color:white;padding:5px;">
                        <asp:Label ID="Label1" runat="server" Text="Вход в кабинет: "></asp:Label>
                    </td>  
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Логин"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbLogin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Пароль"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:right">
                        <asp:Button ID="btnLogin" runat="server" Height="34" Width="60" Text="Войти"  OnClick="btnLogin_Click" />
                    </td>
                </tr>
        </table>
    </asp:Content>