<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="newUser.aspx.vb" Inherits="crossCountry_responsive.newUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate> 
<div class="row">
<div class="form-horizontal form-label-left">
       

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Role :
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlRollList" runat="server"  class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
First Name: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtFirstName" runat="server" required="true"  class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

  
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Last Name: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtLastName" runat="server" required="true" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

    
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Street: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtStreet" runat="server" required="true" TextMode="MultiLine" Rows="2" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
City : <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtCity" runat="server" required="true" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>


<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
State <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlstate" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Zip Code: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtZipCode" runat="server" required="true" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Primary Telephone
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtPrimaryTelephone" runat="server"  placeholder="(xxx)-(xxx)-(xxxx)" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Secondary Telephone
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtSecondaryTelephone" runat="server"  placeholder="(xxx)-(xxx)-(xxxx)" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>



<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Email <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtEmail" runat="server" required="true" data-parsley-type="email" data-parsley-required-message="Email is required" placeholder="email@provider.com" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>


<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Title : <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtTitle" runat="server" required="true" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Symbility ID : <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
                
<asp:TextBox ID="txtSymbilityId" runat="server" required="true" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

</div>



</div>


<div class="ln_solid"></div>
    <div class="form-group">
        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3 ">
             <asp:Button ID="btnSaveuser" CssClass="btn btn-default" OnClick="btnSaveuser_Click" Text="Save User"  runat="server"></asp:Button>
            
        </div>
    </div>
         </ContentTemplate>  
</asp:UpdatePanel>
</div>


</asp:Content>
