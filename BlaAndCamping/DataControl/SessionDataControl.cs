using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BlaAndCamping.Models;

namespace BlaAndCamping
{
    public class SessionDataControl
    {
        
        private Reservation CurrentReservation
        {
            get { return (Reservation)HttpContext.Current.Session["mainReservation"]; }
        }

        public Reservation GetReservation()
        {
            return CurrentReservation;
        }

        public void CreateReservation()
        {
            HttpContext.Current.Session["mainReservation"] = new Reservation();
            CurrentReservation.Extras = new List<ReservationExtras>();
        }

        /// <summary>
        /// Add the specified amount of adults, children and dogs to the existing reservation, on top of the already existing ones
        /// </summary>
        /// <param name="adults"></param>
        /// <param name="children"></param>
        /// <param name="dogs"></param>
        public void AddReservationMembers(int adults, int children, int dogs)
        {
            CurrentReservation.Adults += adults;
            CurrentReservation.Children += children;
            CurrentReservation.Dogs += dogs;
        }

        public void SetReservationStartDate(DateTime startDate)
        {
            // Automatically sets the arrival time to 13:00
            startDate = startDate.AddHours(13);
            CurrentReservation.StartDate = startDate;
        }

        public void SetReservationEndDate(DateTime endDate)
        {
            // Automatically sets the leave time to 10:00
            endDate = endDate.AddHours(10);
            CurrentReservation.EndDate = endDate;
        }

        public void SetReservationSpotNumber(int number)
        {
            CurrentReservation.SpotID = number;
        }

        public void SetReservationCustomerID(int id)
        {
            CurrentReservation.CustomerID = id;
        }

        public void AddReservationExtra(ReservationExtras extra)
        {
            CurrentReservation.Extras.Add(extra);
        }

        public object GetSessionVariable(string name)
        {
            return HttpContext.Current.Session[name];
        }

        public void SetSessionVariable<T>(string name, T value)
        {
            HttpContext.Current.Session[name] = value;
        }

        public void SetCustomerInformation(CustomerInformation customer)
        {
            HttpContext.Current.Session["customerInformation"] = customer;
        }

        public CustomerInformation GetCustomerInformation()
        {
            return (CustomerInformation)HttpContext.Current.Session["customerInformation"];
        }

        
    }
}