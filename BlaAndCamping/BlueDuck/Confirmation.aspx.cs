using BlaAndCamping.LogicControl;
using BlaAndCamping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class Confirmation : System.Web.UI.Page
    {

        public Reservation reservationInfo;
        public DataProcessor _processor;


        protected void Page_Load(object sender, EventArgs e)
        {
            _processor = new DataProcessor();

            ButtonGoToBooking.Width = Unit.Pixel(200);
            ButtonBookNow.Width = Unit.Pixel(200);
            reservationInfo = _processor.AssembleReservation();

            ButtonGoToBooking.Click += (senr, args) =>
            {
              
                Response.Redirect("Booking.aspx");
            };

            List<int> extraPrices = _processor.GetExtraPrices();

            int[] memberPrices = _processor.GetAllMemberPrices();


            LabelNumberOfAdultsConfirmation.Text = reservationInfo.Adults.ToString();
            LabelNumberOfChildrenConfirmation.Text = reservationInfo.Children.ToString();
            LabelNumberOfDdogsConfirmation.Text = reservationInfo.Dogs.ToString();
            LabelCustomerReservationIDConfirmed.Text = reservationInfo.ReservationID.ToString();
            LabelCustomerIDConfirmed.Text = reservationInfo.CustomerID.ToString();
            LabelCustomerCityConfirmed.Text = reservationInfo.Customer.City;
            LabelCustomerEmailConfirmed.Text = reservationInfo.Customer.Email;
            LabelCustomerNameConfirmed.Text = reservationInfo.Customer.FirstName + " " + reservationInfo.Customer.LastName;
            LabelCustomerZipCodeConfirmed.Text = reservationInfo.Customer.ZipCode;
            LabelCustomerOrderDateConfirmed.Text = DateTime.Now.ToString();
            LabelSpotNumberConfirmation.Text = reservationInfo.SpotID.ToString();
            LabelSpotTypeConfirmation.Text = reservationInfo.SpotName;
            LabelArrivalConfirmation.Text = reservationInfo.StartDate.ToString();
            LabelDepartureConfirmation.Text = reservationInfo.EndDate.ToString();
            LabelNumberOfAdultsConfirmation.Text = reservationInfo.Adults.ToString();
            LabelNumberOfChildrenConfirmation.Text = reservationInfo.Children.ToString();
            LabelNumberOfDdogsConfirmation.Text = reservationInfo.Dogs.ToString();

            LabelAdultPrice.Text = (memberPrices[0] * reservationInfo.Adults).ToString();
            LabelChildrenPrice.Text = (memberPrices[1] * reservationInfo.Children).ToString();
            LabelDogsPrice.Text = (memberPrices[2] * reservationInfo.Dogs).ToString();

            int spotPrice = 0;

            if(_processor.GetCorrectSeason() == 0)
            {
               spotPrice = _processor.GetSpotTypeInformation(_processor.GetReservationSelectedType()).LowSeasonDailyPrice;
            }
            else
            {
                spotPrice = _processor.GetSpotTypeInformation(_processor.GetReservationSelectedType()).HighSeasonDailyPrice;
            }

            LabelSpotPrice.Text = (spotPrice * reservationInfo.CalculateAmountDays()).ToString();


      
            


        }
    }
}