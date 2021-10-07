using BlaAndCamping.DataControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping.LogicControl
{
    public static class DataProcessor
    {
        private static DatabaseInterface _dbInterface = new DatabaseInterface("local");

        public static CampingSpotTypeInformation GetSpotTypeInformation(int spotType)
        {
            return _dbInterface.GetCampingSpotTypeInformation(spotType);
        }

    }


}