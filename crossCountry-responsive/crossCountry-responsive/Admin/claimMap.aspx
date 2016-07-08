<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="claimMap.aspx.vb" Inherits="crossCountry_responsive.claimMap" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

    <div class="row">

 <div id="accordion" role="tablist" aria-multiselectable="true">
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingOne">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
           Filter Claim
        </a>
      </h4>
    </div>
    <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">

         <div class="form-horizontal form-label-left">
              <div class="form-group">
                  <label class="control-label col-md-3 col-sm-3 col-xs-12">
Filter By Claim #: <span class="required">*</span> </label>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                       <asp:DropDownList ID="ddClaim" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>

</div>
                  </div>

       <div class="form-group">
        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
           <asp:Button ID="btnFilter" runat="server" Text="Filter by Claim #" CssClass="btn btn-default" />
           <asp:Button ID="btnViewALL" runat="server"  Text="View All" CssClass="btn btn-default" />

        </div>
</div>

             </div>


  




    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingTwo">
      <h4 class="panel-title">
        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
          Route To Claim
        </a>
      </h4>
    </div>
    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
     <div class="form-horizontal form-label-left">
              <div class="form-group">
                  <label class="control-label col-md-3 col-sm-3 col-xs-12">
Starting Point: <span class="required">*</span> </label>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                       <asp:TextBox ID="startClaimText" runat="server"  class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
                  </div>


         <div class="form-group">
                  <label class="control-label col-md-3 col-sm-3 col-xs-12">
OR </label>
          </div>
<div class="form-group">
                  <label class="control-label col-md-3 col-sm-3 col-xs-12">
Select Claim : <span class="required">*</span> </label>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                       <asp:DropDownList ID="ddclaim1" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>

</div>
                  </div>

         <div class="form-group">
                  <label class="control-label col-md-3 col-sm-3 col-xs-12">
Ending Point: <span class="required">*</span> </label>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                       <asp:DropDownList ID="ddclaim2" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>

</div>
                  </div>

       <div class="form-group">
        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
           <asp:Button ID="getDirection" runat="server" Text="Get Direction" CssClass="btn btn-default" />
           
        </div>
</div>

             </div>



    </div>
  </div>
  
</div>





        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<artem:GoogleMap ID="gbcmap" runat="server" Height="500px" Width="100%" MapType="TERRAIN"  Latitude="30.6942"
Longitude="-88.0431" >
</artem:GoogleMap>

<artem:GoogleMarkers ID="claimMarker" runat="server" TargetControlID="gbcmap">
</artem:GoogleMarkers>
</ContentTemplate>
                                
</asp:UpdatePanel>
    </div>

        <asp:UpdatePanel ID="updatePanelDirection" runat="server">
<ContentTemplate>
<div ID="dirpanel">
</div>
</ContentTemplate>
</asp:UpdatePanel>
    </div>
</asp:Content>
