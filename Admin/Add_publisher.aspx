<%@ Page Title="Add_publisher" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Add_publisher.aspx.cs" Inherits="LibraryManagementSystemPT.Admin.Add_publisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <%--7-SweetAlert--%>
<link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
<script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 border">
                <div class="row">
                    <div class="col-12">
                        <h4>Add Publisher</h4>
                        <div class="form-group">
                            <asp:TextBox ID="txtpublisherID" CssClass="form-control" runat="server" placeholder="Publisher ID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="enter publisher id" ValidationGroup="btn_save" ControlToValidate="txtpublisherID" Display="Dynamic" ForeColor="#FF6600" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtpublisherName" CssClass="form-control" runat="server" placeholder="Publisher Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter publisher name" ValidationGroup="btn_save" ControlToValidate="txtpublisherName" Display="Dynamic" ForeColor="#FF0066" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnAdd" CssClass="btn btn-success" ValidationGroup="btn_save" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" CssClass="btn btn-info" ValidationGroup="btn_save" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger" ValidationGroup="btn_save" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                        </div>
                    </div>
                   
                </div>
            </div>
            <div class="col-9 border">
                <div class="table table-responsive">
                    <h4>Show All Publisher List:</h4>
                     <asp:Repeater ID="RptPublisher" runat="server" OnItemCommand="RptPublisher_ItemCommand">
                    <HeaderTemplate>
                    <table class="table table-bordered table-hover">
                    <thead class="alert-info">
                   <tr>
                     <th><span>Publisher ID</span></th>
                     <th><span>Publisher Nane</span></th>
                     <th>&nbsp;</th>
                 </tr>
             </thead>
             <tbody>
     </HeaderTemplate>
     <ItemTemplate>
         <tr>
             <td><%#Eval("publisher_id") %></td>
             <td><%#Eval("publisher_name") %></td>
             <td style="width: 18%">
                 <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("publisher_id") %>' CommandName="edit" ToolTip="edit record">
                     <span class="fa-stack">
                         <i class="fa fa-square fa-stack-2x"></i>
                         <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>
                     </span>
                 </asp:LinkButton>

                 <asp:LinkButton ID="LnkDelete" class="table-link text-danger" runat="server" CommandArgument='<%#Eval("publisher_id") %>' CommandName="delete" Text="Delete" ToolTip="Delete record" OnClientClick="return confirm('Do you want to delete this row?');">
                      <span class="fa-stack">
                          <i class="fa fa-square fa-stack-2x"></i>
                          <i class="fa fa-trash fa-stack-1x fa-inverse"></i>
                    </span>
                 </asp:LinkButton>
             </td>
         </tr>
     </ItemTemplate>
     <FooterTemplate>
         </tbody>
      </table>
     </FooterTemplate>
               

 </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
