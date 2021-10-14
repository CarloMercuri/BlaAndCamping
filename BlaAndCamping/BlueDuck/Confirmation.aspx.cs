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

            //ButtonGoToBooking.Width = Unit.Pixel(200);
            //ButtonBookNow.Width = Unit.Pixel(200);
            reservationInfo = _processor.AssembleReservation();

            btn_Submit.Click += (s, args) =>
            {
                _processor.FinalizeBooking(reservationInfo);
                Response.Redirect("OrderConfirmed.aspx");
            };

            if (!IsPostBack)
            {

            }


            List<int> extraPrices = _processor.GetExtraPrices();

            int[] memberPrices = _processor.GetAllMemberPrices();
            int totalPrice = 0;


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

            int aPrice = memberPrices[0] * reservationInfo.Adults;
            int cPrice = memberPrices[1] * reservationInfo.Children;
            int dPrice = memberPrices[2] * reservationInfo.Dogs;

            totalPrice += aPrice + cPrice + dPrice;

            LabelAdultPrice.Text = FormatPriceTag(aPrice);
            LabelChildrenPrice.Text = FormatPriceTag(cPrice);
            LabelDogsPrice.Text = FormatPriceTag(dPrice);



            int spotPrice = 0;

            if(_processor.GetCorrectSeason() == 0)
            {
               spotPrice = _processor.GetSpotTypeInformation(_processor.GetReservationSelectedType()).LowSeasonDailyPrice;
            }
            else
            {
                spotPrice = _processor.GetSpotTypeInformation(_processor.GetReservationSelectedType()).HighSeasonDailyPrice;
            }

            spotPrice = spotPrice * reservationInfo.CalculateAmountDays();
            totalPrice += spotPrice;

            LabelSpotPrice.Text = FormatPriceTag(spotPrice);

            //0 = bicycle, 1 = bedsheets, 2 = end cleaning, 3 = waterpark adult, 4 = waterpark children

            LabelWaterparkAdultConfirmation.Text = reservationInfo.CountExtraOfType(3).ToString();

            int wpAdultPrice = reservationInfo.CountExtraOfType(3) * extraPrices[3];
            LabelWaterparkAdultPrice.Text = FormatPriceTag(wpAdultPrice);
            totalPrice += wpAdultPrice;

            LabelWaterparkChildrenConfirmation.Text = reservationInfo.CountExtraOfType(4).ToString();

            int wpChildrenPrice = reservationInfo.CountExtraOfType(4) * extraPrices[4];
            LabelWaterparkChildrenPrice.Text = FormatPriceTag(wpChildrenPrice);
            totalPrice += wpChildrenPrice;

            LabelBicycleRentConfirmation.Text = reservationInfo.CountExtraOfType(0).ToString();

            int bicPrice = reservationInfo.CountExtraOfType(0) * extraPrices[0];
            LabelBicycleRentPrice.Text = FormatPriceTag(bicPrice);
            totalPrice += bicPrice;

            LabelBeddingConfirmation.Text = reservationInfo.CountExtraOfType(1).ToString();

            int bedPrice = reservationInfo.CountExtraOfType(1) * extraPrices[1];
            LabelBeddingPrice.Text = FormatPriceTag(bedPrice);
            totalPrice += bedPrice;

            if(reservationInfo.CountExtraOfType(2) > 0)
            {
                LabelEndCleaningConfirmation.Text = "Yes";
                LabelEndCleaningPrice.Text = FormatPriceTag(extraPrices[2]);
                totalPrice += extraPrices[2];
            }
            else
            {
                LabelEndCleaningConfirmation.Text = "No";
                LabelEndCleaningPrice.Text = FormatPriceTag(0);
            }

            LabelTotalPrice.Text = FormatPriceTag(totalPrice);


        }

        protected void btnSendClick(object sender, EventArgs e)
        {
            _processor.FinalizeBooking(reservationInfo);
            Response.Redirect("OrderConfirmed.aspx");
        }

        private string FormatPriceTag(int price)
        {
            return $"{price},-DKK";
        }

        protected void btn_BookClick(object sender, EventArgs e)
        {
            _processor.FinalizeBooking(reservationInfo);
            Response.Redirect("OrderConfirmed.aspx");
        }
    }
}