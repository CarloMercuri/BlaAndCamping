<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingSelectSlot.aspx.cs" MasterPageFile="../Booking.Master" Inherits="BlaAndCamping.BlueDuck.BookingSelectSlot" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--HEADER-->
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8 content">
            <br />
            <h1>Booking - kortere ophold</h1>
            <h3>Her på siden kan du vælge hvilken camping plads du ønsker at reservere</h3>
            <p>Ønsker du i stedet at reservere en plads for en hel sæson, så se mere <a href="/BlueDuck/SesaonPass.aspx">her</a>. Obs! Kun for campingvogn/autocamper pladser.</p>
        </div>
        <div class="col-2"></div>
    </div>


    <div class="row">
        <div class="col-6">
            <img src="../Images/camping_img.png"/>
        </div>
        <div class="col-4">
            <div class="slot-selection-buttons-container" runat="server" id="buttonsContainer">
        </div>
            <div class="col-2"></div>
        </div>
    </div>
    

</asp:Content>
