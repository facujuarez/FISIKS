<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FisiksAppWeb.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <!-- Carousel	================================================== -->
        <div id="myCarousel" class="carousel slide">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li class="active" data-slide-to="0" data-target="#myCarousel"></li>
                <li data-slide-to="1" data-target="#myCarousel"></li>
                <li data-slide-to="2" data-target="#myCarousel"></li>
            </ol>
            <div class="carousel-inner">
                <div class="item active">
                    <img src="../Img/Fondo-Fisio-I.jpg" style="width: 100%; height: 350px" alt="">
                    <div class="container">
                        <div class="carousel-caption pull-right">
                            <h1><font color="#e40000">Piense en Grande!</font></h1>
                            <p> <br/>de manera simple y segura.</p>
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img src="../Img/Fondo-Fisio-II.jpg" style="width: 100%; height: 350px" alt="">
                    <div class="container">
                        <div class="carousel-caption">
                            <h1><font color="#e40000">Transformamos</font></h1>
                            <p>tecnologías y servicios <br/>en soluciones de negocio</p>
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img src="../Img/Fondo-Fisio-III.jpg" style="width: 100%; height: 350px" alt="">
                    <div class="container">
                        <div class="carousel-caption">
                            <h1><font color="#e40000">Despreocúpese!</font></h1>
                            <p>Tenemos la solución <br/>para su empresa.</p>
                        </div>
                    </div>
                </div>
            </div>
            <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="icon-prev"></span></a>
            <a class="right carousel-control" href="#myCarousel" data-slide="next"><span class="icon-next"></span></a>
        </div>
        <!-- Carousel	================================================== -->
    </div>
</asp:Content>
