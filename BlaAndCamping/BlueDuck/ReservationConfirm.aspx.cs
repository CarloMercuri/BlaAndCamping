using BlaAndCamping.LogicControl;
using BlaAndCamping.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class ReservationConfirm : System.Web.UI.Page
    {
        SessionDataControl _sessionControl;
        DataProcessor _processor;
        private bool isEmailValid;
                
        protected void Page_Load(object sender, EventArgs e)
        {
            _processor = new DataProcessor();

            _sessionControl = new SessionDataControl();

            //Reservation reservation = _sessionControl.GetReservation();
            Reservation reservation = new Reservation();

            reservation.SpotID = 2;
            reservation.StartDate = DateTime.Now;
            reservation.EndDate = DateTime.Now;
            reservation.EndDate.AddDays(5);
            

            h3_Summary.InnerText = $"Du har valgt plads: {reservation.SpotID}, Ankomst: {reservation.StartDate}, Afrejse: {reservation.EndDate}";
            tBox_FirstName.BorderColor = System.Drawing.Color.Gray;
            tBox_LastName.BorderColor = System.Drawing.Color.Gray;
            tBox_Email.BorderColor = System.Drawing.Color.Gray;
            tBox_ZipCode.BorderColor = System.Drawing.Color.Gray;
            tBox_City.BorderColor = System.Drawing.Color.Gray;

            label_EmailError.Text = "   Invalid email address.";
            label_PostNumberError.Text = "   Invalid post number, must only contain numbers.";
            label_PostNumberError.ForeColor = System.Drawing.Color.Red;

            if (ValidateForm())
            {
                CustomerInformation customer = new CustomerInformation(tBox_FirstName.Text,
                                                                       tBox_LastName.Text,
                                                                       tBox_Email.Text,
                                                                       tBox_ZipCode.Text,
                                                                       tBox_City.Text);

                _sessionControl.SetCustomerInformation(customer);

                Response.Redirect("ReservationAccept.aspx?");
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;

            if (!IsInputOnlyDigits(tBox_ZipCode.Text))
            {
                label_PostNumberError.Visible = true;
                tBox_ZipCode.BorderColor = System.Drawing.Color.Red;
                isValid = false;
            } else
            {
                label_PostNumberError.Visible = false;
                tBox_ZipCode.BorderColor = System.Drawing.Color.Gray;
            }

            if (!ValidateEmailAddress())
            {
                isValid = false;
            }

            return isValid;

        }

        /// <summary>
        /// Returns true if the string only contains digits
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsInputOnlyDigits(string input)
        {
            foreach (char c in input)
            {
                // check that it's a number (unicode)
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private bool ValidateEmailAddress()
        {
            if(tBox_Email.Text.Length == 0)
            {
                label_EmailError.Visible = false;
                tBox_Email.BorderColor = System.Drawing.Color.Gray;
                isEmailValid = false;
                return false;
            }

            if(!_processor.ValidateEmailAddress(tBox_Email.Text))
            {
                label_EmailError.Visible = true;
                label_EmailError.ForeColor = System.Drawing.Color.Red;
                //tBox_Email.BorderWidth = 2;
                //tBox_Email.BorderStyle = BorderStyle.Ridge;
                tBox_Email.BorderColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                label_EmailError.Visible = false;
                tBox_Email.BorderColor = System.Drawing.Color.Gray;
                return true;
            }
        }
    }
}