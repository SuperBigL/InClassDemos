<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryMenuItems.aspx.cs" Inherits="SamplePages_CategoryMenuItems"  MasterPageFile="~/Site.master"%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Category Menu Items (Repeater)</h1>
    <div class="row col-md-12">
        <asp:Repeater ID="MenuCategories" runat="server" DataSourceID="ODSCategoryMenuItems">
            <ItemTemplate>
                <h3><%# Eval("Description") %> </h3>  
                <asp:Repeater ID="MenuItems" runat="server" DataSource='<%# Eval("MenuItems") %>'>
                    <ItemTemplate>
                        <h2>
                            <%# Eval("Description") %>
                            <%# ((decimal)Eval("Price")).ToString("C") %>
                            <span class="badge" <%#Eval("Calories") %>>Calories</span>
                            <%#Eval("Comment") %>

                        </h2>
                    </ItemTemplate>

                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
    <asp:ObjectDataSource ID="ODSCategoryMenuItems" runat="server"></asp:ObjectDataSource>


</asp:Content>