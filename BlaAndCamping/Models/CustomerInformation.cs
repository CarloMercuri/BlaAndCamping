using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping.Models
{
    public class CustomerInformation
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string zipCode;

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public CustomerInformation(string firstName, string lastName, string email, string zipCode, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.zipCode = zipCode;
            this.city = city;
        }

        public CustomerInformation()
        {

        }
    }
}