<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="newCarrier.aspx.vb" Inherits="crossCountry_responsive.newCarrier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate> 
<div class="container">
  
    

<div class="row">
<div class="form-horizontal form-label-left">

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Carrier Name: <span class="required">*</span>   
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
<asp:TextBox ID="txtPrimaryEmail" runat="server" data-parsley-type="email" placeholder="email@provider.com" class="form-control col-md-7 col-xs-12" required="true"></asp:TextBox>          
</div>
</div>


<div class="ln_solid"></div>
    <div class="form-group">
        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3 ">
            <asp:Button ID="btnSaveContact" CssClass="btn btn-default" Text="Save Carrier" OnClick="btnSaveContact_Click"  runat="server"></asp:Button>
           
        </div>
    </div>

</div>

</div>

</div >


 </div>
</ContentTemplate> 

</asp:UpdatePanel>
</asp:Content>
