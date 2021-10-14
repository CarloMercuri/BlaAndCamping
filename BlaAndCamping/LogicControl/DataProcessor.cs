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

        public int[] GetAllMemberPrices()
        {
            return _dbInterface.GetAllMemberPrices(GetCorrectSeason());
        }

        public int[] GetAllMemberPricesInSeason(int season)
        {
            return _dbInterface.GetAllMemberPrices(season);
        }

        public int GetCorrectSeason()
        {
            DateTime currentDate = DateTime.Now;

            string year = currentDate.Year.ToString();

            DateTime startHighSeason = DateTime.Parse($"14-06-{year}");
            DateTime endHighSeason = DateTime.Parse($"15-08-{year}");

            if (currentDate >= startHighSeason && currentDate <= endHighSeason)
           {
              return 1;
           }
           else
            {
                return 0;
            }
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

        public int InsertReservation(Reservation reservation)
        {
            return _dbInterface.InsertReservation(reservation);
        }

        public List<Reservation> GetReservations()
        {
            return _dbInterface.GetReservations();
        }

        public Reservation AssembleReservation()
        {
            Reservation r = new Reservation();
            r.Adults = _sessionControl.GetReservationMembers((int)ReservationExtraID.Adult); // adults
            r.Children = _sessionControl.GetReservationMembers((int)ReservationExtraID.Child);
            r.Dogs = _sessionControl.GetReservationMembers((int)ReservationExtraID.Dog);
            r.Customer = _sessionControl.GetCustomerInformation();
            r.CreatedDate = DateTime.Now;
            r.CustomerID = GetCustomer(r.Customer.Email);
            r.StartDate = _sessionControl.GetReservationStartDate();
            r.EndDate = _sessionControl.GetReservationEndDate();
            r.SpotID = _sessionControl.GetReservationSpotNumber();


            r.Extras = new List<ReservationExtra>();

            r.SpotName = _dbInterface.GetCampingSpotTypeInformation(_sessionControl.GetReservationSelectedType()).SpotName;

            // 0 = bycicle
            for (int i = 0; i < GetReservationExtra(0); i++)
            {
                ReservationExtra extra = new ReservationExtra(0, r.CalculateAmountDays());
                r.Extras.Add(extra);
            }


            // 1 = bedsheets
            for (int i = 0; i < GetReservationExtra(1); i++)
            {
                ReservationExtra extra = new ReservationExtra(1, r.CalculateAmountDays());
                r.Extras.Add(extra);
            }


            // 2 = end cleaning
            if (GetReservationExtra(2) == 1)
            {
                ReservationExtra extra = new ReservationExtra(2, r.CalculateAmountDays());
                r.Extras.Add(extra);
            }


            // 3 = waterpark adult
            for (int i = 0; i < GetReservationExtra(3); i++)
            {
                ReservationExtra extra = new ReservationExtra(3, r.CalculateAmountDays());
                r.Extras.Add(extra);
            }


            // 4 = waterpark children
            for (int i = 0; i < GetReservationExtra(4); i++)
            {
                ReservationExtra extra = new ReservationExtra(4, r.CalculateAmountDays());
                r.Extras.Add(extra);
            }


            return r;
        }

        public void FinalizeBooking(Reservation reservation)
        {
            int reservationID = _dbInterface.InsertReservation(reservation);

            // extras

            foreach(ReservationExtra extra in reservation.Extras)
            {
                _dbInterface.InsertReservationExtra(extra, reservationID);
            }
        }

        public Reservation GetReservationFromDatabase()
        {
            return _dbInterface.GetReservation();
        }

        public int GetCustomer(string email)
        {
            return _dbInterface.Getcustomer(email);
        }

        public void SetReservationExtra(int id, int amount)
        {
            _sessionControl.SetReservationExtra(id, amount);
        }

        public int GetReservationExtra(int id)
        {
            return _sessionControl.GetReservationExtra(id);
        }

        public void SetReservationMember(int id, int amount)
        {
            _sessionControl.SetReservationMember(id, amount);
        }

        public void SetReservationMembers(int adults, int children, int dogs)
        {
            _sessionControl.SetReservationMembers(adults, children, dogs);
        }

        public int GetReservationMembers(int id)
        {
            return _sessionControl.GetReservationMembers(id);
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

        public List<int> GetExtraPrices()
        {
            return _dbInterface.GetExtraPrices();
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