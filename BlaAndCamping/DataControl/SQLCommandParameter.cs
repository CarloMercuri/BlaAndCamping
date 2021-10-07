using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaAndCamping.DataControl
{
    public class SQLCommandParameter
    {
        private string parameterName;

        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        private string parameterValue;

        public string ParameterValue
        {
            get { return parameterValue; }
            set { parameterValue = value; }
        }


        public SQLCommandParameter(string name, string value)
        {
            parameterName = name;
            parameterValue = value;
        }

    }
}