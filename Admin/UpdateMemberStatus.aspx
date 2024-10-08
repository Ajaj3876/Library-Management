<%@ Page Title="Member Update" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="UpdateMemberStatus.aspx.cs" Inherits="LibraryManagementSystemPT.Admin.UpdateMemberStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">

            <div class="col-sm-4 border">
                <p></p>
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="txtMemberID" CssClass="form-control" placeholder="Member Id" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Member Id" ControlToValidate="txtMemberId" ForeColor="Red" ValidationGroup="btnsearch"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:Button ID="btnSearchMember" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearchMember_Click" ValidationGroup="btnsearch" />
                            <asp:Button ID="btnActiveMember" CssClass="btn btn-success" runat="server" Text="Active" OnClick="btnActiveMember_Click" ValidationGroup="btnsearch" />
                            <asp:Button ID="btnPendingMember" CssClass="btn btn-info" runat="server" ForeColor="Black" BackColor="Yellow" Text="Pending" OnClick="btnPendingMember_Click" ValidationGroup="btnsearch" />
                            <asp:Button ID="btnDeactiveMember" CssClass="btn btn-danger" runat="server" Text="Deactive" OnClick="btnDeactiveMember_Click" ValidationGroup="btnsearch" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="txtFullName" CssClass="form-control" placeholder="Full Name" runat="server" ReadOnly="true"></asp:TextBox>

                        </div>

                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="txtDOB" CssClass="form-control" placeholder="DOB" TextMode="Date" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="txtContactNo" CssClass="form-control" placeholder="Contact No." runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email" TextMode="Email" runat="server" ReadOnly="true"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
                                <asp:ListItem Text="select" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                                <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                                <asp:ListItem Text="Assam" Value="Assam" />
                                <asp:ListItem Text="Bihar" Value="Bihar" />
                                <asp:ListItem Text="Chattishgarh" Value="Chattishgarh" />
                                <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                <asp:ListItem Text="Goa" Value="Goa" />
                                <asp:ListItem Text="Gujarat" Value="Gujrat" />
                                <asp:ListItem Text="Haryana" Value="Haryana" />
                                <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                                <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                                <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                                <asp:ListItem Text="Karnataka" Value="Karnataka" />
                                <asp:ListItem Text="kerla" Value="Kerla" />
                                <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                                <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                                <asp:ListItem Text="Manipur" Value="Manipur" />
                                <asp:ListItem Text="meghalaya" Value="meghalaya" />
                                <asp:ListItem Text="Mizoram" Value="Mizoram" />
                                <asp:ListItem Text="Nagaland" Value="ANagaland" />
                                <asp:ListItem Text="Odisha" Value="Odisha" />
                                <asp:ListItem Text="Punjab" Value="Punjab" />
                                <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                <asp:ListItem Text="Sikkim" Value="Sikkim" />
                                <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                                <asp:ListItem Text="Telangana" Value="Telangana" />
                                <asp:ListItem Text="Tripura" Value="Tripura" />
                                <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                                <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                                <asp:ListItem Text="West Bangal" Value="West Bangal" />
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:TextBox ID="txtCity" CssClass="form-control" placeholder="City" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="txtPIN" CssClass="form-control" placeholder="PIN CODE" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="txtAddress" CssClass="form-control" placeholder="Address" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-sm-12">
                <h4>Member List</h4>
                <div class="table table-responsive">
                    <asp:GridView ID="GridView1" CssClass="table table-sm" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" PageSize="5" Font-Size="8" OnRowDataBound="GridView1_RowDataBound">
                        <HeaderStyle BackColor="#0066FF" Font-Bold="true" ForeColor="White" />
                        <FooterStyle BackColor="#3366CC" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayID" runat="server" Text='<%# Eval("member_id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayName" runat="server" Text='<%# Eval("full_name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditName" CssClass="form-control" Text='<%# Eval("full_name") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DOB">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayDOB" runat="server" Text='<%# Eval("dob") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditdob" CssClass="form-control" Text='<%# Eval("dob") %>' TextMode="Date" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Contact">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayContact" runat="server" Text='<%# Eval("contact_no") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditcontact" CssClass="form-control" Text='<%# Eval("contact_no") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditemail" CssClass="form-control" Text='<%# Eval("email") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayState" runat="server" Text='<%# Eval("state") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblEditState" runat="server" Text='<%# Eval("state") %>' Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlEditState" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                                        <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                                        <asp:ListItem Text="Assam" Value="Assam" />
                                        <asp:ListItem Text="Bihar" Value="Bihar" />
                                        <asp:ListItem Text="Chattishgarh" Value="Chattishgarh" />
                                        <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                        <asp:ListItem Text="Goa" Value="Goa" />
                                        <asp:ListItem Text="Gujarat" Value="Gujrat" />
                                        <asp:ListItem Text="Haryana" Value="Haryana" />
                                        <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                                        <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                                        <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                                        <asp:ListItem Text="Karnataka" Value="Karnataka" />
                                        <asp:ListItem Text="kerla" Value="Kerla" />
                                        <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                                        <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                                        <asp:ListItem Text="Manipur" Value="Manipur" />
                                        <asp:ListItem Text="meghalaya" Value="meghalaya" />
                                        <asp:ListItem Text="Mizoram" Value="Mizoram" />
                                        <asp:ListItem Text="Nagaland" Value="ANagaland" />
                                        <asp:ListItem Text="Odisha" Value="Odisha" />
                                        <asp:ListItem Text="Punjab" Value="Punjab" />
                                        <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                        <asp:ListItem Text="Sikkim" Value="Sikkim" />
                                        <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                                        <asp:ListItem Text="Telangana" Value="Telangana" />
                                        <asp:ListItem Text="Tripura" Value="Tripura" />
                                        <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                                        <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                                        <asp:ListItem Text="West Bangal" Value="West Bangal" />
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayCity" runat="server" Text='<%# Eval("city") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditCity" CssClass="form-control" Text='<%# Eval("city") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Pincode">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayPinCode" runat="server" Text='<%# Eval("pincode") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditPinCode" CssClass="form-control" Text='<%# Eval("pincode") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayAddress" runat="server" Text='<%# Eval("full_address") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditAddress" CssClass="form-control" Text='<%# Eval("full_address") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="account_status" HeaderText="Status" ReadOnly="true" />

                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" Text="Edit" ToolTip="Edit record" CommandName="Edit">
                                            <span class="fa-stack">
                                                <i class="fa fa-square fa-stack-2x"></i>
                                                <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>
                                            </span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="LnkDelete" class="table-link text-danger" runat="server" Text="Delete" ToolTip="Delete record" CommandName="Delete" OnClientClick="return confirm('Do you want to delete this row?');">
                                            <span class="fa-stack">
                                                <i class="fa fa-square fa-stack-2x"></i>
                                                <i class="fa fa-trash fa-stack-1x fa-inverse"></i>
                                            </span>
                                    </asp:LinkButton>

                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" class="table-link text-success" runat="server" Text="Update" ToolTip="Update record" CommandName="Update">
                                         <span class="fa-stack">
                                              <i class="fa fa-square fa-stack-2x"></i>
                                              <i class="fa fa-spinner fa-stack-1x fa-inverse"></i>
                                         </span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="lnkCancel" class="table-link text-danger" runat="server" Text="Cancel" ToolTip="Cancel record" CommandName="Cancel">
                                           <span class="fa-stack">
                                             <i class="fa fa-square fa-stack-2x"></i>
                                             <i class="fa fa-time-circle fa-stack-1x fa-inverse"></i>
                                          </span>
                                    </asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
                    </asp:GridView>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
