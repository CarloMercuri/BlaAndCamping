<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="..\Site.Master" CodeBehind="Index.aspx.cs" Inherits="BlaAndCamping.BlueDuck.index" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--HEADER, IMAGE & DESCRIPTION-->

    <div class="row">
        <div class="col-2"></div>
        <div class="col-8 content">
            <img src="/images/blue_duck.png" alt="Blue Duck Logo" style="width:100px;"/>
            <h1>Velkommen til Camp Den Blå And</h1>
            <h3>Hos os finder du alt det du drømmer om når du holder ferie, om det er nærvær, hygge, aktiviteter og sjove oplevelser eller at kommer helt telt på naturen.</h3>
           
        </div>
        <div class="col-2"></div>
    </div>
    <br />
    <br />

   <!--BUTTONS - REDIRECTING TO ORDER SPOT TYPES AND OTHER INFORMATION-->
    <div class="row"> 
<div class="col-3"></div>
        <div class="col-6">
            
             <div class="order-buttons">
               <asp:ImageButton ID="OrderButtonCabin" runat="server" CssClass="button-style" OnClick="TypeButtonClick"/>
                <asp:ImageButton ID="OrderButtonTent" runat="server" CssClass="button-style" OnClick="TypeButtonClick"/>
                <asp:ImageButton ID="OrderButtonWagon" runat="server" CssClass="button-style" OnClick="TypeButtonClick"/>
                <asp:ImageButton ID="ButtonActivities" runat="server" CssClass="button-style" OnClick="ActivitesButtonClick"/>
                <asp:ImageButton ID="OrderButton" runat="server" CssClass="button-style" OnClick="OrderButtonClick"/>
                <asp:ImageButton ID="SeasonPassButton" runat="server" CssClass="button-style" OnClick="SeasonPassButtonClick"/>
           </div>
        </div>
        <div class="col-3"></div>
    </div>

   
 
        
 
</asp:Content>

