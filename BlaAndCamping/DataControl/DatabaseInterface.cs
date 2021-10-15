using BlaAndCamping.Models;
using BlaAndCamping.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlaAndCamping.DataControl
{
    public class DatabaseInterface
    {
        private string connectionString;

        /// <summary>
        /// Instantiates a DatabaseInterface with the desired database type. "local", "esxi"
        /// </summary>
        /// <param name="dbLocation"></param>
        public DatabaseInterface(string dbLocation)
        {
            // Grab the correct connection string based on the requested type of interface

            switch (dbLocation)
            {
                case "local":
                    connectionString = Constants.GetLocalConnectionString();
                    break;

                case "esxi":
                    connectionString = Constants.GetEsxiConnectionString();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Returns a customer ID if existing, otherwise returns -1
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int Getcustomer(string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return -1;
                    }

                    rdr.Read();
                    return (int)rdr["customer_id"];

                } // end of reader

            } // end of cmd
        }

        /// <summary>
        /// Adds an extra to the database
        /// </summary>
        /// <param name="extra"></param>
        /// <param name="reservationID"></param>
        public void InsertReservationExtra(ReservationExtra extra, int reservationID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("InsertReservationExtra", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@reservationID", SqlDbType.Int).Value = reservationID;
                cmd.Parameters.Add("@days", SqlDbType.Int).Value = extra.Days;
                cmd.Parameters.Add("@type", SqlDbType.Int).Value = extra.ID;
                con.Open();

                cmd.ExecuteNonQuery();

            } // end of cmd
        }



        public Reservation GetReservation()
        {
            return null;
        }

        /// <summary>
        /// Authenticates a user. Returns user ID if successful, -1 if unsuccessful
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int AuthenticateUserPass(string username, string password)
        {
            return 1;
        }

        /// <summary>
        /// Inserts a reservation into the databse and returns an id
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public int InsertReservation(Reservation reservation)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("InsertReservation", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@spotNumber", SqlDbType.Int).Value = reservation.SpotID;
                cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = reservation.StartDate;
                cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = reservation.EndDate;
                cmd.Parameters.Add("@customerID", SqlDbType.Int).Value = reservation.CustomerID;
                cmd.Parameters.Add("@createdDate", SqlDbType.DateTime).Value = reservation.CreatedDate;
                cmd.Parameters.Add("@adults", SqlDbType.Int).Value = reservation.Adults;
                cmd.Parameters.Add("@children", SqlDbType.Int).Value = reservation.Children;
                cmd.Parameters.Add("@dogs", SqlDbType.Int).Value = reservation.Dogs;
                con.Open();

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();
                int result = (int)returnParameter.Value;
                
                return result;

            } // end of cmd
        }

        /// <summary>
        /// Get all the extras connected to a reservation
        /// </summary>
        /// <param name="resID"></param>
        /// <returns></returns>
        public List<ReservationExtra> GetReservationExtras(int resID)
        {
            List<ReservationExtra> returnList = new List<ReservationExtra>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetReservationExtras", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@resID", SqlDbType.Int).Value = resID;
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return returnList;
                    }

                    while (rdr.Read())
                    {
                        ReservationExtra extra = new ReservationExtra();

                        extra.ID = (int)rdr["extra_type"];
                        extra.Days = (int)rdr["amount_days"];

                        returnList.Add(extra);
                    }

                } // end of reader

            } // end of cmd

            return returnList;
        }

        /// <summary>
        /// Gets all the reservations that a customer has made in the past
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public int GetCustomerPastReservations(int customerID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("CountReservationsByCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@customerID", SqlDbType.VarChar).Value = customerID;

                con.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return 0;
                    }

                    while (rdr.Read())
                    {
                        return (int)rdr["number_reservations"];
                    }

                } // end of reader

            } // end of cmd

            return 0;
        }

        public int GetCustomer(string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
      
                con.Open();

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return -1;
                    }

                    while (rdr.Read())
                    {
                        return (int)rdr["customer_id"];
                    }

                } // end of reader

            } // end of cmd

            return -1;
        }

        /// <summary>
        /// Inserts a customer into the databse and returns a customer id
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int InsertCustomer(CustomerInformation customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("InsertCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@c_email", SqlDbType.VarChar).Value = customer.Email;
                cmd.Parameters.Add("@c_fist_name", SqlDbType.VarChar).Value = customer.FirstName;
                cmd.Parameters.Add("@c_last_name", SqlDbType.VarChar).Value = customer.LastName;
                cmd.Parameters.Add("@c_zip_code", SqlDbType.VarChar).Value = customer.ZipCode;
                cmd.Parameters.Add("@c_city", SqlDbType.VarChar).Value = customer.City;
                con.Open();

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();
                int result = (int)returnParameter.Value;

                return result;

            } // end of cmd
        }

        /// <summary>
        /// Grab all the reservations from the database
        /// </summary>
        /// <returns></returns>
        public List<Reservation> GetReservations()
        {
            List<Reservation> returnList = new List<Reservation>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetAllReservations", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return returnList;
                    }

                    while (rdr.Read())
                    {
                        Reservation r = new Reservation();
                        r.ReservationID = (int)rdr["reservation_id"];
                        r.SpotID = (int)rdr["spot_number"];
                        r.StartDate = (DateTime)rdr["start_dato"];
                        r.EndDate = (DateTime)rdr["end_dato"];
                        r.Adults = (int)rdr["adults"];
                        r.Children = (int)rdr["children"];
                        r.Dogs = (int)rdr["dogs"];

                        r.Customer = new CustomerInformation();
                        r.Customer.FirstName = rdr["c_fist_name"].ToString();
                        r.Customer.LastName = rdr["c_last_name"].ToString();
                        r.Customer.Email = rdr["c_email"].ToString();

                        returnList.Add(r);
                    }

                } // end of reader

            } // end of cmd


            return returnList;
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
            List<int> returnList = new List<int>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetAvailableCampingSpotsTypes", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@spotType", SqlDbType.Int).Value = type;
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return null;
                    }

                    while (rdr.Read())
                    {
                        returnList.Add((int)rdr["spot_number"]);
                    }

                } // end of reader

            } // end of cmd


            return returnList;
        }

        
        /// <summary>
        /// Get general information about all the spot types
        /// </summary>
        /// <returns></returns>
        public List<CampingSpotTypeInformation> GetCampingSpotTypesInformation()
        {
            List<CampingSpotTypeInformation> returnList = new List<CampingSpotTypeInformation>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetCampingSpotTypes", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return null;
                    }

                    while (rdr.Read())
                    {
                        CampingSpotTypeInformation spot = new CampingSpotTypeInformation();
                        spot.SpotName = rdr["spot_name"].ToString();
                        spot.SpotDescription = rdr["spot_description"].ToString();
                        spot.SquareMeters = (int)rdr["square_meters"];
                        spot.SpotType = (int)rdr["spot_type"];
                        spot.MaxPeople = (int)rdr["max_people"];

                        returnList.Add(spot);
                    }

                } // end of reader

            } // end of cmd

            return returnList;
        }

        /// <summary>
        /// Returns a list of prices for all the extas
        /// </summary>
        /// <returns></returns>
        public List<int> GetExtraPrices()
        {
            List<int> returnList = new List<int>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetExtraPrices", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return returnList;
                    }

                    while (rdr.Read())
                    {
                        int price = (int)rdr["price"];
                        returnList.Add(price);

                    }


                } // end of reader

            } // end of cmd

            return returnList;
        }

        /// <summary>
        /// Get information about a specific spot type
        /// </summary>
        /// <param name="spotType"></param>
        /// <returns></returns>
        public CampingSpotTypeInformation GetCampingSpotTypeInformation(int spotType)
        {
            CampingSpotTypeInformation spot = new CampingSpotTypeInformation();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetCampingSpotTypeInfoWithPrices", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@spotType", SqlDbType.VarChar).Value = spotType;
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        return null;
                    }

                    rdr.Read();
                    spot.SpotName = rdr["spot_name"].ToString();
                    spot.SpotDescription = rdr["spot_description"].ToString();
                    spot.SquareMeters = (int)rdr["square_meters"];
                    spot.SpotType = (int)rdr["spot_type"];
                    spot.MaxPeople = (int)rdr["max_people"];
                    spot.LowSeasonDailyPrice = (int)rdr["base_price"];
                    spot.SpotImage = rdr["spot_img"].ToString();


                    rdr.Read();
                    spot.HighSeasonDailyPrice = (int)rdr["base_price"];

                  
                } // end of reader

            } // end of cmd

            return spot;
        }

        /// <summary>
        /// returns an array with people prices in a specified season. 0 = adult, 1 = children, 2 = dogs
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        public int[] GetAllMemberPrices(int season)
        {
            int[] returnArray = new int[3];

            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetAllMemberPricesInSeason", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@season", SqlDbType.Int).Value = season;

                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {

                    }
                    int i = 0;

                    while (rdr.Read())
                    {
                        int price = (int)rdr["daily_price"];
                        returnArray[i] = price;
                        i++;
                        if (i > 2) i = 2;

                    }
                } // end of reader

            } // end of cmd

            return returnArray;
        }

        /// <summary>
        /// Returns a list of information about all the spot types available in a specified time frame
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<CampingSpotTypeInformation> GetAvaibleSpotTypesInDates(DateTime startDate, DateTime endDate)
        {


            List<CampingSpotTypeInformation> returnList = new List<CampingSpotTypeInformation>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetAvailableCampingSpotsTypesFull", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = startDate.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@endDate", SqlDbType.VarChar).Value = endDate.ToString("yyyy-MM-dd");

                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {

                    }

                    while (rdr.Read())
                    {

                        string spot_name = rdr["spot_name"].ToString();
                        string spot_description = rdr["spot_description"].ToString();
                        int spot_type = (int)rdr["spot_type"];
                        int spot_squareMeters = (int)rdr["square_meters"];
                        int spot_maxPeople = (int)rdr["max_people"];
                        string spot_image = rdr["spot_img"].ToString();


                        CampingSpotTypeInformation model = new CampingSpotTypeInformation(spot_name, spot_description, spot_type, spot_squareMeters, spot_maxPeople, spot_image);
                        returnList.Add(model);

                    }
                } // end of reader

            } // end of cmd
       

            return returnList;
        }

    }

}