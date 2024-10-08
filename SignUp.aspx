<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LibraryManagementSystemPT.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <link rel="shortcut icon" href="Logoimg/logoIcon.ico" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width-device, initial-scale=1" />

    <%--1-Bootstrap CSS--%>
    <link href="Bootstrap/CSS/bootstrap.min.css" rel="stylesheet" />

    <%--2-Datatable CSS--%>
    <link href="Datatable/Css/dataTables.dataTables.min.css" rel="stylesheet" />

    <%--3-Fontawesome CSS--%>
    <link href="fontawesome/css/all.css" rel="stylesheet" />

    <%--4-Jquery jS--%>
    <script src="Bootstrap/JS/jquery-3.2.1.slim.min.js"></script>

    <%--5-Popper JS--%>
    <script src="Bootstrap/JS/popper.min.js"></script>

    <%--6-Bootstrap JS--%>
    <script src="Bootstrap/JS/bootstrap.min.js"></script>

     <%--7-SweetAlert--%>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-sm navbar-dark bg-primary">
                <a class="navbar-brand" href="default.aspx">
                    <img src="Logoimg/Library.ico" alt="LMS Application" width="49" height="49" />Library</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="default.aspx"><b>Home</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Library Collection</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Archives</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Publications</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Gallery</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Contact</b></a>
                        </li>
                    </ul>
                </div>
                <!-- Navbar Right Icon -->
                <div class="pmd-navbar-right-icon ml-auto">
                    <%-- <a class="btn btn-sm btn-primary" href="#">Sign Up</a>--%>
                    <a class="btn btn-sm btn-primary" href="Login.aspx">Sign In</a>
                </div>
            </nav>

            <div class="jumbotron text-center alert alert-primary" style="margin-bottom: 0">
                <h1>Library Management System</h1>
                <p>Building Community. Inspiring readers. Epanding book access!</p>
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-2 border border-info">
                        <h2>Filter</h2>

                        <p>Top Search</p>
                        <ul class="nav nav-pills flex-column">
                            <li class="nav-item">
                                <a class="nav-link active" href="#">Active</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Link</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Link</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link disabled" href="#">Disabled</a>
                            </li>
                        </ul>
                        <hr class="d-sm-none" />
                    </div>
                    <div class="col-sm-10 border border-info">
                        <%-- write your code here--%>

                        <%--Login Screen--%>
                        <div class="container mt-3">
                            <h2>Create New Account</h2>
                            <br>
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#signup">Sign Up</a>
                                </li>

                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div id="signup" class="container tab-pane active">
                                    <br>
                                    <h3>Sign Up</h3>
                                    <p></p>
                                    <!---design login form--->
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12 mx-auto">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <center>
                                                                    <img width="150px" src="Logoimg/sign.jpg" />
                                                                </center>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <center>
                                                                    <h3>Member/User Sign Up</h3>
                                                                </center>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <hr />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label>Member ID</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtMemberID" CssClass="form-control" placeholder="Member Id" runat="server"></asp:TextBox>
                                                                </div>

                                                                <label>Password</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Valid Password" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <label>Full Name</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtFullName" CssClass="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter full name" ControlToValidate="txtFullName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                </div>



                                                                <%-- <div class="form-group">
                                                                    <a href="SignUp.aspx">
                                                                        <input type="button" class="btn btn-info btn-lg btn-block" value="Sign Up" /></a>
                                                                </div>--%>
                                                            </div>


                                                            <div class="col-4">

                                                                <label>Date of Birth</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtDOB" CssClass="form-control" placeholder="DOB" TextMode="Date" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>Contact No.</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtContactNo" CssClass="form-control" placeholder="Contact No." runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>EmailID</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email" TextMode="Email" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="enter valid email address" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="enter valid email address" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="#CC0099" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                </div>

                                                            </div>
                                                            <div class="col-4">
                                                                <label>State</label>
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

                                                                <label>City</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtCity" CssClass="form-control" placeholder="City" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>PIN </label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtPIN" CssClass="form-control" placeholder="PIN CODE" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <label>Full Address </label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtAddress" CssClass="form-control" placeholder="Address" runat="server"></asp:TextBox>
                                                                </div>

                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-3">
                                                                <div class="form-group">

                                                                    <asp:Button ID="btnSignup" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Sign Up" OnClick="btnSignup_Click" />

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <a href="default.aspx"><< Back to Home Page >></a>
                                        </div>
                                    </div>
                                </div>

                                <!---design End--->
                            </div>

                        </div>
                    </div>

                    <!--- END login screen --->

                </div>

            </div>
        </div>

        <br />
        <div class="jumbotron text-center alert alert-danger" style="margin-bottom: 0; border: 2px solid red">
            <p>Footer</p>
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <div class="footer-pad">
                            <h4>Heading1</h4>
                            <ul class="list-unstyled">
                                <li><a href="#"></a></li>
                                <li><a href="#">Payment Center</a></li>
                                <li><a href="#">News and updates</a></li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="footer-pad">
                            <h4>Heading1</h4>
                            <ul class="list-unstyled">
                                <li><a href="#"></a></li>
                                <li><a href="#">Website</a></li>
                                <li><a href="#">Disclaimer</a></li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <h4>Follow Us</h4>
                        <ul class="social-network social-circle">
                            <li><a href="#" title="Facebook"><i class="fa fa-facebook"></i></a></li>
                        </ul>
                    </div>

                </div>

                <div class="row">
                    <div class="col-md-12 fa-copyright border-dark">
                        <p class="text-center">&copy; Copyright 2023 - DotNet Library. All rights reserved.</p>
                    </div>
                </div>
            </div>
        </div>

        </div>
    </form>
</body>
</html>
