using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping
{
    public class CampingSpotTypeInformation
    {
        private int spotType;

        public int SpotType
        {
            get { return spotType; }
            set { spotType = value; }
        }

        private string spotDescription;

        public string SpotDescription
        {
            get { return spotDescription; }
            set { spotDescription = value; }
        }

        private string spotName;

        public string SpotName
        {
            get { return spotName; }
            set { spotName = value; }
        }

        private int squareMeters;

        public int SquareMeters
        {
            get { return squareMeters; }
            set { squareMeters = value; }
        }

        private int maxPeople;

        public int MaxPeople
        {
            get { return maxPeople; }
            set { maxPeople = value; }
        }

        private int lowSeasonDailyPrice;

        public int LowSeasonDailyPrice
        {
            get { return lowSeasonDailyPrice; }
            set { lowSeasonDailyPrice = value; }
        }

        private int highSeasonDailyPrice;

        public int HighSeasonDailyPrice
        {
            get { return highSeasonDailyPrice; }
            set { highSeasonDailyPrice = value; }
        }




        public CampingSpotTypeInformation(string spotName, string spotDescription, int spotType, int squareMeters, int maxPeople)
        {
            this.spotType = spotType;
            this.spotDescription = spotDescription;
            this.spotName = spotName;
            this.squareMeters = squareMeters;
            this.maxPeople = maxPeople;
        }

        public CampingSpotTypeInformation()
        {

        }

    }
}