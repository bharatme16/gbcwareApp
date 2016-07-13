<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="assignClaim.aspx.vb" Inherits="crossCountry_responsive.assignClaim" %>

<%@ Register Assembly="Artem.Google" Namespace="Artem.Google.UI" TagPrefix="artem" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
<h1>ASSIGN CLAIMS</h1>
<div class="panel-group" id="accordion">
<div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a data-toggle="collapse" data-parent="#accordion" href="#stateFilter">Filter By Claim / And Or State</a>
</h4>
</div>
<div id="stateFilter" class="panel-collapse collapse in">
<div class="panel-body">
<asp:UpdatePanel runat="server" ID="UpdatePanel3">
<ContentTemplate>


<div class="form-horizontal form-label-left">

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">Choose Claim: </label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlChooseClaim" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
    
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12" >Choose State: </label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlState" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
</div>
</div>

<div class="ln_solid"></div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnFilterByClaimState" runat="server" CausesValidation="False"  Text="Filter"  CssClass="btn btn-default" />

</div>
</div>

        
</div>
</ContentTemplate>
</asp:UpdatePanel>

</div>
</div>
</div>
<div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a data-toggle="collapse" data-parent="#accordion" href="#adjusterFilter">Filter Map By Adjuster</a>
</h4>
</div>
<div id="adjusterFilter" class="panel-collapse collapse">
<div class="panel-body">
<asp:UpdatePanel runat="server" ID="UpdatePanel4">
<ContentTemplate>
<div class="form-horizontal form-label-left">
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12" >Choose Adjuster: </label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlChooseAdjuster" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
</div>
</div>

<div class="ln_solid"></div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnFilterByAdjuster" runat="server" CausesValidation="False"  Text="Filter"  CssClass="btn btn-default" />

</div>
</div>

        
</div>
</ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</div>
<div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a data-toggle="collapse" data-parent="#accordion" href="#claimRepFilter">Filter Map By Claim Rep</a>
</h4>
</div>
<div id="claimRepFilter" class="panel-collapse collapse">
<div class="panel-body">
<asp:UpdatePanel runat="server" ID="UpdatePanel2">
<ContentTemplate>
<div class="form-horizontal form-label-left">
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12" >Choose Claim Rep: </label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlChooseClaimRep" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
</div>
</div>

<div class="ln_solid"></div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnFilterByClaimRep" runat="server" CausesValidation="False"  Text="Filter"  CssClass="btn btn-default" />
</div>
</div>

        
</div>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a data-toggle="collapse" data-parent="#accordion" href="#carrierFilter">Filter Map By Carrier</a>
</h4>
</div>
<div id="carrierFilter" class="panel-collapse collapse">
<div class="panel-body">
<asp:UpdatePanel runat="server" ID="UpdatePanel5">
<ContentTemplate>
<div class="form-horizontal form-label-left">
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12" >Choose Carrier: </label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlChooseCarrier" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
</div>
</div>

<div class="ln_solid"></div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnFilterByCarrier" runat="server" CausesValidation="False"  Text="Filter"  CssClass="btn btn-default" />
</div>
</div>

        
</div>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</div>


<div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a data-toggle="collapse" data-parent="#accordion" href="#lossTypeFilter">Filter Map By Loss Type</a>
</h4>
</div>
<div id="lossTypeFilter" class="panel-collapse collapse">
<div class="panel-body">
<asp:UpdatePanel runat="server" ID="UpdatePanel6">
<ContentTemplate>
<div class="form-horizontal form-label-left">
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12" >Choose Loss Type: </label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlChooseLossType" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
</div>
</div>

<div class="ln_solid"></div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnFilterByLossType" runat="server" CausesValidation="False"  Text="Filter"  CssClass="btn btn-default" />


</div>
</div>

        
</div>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a data-toggle="collapse" data-parent="#accordion" href="#searchClaims">Search Claims</a>
</h4>
</div>
<div id="searchClaims" class="panel-collapse collapse">
<div class="panel-body">
<asp:UpdatePanel runat="server" ID="UpdatePanel7">
<ContentTemplate>
<div class="form-horizontal form-label-left">
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12" >Search: </label>
<div class="col-md-6 col-sm-6 col-xs-12">
 <asp:TextBox ID="txtSearchClaims" runat="server"  class="form-control col-md-7 col-xs-12"></asp:TextBox>
</div>
</div>

<div class="ln_solid"></div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnSearchClaims" runat="server" CausesValidation="False"  Text="Search"  CssClass="btn btn-default" />
</div>
</div>

        
</div>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</div>

</div>










