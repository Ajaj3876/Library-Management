<%@ Page Title="Fine Payment Details" Language="C#" MasterPageFile="~/UserScreen/User.Master" AutoEventWireup="true" CodeBehind="uPayment.aspx.cs" Inherits="LibraryManagementSystemPT.UserScreen.uPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Fine Payment Details</h2>
                <hr />
                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
