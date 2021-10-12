<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservationConfirm.aspx.cs" MasterPageFile="..\Booking.Master" Inherits="BlaAndCamping.BlueDuck.ReservationConfirm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--HEADER-->
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8 content">
            <h1>Booking - confirmation</h1>
             <p>Ønsker du i stedet at reservere en plads for en hel sæson, så se mere <a href="/BlueDuck/SesaonPass.aspx">her</a>. Obs! Kun for campingvogn/autocamper pladser.</p>
        </div>
        <div class="col-2"></div>
    </div>


    <!-- REMINDER -->
    <div class="row">
        <div class="col-2"></div>
            <div class="col-8 content">
                <h3 ID="h3_Summary" runat="server"></h3>
                        <asp:Label ID="label_fillData" runat="server" Text="">Fill in your data to continue with the reservation</asp:Label>
                                   
            </div>
        <div class="col-2"></div>
    </div>
    <br />

    <!-- SUMMARY & INPUT -->
    <div class="row">
        <div class="col-2"></div>
        <div class="col-2"></div>
            <div class="col-5 content-left">
                <asp:Table ID="UserInfoTable" runat="server">
  
                    <asp:TableRow>
                                <asp:TableHeaderCell>
                                    <asp:Label ID="FirstNameLabel" runat="server" Text="Label">Fornavn:</asp:Label>
                                </asp:TableHeaderCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tBox_FirstName" runat="server" AutoPostBack="false" required="true"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>

 
                     <asp:TableRow>
                                <asp:TableHeaderCell>
                                    <asp:Label ID="LastNameLabel" runat="server" Text="Label">Efternavn:</asp:Label>
                                </asp:TableHeaderCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tBox_LastName" runat="server" AutoPostBack="false" required="true"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>

                     <asp:TableRow>
                                <asp:TableHeaderCell>
                                    <asp:Label ID="EmailLabel" runat="server" Text="Label">Email:</asp:Label>
                                </asp:TableHeaderCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tBox_Email" runat="server" required="true"></asp:TextBox>
                                    <asp:Label ID="label_EmailError" runat="server" Text="Label"></asp:Label>
                                </asp:TableCell>

                    </asp:TableRow> 


                     <asp:TableRow>
                                <asp:TableHeaderCell>
                                    <asp:Label ID="ZipCodeLabel" runat="server" Text="Label">Postnummer:</asp:Label>
                                </asp:TableHeaderCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tBox_ZipCode" runat="server" AutoPostBack="false" required="true"></asp:TextBox>
                                    <asp:Label ID="label_PostNumberError" runat="server" Text="Label"></asp:Label>
                                </asp:TableCell>
                    </asp:TableRow> 

                                         <asp:TableRow>
                                <asp:TableHeaderCell>
                                    <asp:Label ID="CityLabel" runat="server" Text="Label">By:</asp:Label>
                                </asp:TableHeaderCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tBox_City" runat="server" AutoPostBack="false" required="true"></asp:TextBox></asp:TableCell>
                    </asp:TableRow> 

                </asp:Table>
            </div>
        <div class="col-3"></div>
   </div>

    <br />

    <div class="row">
            <div class="col-4"></div>
            <div class="col-2">
                            <asp:Button ID="Button1" CssClass="confirm-button button-hover" runat="server" Text="Submit" />
            </div>
            <div class="col-6"></div>
        </div>
</asp:Content>
