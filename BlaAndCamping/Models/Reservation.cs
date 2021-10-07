using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping.Models
{
    public class Reservation
    {
        private int spotID;

        public int SpotID
        {
            get { return spotID; }
            set { spotID = value; }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private int customerID;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private int reservationID;

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        private List<ReservationExtras> extras;

        public List<ReservationExtras> Extras
        {
            get { return extras; }
            set { extras = value; }
        }

        private int adults;

        public int Adults
        {
            get { return adults; }
            set { adults = value; }
        }

        private int children;

        public int Children
        {
            get { return children; }
            set { children = value; }
        }

        private int dogs;

        public int Dogs
        {
            get { return dogs; }
            set { dogs = value; }
        }




    }
}