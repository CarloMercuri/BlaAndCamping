using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping
{
    public class ReservationExtra
    {
        private int id;

        /// <summary>
        /// 0 = bicycle, 1 = bedsheets, 2 = end cleaning, 3 = waterpark adult, 4 = waterpark children
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int reservationID;

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }


        private int days;

        public int Days
        {
            get { return days; }
            set { days = value; }
        }

        private int dailyPrice;

        public int DailyPrice
        {
            get { return dailyPrice; }
            set { dailyPrice = value; }
        }


        public ReservationExtra(int id, int days)
        {
            this.id = id;
            this.days = days;
        }


    }
}