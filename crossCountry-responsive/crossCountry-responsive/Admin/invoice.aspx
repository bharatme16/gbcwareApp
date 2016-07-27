<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="invoice.aspx.vb" Inherits="crossCountry_responsive.invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
<div class="row">
<div class="col-md-6">    

<div class="panel panel-default">
<div class="panel-heading">
<h4>Invoice Info</h4></div>
<div class="panel-body">
<div class="row">

<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Invoice #: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblInvoiceNumber" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Invoice Date: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblInvoiceDate" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
    </div>



</div>

    </div>

<div class="panel panel-default">
<div class="panel-heading">
<h4>Carrier Info</h4>
</div>
<div class="panel-body">
        <div class="row">

<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Name: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblCarrierName" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Invoice Type: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblInvoiceType" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Street Address: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblCarrierStreetAddress" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">

</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblCarrierCityStateZip" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Telephone: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblCarrierPhone" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Attention: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblAttention" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>


    </div>
    </div>
<div class="panel-footer">

<button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Change Invoice Type  <span class="fa fa-refresh fa-lg"></span></button>


</div>  

</div>
<div id="demo" class="collapse">

<div class="panel panel-default">

<div class="panel-heading">
<h5>Choose New Invoice Type</h5>

</div>

<div class="panel-body">
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">Select Invoice Type: </label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:DropDownList ID="ddlInvoiceType" runat="server" class="form-control" ></asp:DropDownList>
    
</div>
</div>

<div class="form-group">
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Button ID="btnChange" runat="server" CausesValidation="False"  Text="Change"  CssClass="btn btn-default" />
<asp:Button ID="btnCancel" runat="server" CausesValidation="False"  Text="Cancel"  CssClass="btn btn-default" />

</div>
</div>

</div>


</div> 



  </div>
</div>


<div class="col-md-6">
<div class="panel panel-default">
<div class="panel-heading">
<h4>Claim Info</h4></div>
<div class="panel-body">
<div class="row">
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Insured Name: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblInsuredName" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Policy#: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblPolicyNumber" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Claim #: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblClaimNumber" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Adjuster: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblAdjuster" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Loss Date: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblLossDate" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Loss Unit: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblLossUnit" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
<div class="form-group">
<label class="control-label col-lg-3 col-md-3 col-sm-12 col-xs-12">
Loss Type: 
</label>
<div class="col-lg-9 col-md-9 col-sm-6 col-xs-12 pull-left">
<asp:Label ID="lblLossType" runat="server" CssClass="form-control-noborder pull-left"></asp:Label>
</div>
</div>
</div>
</div>
 </div>
</div>

</div>



<div class="row">



<asp:UpdatePanel ID="UpdtPanelBill" runat="server">
<ContentTemplate>
<div class="panel panel-default">
<div class="panel-heading">
<h4>Add Expense(s)</h4>
</div>
<div class="panel-body">
 <div class="form-horizontal form-label-left">

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Expense Type: 
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtExpenseType" runat="server" required="required" data-parsley-error-message="Expense Type is required" class="form-control col-md-7 col-xs-12"></asp:TextBox>
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Description : 
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtDescription" runat="server" Rows ="3" required="required" data-parsley-error-message="Description is required" class="form-control col-md-7 col-xs-12" TextMode="MultiLine"></asp:TextBox>
</div>
</div>


<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Price ($): 
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtPrice" runat="server" required="required" data-parsley-error-message="Expense Type is required" class="form-control col-md-7 col-xs-12"></asp:TextBox>
</div>
</div>
</div>

  
    <div class="ln_solid"></div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnAddExpense" Text="Add Expense" OnClick="btnAddExpense_Click" CssClass="btn btn-default" runat="server"></asp:Button>
          
</div>
</div>

</div>
</div>


<div class="panel panel-default">
<div class="panel-heading">
    <h4>Billable Items</h4>
</div>

<div class="panel-body">
<asp:GridView ID="gridViewInvoice" runat="server"  AutoGenerateColumns="False"
GridLines="None"  ShowFooter="True" CssClass="table table-hover table-striped">
<Columns>
<asp:BoundField DataField="item" HeaderText="Item" />
<asp:BoundField DataField="Description" HeaderText="Descriptions" />
<asp:BoundField DataField="Price" HeaderText="Price" />
<asp:TemplateField AccessibleHeaderText="Delete" HeaderText="Delete">
<ItemTemplate>
<asp:LinkButton ID="imgDeleteButton" ToolTip="Delete File" runat="server" CausesValidation="false"  CommandName="Delete" 
    OnClientClick="return confirm('Are you sure you want to delete this Bill item?');"   >
    <span class="fa fa-trash-o fa-2x pull-center"></span></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
    
    
</Columns>
    
</asp:GridView>

    <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">

    </div>
    <div class="col-md-9 col-lg-9 col-sm-9 col-xs-9">
<table  Class="table  table-striped pull-left">
<tr>
<td class="text-center">Sub Total $:</td>
<td>
<asp:Label ID="lblSubTotal" runat="server" ></asp:Label>
</td>
</tr>
<tr>
<td class="text-center">Tax and Fees $:</td>
<td>
<asp:Label ID="lblTaxFees" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td class="text-center">Total Amount $:</td>
<td>
<asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
</td>
</tr>
</table>

</div>


</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
<asp:Button ID="btnCreatePDF" runat="server" CausesValidation="False" 
Text="Generate Invoice" CssClass="btn btn-default" OnClick="btnCreatePDF_Click"  UseSubmitBehavior="false" OnClientClick="this.disabled=true"  />
 </div> 
</div>

</asp:Content>
