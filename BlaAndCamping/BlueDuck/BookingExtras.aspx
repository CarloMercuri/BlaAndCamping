<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingExtras.aspx.cs" MasterPageFile="../Booking.Master" Inherits="BlaAndCamping.BlueDuck.BookingExtras" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <!--HEADER-->
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8 content">
            <br />
            <h1>Booking - kortere ophold</h1>
            <h3>Her på siden kan du vælge antal personer og hvilke tillæg du ønsker</h3>
            <p>Ønsker du i stedet at reservere en plads for en hel sæson, så se mere <a href="/BlueDuck/SesaonPass.aspx">her</a>. Obs! Kun for campingvogn/autocamper pladser.</p>
        </div>
        <div class="col-2"></div>
    </div>
    <%-- ADULTS, CHILDREN, DOGS --%>
   <div class="row">
       <div class="col-3"></div>
     <div class="col-3">
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

    <%-- EXTRAS --%>
      </div>
       <div class="col-2">
        <div class="booking-extras-container">
            <div class="row">
                <div class="col-3">
                    <h5>Badeland voksene:</h5>
                </div>
                <div class="col-1">
                    <asp:TextBox ID="tBox_WaterAdult" CssClass="booking-extras-tbox" runat="server"></asp:TextBox>
                </div>
                <div class="col-1">
                    <asp:Button Text="+" ID="btn_WaterAdultPlus" runat="server" CssClass="booking-extras-button" />
                </div>
                <div class="col-1">
                    <asp:Button Text="-" ID="btn_WaterAdultMinus" runat="server" CssClass="booking-extras-button" />
                </div>
                <div class="col-6"></div>
            </div>
            <div class="row"> 
                <div class="col-3">
                    <h5>BadeLand børn:</h5>
                </div>
                <div class="col-1">
                    <asp:TextBox ID="tBox_WaterChild" CssClass="booking-extras-tbox" runat="server"></asp:TextBox>
                </div>
                <div class="col-1">
                    <asp:Button Text="+" ID="btn_WaterChildPlus" runat="server" CssClass="booking-extras-button" />
                </div>
                <div class="col-1">
                    <asp:Button Text="-" ID="btn_WaterChildMinus" runat="server" CssClass="booking-extras-button" />
                </div>
                <div class="col-6"></div>
            </div>
            <div class="row" runat="server" id="row_Bedsheet">
                <div class="col-3">
                    <h5>Sengelinned:</h5>
                </div>
                <div class="col-1">
                    <asp:TextBox ID="tBox_Bedsheets" CssClass="booking-extras-tbox" runat="server"></asp:TextBox>
                </div>
                <div class="col-1">
                    <asp:Button Text="+" ID="btn_BedsheetsPlus" runat="server" CssClass="booking-extras-button" />
                </div>
                <div class="col-1">
                    <asp:Button Text="-" ID="btn_BedsheetsMinus" runat="server" CssClass="booking-extras-button" />
                </div>
                <div class="col-6"></div>
            </div>
            <div class="row">
                <div class="col-3">
                    <h5>Antal Cykler:</h5>
                </div>
                <div class="col-1">
                    <asp:TextBox ID="tBox_Bikes" CssClass="booking-extras-tbox" runat="server"></asp:TextBox>
                </div>
                <div class="col-1">
                    <asp:Button Text="+" ID="btn_BikesPlus" runat="server" CssClass="booking-extras-button" />
                </div>
                <div class="col-1">
                    <asp:Button Text="-" ID="btn_BikesMinus" runat="server" CssClass="booking-extras-button" />
                </div>
                <div class="col-6"></div>
            </div>
            <div class="row" runat="server" id="row_EndCleaning">
                <div class="col-3">
                    <h5>Slutrengøring:</h5>
                </div>
                <div class="col-1">
                    <asp:CheckBox Text="" ID="check_EndCleaning" CssClass="booking-extras-check" runat="server" />
                </div>
            
            
            </div>
        </div>
             
           
       </div>

       <div class="col-3">
          <%-- <br />       
           <br />       
           <br />       
           <br />       
           <br />       
           <br />       
           <br />       
           <br />       
           <br />       
           <asp:Button Text="Videre" ID="btn_Submit" CssClass="extra-button-submit" runat="server" />--%>
       </div>
       <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4 content">
            <br />  
            <br />  
            <br />  
                    <asp:Button Text="Videre" ID="btn_Submit" CssClass="extra-button-submit" runat="server" />
        </div>
        <div class="col-4"></div>
    </div>

</asp:Content>