<asp:UpdatePanel runat="server" ID="updtFilter">
<ContentTemplate>



</ContentTemplate>
</asp:UpdatePanel>
<asp:panel runat="server" 
            
            
style="float:left; padding-top:10px; padding-bottom:30px; text-align:left;" 
Height="100px" >

</asp:panel>        
    

 
  <div class="panel panel-default">
      
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="panel-heading">
           <h4><asp:Label ID="lblMapHeading" runat="server"></asp:Label></h4>
  <h4><asp:Label ID="lblMapInfo" runat="server" CssClass="Heading"></asp:Label></h4></td>   
      <asp:Label ID="lblClaimCount" runat="server"></asp:Label>     

    </div>
    </ContentTemplate>
</asp:UpdatePanel>

      <div class="panel-body">
<div id="map_canvas"></div>

      </div>
</div>          
  

                



<%-- <artem:GoogleMap ID="gbcmap" runat="server" Height="500px" Width="500px" Address="36608" Zoom="10">
                       
</artem:GoogleMap>
<artem:GoogleMarkers ID="claimMarker" runat="server" TargetControlID="gbcmap" >
<InfoWindowOptions PixelOffset-Height="20" PixelOffset-Width="20">
                  
</InfoWindowOptions>
<Markers>
                  
</Markers>
</artem:GoogleMarkers>--%><%-- </ContentTemplate> 
</asp:UpdatePanel>--%><%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="mapudPanel"
DisplayAfter="1">
<ProgressTemplate>
Please Wait...
</ProgressTemplate>
</asp:UpdateProgress>--%>
          
             
  


<asp:UpdatePanel ID="gdPanel" runat="server">

<ContentTemplate>
        
<div class="panel panel-default">
<div class="panel-heading">
<h4>Claim(s) List</h4>
</div>

<div class="panel-body">
<asp:GridView ID="gdClaimCount" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" GridLines="None">
<Columns>
<asp:TemplateField HeaderText="Assign">
<ItemTemplate>
<asp:CheckBox ID="assignCheckbox" runat="server" Enabled="true" />
</ItemTemplate>
</asp:TemplateField>
 <asp:BoundField DataField="Claim ID" HeaderText="Claim ID" />
 <asp:BoundField DataField="Claim #" HeaderText="Claim #" />
 <asp:BoundField DataField="Insured Name" HeaderText="Insured Name" />
 <asp:BoundField DataField="Address" HeaderText="Address" />
 <asp:BoundField DataField="Carrier" HeaderText="Carrier" />
     <asp:BoundField DataField="Claim Contact" HeaderText="Claim Contact" />
     <asp:BoundField DataField="Loss Type" HeaderText="Loss Type" />
     <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
     <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
     <asp:BoundField DataField="Adjuster" HeaderText="Adjuster" />
     <asp:BoundField DataField="Received Date" HeaderText="Received Date" />
     <asp:BoundField DataField="Status" HeaderText="Status" />

</Columns>                                

</asp:GridView>

<asp:AnimationExtender ID="gdClaimCount_AnimationExtender" runat="server" 
Enabled="True" TargetControlID="gdClaimCount">
<Animations>
<OnLoad>
<FadeIn Duration=".5" Fps="20" />
</OnLoad>                        
</Animations>
</asp:AnimationExtender>


</div>


</div> 
    

<div class="panel panel-default">
<div class="panel-heading">
<h4>Assign/ Reassign</h4>

<div class="panel-body">

<div class="form-horizontal form-label-left">
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12" >Select Adjuster: </label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="ddlAdjuster" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
</div>
</div>

<div class="ln_solid"></div>
<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
    <asp:LinkButton ID="btnAssign" runat="server"  CausesValidation="False" CssClass="btn btn-default">Assign / Unassign <i class="fa fa-user" aria-hidden="true"></i></asp:LinkButton>

</div>
</div>

        
</div>

</div>
<asp:Label ID="lblSelectAdjusterInfo" runat="server" ForeColor="Black"></asp:Label>
<asp:Label ID="lblSelectAdjuster" runat="server" ForeColor="Red"></asp:Label>
  
</div>


</div>



</updatepanel>

                        
<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="gdpanel"
DisplayAfter="1">
<ProgressTemplate>
<asp:Image ID="imgWaitIcon1" runat="server" 
ImageAlign="AbsMiddle" ImageUrl="~/Resources/loading.gif" />
<br />
<span class="style52">&nbsp; Please Wait... </span>
</ProgressTemplate>
</asp:UpdateProgress>
</ContentTemplate> 
</asp:UpdatePanel> 

</div>
   
</asp:Content>
