using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping.Models
{
    public class Reservation
    {
        private int spotID;

        /// <summary>
        /// The number of the selected spot
        /// </summary>
        public int SpotID
        {
            get { return spotID; }
            set { spotID = value; }
        }

        private DateTime startDate;

        /// <summary>
        /// The start date with arrival time
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        /// <summary>
        /// The end date with departure time
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private int customerID;

        /// <summary>
        /// The ID of the customer associated with the reservation
        /// </summary>
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private int reservationID;

        /// <summary>
        /// The ID of the reservation
        /// </summary>
        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        private string spotName;

        public string SpotName
        {
            get { return spotName; }
            set { spotName = value; }
        }


        private List<ReservationExtra> extras;

        /// <summary>
        /// The Extras included in the reservation
        /// </summary>
        public List<ReservationExtra> Extras
        {
            get { return extras; }
            set { extras = value; }
        }

        private int adults; 

        /// <summary>
        /// The number of Adults included in the reservation
        /// </summary>
        public int Adults
        {
            get { return adults; }
            set { adults = value; }
        }

        private int children;

        /// <summary>
        /// The number of Children included in the reservation
        /// </summary>
        public int Children
        {
            get { return children; }
            set { children = value; }
        }

        private int dogs;

        /// <summary>
        /// The number of Dogs included in the reservation
        /// </summary>
        public int Dogs
        {
            get { return dogs; }
            set { dogs = value; }
        }

        private CustomerInformation customer;

        public CustomerInformation Customer
        {
            get { return customer; }
            set { customer = value; }
        }


        public Reservation()
        {

        }

        public int CalculateAmountDays()
        {
            return (int)(endDate - startDate).TotalDays;
        }


    }
}