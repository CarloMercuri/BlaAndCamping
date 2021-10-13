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

        /// <summary>
        /// Returns information about a specific spot type
        /// </summary>
        /// <param name="spotType"></param>
        /// <returns></returns>
        public CampingSpotTypeInformation GetSpotTypeInformation(int spotType)
        {
            return _dbInterface.GetCampingSpotTypeInformation(spotType);
        }

        /// <summary>
        /// Returns a list of info about all the spot types
        /// </summary>
        /// <returns></returns>
        public List<CampingSpotTypeInformation> GetSpotTypesInformation()
        {
            return _dbInterface.GetCampingSpotTypesInformation();
        }

        /// <summary>
        /// Returns a list of id's of the spots of a specifit type, available in a specified time frame
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<int> GetAvailableSpotsDateType(DateTime startDate, DateTime endDate, int type)
        {
            return _dbInterface.GetAvailableSpotsDateType(startDate, endDate, type);
        }

        public List<CampingSpotTypeInformation> GetAvaibleSpotTypesInDates(DateTime startDate, DateTime endDate)
        {
            return _dbInterface.GetAvaibleSpotTypesInDates(startDate, endDate);
        }

        public void SetCustomerInformation(CustomerInformation customer)
        {
            _sessionControl.SetCustomerInformation(customer);
        }

        public int GetReservationSelectedType()
        {
            return _sessionControl.GetReservationSelectedType();
        }

        public void SetReservationSelectedType(int i)
        {
            _sessionControl.SetReservationSelectedType(i);
        }

        /// <summary>
        /// Sets the reservation start date in the session
        /// </summary>
        /// <param name="date"></param>
        public void SetReservationStartDate(DateTime date)
        {
            // Automatically sets the arrival time to 13:00
            date = date.AddHours(13);
            _sessionControl.SetReservationStartDate(date);
        }

        /// <summary>
        /// Sets the reservation end date in the session
        /// </summary>
        /// <param name="date"></param>
        public void SetReservationEndDate(DateTime date)
        {
            // Automatically sets the leave time to 10:00
            date = date.AddHours(10);
            _sessionControl.SetReservationEndDate(date);
        }

        public DateTime GetReservationStartDate()
        {
            return _sessionControl.GetReservationStartDate();
        }

        public DateTime GetReservationEndDate()
        {
            return _sessionControl.GetReservationEndDate();
        }

        public void InitializeReservation()
        {
            _sessionControl.InitializeReservation();
        }

        /// <summary>
        /// Sets the reservation spot number in the session
        /// </summary>
        /// <param name="number"></param>
        public void SetReservationSpotNumber(int number)
        {
            _sessionControl.SetReservationSpotNumber(number);
        }

        public int GetReservationSpotNumber()
        {
            return _sessionControl.GetReservationSpotNumber();
        }

        public void SetSessionVariable<T>(string name, T value)
        {
            _sessionControl.SetSessionVariable(name, value);
        }


        public void AddCustomerToSession(CustomerInformation customer)
        {

        }

        /// <summary>
        /// Returns true if the email is valid
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool ValidateEmailAddress(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

    }


}