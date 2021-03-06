﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="modifyCarrier.aspx.vb" Inherits="crossCountry_responsive.modifyCarrier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate> 
<div class="container">
  
    

<div class="row">
<div class="form-horizontal form-label-left">

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Carrier Name:<span class="required">*</span>   
</label>
    <div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtCarrierName" runat="server" required="true"  class="form-control col-md-7 col-xs-12"></asp:TextBox>
        </div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Street: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtCarrierStreet" runat="server" required="true"  class="form-control col-md-7 col-xs-12"></asp:TextBox>
</div>
</div>

  
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
City: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">    
 <asp:TextBox ID="txtCity" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:TextBox>          
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
State: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">     
<asp:DropDownList ID="ddlState" runat="server" required="true" class="form-control col-md-7 col-xs-12"></asp:DropDownList>
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Zip: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">    
 <asp:TextBox ID="txtZip" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:TextBox>          
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Primary Phone: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">    
<asp:TextBox ID="txtPrimaryPhone" runat="server" placeholder="(xxx)-(xxx)-(xxxx)" class="form-control col-md-7 col-xs-12" required="true"></asp:TextBox>          
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Primary Email: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">    
<asp:TextBox ID="txtPrimaryEmail" runat="server" data-parsley-type="email" data-parsley-required-message="Email is required" placeholder="email@provider.com" class="form-control col-md-7 col-xs-12" required="true"></asp:TextBox>          
</div>
</div>

<div class="form-group">
<asp:Label ID="lblConfirmation" runat="server" Text="Label" class="form-control-no border col-md-7 col-xs-12"></asp:Label>
</div>

<div class="ln_solid"></div>
    <div class="form-group">
        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3 ">
            <asp:Button ID="btnSaveContact" CssClass="btn btn-default" Text="Save Carrier" OnClick="btnSaveContact_Click"   runat="server" UseSubmitBehavior="False"></asp:Button>
            <asp:Button ID="btnDeleteContact" CssClass="btn btn-default"  Text="Delect Carrier"  OnClick="btnDeleteContact_Click"   runat="server" UseSubmitBehavior="False"></asp:Button>
            <asp:Button ID="btnYes" CssClass="btn btn-default"  Text="Yes"  OnClick="btnYes_Click"   runat="server" UseSubmitBehavior="False"></asp:Button>
            <asp:Button ID="btnNo" CssClass="btn btn-default"  Text="No"  OnClick="btnNo_Click"   runat="server" UseSubmitBehavior="False"></asp:Button>
        </div>
    </div>

</div>

</div>

</div >


 </div>
</ContentTemplate> 

</asp:UpdatePanel>
</asp:Content>
