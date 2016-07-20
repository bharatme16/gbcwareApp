<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="billingList.aspx.vb" Inherits="crossCountry_responsive.billingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div class="panel panel-default">

        <div class="panel-body">
            <asp:GridView ID="gdFiles" runat="server" Width="100%" CssClass="table table-hover table-striped" GridLines="None"  
                AllowPaging="true" pagesize="50" DataKeyNames="Invoice Type ID" ShowHeaderWhenEmpty="true"  
        AutoGenerateColumns="false" AllowSorting="true" OnSorting="sortRecords" EmptyDataText="There are no billings to display"> 
        <Columns>
            <asp:BoundField DataField="Invoice Type ID" HeaderText="Invoice Type ID" ReadOnly="True" SortExpression="Invoice Type ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" /> 
            <asp:hyperlinkField DataTextField="Invoice Type" HeaderText="Invoice Type" DataNavigateUrlFields="Invoice Type ID" DataNavigateUrlFormatString="/Admin/modifyInvoice.aspx?invoiceId={0}"  SortExpression="Invoice Type" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
               <asp:BoundField DataField="Company" HeaderText="Company" ReadOnly="True" SortExpression="Company" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md" /> 
            <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" SortExpression="Description" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md"/>            
             <asp:BoundField DataField="Fee" HeaderText="Fee" ReadOnly="True" SortExpression="Fee" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
          
        </Columns>

    </asp:GridView>


        </div>

    </div>












</asp:Content>
