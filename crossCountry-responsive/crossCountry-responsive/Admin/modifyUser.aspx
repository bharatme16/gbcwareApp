<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="modifyUser.aspx.vb" Inherits="crossCountry_responsive.modifyUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate> 
<div class="row">
<div class="form-horizontal form-label-left">
       

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Current Role :
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
   
<asp:Label ID="lblCurrentRole" runat="server" CssClass="form-control-noborder pull-left col-md-7 col-xs-12"></asp:Label>
    
   <%-- <asp:Button ID="btnChangeRole" runat="server" Text="< >" class="btn btn-default" OnClick="btnChangeRole_Click" data-toggle="collapse" data-target="#demo" UseSubmitBehavior="False" />--%>
    <button type="button" class="btn btn-default" data-toggle="collapse" data-target="#demo"><span class="fa fa-retweet"></span></button>
</div>
</div>

<div id="demo" class="collapse">

<div class="panel panel-default">

<div class="panel-heading">
<h5>Select Role</h5>

</div>

<div class="panel-body">

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
 Role :
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlSelectRole" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList></div>
</div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3 ">
<asp:Button ID="btnChange" runat="server" CausesValidation="False" onclick="btnChange_Click" Text="Change"  CssClass="btn btn-default" UseSubmitBehavior="False" />
<asp:Button ID="btnCancel" runat="server" CausesValidation="False"  Text="Cancel"  CssClass="btn btn-default" />

</div>
</div>

</div>


</div> 


</div>


<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Status :
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:Label ID="lblUserStatus" runat="server" CssClass="form-control-noborder pull-left col-md-7 col-xs-12"></asp:Label>

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


<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Adjuster Status :
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:Label ID="lblAdjusterStatus" runat="server" CssClass="form-control-noborder pull-left col-md-7 col-xs-12"></asp:Label>
</div>
</div>


</div>



</div>


<div class="ln_solid"></div>
    <div class="form-group">
        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3 ">
            <asp:Button ID="btnLockUnlockUser" CssClass="btn btn-default" OnClick="btnLockUnlockUser_Click"   runat="server" UseSubmitBehavior="False"></asp:Button>
             <asp:Button ID="btnSaveuser" CssClass="btn btn-default"  Text="Save User"  runat="server"></asp:Button>
             <asp:Button ID="btnEnableDisable" CssClass="btn btn-default"  Text="Disable User"  runat="server"></asp:Button>
             <asp:Button ID="btnDeleteUser" CssClass="btn btn-danger"  Text="Delete"  runat="server"></asp:Button>
              <asp:Button ID="btnEmailPassword" CssClass="btn btn-default"  Text="Email Password"  runat="server"></asp:Button>

        </div>
    </div>
         </ContentTemplate>  
</asp:UpdatePanel>
</div>


</asp:Content>
