<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="claimDetail.aspx.vb" Inherits="crossCountry_responsive.claimDetail" %>

<%@ Register Assembly="Artem.Google" Namespace="Artem.Google.UI" TagPrefix="artem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <script type="text/javascript">
    $(document).ready(function () {
        var tab = document.getElementById('<%= hidTAB.ClientID%>').value;
        $('#myTabs a[href="' + tab + '"]').tab('show');
    });
</script>
 
<div class="container">
    
<h4 class="lead"> <strong>Claim #: </strong> <asp:Label ID="lblClaimNumber" runat="server" Text=""></asp:Label></h4>
 <div class="btn-group btn-group-md">
     <asp:LinkButton ID="lnkButtonGenerateInv" data-toggle="tooltip" title="Generate Invoice" OnClick="btnGenerateInvoice_Click" CssClass="btn btn-default" runat="server"><span class="fa fa-file-text-o fa-2x"></span> </asp:LinkButton>
     <asp:LinkButton ID="lnkButtonCloseSend"  CssClass="btn btn-default" runat="server"><span class="fa fa-times-circle-o fa-2x fa-pull-center"></span> / <span class="fa fa-share-square-o fa-2x fa-pull-center"></span></asp:LinkButton>
     <asp:LinkButton ID="lnkButtonSendFiles" CssClass="btn btn-default" runat="server"><span class="fa fa-envelope-o fa-2x"></span></asp:LinkButton>
     <asp:LinkButton ID="lnkButtonCancelClaim" CssClass="btn btn-default" runat="server"><span class="fa fa-ban fa-2x"></span></asp:LinkButton>
     <asp:LinkButton ID="lnkReopenClaim" CssClass="btn btn-default" runat="server"><span class="fa fa-repeat fa-2x"></span></asp:LinkButton>
     <asp:LinkButton ID="lnkButtonCloseNoSend" CssClass="btn btn-danger" runat="server"><span class="fa fa-times-circle-o fa-2x"></span></asp:LinkButton>
    
  </div>
<div id="Tabs" role="tabpanel">

<ul id="myTabs" class="nav nav-tabs" role="tablist">
<li class="active"><a data-toggle="tab" href="#claim" role="tab" aria-controls="claim">Claim Info</a></li>
<li><a data-toggle="tab" href="#Files" role="tab" aria-controls="Files">Files</a></li>
<li><a data-toggle="tab" href="#Map" role="tab" aria-controls="Map">Claim Map</a></li>
</ul>
<asp:HiddenField ID="hidTAB" runat="server" Value="#Claim" />
<div class="tab-content"> 
   
<div id="claim" class="tab-pane active" role="tabpanel">
  
    <br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

<div class="row">
<div class="col-md-4">
<div class="panel panel-default">
<div class="panel-heading">
<h4>Claim Summary</h4>
</div>

<div class="panel-body">
<table class="table">
<tr>
<td>
<p><strong>Claim Status:</strong></p>
<p class="text-info"><strong><asp:Label ID="lblClaimStatus" runat="server" Text=""></asp:Label></strong></p>
</td>
</tr>
<tr>
<td>
<p><strong>Insured:</strong></p>
<p><asp:Label ID="lblInsured" runat="server" Text=""></asp:Label></p>
</td>
</tr>

<tr>
<td>
<p><strong>Loss Address:</strong></p>
<p ><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></p>
</td>
</tr>

<tr>
<td>
<p><strong>Carrier:</strong></p>
<p ><asp:Label ID="lblCarrier" runat="server" Text=""></asp:Label></p>
</td>
</tr>


<tr>
<td>
<p><strong>Claim Contact:</strong></p>
<p ><asp:Label ID="lblCarrierRep" runat="server" Text=""></asp:Label></p>
</td>
</tr>

<tr>
<td>
<p><strong>Contact Email:</strong></p>
<p><asp:Label ID="lblRepEmail" runat="server" Text=""></asp:Label></p>
</td>
</tr>

<tr>
<td>
<p><strong>Due Date:</strong></p>
<p ><asp:Label ID="lblDueDate" runat="server" Text=""></asp:Label></p>
</td>
</tr>

<tr>
<td>
<p><strong>Loss Type:</strong></p>
<p ><asp:Label ID="lblLossType" runat="server" Text=""></asp:Label></p>
</td>
</tr>

<tr>
<td>
<p><strong>Primary Phone <i class="fa fa-phone-square fa-lg"></i>: </strong></p>
<p ><asp:Label ID="lblPrimaryPhone" runat="server" Text=""></asp:Label></p>
</td>
</tr>

