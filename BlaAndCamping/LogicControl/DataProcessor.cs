using BlaAndCamping.DataControl;
using BlaAndCamping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BlaAndCamping.LogicControl
{
    public class DataProcessor
    {
        private DatabaseInterface _dbInterface;

        private SessionDataControl _sessionControl;


        public DataProcessor()
        {
            _sessionControl = new SessionDataControl();
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

        public void UpdateReservationStartDate(DateTime date)
        {
            _sessionControl.SetReservationStartDate(date);
        }

        public void UpdateReservationEndDate(DateTime date)
        {
            _sessionControl.SetReservationEndDate(date);
        }

        public void UpdateReservationSpotNumber(int number)
        {
            _sessionControl.SetReservationSpotNumber(number);
        }

        public void AddCustomerToSession(CustomerInformation customer)
        {

        }

        public bool ValidateEmailAddress(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

    }


}