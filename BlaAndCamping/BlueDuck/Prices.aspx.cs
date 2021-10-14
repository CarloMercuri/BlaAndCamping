using BlaAndCamping.LogicControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class Prices : System.Web.UI.Page
    {
        private DataProcessor _dataProcessor;

        public CampingSpotTypeInformation regularCabin;
        public CampingSpotTypeInformation luxuryCabin;
        public CampingSpotTypeInformation regularSpot;
        public CampingSpotTypeInformation regularSpotView;
        public CampingSpotTypeInformation comfortSpot;
        public CampingSpotTypeInformation comfortSpotView;
        public CampingSpotTypeInformation tent;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dataProcessor = new DataProcessor();

            regularSpot = _dataProcessor.GetSpotTypeInformation(0);
            regularSpotView = _dataProcessor.GetSpotTypeInformation(1);
            comfortSpot = _dataProcessor.GetSpotTypeInformation(2);
            comfortSpotView = _dataProcessor.GetSpotTypeInformation(3);
            regularCabin = _dataProcessor.GetSpotTypeInformation(4);
            luxuryCabin = _dataProcessor.GetSpotTypeInformation(5);
            tent = _dataProcessor.GetSpotTypeInformation(6);




        }
    }
}