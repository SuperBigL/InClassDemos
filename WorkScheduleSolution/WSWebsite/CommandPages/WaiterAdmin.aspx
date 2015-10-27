<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="CommandPages_WaiterAdmin" MasterPageFile="~/Site.master" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>







<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Waiter Admin</h1>
    <p>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Waiters_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    </p>





    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />



    Select Waiter to Update:
    <asp:DropDownList ID="WaiterList" runat="server" AppendDataBoundItems="True" DataSourceID="ObjectDataSource1" Height="42px" DataTextField="FullName" DataValueField="WaiterID">
    </asp:DropDownList>
    <asp:List Value ="0"></asp:List>
    <asp:LinkButton ID="FetchWaiter" runat="server" OnClick="FetchWaiter_Click">Fetch a Waiter</asp:LinkButton>
&nbsp;<table align="center" style="width: 70%">
        <tr>
            <td>ID:</td>
            <td>
                <asp:TextBox ID="WaiterID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>First Name:</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name:</td>
            <td>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Phone:</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date Hired:</td>
            <td>
                <asp:TextBox ID="DateHired" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date Relased:</td>
            <td>
                <asp:TextBox ID="Released" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="Insert" runat="server" OnClick="Insert_Click">Add Waiter</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>




    




</asp:Content>


