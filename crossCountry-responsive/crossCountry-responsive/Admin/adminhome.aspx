<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="adminhome.aspx.vb" Inherits="crossCountry_responsive.adminhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1></h1>
<div class="container">
 
<div class="well dashboard">
<div class="row">
<div class="col-lg-4 col-md-4">
<asp:LinkButton ID="lnButtonClaimsToReview" class="btn btn-success" OnClick="viewClaimsToReview" runat="server">Claims to review      <span class="badge" ><asp:Label ID="lblClaimsReview" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>
</div>
<div class=" col-lg-4 col-md-4">
<asp:LinkButton ID="lnButtonOverDueInvoices" class="btn btn-success" OnClick="ClaimsToReview_Click" runat="server">Overdue Invoices      <span class="badge" ><asp:Label ID="lblOverdueInvoices" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>
</div>
<div class=" col-lg-4 col-md-4">
<asp:LinkButton ID="lnButtonCriticalClaims" class="btn btn-success" OnClick="viewCriticalClaims" runat="server">Critical Claims      <span class="badge" ><asp:Label ID="lblCriticalClaims" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>                  
</div>
</div>

<div class="row">
<div class="col-lg-4 col-md-4">
<asp:LinkButton ID="lnButtonTotalOpenClaims" class="btn btn-success" OnClick="viewOpenClaims" runat="server">Total Open Claims      <span class="badge" ><asp:Label ID="lblOpenClaims" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>
</div>
<div class=" col-lg-4 col-md-4">
<asp:LinkButton ID="lnButtonOverdueClaims" class="btn btn-success" OnClick="viewOverdueClaims" runat="server">Overdue Claims      <span class="badge" ><asp:Label ID="lblOverdueClaims" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>
</div>
<div class=" col-lg-4 col-md-4">
<asp:LinkButton ID="lnButtonClaimsThisMonth" class="btn btn-success" OnClick="viewClaimsThisMonth" runat="server">Total Claims Entered This Month      <span class="badge" ><asp:Label ID="lblClaimsThisMonth" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>             
</div>
</div>

<div class="row">
<div class="col-lg-4 col-md-4">
<asp:LinkButton ID="lnButtonUnassignedClaims" class="btn btn-success" OnClick="ClaimsToReview_Click" runat="server">Unassigned Claims      <span class="badge" ><asp:Label ID="lblUnassignedClaims" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>
</div>
<div class=" col-lg-4 col-md-4">
<asp:LinkButton ID="lnButtonClaimsToday" class="btn btn-success" OnClick="viewclaimsToday" runat="server">Total Claims Entered Today      <span class="badge" ><asp:Label ID="lblClaimsToday" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>
</div>
<div class=" col-lg-4 col-md-4">
<asp:LinkButton ID="lnButton10DaysOld" class="btn btn-success" OnClick="view10DaysOldClaims" runat="server">10 Days Old      <span class="badge" ><asp:Label ID="lbl10DaysOld" runat="server" Text="Label"></asp:Label></span></asp:LinkButton>                
</div>
</div>



      
</div>
         
</div>



    <div class="panel panel-default">
        <div class="panel-heading"><h4>
            <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label></h4></div>
    <div class="panel-body">
        <asp:GridView ID="gdupdate" runat="server" Width="100%" CssClass="table table-hover table-striped" GridLines="None"  AllowPaging="true" pagesize="50" DataKeyNames="Claim ID" ShowHeaderWhenEmpty="true"  
        AutoGenerateColumns="false" AllowSorting="true" OnSorting="sortRecords" EmptyDataText="There are no claims to display"> 
        <Columns>
             <asp:BoundField DataField="Claim ID" HeaderText="Claim ID" ReadOnly="True" SortExpression="Claim ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" /> 
               <asp:hyperlinkField DataTextField="Claim #" HeaderText="Claim #" DataNavigateUrlFields="Claim ID" DataNavigateUrlFormatString="/Admin/claimDetail.aspx?claimID={0}"  SortExpression="FILE" /> 
          
            <asp:BoundField DataField="Insured Name" HeaderText="Insured" ReadOnly="True" SortExpression="Insured Name" /> 
             <asp:BoundField DataField="Carrier" HeaderText="Carrier" ReadOnly="True" SortExpression="Carrier" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"  /> 
            <asp:BoundField DataField="Claim Contact" HeaderText="Claim Contact" ReadOnly="True" SortExpression="Claim Contact" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" /> 
            <asp:BoundField DataField="Loss Type" HeaderText="Loss Type" ReadOnly="True" SortExpression="Loss Type" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"  /> 
            <asp:BoundField DataField="Adjuster" HeaderText="Adjuster" ReadOnly="True" SortExpression="Adjuster" HeaderStyle-CssClass="visible-md visible-lg" ItemStyle-CssClass="visible-md visible-lg" /> 
            <asp:BoundField DataField="Received Date" HeaderText="Received Date" ReadOnly="True" SortExpression="Received Date"  /> 
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"  /> 

        </Columns>



    </asp:GridView>
        </div>
  </div>

    

</asp:Content>
