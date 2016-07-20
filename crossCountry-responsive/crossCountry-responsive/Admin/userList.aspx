<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="userList.aspx.vb" Inherits="crossCountry_responsive.userList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">

        <div class="panel-body">
            <asp:GridView ID="gdFiles" runat="server" Width="100%" CssClass="table table-hover table-striped" GridLines="None"  
                AllowPaging="true" pagesize="50" DataKeyNames="users_id" ShowHeaderWhenEmpty="true"  
        AutoGenerateColumns="false" AllowSorting="true" OnSorting="sortRecords" EmptyDataText="There are no users to display"> 
        <Columns>
             <asp:BoundField DataField="users_id" HeaderText="userId" ReadOnly="True" SortExpression="users_id" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" /> 
            <asp:hyperlinkField DataTextField="Name" HeaderText="Name" DataNavigateUrlFields="users_id" DataNavigateUrlFormatString="/Admin/userDetail.aspx?userId={0}"  SortExpression="Name" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
               <asp:BoundField DataField="Street" HeaderText="Street" ReadOnly="True" SortExpression="Street" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md" />            
             <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" SortExpression="City" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md"/> 
            <asp:BoundField DataField="State" HeaderText="State" ReadOnly="True" SortExpression="State" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
            <asp:BoundField DataField="Zip" HeaderText="Zip" ReadOnly="True" SortExpression="Zip" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"/> 
            <asp:BoundField DataField="Phone" HeaderText="Phone" ReadOnly="True" SortExpression="Phone" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
            <asp:BoundField DataField="Group/Role" HeaderText="Group/Role" ReadOnly="True" SortExpression="Group/Role" HeaderStyle-CssClass="visible-lg visible-md visible-sm" ItemStyle-CssClass="visible-lg visible-md visible-sm"/> 
            <asp:BoundField DataField="Password" HeaderText="Password" ReadOnly="True" SortExpression="Password" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg visible-md"/> 
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" HeaderStyle-CssClass="visible-lg visible-md visible-sm" ItemStyle-CssClass="visible-lg visible-md visible-sm" /> 
            <asp:BoundField DataField="Adjuster Status" HeaderText="Adjuster Status" ReadOnly="True" SortExpression="Adjuster Status" HeaderStyle-CssClass="visible-lg visible-md visible-sm" ItemStyle-CssClass="visible-lg visible-md visible-sm"/> 
                   </Columns>



    </asp:GridView>


        </div>

    </div>

</asp:Content>
