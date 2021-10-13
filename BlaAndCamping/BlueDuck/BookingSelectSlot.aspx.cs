using BlaAndCamping.LogicControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class BookingSelectSlot : System.Web.UI.Page
    {
        SessionDataControl _sessionControl;
        DataProcessor _processor;

        protected void Page_Load(object sender, EventArgs e)
        {
            _processor = new DataProcessor();
            _sessionControl = new SessionDataControl();

            //List<int> aviableSpotNumbers = _processor.GetAvailableSpotsDateType(_processor.GetReservationStartDate(),
            //                                                                    _processor.GetReservationEndDate(),
            //                                                                    _processor.GetReservationSelectedType());

            List<int> aviableSpotNumbers = new List<int>();
            aviableSpotNumbers.Add(3);
            aviableSpotNumbers.Add(2);
            aviableSpotNumbers.Add(10);
            aviableSpotNumbers.Add(89);
            aviableSpotNumbers.Add(123);
            aviableSpotNumbers.Add(42);
            aviableSpotNumbers.Add(2);
            aviableSpotNumbers.Add(3);
            aviableSpotNumbers.Add(9);
            aviableSpotNumbers.Add(199);
            aviableSpotNumbers.Add(124);
            aviableSpotNumbers.Add(101);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);
            aviableSpotNumbers.Add(87);


            AddSpotSelectionButtons(aviableSpotNumbers);
        }

        private void AddSpotSelectionButtons(List<int> aviableSpotNumbers)
        {
            foreach (int number in aviableSpotNumbers)
            {
                Button btn = new Button();
                btn.Text = number.ToString();
                btn.CssClass = "booking-spot-button";
                buttonsContainer.Controls.Add(btn);

                btn.Click += (sender, args) =>
                {
                    _processor.SetReservationSpotNumber(number);

                    Response.Redirect("BookingCustomerData.aspx");
                };
            }


        }
    }
}