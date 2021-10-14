using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping.Models
{
    public class ReservationPrices
    {
        private int adultDailyPrice;

        public int AdultDailyPrice
        {
            get { return adultDailyPrice; }
            set { adultDailyPrice = value; }
        }

        private int childrenDailyPrice;

        public int ChildrenDailyPrice
        {
            get { return childrenDailyPrice; }
            set { childrenDailyPrice = value; }
        }

        private int dogsDailyPrice;

        public int DogsDailyPrice
        {
            get { return dogsDailyPrice; }
            set { dogsDailyPrice = value; }
        }



    }
}