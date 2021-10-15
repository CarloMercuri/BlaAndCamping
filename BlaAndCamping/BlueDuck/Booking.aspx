<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" maintainScrollPositionOnPostback="true" Inherits="BlaAndCamping.BlueDuck.Booking" MasterPageFile="../Booking.Master" %>


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
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8 content">
            <h3>Vælg en dato:</h3>
        </div>
        <div class="col-2"></div>
        
    </div>
    <div class="row">
             <asp:ScriptManager ID="calendarScriptManager" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1"
                             runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="calendar_Main" 
                                  ShowTitle="True"
                                  runat="server" CssClass="main-calendar" />
                        <div runat="server" ID="selectionMainDiv">
       
                    </div>
                       </ContentTemplate>

            </asp:UpdatePanel>
    </div>



    <!-- TYPE SELECTION -->
    <br />
    <br />
   <%-- <div col="row">
        <div class="col-4"></div>
        <div class="col-4 content">
                <asp:TextBox runat="server" ID="tBox_Selection" />  
        </div>
        <div class="col-4"></div>
    </div>--%>



</asp:Content>