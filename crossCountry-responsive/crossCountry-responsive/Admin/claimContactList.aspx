<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="claimContactList.aspx.vb" Inherits="crossCountry_responsive.claimContactList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">

        <div class="panel-body">
            <asp:GridView ID="gdFiles" runat="server" Width="100%" CssClass="table table-hover table-striped" GridLines="None"  
                AllowPaging="true" pagesize="50" DataKeyNames="Rep ID" ShowHeaderWhenEmpty="true"  
        AutoGenerateColumns="false" AllowSorting="true" OnSorting="sortRecords" EmptyDataText="There are no companies to display"> 
        <Columns>
             <asp:BoundField DataField="Rep ID" HeaderText="repId" ReadOnly="True" SortExpression="Rep ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" /> 
            <asp:hyperlinkField DataTextField="Contact Name" HeaderText="Name" DataNavigateUrlFields="Rep ID" DataNavigateUrlFormatString="/Admin/modifyClaimContact.aspx?userId={0}"  SortExpression="Name" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
               <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Street" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md" />            
             <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" SortExpression="City" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md"/> 
            <asp:BoundField DataField="State" HeaderText="State" ReadOnly="True" SortExpression="State" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
            <asp:BoundField DataField="Zip" HeaderText="Zip" ReadOnly="True" SortExpression="Zip" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"/> 
            <asp:BoundField DataField="Telephone" HeaderText="Phone" ReadOnly="True" SortExpression="Phone" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
             
                   </Columns>

    </asp:GridView>


        </div>

    </div>

</asp:Content>
