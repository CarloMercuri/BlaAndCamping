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

        public int AuthenticateUserPass(string username, string password)
        {
            return 1;
        }

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