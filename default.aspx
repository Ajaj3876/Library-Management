<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LibraryManagementSystemPT._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div id="demo" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ul class="carousel-indicators">
                    <li data-target="#demo" data-slide-to="0" class="active"></li>
                    <li data-target="#demo" data-slide-to="1"></li>
                    <li data-target="#demo" data-slide-to="2"></li>
                </ul>

                <!-- The Slideshow -->
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="SlideImg/lms1.png" alt="Los Angeles">
                    </div>
                    <div class="carousel-item ">
                        <img src="SlideImg/lms2.jpg" alt="Chicago" width="1000px" height="575px">
                    </div>
                    <div class="carousel-item ">
                        <img src="SlideImg/lms3.jpg" alt="New York" width="1000px" height="575px">
                    </div>
                </div>

                <!-- Left and right controls -->
                <a class="carousel-control-prev" href="#demo" data-slide="prev">
                    <span class="carousel-control-prev-icon"></span>
                </a>
                <a class="carousel-control-next" href="#demo" data-slide="next">
                    <span class="carousel-control-next-icon"></span>
                </a>

            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <h2>Tittle Heading</h2>
                <h5>Tittle description, Sep27, 2024</h5>
                <div class="fakeimg">Fake Image</div>
                <p>Some Text......</p>
                <p>Some in the details can be explaind to the our library management system</p>
                <br />
                <h2>Tittle Heading</h2>
                <h5>Tittle description, Sep7, 2024</h5>
                <div class="fakeimg">Fake Image</div>
                <p>Some Text......</p>
                <p>Some in the details can be explaind to the our library management system</p>
            </div>
        </div>

        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">BLACK FRIDAY DEAL</div>
                            <div class="card-body">
                                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width: 100%" alt="" />
                            </div>
                            <div class="panel-footer">Buy 50 mobiles and get a gift free</div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="card panel panel-danger">
                            <div class="panel-heading">BLACK FRIDAY DEAL</div>
                            <div class="card-body">
                                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width: 100%" alt="" />
                            </div>
                            <div class="panel-footer">Buy 50 mobiles and get a gift free</div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="panel panel-success">
                            <div class="panel-heading">BLACK FRIDAY DEAL</div>
                            <div class="card-body">
                                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width: 100%" alt="" />
                            </div>
                            <div class="panel-footer">Buy 50 mobiles and get a gift free</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
