<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="Prices.aspx.cs" Inherits="BlaAndCamping.BlueDuck.Prices" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SitePrices"></asp:DataList>
        <asp:SqlDataSource ID="SitePrices" runat="server"></asp:SqlDataSource>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6 content">
            <h1>Prisoversigt</h1>
            <br />
            <h6>Højsæson: 14. juni til 15. august </h6> 
              <h6> Lavsæson: 1. januar til 14. juni og 15. august til 31. december.</h6>
            <br />
            <div class="w3-container">


                <table class="w3-table-all w3-small">
                    <tr>
                        <th>
                           Campingplads (campingvogn/autocamper)*
                        </th>
                        <th>
                            Højsæson/Lavsæson
                        </th>               
                    </tr>
                    <tr>
                        <td>Pladsgebyr (almindelig plads) pr. døgn m. strøm</td>
                        <td>DKK kr. <%=regularSpot.HighSeasonDailyPrice%>,- / <%=regularSpot.LowSeasonDailyPrice%>,-</td>
                    </tr>
                    <tr>
                        <td>Pladsgebyr (almindelig plads + udsigt) pr. døgn m. strøm</td>
                        <td>DKK kr. <%=regularSpotView.HighSeasonDailyPrice%>,- / <%=regularSpotView.LowSeasonDailyPrice%>,-</td>
                    </tr>
                    <tr>
                        <td>Pladsgebyr (komfort plads) pr. døgn m. strøm</td>
                        <td>DKK kr. <%=comfortSpot.HighSeasonDailyPrice%>,- / <%=comfortSpot.LowSeasonDailyPrice%>,-</td>
                    </tr>
                    <tr>
                        <td>Pladsgebyr (komfort plads + udsigt) pr. døgn m. strøm</td>
                        <td>DKK kr. <%=comfortSpotView.HighSeasonDailyPrice%>,- / <%=comfortSpotView.LowSeasonDailyPrice%>,-</td>
                    </tr>

                     <tr>
                        <th>
                           Teltplads*
                        </th>
                        <th>
                            Højsæson/Lavsæson
                        </th>               
                    </tr>

                    <tr>
                        <td>Pladsgebyr  pr. døgn m. strøm</td>
                        <td>DKK kr. <%=tent.HighSeasonDailyPrice%>,- / <%=tent.LowSeasonDailyPrice%>,-</td>
                    </tr>

                    <tr>
                        <th>
                           Hytter*
                        </th>
                        <th>
                            Højsæson/Lavsæson
                        </th>               
                    </tr>

                    <tr>
                        <td>Standard hytte (4 pers.) pr. døgn m. strøm</td>
                        <td>DKK kr. <%=regularCabin.HighSeasonDailyPrice%>,- / <%=regularCabin.LowSeasonDailyPrice%>,-</td>
                    </tr>
                    <tr>
                        <td>Luksus hytte (6 pers.) pr. døgn m. strøm</td>
                        <td>DKK kr. <%=luxuryCabin.HighSeasonDailyPrice%>,- / <%=luxuryCabin.LowSeasonDailyPrice%>,-</td>
                    </tr>

                    <tr>
                        <th>
                           Pris pr. voksen/barn/hund
                        </th>
                        <th>
                            Højsæson/Lavsæson
                        </th>               
                    </tr>

                    <tr>
                        <td>Voksen</td>
                        <td>DKK kr. <%=regularCabin.HighSeasonDailyPrice%>,- / <%=regularCabin.LowSeasonDailyPrice%>,-</td>
                    </tr>
                    <tr>
                        <td>Barn</td>
                        <td>DKK kr. <%=luxuryCabin.HighSeasonDailyPrice%>,- / <%=luxuryCabin.LowSeasonDailyPrice%>,-</td>
                    </tr>
                    <tr>
                        <td>Hund</td>
                        <td>DKK kr. <%=luxuryCabin.HighSeasonDailyPrice%>,- / <%=luxuryCabin.LowSeasonDailyPrice%>,-</td>
                    </tr>

                    <tr>
                        <th>
                           Sæsonpladser
                        </th>
                        <th>
                            Pris
                        </th>               
                    </tr>
                    <tr>
                        <td>Forår (1. april til 30. juni)</td>
                        <td>DKK kr. -- ,-</td>
                    </tr>
                    <tr>
                        <td>Sommer (1. april til 30. september)</td>
                        <td>DKK kr. -- ,-</td>
                    </tr>
                    <tr>
                        <td>Efterår (15. august til 31. oktober)</td>
                        <td>DKK kr. -- ,-</td>
                    </tr>
                    <tr>
                        <td>Vinter (1. oktober til 31. marts)</td>
                        <td>DKK kr. -- ,-</td>
                    </tr>

                    <tr>
                        <th>
                           Tillæg
                        </th>
                        <th>
                            Pris
                        </th>               
                    </tr>

                    <tr>
                        <td>Sengelinned (pr. ophold)</td>
                        <td>DKK kr. -- ,-</td>
                    </tr>
                    <tr>
                        <td>Slutrengøring (hytter)**</td>
                        <td>DKK kr. -- ,-</td>
                    </tr>
                    <tr>
                        <td>
                            Cykelleje (pr. dag)
                        </td>
                        <td>DKK kr. -- ,-</td>
                    </tr>
                    <tr>
                        <td>Adgang til vandland (voksen)</td>
                        <td>DKK kr. -- ,-</td>
                    </tr>
                    <tr>
                        <td>Adgang til vandland (barn)</td>
                        <td>DKK kr. -- ,-</td>
                    </tr>

                    <tr>
                        <td colspan="2">* Der skal altid lægges personpriser oven i pladsgebyr</td>
                    </tr>
                    <tr>
                        <td colspan="2">** Priser på personer og hund er inklusiv i prisen for sæsonspladsen</td>
                    </tr>
                    
                </table>
            </div>

        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
