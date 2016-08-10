<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="claimContactList.aspx.vb" Inherits="crossCountry_responsive.claimContactList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">

        <div class="form-group">

            <div class="col-md-6 col-sm-6 col-xs-12">
              <asp:DropDownList ID="ddlChooseCarrier" runat="server" class="form-control col-md-7 col-xs-12" required="true"></asp:DropDownList>
              <asp:Button ID="btnSelect" runat="server" CausesValidation="False"  Text="Filter"  CssClass="btn btn-default"/>
            </div>

        </div>
        

        <div class="panel-body">
            <asp:GridView ID="gdFiles" runat="server" Width="100%" CssClass="table table-hover table-striped" GridLines="None"  
            AllowPaging="true" pagesize="50" DataKeyNames="Rep ID" ShowHeaderWhenEmpty="true"  
            AutoGenerateColumns="false" AllowSorting="true" OnSorting="sortRecords" EmptyDataText="There are no contacts to display"> 
        <Columns>
            <asp:BoundField DataField="Rep ID" HeaderText="repId" ReadOnly="True" SortExpression="Rep ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" /> 
            <asp:hyperlinkField DataTextField="Contact Name" HeaderText="Name" DataNavigateUrlFields="Rep ID" DataNavigateUrlFormatString="/Admin/modifyContact.aspx?contactId={0}"  SortExpression="Contact Name" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" />            
            <asp:BoundField DataField="password" HeaderText="Password" ReadOnly="True" SortExpression="password" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"/> 
           
         </Columns>

    </asp:GridView>


        </div>

    </div>

</asp:Content>
