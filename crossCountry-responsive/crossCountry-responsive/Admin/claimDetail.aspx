<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="claimDetail.aspx.vb" Inherits="crossCountry_responsive.claimDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            
        </div>



        <ul class="nav nav-tabs">
  <li class="active"><a data-toggle="tab" href="#claim">Claim Info</a></li>
  <li><a data-toggle="tab" href="#Files">Files</a></li>
 </ul>

<div class="tab-content">
  <div id="claim" class="tab-pane fade in active">
  <div class="row">
      <div class="col-md-4">
<table class="table">
<tr>
<td>
<p><strong>Claim #:</strong> </p>
<p ><asp:Label ID="lblClaimNumber" runat="server" Text=""></asp:Label></p>
</td>
</tr>

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
<div class="col-md-8">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
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
</ContentTemplate>
</asp:UpdatePanel>
 </div>
  </div>
  </div>
  <div id="Files" class="tab-pane fade">
    <h3>Menu 1</h3>
    <p>Some content in menu 1.</p>
  </div>
  <div id="menu2" class="tab-pane fade">
    <h3>Menu 2</h3>
    <p>Some content in menu 2.</p>
  </div>
</div>
        
    </div>
</asp:Content>
