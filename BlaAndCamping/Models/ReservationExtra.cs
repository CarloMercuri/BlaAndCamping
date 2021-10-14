using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping
{
    public class ReservationExtra
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
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