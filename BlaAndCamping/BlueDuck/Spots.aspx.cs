    using BlaAndCamping.LogicControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{ 
    public partial class Spots : System.Web.UI.Page
    {
        private DataProcessor _dataProcessor;

        public CampingSpotTypeInformation regularCabin;
        public CampingSpotTypeInformation luxuryCabin;
        public CampingSpotTypeInformation regularSpot;
        public CampingSpotTypeInformation regularSpotView;
        public CampingSpotTypeInformation comfortSpot;
        public CampingSpotTypeInformation comfortSpotView;
        public CampingSpotTypeInformation tent;

        public List<CampingSpotTypeInformation> SpotInformationList = new List<CampingSpotTypeInformation>();

        protected void Page_Load(object sender, EventArgs e)
        {
            _dataProcessor = new DataProcessor();
            string spotType = Request.QueryString["Type"];


            switch (spotType)
            {
                case "cabin":
                    headerSpotType.InnerText = "Hytter";
                    headerSpotDescription.InnerText = "Her finder du en oversigt over alle vores typer af hytter.";

                    regularCabin = _dataProcessor.GetSpotTypeInformation(4);
                    luxuryCabin = _dataProcessor.GetSpotTypeInformation(5);

                    SpotInformationList.Add(regularCabin);
                    SpotInformationList.Add(luxuryCabin);

                    break;

                case "wagon":

                    headerSpotType.InnerText = "Pladser til Campingvogn/Autocamper";
                    headerSpotDescription.InnerText = "Her finder du en oversigt over alle vores typer af pladser.";

                    regularSpot = _dataProcessor.GetSpotTypeInformation(0);
                    regularSpotView = _dataProcessor.GetSpotTypeInformation(1);
                    comfortSpot = _dataProcessor.GetSpotTypeInformation(2);
                    comfortSpotView = _dataProcessor.GetSpotTypeInformation(3);

                    SpotInformationList.Add(regularSpot);
                    SpotInformationList.Add(regularSpotView);
                    SpotInformationList.Add(comfortSpot);
                    SpotInformationList.Add(comfortSpotView);

                    break;

                case "tent":

                    headerSpotType.InnerText = "Telt";
                    headerSpotDescription.InnerText = "Her finder du information om vores teltplads.";
                    tent = _dataProcessor.GetSpotTypeInformation(6);

                    SpotInformationList.Add(tent);

                    break;

            }

            CreateVisual();


        }
        private void CreateVisual()
        {
            foreach (CampingSpotTypeInformation spot in SpotInformationList)
            {
                //
                // HEADER
                //

                HtmlGenericControl headerDiv = new HtmlGenericControl("DIV");
                headerDiv.Attributes.Add("class", "row");
                headerDiv.Attributes.Add("runat", "server");
                headerDiv.Attributes.Add("ID", "h1");

                HtmlGenericControl headerDivCol2 = new HtmlGenericControl("DIV");
                headerDivCol2.Attributes.Add("class", "col-2");

                HtmlGenericControl headerDivCol8 = new HtmlGenericControl("DIV");
                headerDivCol8.Attributes.Add("class", "col-8 spot-header");

                HtmlGenericControl headerDivCol2_2 = new HtmlGenericControl("DIV");
                headerDivCol2_2.Attributes.Add("class", "col-2");

                Label labelHeader = new Label();
                labelHeader.Text = spot.SpotName;

                HtmlGenericControl breakLine = new HtmlGenericControl("BR");

                mainBodyDiv.Controls.Add(headerDiv);

                headerDiv.Controls.Add(headerDivCol2);
                headerDiv.Controls.Add(headerDivCol8);
                headerDivCol8.Controls.Add(labelHeader);
                headerDivCol8.Controls.Add(breakLine);
                headerDiv.Controls.Add(headerDivCol2_2);

                //
                // IMAGE
                //

                HtmlGenericControl bodyMainDiv = new HtmlGenericControl("DIV");
                bodyMainDiv.Attributes.Add("class", "row");

                HtmlGenericControl bodyDivCol2 = new HtmlGenericControl("DIV");
                bodyDivCol2.Attributes.Add("class", "col-2");

                HtmlGenericControl bodyDivCol4 = new HtmlGenericControl("DIV");
                bodyDivCol4.Attributes.Add("class", "col-4");

                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();

                img.ImageUrl = "../Images/" + spot.SpotImage;
                img.Attributes.Add("style", "width: 450px;");
                //img.CssClass = "width:350 px;";

                HtmlGenericControl bodyBreakLine = new HtmlGenericControl("BR");

                mainBodyDiv.Controls.Add(bodyMainDiv);

                bodyMainDiv.Controls.Add(bodyDivCol2);
                bodyMainDiv.Controls.Add(bodyDivCol4);
                bodyDivCol4.Controls.Add(img);
                bodyDivCol4.Controls.Add(bodyBreakLine);

                //
                // DESCRIPTION
                //

                HtmlGenericControl descriptionMainDiv = new HtmlGenericControl("DIV");
                descriptionMainDiv.Attributes.Add("class", "col-4 spot-description");

                bodyMainDiv.Controls.Add(descriptionMainDiv);

                Label l = new Label();
                l.Text = $"{spot.SpotName} <br /> " +
                    $"Størrelse: {spot.SquareMeters} kvm <br />" +
                    $"{spot.SpotDescription} <br />";

                descriptionMainDiv.Controls.Add(l);

                if (spot.MaxPeople > 0)
                {
                    Label l1 = new Label();
                    l1.Text = $"Plads til {spot.MaxPeople} personer <br /> ";
                    descriptionMainDiv.Controls.Add(l1);
                }

                int[] lowPrices = _dataProcessor.GetAllMemberPricesInSeason(0);
                int[] highPrices = _dataProcessor.GetAllMemberPricesInSeason(1);

                Label l2 = new Label();
                l2.Text = $"Pris Højsæson/Lavsæson pr. døgn, pr. hytte/plads <br /> " +
                    $"DKK kr. {spot.HighSeasonDailyPrice},- / {spot.LowSeasonDailyPrice},- <br />" +
                    $"Pris Højsæson/Lavsæson pr. døgn, pr. person <br />" +
                    $"Voksen DKK kr. {highPrices[0]},- / {lowPrices[0]},- <br />" +
                    $"Barn DKK kr. {highPrices[1]},- / {lowPrices[1]},- <br />" +
                    $"Hund DKK kr. {highPrices[2]},- uanset sæson";


                descriptionMainDiv.Controls.Add(l2);

            }

        }
    }
}