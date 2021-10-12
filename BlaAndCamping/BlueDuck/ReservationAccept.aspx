<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservationAccept.aspx.cs" MasterPageFile="../Booking.Master" Inherits="BlaAndCamping.BlueDuck.ReservationAccept" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <!--HEADER-->
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8 content">
            <br />
            <h1>Ordrebekræftelse</h1>
            <h3>Bekræft at dine indtastede oplysninger er rigtige</h3>
        </div>
        <div class="col-2"></div>
    </div>

    <!-- SUMMARY -->
    <div class="row">
        <div class="col-4"></div>
            <div class="col-4 content-left">
                <table class="w3-table-all w3-small">
    <tr>
      <td><%=testVar%></td>
      <td>Smith</td>
    </tr>
    <tr>
      <td>Eve</td>
      <td>Jackson</td>
    </tr>
    <tr>
      <td>Adam</td>
      <td>Johnson</td>
    </tr>
  </table>
            </div>
        <div class="col-4"></div>
   </div>
</asp:Content>


