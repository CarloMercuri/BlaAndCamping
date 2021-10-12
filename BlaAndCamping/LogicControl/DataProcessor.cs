using BlaAndCamping.DataControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping.LogicControl
{
    public class DataProcessor
    {
        private DatabaseInterface _dbInterface;


        public DataProcessor()
        {
            _dbInterface = new DatabaseInterface("esxi");
        }
        public CampingSpotTypeInformation GetSpotTypeInformation(int spotType)
        {
            return _dbInterface.GetCampingSpotTypeInformation(spotType);
        }

        public List<CampingSpotTypeInformation> GetSpotTypesInformation()
        {
            return _dbInterface.GetCampingSpotTypesInformation();
        }

        public List<int> GetAvailableSpotsDateType(DateTime startDate, DateTime endDate, int type)
        {
            return _dbInterface.GetAvailableSpotsDateType(startDate, endDate, type);
        }

    }


}