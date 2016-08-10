<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="carrierList.aspx.vb" Inherits="crossCountry_responsive.carrierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">

        <div class="panel-body">
            <asp:GridView ID="gdFiles" runat="server" Width="100%" CssClass="table table-hover table-striped" GridLines="None"  
                AllowPaging="true" pagesize="50" DataKeyNames="Company ID" ShowHeaderWhenEmpty="true"  
        AutoGenerateColumns="false" AllowSorting="true" OnSorting="sortRecords" EmptyDataText="There are no companies to display"> 
        <Columns>
             <asp:BoundField DataField="Company ID" HeaderText="companyId" ReadOnly="True" SortExpression="Company ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" /> 
            <asp:hyperlinkField DataTextField="Company" HeaderText="Name" DataNavigateUrlFields="Company ID" DataNavigateUrlFormatString="/Admin/modifyCarrier.aspx?companyId={0}"  SortExpression="Name" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
               <asp:BoundField DataField="Street" HeaderText="Street" ReadOnly="True" SortExpression="Street" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md" />            
             <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" SortExpression="City" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md"/> 
            <asp:BoundField DataField="State" HeaderText="State" ReadOnly="True" SortExpression="State" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
            <asp:BoundField DataField="Zip" HeaderText="Zip" ReadOnly="True" SortExpression="Zip" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"/> 
            <asp:BoundField DataField="Telephone" HeaderText="Phone" ReadOnly="True" SortExpression="Phone" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
             
                   </Columns>

    </asp:GridView>


        </div>

    </div>

</asp:Content>
