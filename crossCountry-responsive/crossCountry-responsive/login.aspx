<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/custom.Master" CodeBehind="login.aspx.vb" Inherits="crossCountry_responsive.login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="customContent" runat="server">
 


      <div class="center">

          <div class="container">
 
  <div class="panel panel-default">
    <div class="panel-heading text-center"> <h4>LOGIN</h4></div>
    <div class="panel-body">
  <div class="col-md-12 form-group has-feedback">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control has-feedback-left" placeholder="Username"></asp:TextBox>
                            <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="None" ErrorMessage="Username is required"></asp:RequiredFieldValidator>

                        </div>
 <div class="col-md-12 form-group has-feedback">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control has-feedback-left" placeholder="Password"></asp:TextBox>
                            <span class="fa fa-key form-control-feedback left" aria-hidden="true"></span>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Password is required"></asp:RequiredFieldValidator>

                        </div>
        
    

 <div class="col-md-12">
<asp:Button ID="btnLogin" runat="server" OnClick="btnLogIn_Click" CssClass="btn btn-default" Text="Login" />
  </div>
    </div>

  </div>
              <div>
                                <h5><i class="fa fa-files-o" style="font-size: 26px;"></i>&nbsp;GBCWARE LLC BETA 1.5</h5>

                                <p>©2016 All Rights Reserved. A claim adjustment software. Privacy and Terms</p>
                            </div>

</div>
   <asp:ValidationSummary ID="vSummary" ShowMessageBox="true" ShowSummary="false" DisplayMode="BulletList" runat="server" />

    </div>


     

</asp:Content>
