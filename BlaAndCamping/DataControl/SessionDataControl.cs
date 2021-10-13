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
            Reservation r = new Reservation();
            r.Adults = (int)HttpContext.Current.Session["reservation_Adults"];
            r.Children = (int)HttpContext.Current.Session["reservation_Children"];
            r.Dogs = (int)HttpContext.Current.Session["reservation_Dogs"];

            r.CustomerID = (int)HttpContext.Current.Session["reservation_CustomerID"];
            r.StartDate = (DateTime)HttpContext.Current.Session["reservation_StartDate"];
            r.EndDate = (DateTime)HttpContext.Current.Session["reservation_EndDate"];
            r.SpotID = (int)HttpContext.Current.Session["reservation_SpotNumber"];


            return r;
        }

        /// <summary>
        /// Resets any stored value and makes it ready for a new reservation
        /// </summary>
        public void ResetReservation()
        {
            SetReservationMembers(0, 0, 0);
            SetReservationStartDate(DateTime.MinValue);
            SetReservationEndDate(DateTime.MinValue);
            SetReservationSpotNumber(-1);
            SetReservationSelectedType(-1);
            SetReservationCustomerID(-1);
        }

        /// <summary>
        /// Sets the specified amount of adults, children and dogs to the existing reservation
        /// </summary>
        /// <param name="adults"></param>
        /// <param name="children"></param>
        /// <param name="dogs"></param>
        public void SetReservationMembers(int adults, int children, int dogs)
        {
            HttpContext.Current.Session["reservation_Adults"] = adults;
            HttpContext.Current.Session["reservation_Children"] = children;
            HttpContext.Current.Session["reservation_Dogs"] = dogs;
        }

        /// <summary>
        /// Stores the reservation start date in session
        /// </summary>
        /// <param name="startDate"></param>
        public void SetReservationStartDate(DateTime startDate)
        {
            HttpContext.Current.Session["reservation_StartDate"] = startDate;
        }

        /// <summary>
        /// Returns the start date stored in session
        /// </summary>
        /// <returns></returns>
        public DateTime GetReservationStartDate()
        {
            return (DateTime)HttpContext.Current.Session["reservation_StartDate"];
        }

        /// <summary>
        /// Stores the reservation end date in session
        /// </summary>
        /// <param name="endDate"></param>
        public void SetReservationEndDate(DateTime endDate)
        {
            HttpContext.Current.Session["reservation_EndDate"] = endDate;
        }

        /// <summary>
        /// Returns the end date stored in session
        /// </summary>
        /// <returns></returns>
        public DateTime GetReservationEndDate()
        {
            return (DateTime)HttpContext.Current.Session["reservation_EndDate"];
        }

        /// <summary>
        /// Stores the reservation spot number in session
        /// </summary>
        /// <param name="number"></param>
        public void SetReservationSpotNumber(int number)
        {
            HttpContext.Current.Session["reservation_SpotNumber"] = number;
        }

        /// <summary>
        /// Returns the reservation spot number stored in session
        /// </summary>
        /// <param name="number"></param>
        public int GetReservationSpotNumber()
        {
            return (int)HttpContext.Current.Session["reservation_SpotNumber"];
        }

        /// <summary>
        /// Stores the reservation customer id in session
        /// </summary>
        /// <param name="id"></param>
        public void SetReservationCustomerID(int id)
        {
            HttpContext.Current.Session["reservation_CustomerID"] = id;
        }

        /// <summary>
        /// Stores the selected type in session
        /// </summary>
        /// <param name="type"></param>
        public void SetReservationSelectedType(int type)
        {
            HttpContext.Current.Session["reservation_SelectedType"] = type;
        }

        /// <summary>
        /// Returns the selected type stored in session
        /// </summary>
        /// <param name="type"></param>
        public int GetReservationSelectedType()
        {
            return (int)HttpContext.Current.Session["reservation_SelectedType"];
        }

        /// <summary>
        /// Returns the reservation customer id stored in session
        /// </summary>
        /// <param name="id"></param>
        public int GetReservationCustomerID()
        {
            return (int)HttpContext.Current.Session["reservation_CustomerID"];

        }

        public void AddReservationExtra(ReservationExtras extra)
        {
         //   CurrentReservation.Extras.Add(extra);
        }

        public void SetCustomerInformation(CustomerInformation customer)
        {
            HttpContext.Current.Session["customerInformation"] = customer;
        }

        /// <summary>
        /// Stores a specified variable in session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetSessionVariable<T>(string name, T value)
        {
            HttpContext.Current.Session[name] = value;
        }

        /// <summary>
        /// Gets a specified variable stored in session
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetSessionVariable(string name)
        {
            return HttpContext.Current.Session[name];
        }

        public CustomerInformation GetCustomerInformation()
        {
            return (CustomerInformation)HttpContext.Current.Session["customerInformation"];
        }

        
    }
}