<%@ Page Title="Book Inventory" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="LibraryManagementSystemPT.Admin.BookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Datatable/js/dataTables.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 font-weight-normal">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Book Details</h6>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>

                                    <asp:Image ID="ImgPhoto" ImageUrl="~/imgs/Books.png" runat="server" Height="100" Width="100" alt="" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBookID" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="form-control btn btn-primary" OnClick="btnGo_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBookName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlLanguage" runat="server">
                                        <asp:ListItem Text="Select Language" Value="Select" />
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Marathi" Value="Marathi" />
                                        <asp:ListItem Text="Urdu" Value="Urdu" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="German" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlPublisherName" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Publisher 1" Value="publisher 1" />
                                        <asp:ListItem Text="publisher 2" Value="publisher 2" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlAuthorName" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Author 1" Value="Author 1" />
                                        <asp:ListItem Text="Author 2" Value="Author 2" />
                                    </asp:DropDownList>
                                </div>
                                <label>Publisher Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPublishDate" CssClass="form-control" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="lstBoxGenre" CssClass="form-control" runat="server" SelectionMode="Multiple" Rows="5">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Comic Book" Value="omic Book" />
                                        <asp:ListItem Text="Self Help" Value="Self Help" />
                                        <asp:ListItem Text="Motivation" Value="Motivation" />
                                        <asp:ListItem Text="Healthy Living" Value="Helathy Living" />
                                        <asp:ListItem Text="Wellness" Value="Wellness" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Poetry" Value="Poetry" />
                                        <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                        <asp:ListItem Text="Suspense" Value="Suspense" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Art" Value="Art" />
                                        <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                        <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                        <asp:ListItem Text="Health" Value="Health" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Mathematics" Value="Mathematics" />
                                        <asp:ListItem Text="TextBook" Value="TextBook" />
                                        <asp:ListItem Text="Science" Value="Science" />
                                        <asp:ListItem Text="Travel" Value="Travel" />
                                        <asp:ListItem Text="Programming" Value="Programming" />
                                        <asp:ListItem Text="Computer Science" Value="Computer Science" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEdition" CssClass="form-control" runat="server" placeholder="Edition"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost(per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookCost" CssClass="form-control" runat="server" placeholder="Book Cost(per unit)" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPages" CssClass="form-control" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtActualStock" CssClass="form-control" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCurrectStock" CssClass="form-control" runat="server" placeholder="Current Stock(per unit)" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtIssuedBooks" CssClass="form-control" runat="server" placeholder="Issued Books" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookDesc" CssClass="form-control" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="btnAdd" CssClass="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnUpdate" CssClass="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnDelete" CssClass="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                            </div>
                        </div>
                    </div>

                </div>
                <a href="AdminHome.aspx"><< Back to Home</a><br />
                <br />
            </div>

            <div class="col-md-7">

                <div class="card">

                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Details List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" DataKeyNames="book_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="true" SortExpression="book_id" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="true" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <span>Author - </span>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="true"></asp:Label>
                                                                    &nbsp;| <span><span>&nbsp;</span>Genre - </span>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("genre") %>' Font-Bold="true"></asp:Label>
                                                                    &nbsp;|
                                                                    <span>Language -<span>&nbsp;</span>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("language") %>' Font-Bold="true"></asp:Label>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher - 
                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="true"></asp:Label>
                                                                    &nbsp;| Publish Date - 
                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("publisher_date") %>' Font-Bold="true"></asp:Label>
                                                                    &nbsp;| Pages -
                                                                     <asp:Label ID="Label7" runat="server" Text='<%# Eval("no_of_pages") %>' Font-Bold="true"></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("edition") %>' Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Cost - 
                                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("book_cost") %>' Font-Bold="true"></asp:Label>
                                                                    &nbsp;| Actual Stock - 
                                                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("actual_stock") %>' Font-Bold="true"></asp:Label>
                                                                    &nbsp;| Available Stock -
                                                                   <asp:Label ID="Label11" runat="server" Text='<%# Eval("currect_stock") %>' Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Description - 
                                                                   <asp:Label ID="Label12" runat="server" Text='<%# Eval("book_description") %>' Font-Bold="true" Font-Italic="true" Font-Size="Smaller"> </asp:Label>                                                                   
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

        </div>
    </div>
</asp:Content>
