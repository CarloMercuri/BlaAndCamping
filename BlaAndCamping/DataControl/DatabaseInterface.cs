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