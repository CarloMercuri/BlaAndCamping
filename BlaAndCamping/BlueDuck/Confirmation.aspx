<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Booking.Master" CodeBehind="Confirmation.aspx.cs" Inherits="BlaAndCamping.BlueDuck.Confirmation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--LOGO, HEADER & DESCRIPTION-->

    <div class="row">
        <div class="col-2"></div>
        <div class="col-8 content">
            <img src="/images/blue_duck.png" alt="Blue Duck Logo" style="width: 100px;" />
            <h1>Ordrebekræftelse</h1>
            <h3>Tak fordi du har booket din ferie hos os!</h3>
            <h3>Vi har modtaget din bestilling og nedenfor kan du se dine oplysninger.</h3>
            <h6>Kontakt os hurtigst muligt hvis du måtte opleve at der er fejl på din ordrebekræftelse ved at sende os en 
                <a href="kontakt@campdba.dk" target="_blank">mail</a>.
            </h6>

            <br />
            <hr />
            <br />
            <!-- Personal information confirmation -->
            <h3>Dine personlige oplysninger:</h3>

            <div class="w3-container">
                <table class="w3-table-all w3-small">
                    <tr>
                        <th>
                            <asp:Label ID="LabelReservationID" runat="server" Text="Label">Bookingnummer</asp:Label>
                        </th>
                        <td >
                            <asp:Label ID="LabelCustomerReservationIDConfirmed" runat="server" Text="Label"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelOrderDate" runat="server" Text="Label">Bestillingsdato</asp:Label>
                        </th>
                        <td >
                            <asp:Label ID="LabelCustomerOrderDateConfirmed" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>

                   <tr>
                        <th>
                            <asp:Label ID="LabelName" runat="server" Text="Label">Navn</asp:Label>
                        </th>
                        <td >
                            <asp:Label ID="LabelCustomerNameConfirmed" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label ID="LabelAddress" runat="server" Text="Label">Adresse</asp:Label>
                        </th>
                        <td >
                            <asp:Label ID="LabelCustomerAddressConfirmed" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label ID="LabelZipCode" runat="server" Text="Label">Postnummer</asp:Label>
                        </th>
                        <td >
                            <asp:Label ID="LabelCustomerZipCodeConfirmed" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label ID="LabelCity" runat="server" Text="Label">By</asp:Label>
                        </th>
                        <td >
                            <asp:Label ID="LabelCustomerCityConfirmed" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelEmail" runat="server" Text="Label">E-mail adresse</asp:Label>
                        </th>
                        <td >
                            <asp:Label ID="LabelCustomerEmailConfirmed" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <br />
            <hr />
            <br />
            <!-- Spot specifics confirmation -->
            <h3>Specifikation:</h3>

            <div class="w3-container">
                <table class="w3-table-all w3-small">
                    <tr>
                        <th></th>
                        <th></th>
                        <th>
                            <asp:Label ID="LabelHeaderPrice" runat="server" Text="Label">Pris</asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelSpotNumber" runat="server" Text="Label">Pladsnr.</asp:Label>
                        </th>
                        <td colspan="2">
                            <asp:Label ID="LabelSpotNumberConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelArrival" runat="server" Text="Label">Ankomst</asp:Label>
                        </th>
                        <td colspan="2">
                            <asp:Label ID="LabelArrivalConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelDeparture" runat="server" Text="Label">Afrejse</asp:Label>
                        </th>
                        <td colspan="2">
                            <asp:Label ID="LabelDepartureConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelSpotType" runat="server" Text="Label">Type</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelSpotTypeConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelSpotPrice" runat="server" Text="Label"></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelNumberOfAdults" runat="server" Text="Label">Antal voksne</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelNumberOfAdultsConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelAdultPrice" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>

                    <tr>

                        <th>
                            <asp:Label ID="LabelNumberOfChildren" runat="server" Text="Label">Antal børn</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelNumberOfChildrenConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelChildrenPrice" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label ID="LabelNumberOfDdogs" runat="server" Text="Label">Antal hunde</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelNumberOfDdogsConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelDogsPrice" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelWaterparkAdult" runat="server" Text="Label">Adgang til vandland, voksen</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelWaterparkAdultConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelWaterparkAdultPrice" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelWaterparkChildren" runat="server" Text="Label">Adgang til vandland, barn</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelWaterparkChildrenConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelWaterparkChildrenPrice" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelBicycleRent" runat="server" Text="Label">Cykelleje</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelBicycleRentConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelBicycleRentPrice" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelBedding" runat="server" Text="Label">Sengelinned (ved bestilling af hytte)</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelBeddingConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelBeddingPrice" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="LabelEndCleaning" runat="server" Text="Label">Slutrengøring (ved bestilling af hytte)</asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelEndCleaningConfirmation" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelEndCleaningPrice" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="label_DiscountReason" runat="server" Text="Discount"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="label_DiscountTotal" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label ID="LabelEmpty" runat="server" Text=""></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelIAlt" runat="server" Text="Label">I alt:</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelTotalPrice" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                </table>
                <br />
                <div>
                    <asp:Button ID="ButtonGoToBooking" runat="server" style="width: 250px;" Text="Gå tilbage til Bestilling" />
                    
                <%--<asp:Button Text="Book nu" ID="btn_Submit" runat="server" CausesValidation="False" OnClick="btn_BookClick" />--%>
                <asp:Button Text="Book nu" ID="btn_Submit" runat="server" CausesValidation="False"/>
                </div>
                
                   
            </div>
        </div>
        <div class="col-2"></div>

    </div>
    <br />
    <br />



</asp:Content>
