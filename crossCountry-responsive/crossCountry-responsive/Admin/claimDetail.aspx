<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="claimDetail.aspx.vb" Inherits="crossCountry_responsive.claimDetail" %>

<%@ Register Assembly="Artem.Google" Namespace="Artem.Google.UI" TagPrefix="artem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >

 
<div class="container">
    
    <h4 class="lead"> <strong>Claim #: </strong> <asp:Label ID="lblClaimNumber" runat="server" Text=""></asp:Label></h4>



<ul class="nav nav-tabs">
<li class="active"><a data-toggle="tab" href="#claim">Claim Info</a></li>
<li><a data-toggle="tab" href="#Files">Files</a></li>
<li><a data-toggle="tab" href="#Map">Claim Map</a></li>
</ul>

<div class="tab-content"> 
   
<div id="claim" class="tab-pane active">
  
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
<td><asp:GridView ID="GVNoteRecipient" runat="server" BackColor="White" 
BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
ForeColor="Black" GridLines="Horizontal" ShowHeader="False" Width="100%" 
style="font-size: small; font-family: 'Segoe UI'">
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
<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
<SortedAscendingCellStyle BackColor="#F7F7F7" />
<SortedAscendingHeaderStyle BackColor="#4B4B4B" />
<SortedDescendingCellStyle BackColor="#E5E5E5" />
<SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView></td>
</tr>
<tr>
<td></td>
</tr>
<tr>
<td>  <asp:LinkButton ID="lnkRepButton" runat="server" CausesValidation="False" 
CssClass="btn btn-primary" >Enable Claim Contact</asp:LinkButton></td>
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
<div id="Files" class="tab-pane ">
     

<h3>Menu 1</h3>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>



<div class="panel panel-default">

    <div class="panel-heading">
        <h4>Associated Files</h4>

    </div>
    <div class="panel-body">
<asp:GridView ID="GVAssociatedFiles"  AutoGenerateColumns="false" GridLines="None" runat="server" CssClass="table table-hover table-striped" >
<Columns>
    <asp:TemplateField HeaderText="Select">
<EditItemTemplate>
<asp:CheckBox ID="CheckBox1" runat="server" />
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox ID="CheckBox1" runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Description" HeaderText="Description" />
<asp:BoundField DataField="File" HeaderText="File" />
<asp:BoundField DataField="Uploaded" HeaderText="Uploaded" />
<asp:BoundField DataField="status" HeaderText="status" />
<asp:TemplateField HeaderText="Delete" ShowHeader="False">
<ItemTemplate>
<asp:LinkButton ID="imgDelete" ToolTip="Delete File" runat="server" CausesValidation="false"  CommandName="Delete" 
    OnClientClick="return confirm('Are you sure you want to delete this File?');"   >
    <span class="fa fa-trash-o fa-2x pull-right"></span></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Mark As" ShowHeader="False">
<ItemTemplate>
<asp:Button ID="btnStatus" runat="server" CausesValidation="false" cssclass="btn btn-default"
CommandArgument="<%# Container.DataItemIndex%>"   CommandName="Status" Text="Read" />
</ItemTemplate>
</asp:TemplateField>
</Columns>

</asp:GridView>

    </div>

</div>

<div class="panel panel-default">
<div class="panel-heading">
<h4>Merge File(s)</h4>
</div>
<div class="panel-body">
<div class="row">
<asp:GridView ID="gvMergeFile" runat="server" AllowSorting="True" 
AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
BorderStyle="None" BorderWidth="0px" CellPadding="2" ForeColor="Black" 
GridLines="Horizontal" HorizontalAlign="Center" 
ShowHeaderWhenEmpty="True" 
style="margin-right: 0px; font-size: x-small; font-family: 'Segoe UI';" 
Width="100%" Font-Size="Smaller" CssClass="tableClass">
<AlternatingRowStyle HorizontalAlign="Center" />
<Columns>
<asp:BoundField DataField="fileDescription" HeaderText="File Description" />
<asp:BoundField DataField="fileName" HeaderText="File Name" />
<asp:BoundField DataField="filePath" HeaderText="File Path" />
<asp:TemplateField AccessibleHeaderText="Delete" HeaderText="Delete">
<ItemTemplate>
<asp:ImageButton ID="imgremoveButton" runat="server" CausesValidation="false" 
CommandName="delete" ImageUrl="~/Resources/delete_icon.png" 
OnClientClick="return confirm('Are you sure you want to remove this file?');" 
Text="Remove" />
</ItemTemplate>
</asp:TemplateField>
</Columns>
<EditRowStyle HorizontalAlign="Center" />
<EmptyDataRowStyle HorizontalAlign="Center" />
<FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" 
HorizontalAlign="Center" />
<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
<RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
<SortedAscendingCellStyle BackColor="#F7F7F7" />
<SortedAscendingHeaderStyle BackColor="#4B4B4B" />
<SortedDescendingCellStyle BackColor="#E5E5E5" />
<SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView>

   <div class="form-horizontal form-label-left">
    <asp:Label ID="lblMergeError" runat="server"></asp:Label>
<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Merge File Name: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtMergeFileName" runat="server" required="required" data-parsley-error-message="First Name is required" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<label class="control-label col-md-3 col-sm-3 col-xs-12">
Merge File Description: <span class="required">*</span>
</label>
<div class="col-md-6 col-sm-6 col-xs-12">
<asp:TextBox ID="txtMergeFileDescription" runat="server" required="required" data-parsley-error-message="First Name is required" class="form-control col-md-7 col-xs-12"></asp:TextBox>

</div>
</div>

<div class="form-group">
<div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
<asp:Button ID="btnMergeFile" CssClass="btn btn-success" OnClick="btnMergeFile_Click" Text="Merge Selected File" runat="server"></asp:Button>
</div>
</div>


</div>

</div>

</div>
</div>


<div class="panel panel-default">
<div class="panel-heading">
    <h4>Upload Files</h4>
</div>

    <div class="panel-body">
      <button type="button" class="btn btn-info btn-lg"  runat="server" data-toggle="modal" data-target="#myModal" id="btnFileUpload">Click to Upload File</button>

<!-- Modal -->

    </div>

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
<asp:FileUpload ID="ascFileUpload" runat="server" CssClass="form-control col-md-7 col-xs-12" />
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
<asp:Button ID="btnUpload" CssClass="btn btn-default"  Text="Upload" runat="server"></asp:Button>
</div>
</div>


</div>




      </div>
      <div class="modal-footer">
     
      </div>
    </div>

  </div>
</div>

</ContentTemplate>
</asp:UpdatePanel>
</div>
<div id="Map" class="tab-pane active">  
    
    <h3>MAP</h3>

   <div id="map_canvas" ></div>

<div class="panel panel-default">


   

</div>

    
</div>
</div>
  
</div>
     
</asp:Content>
