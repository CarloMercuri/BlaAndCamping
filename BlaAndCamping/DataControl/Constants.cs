using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping.DataControl
{
    public static class Constants
    {
        private static string esxiConnectionString = "Server=172.16.59.80,1433;Database=Camping;User Id=BlaWebServer;Password=Passw0rd;";
        private static string localConnectionString = "Server=localhost;Database=Camping;User Id=BlaWebServer;Password=Passw0rd;Trusted_Connection=true";
        private static string carloPcConnectionString = "Server=172.16.53.238;Database=Camping;User Id
            Server;Password=Passw0rd;Trusted_Connection=true";

        public static string GetLocalConnectionString()
        {
            return localConnectionString;
        }

        public static string GetEsxiConnectionString()
        {
            return esxiConnectionString;
        }
    }

    public enum ReservationExtraID
    {
        Adult = 0,
        Child = 1,
        Dog = 2,
        Bicycle = 0,
        Bedsheet = 1,
        EndCleaning = 2,
        WaterparkAdult = 3,
        WaterparkChild = 4

    }
}