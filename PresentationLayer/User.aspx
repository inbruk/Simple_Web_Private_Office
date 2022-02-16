<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" 
    CodeBehind="User.aspx.cs" Inherits="PresentationLayer.User" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxCtlTool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <ajaxCtlTool:TabContainer ID="TabContainer1" runat="server" Width="1280px" Height="480px" ActiveTabIndex="0">
        <ajaxCtlTool:TabPanel ID="tpProfile" runat="server" HeaderText="Профиль" ForeColor="DarkCyan">
            <ContentTemplate>
                
                <div style="font-size:20px;background-color:white;margin-top:30px;padding-left:100px">
                    <asp:Button ID="btnGotoAdministrator" runat="server" Text="Вернуться на страницу администратора" 
                        Width="400px" OnClick="btnGotoAdministrator_Click"/>
                </div>
                <table style="font-size:20px;background-color:white;margin-top:40px;">
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label2" runat="server" Text="ФИО"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbFullName" TextMode="SingleLine" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label6" runat="server" Text="Адрес"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbAddress" TextMode="SingleLine" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label3" runat="server" Text="Номер паспорта"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbPassportNumber" TextMode="SingleLine"  runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label7" runat="server" Text="Домашний телефон"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbHomePhone" TextMode="Number" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label1" runat="server" Text="Логин"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbLogin" TextMode="SingleLine" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label8" runat="server" Text="Рабочий телефон"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbWorkPhone" TextMode="Number" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label4" runat="server" Text="Пароль"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbPassword" TextMode="SingleLine" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label9" runat="server" Text="Мобильный телефон"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbMobilePhone" TextMode="Number" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:CheckBox ID="cbxBlocked" runat="server" Enabled="false" />
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:Label ID="Label13" runat="server" Text="Заблокирован"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label10" runat="server" Text="Веб страница"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbWebPage" TextMode="Url" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label5" runat="server" Text="Время создания"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbCreationDate" TextMode="DateTime" Enabled="false" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label11" runat="server" Text="ICQ"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbICQ" TextMode="Number" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label12" runat="server" Text="Электронная почта"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbEmail" TextMode="Email" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center; vertical-align:bottom; height:60px;">
                            <asp:Button ID="btnProfileSave" runat="server" Text="Сохранить изменения" 
                                Height="30px" OnClick="btnProfileSave_Click" />
                        </td>
                        <td colspan="2" style="text-align:center; vertical-align:bottom; height:60px;">
                            <asp:Button ID="btnProfileCancel" runat="server" Text="Восстановить значения" 
                                Height="30px" OnClick="btnProfileCancel_Click" />
                        </td>
                    </tr>
               </table>
                
            </ContentTemplate>
        </ajaxCtlTool:TabPanel>
        <ajaxCtlTool:TabPanel ID="tpPersonalAccount" runat="server" HeaderText="Личный счет" ForeColor="DarkCyan">
            <ContentTemplate>

                <table style="font-size:20px;background-color:white;margin-top:100px;">
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label14" runat="server" Text="Личный счет"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbPersonalAccount" TextMode="Number" runat="server" 
                                Enabled="false" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                        </td>
                        <td style="width:315px;text-align:left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label16" runat="server" Text="Баланс"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbBalance" TextMode="Number"  runat="server" 
                                Enabled="false" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                        </td>
                        <td style="width:315px;text-align:left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label18" runat="server" Text="Рекомендованый платеж"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbRecommendedPayment" TextMode="Number" runat="server" 
                                Enabled="false" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                        </td>
                        <td style="width:315px;text-align:left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width:315px;text-align:right">
                            <asp:Label ID="Label20" runat="server" Text="Кредит"></asp:Label>
                        </td>
                        <td style="width:315px;text-align:left">
                            <asp:TextBox ID="txbCredit" TextMode="Number" runat="server" 
                                Enabled="false" Width="300px"></asp:TextBox>
                        </td>
                        <td style="width:315px;text-align:right">
                        </td>
                        <td style="width:315px;text-align:left">

                        </td>
                    </tr> 
               </table>

            </ContentTemplate>
        </ajaxCtlTool:TabPanel>

    </ajaxCtlTool:TabContainer>

</asp:Content>