<tr>
<td>
<p><strong>Alternate Phone <i class="fa fa-phone-square fa-lg"></i>:</strong></p>
<p ><asp:Label ID="lblAltPhone" runat="server" Text=""></asp:Label></p>
</td>
</tr>

<tr>
<td>
<p><strong>Adjuster:</strong></p>
<p ><asp:Label ID="lblAssignedAdjuster" runat="server" Text=""></asp:Label></p>
</td>
</tr>
</table>


</div>

</div>


</div>
<div class="col-md-8">

<asp:Panel ID="Panel2" runat="server">
<div class="panel panel-default">
<div class="panel-heading"><h4>Notes</h4></div>
<div class="panel-body">
<div ID="Notes" runat="server" class="ListDiv">                             
</div>
</div>
</div>
<div class="panel panel-default">
<div class="panel-heading">
<h4>New Notes</h4>
</div>
<div class="panel-body">
<div class="row">
<div class="col-md-8">
<h5>Add New Note</h5>
<table class="table-borderless" style="width:100%">
<tr>
<td>
<asp:TextBox ID="txtNewNote" runat="server" Height="150px" Rows="5" 
style="text-align: left" TextMode="MultiLine" Width="100%" 
BackColor="White" CssClass="inputBox"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:CheckBox ID="chkVisibleToClaimRep" runat="server" 
Text="Make note visible to claim contact" />
</td>
</tr>

<tr>
<td>
<asp:Label ID="lblNewNoteMsg" runat="server" ForeColor="Black" 
style="color: #000000"></asp:Label>
</td>
</tr>
<tr>
<td>

    <asp:LinkButton ID="lnkAddNotes" runat="server" CssClass="btn btn-default" OnClick="btnAdd_Click">Add New Note <span class="fa fa-comments-o fa-lg"></span></asp:LinkButton>
<asp:Button ID="btnAdd" runat="server" CausesValidation="False" 
CssClass="btn btn-primary"  OnClientClick="this.disabled=true" 
Text="Add New Note" UseSubmitBehavior="false" />

   
</td>
</tr>
</table>
</div>
<div class="col-md-4">
<h5>Send Copy To</h5>
<table class="table-borderless">
<tr>
<td><asp:GridView ID="GVNoteRecipient" GridLines="None" runat="server" CssClass="table table-hover table-striped" ShowHeader="False" >
<Columns>
<asp:TemplateField HeaderText="Select">
<EditItemTemplate>
<asp:CheckBox ID="CheckBox1" runat="server" />
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox ID="CheckBox1" runat="server" />
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView></td>
</tr>
<tr>
<td></td>
</tr>
<tr>
<td>  <asp:LinkButton ID="lnkRepButton"  runat="server" CausesValidation="False" 
CssClass="btn btn-default" >Enable Claim Contact</span></asp:LinkButton></td>
</tr>
</table>


</div>
</div>

</div>
</div>

</asp:Panel>

</div>
</div>

</ContentTemplate>
</asp:UpdatePanel>

</div>


<div id="Files" class="tab-pane" role="tabpanel">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<div class="panel panel-default">
<div class="panel-heading">
 <h4>Associated Files</h4>
</div>

<div class="panel-body">
    <asp:LinkButton ID="lnkUpload" runat="server" cssClass="btn btn-default btn-lg" data-toggle="modal" data-target="#myModal">Click to Upload File <span class="fa fa-upload fa-lg"></span></asp:LinkButton>

<%--<button type="button" class="btn btn-info btn-lg"  runat="server" data-toggle="modal" data-target="#myModal" id="btnFileUpload">Click to Upload File</button>--%>

<!-- Modal -->

</div>

</div>

<div class="panel panel-default">

    <div class="panel-body">
<asp:GridView ID="GVAssociatedFiles"  AutoGenerateColumns="false" GridLines="None" runat="server" CssClass="table table-hover table-striped" Width="100%">
<Columns>
    <asp:TemplateField HeaderText="Select">
<EditItemTemplate>
<asp:CheckBox ID="CheckBox1" runat="server" />
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox ID="CheckBox1" runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="File Path ID" HeaderText="File Path ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/>
<asp:BoundField DataField="Claim ID" HeaderText="Claim ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/>
<asp:BoundField DataField="File Path" HeaderText="File Path" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/>
    <asp:BoundField DataField="File Type" HeaderText="File Type" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"/>
<asp:BoundField DataField="Description" HeaderText="Description" />
 <asp:hyperlinkField DataTextField="FILE" HeaderText="File" DataNavigateUrlFields="File Path" Target="_blank" DataNavigateUrlFormatString="/Admin/crosscountryFiles.aspx?file={0}"  SortExpression="FILE" /> 
