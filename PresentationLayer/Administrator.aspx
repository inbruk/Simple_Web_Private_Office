<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" 
    CodeBehind="Administrator.aspx.cs" Inherits="PresentationLayer.Administrator" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxCtlTool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <ajaxCtlTool:TabContainer ID="TabContainer1" runat="server" Width="1280px" Height="480px" ActiveTabIndex="0">
        <ajaxCtlTool:TabPanel ID="tpProfile" runat="server" HeaderText="Профиль" ForeColor="DarkCyan">
            <ContentTemplate>
                
                <table style="font-size:20px;background-color:white;margin-top:100px;">
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
        <ajaxCtlTool:TabPanel ID="tpUsersList" runat="server" HeaderText="Список пользователей" ForeColor="DarkCyan">
            <ContentTemplate>
                <asp:GridView ID="gvUsersList" runat="server" OnRowEditing="gvUsersList_RowEditing"
                    AutoGenerateColumns="False" BackColor="White"  Width="1260px" Height="480px"
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"                     
                >
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" /> 
                    <Columns> 
                        <asp:CommandField  ShowEditButton="True" /> 
                        <asp:BoundField DataField="Id" Visible="false"  /> 
                        <asp:BoundField DataField="FullName" HeaderText="ФИО" ReadOnly="True" /> 
                        <asp:BoundField DataField="Login" HeaderText="Логин" ReadOnly="True" /> 
                        <asp:BoundField DataField="TypeName" HeaderText="Тип" ReadOnly="True" /> 
                        <asp:BoundField DataField="Blocked" HeaderText="Блокировка" ReadOnly="True" /> 
                        <asp:BoundField DataField="MobilePhone" HeaderText="Моб. телефон" ReadOnly="True" /> 
                        <asp:BoundField DataField="AccountPersonalAccount" HeaderText="Личный счет" ReadOnly="True" /> 
                        <asp:BoundField DataField="AccountBalance" HeaderText="Баланс" ReadOnly="True" /> 
                        <asp:BoundField DataField="AccountRecommendedPayment" HeaderText="Рекомендуемый платеж" ReadOnly="True" /> 
                        <asp:BoundField DataField="AccountCredit" HeaderText="Кредит" ReadOnly="True" /> 
                    </Columns> 
                </asp:GridView>
            </ContentTemplate>
        </ajaxCtlTool:TabPanel>
    </ajaxCtlTool:TabContainer>

</asp:Content>
    