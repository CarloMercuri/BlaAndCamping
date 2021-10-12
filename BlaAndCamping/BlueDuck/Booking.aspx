<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" maintainScrollPositionOnPostback="true" Inherits="BlaAndCamping.BlueDuck.Booking" MasterPageFile="..\Booking.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--HEADER-->
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8 content">
            <br />
            <h1>Booking - kortere ophold</h1>
            <h3>Her på siden kan du se hvilke typer af pladser eller hytter der er ledige i din ønskede periode samt du kan lave din reservation.</h3>
            <p>Ønsker du i stedet at reservere en plads for en hel sæson, så se mere <a href="/BlueDuck/SesaonPass.aspx">her</a>. Obs! Kun for campingvogn/autocamper pladser.</p>
        </div>
        <div class="col-2"></div>
    </div>
    <br />
    <br />

    <!--BOOKING CONTENT-->
    <div class="booking-mid-section">
        <div class="booking-mid-section-half">
            <asp:Calendar ID="calendar_Main" runat="server"></asp:Calendar>
        </div>

        <div class="booking-mid-section-half" ID="bookingRadioSection" runat="server">
    </div>
        
    </div>


    <!-- SELECTION -->

    <div class="booking-spot-selection" style="margin-top: 40px;">
        <div class="booking-selection-mid-section-half">
            <img class="map" src="../Images/camping_img.png" />
        </div>

        <div class="booking-selection-mid-section-half">
            <div id="ButtonsMidSection" class="booking-button-wrapper" runat="server"></div>
        </div>

    </div>



</asp:Content>