<asp:BoundField DataField="Uploaded" HeaderText="Uploaded" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"/>
    <asp:BoundField DataField="Document Type" HeaderText="Document Type" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/>
<asp:BoundField DataField="status" HeaderText="status" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"/>
<asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
<ItemTemplate>
<asp:LinkButton ID="imgDelete" ToolTip="Delete File" runat="server" CausesValidation="false"  CommandName="Delete" 
    OnClientClick="return confirm('Are you sure you want to delete this File?');"   >
    <span class="fa fa-trash-o fa-2x pull-right"></span></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Mark As" ShowHeader="False" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
<ItemTemplate>
<asp:Button ID="btnStatus" runat="server" CausesValidation="false" cssclass="btn btn-default"
CommandArgument="<%# Container.DataItemIndex%>"   CommandName="Status" Text="Read" />
</ItemTemplate>
</asp:TemplateField>
</Columns>

</asp:GridView>
  

    </div>

    <div class="panel-footer">
<asp:LinkButton ID="lnkAddFiles" runat="server" cssclass="btn btn-default" OnClick="btnAddFile_Click">Add File to Merge List <span class="fa fa-plus"></span></asp:LinkButton>

    </div>
</div>

<div>
<asp:GridView ID="gvMergeFile" runat="server" AllowSorting="True" GridLines="None"
AutoGenerateColumns="False" CssClass="table table-hover table-striped" ShowHeaderWhenEmpty="True" >
<Columns>
<asp:BoundField DataField="fileDescription" HeaderText="File Description" />
<asp:BoundField DataField="fileName" HeaderText="File Name" />
<asp:BoundField DataField="filePath" HeaderText="File Path" />
<asp:TemplateField AccessibleHeaderText="Delete" HeaderText="Delete">
<ItemTemplate>
<asp:LinkButton ID="imgDelete" ToolTip="Delete File" runat="server" CausesValidation="false"  CommandName="Delete" 
    OnClientClick="return confirm('Are you sure you want to delete this File?');"   >
    <span class="fa fa-trash-o fa-2x pull-center"></span></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>

    </div>

<div id="myModal" class="modal fade" role="dialog">
<div class="modal-dialog">

    <!-- Modal content-->
<div class="modal-content">
<div class="modal-header">
<button type="button" class="close" data-dismiss="modal">&times;</button>
<h4 class="modal-title">Upload File(s)</h4>
</div>
<div class="modal-body">
<p>Please select the following file types:</p>
<p>(pdf)| Images(jpg, jpeg, png) | documents(doc, docx)| Other(esx, dds)</p>

<div class="form-horizontal form-label-left">
<asp:Label ID="Label1" runat="server"></asp:Label>
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
File: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:FileUpload ID="ascFileUpload" runat="server" CssClass="form-control col-md-7 col-xs-12" AllowMultiple="True" BorderStyle="Dotted" />
</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
File Type: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:DropDownList ID="cmbFileType" runat="server" class="form-control col-md-7 col-xs-12"></asp:DropDownList>

</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Description: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
 <asp:TextBox ID="txtDescription" runat="server" required="required" data-parsley-error-message="Last Name is required" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnUpload" CssClass="btn btn-default"  Text="Upload" runat="server"  onclick="upload_click" data-dismiss="modal" UseSubmitBehavior="False"></asp:Button>
</div>
</div>


</div>
</div>
 <div class="modal-footer">
 </div>
</div>

  </div>     
   </div>

<div class="panel panel-default">
<div class="panel-heading">
<h4>Merge File(s)</h4>
</div>
<div class="panel-body">
<div class="row">


 <div class="form-horizontal form-label-left">
    <asp:Label ID="lblMergeError" runat="server"></asp:Label>
    
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Merge File Name: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtMergeFileName" runat="server"  class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Merge File Description: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtMergeFileDescription" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">

    <asp:LinkButton ID="lnkMergeFiles" runat="server" OnClick="btnMergeFile_Click" CssClass="btn btn-primary">Merge Selected File(s) <span class="fa fa-compress"></span></asp:LinkButton>

</div>
</div>
   </div>

</div>
</div>


</div>

      </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnUpload" />

    </Triggers>
</asp:UpdatePanel>
</div>


<div id="Map" class="tab-pane" role="tabpanel">  
    
<h3>MAP</h3>

<div id="map_canvas" >

</div>

<div class="panel panel-default">


   

</div>

    
</div>

</div>




  

 


</div>
 
</div>

 
























    </div>

 
























</asp:Content>
