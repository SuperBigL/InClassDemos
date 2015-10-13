<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReservationByDate.aspx.cs" Inherits="SamplePages_ReservationByDate" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceholderID="MainContent" runat="server">
    <h1>Reservation By Date</h1>
    <table align="right" style="width: 70%">
        <tr>
            <td colspan="2">
                <asp:TextBox ID="ReservationDataLog" runat="server" ToolTip="mm/dd/yyyy" Text="01/01/1900"></asp:TextBox> <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservation</asp:LinkButton>

            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                </td>
          
        </tr>
        <tr>
            <td colspan="2">
                <div class="row col-md-12">
                    <asp:Repeater ID="EventReservations" runat="server" DataSourceID="ODSEventReserations">
                        <ItemTemplate>
                            <h3><%# Eval("Description") %></h3>
                            <asp:Repeater ID="ReservationList" runat="server" DataSource='<%#Eval("Reservations")%>'>
                                <itemTemplate>
                                <h5>
                                    <%#Eval("CustomerName") %>
                                    <%#Eval("ContactPhone") %>
                                </h5>
                                </itemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>

                    </asp:Repeater>
                </div>


            </td>
           
        </tr>
    </table>
    




    


</asp:Content>