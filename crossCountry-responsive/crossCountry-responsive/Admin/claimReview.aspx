<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="claimReview.aspx.vb" Inherits="crossCountry_responsive.claimReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Claims To Review</h4>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gdFiles" runat="server" Width="100%" CssClass="table table-hover  table-striped" GridLines="None"  
                AllowPaging="true" pagesize="50" DataKeyNames="Claim ID" ShowHeaderWhenEmpty="true"  
        AutoGenerateColumns="false" AllowSorting="true" OnSorting="sortRecords" EmptyDataText="There are no claims to display"> 
        <Columns>
             <asp:BoundField DataField="Claim ID" HeaderText="Claim ID" ReadOnly="True" SortExpression="Claim ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" /> 
                               <asp:hyperlinkField DataTextField="FILE" HeaderText="File" DataNavigateUrlFields="File Path" DataNavigateUrlFormatString="/Admin/crosscountryFiles.aspx?claimID={0}"  SortExpression="FILE" /> 
                     <asp:BoundField DataField="File Path" HeaderText="Files " ReadOnly="True" SortExpression="File Path" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"   /> 
              <asp:hyperlinkField DataTextField="Claim #" HeaderText="Claim #" DataNavigateUrlFields="Claim ID" DataNavigateUrlFormatString="/Admin/claimDetail.aspx?claimID={0}"  SortExpression="FILE" /> 
            <asp:BoundField DataField="Adjuster" HeaderText="Adjuster" ReadOnly="True" SortExpression="Adjuster" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/> 
            <asp:BoundField DataField="Date Recevied" HeaderText="Date Recevied" ReadOnly="True" SortExpression="Date Recevied" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" /> 
            <asp:BoundField DataField="Date Uploaded" HeaderText="Date Uploaded" ReadOnly="True" SortExpression="Date Uploaded" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"/> 
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" /> 
                   </Columns>



    </asp:GridView>


        </div>
      
    </div>

</asp:Content>
