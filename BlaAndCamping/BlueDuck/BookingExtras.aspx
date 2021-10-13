<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingExtras.aspx.cs" MasterPageFile="../Booking.Master" Inherits="BlaAndCamping.BlueDuck.BookingExtras" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="booking-members-container">
        <div class="row">
            <div class="col-3">
                <h5>Adults:</h5>
            </div>
            <div class="col-1">
                <asp:TextBox ID="tBox_Adults" CssClass="booking-members-tbox" runat="server"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:Button Text="+" ID="btn_AdultsPlus" runat="server" CssClass="booking-members-button" />
            </div>
            <div class="col-1">
                <asp:Button Text="-" ID="btn_AdultsMinus" runat="server" CssClass="booking-members-button" />
            </div>
            <div class="col-6"></div>
        </div>
        <div class="row"> 
            <div class="col-3">
                <h5>Children:</h5>
            </div>
            <div class="col-1">
                <asp:TextBox ID="tBox_Children" CssClass="booking-members-tbox" runat="server"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:Button Text="+" ID="btn_ChildrenPlus" runat="server" CssClass="booking-members-button" />
            </div>
            <div class="col-1">
                <asp:Button Text="-" ID="btn_ChildrenMinus" runat="server" CssClass="booking-members-button" />
            </div>
            <div class="col-6"></div>
        </div>
        <div class="row">
            <div class="col-3">
                <h5>Dogs:</h5>
            </div>
            <div class="col-1">
                <asp:TextBox ID="tBox_Dogs" CssClass="booking-members-tbox" runat="server"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:Button Text="+" ID="btn_DogsPlus" runat="server" CssClass="booking-members-button" />
            </div>
            <div class="col-1">
                <asp:Button Text="-" ID="btn_DogsMinus" runat="server" CssClass="booking-members-button" />
            </div>
            <div class="col-6"></div>
        </div>
    </div>

</asp:Content>
