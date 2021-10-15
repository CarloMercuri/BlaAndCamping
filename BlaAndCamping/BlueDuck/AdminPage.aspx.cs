using BlaAndCamping.LogicControl;
using BlaAndCamping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class AdminPage : System.Web.UI.Page
    {
        DataProcessor _processor;

        protected void Page_Load(object sender, EventArgs e)
        {
           //if((int)Session["AdminUser"] == -1)
           //{
           //   return;
           //}

            _processor = new DataProcessor();

            FillTableHeader();
           

            List<Reservation> reservations = _processor.GetReservations();

            foreach(Reservation reservation in reservations)
            {
                List<ReservationExtra> extras = _processor.GetReservationExtras(reservation.ReservationID);
                reservation.Extras = extras;

                

                Label l = new Label();
                l.Text = $"ID: {reservation.ReservationID} - Name: {reservation.Customer.FirstName} - Surname: {reservation.Customer.LastName}" +
                    $" Email: {reservation.Customer.Email} - Spot number: {reservation.SpotID}, {reservation.SpotName} - " +
                    $"Arrival: {reservation.StartDate.ToString("dd-mm-yyyy")} - Departure: {reservation.EndDate.ToString("dd-mm-yyyy")} - " +
                    $"Adults: {reservation.Adults} - Children: {reservation.Children} - Dogs: {reservation.Dogs} - Bicycles: {reservation.CountExtraOfType(0)}" +
                    $" Extra bedsheet: {reservation.CountExtraOfType(1)} - WaterPark Adult: {reservation.CountExtraOfType(3)} - WaterPark children: {reservation.CountExtraOfType(4)}";

                HtmlGenericControl customDiv = new HtmlGenericControl("DIV");

                l.Attributes.Add("style", "margin-top: 20px;");

                customDiv.Attributes.Add("class", "row");

                mainDiv.Controls.Add(customDiv);

                customDiv.Controls.Add(l);
            }

        }

        private void FillTableHeader()
        {
            TableRow header = new TableRow();
            
            TableCell c = new TableCell();
            c.Text = "<b>Reservation ID</b>";
            header.Cells.Add(c);

            //mainTable.Rows.Add(header);

            TableCell c1 = new TableCell();
            c1.Text = "Spot Number";
            header.Cells.Add(c1);

            TableCell c2 = new TableCell();
            c2.Text = "First Name";
            header.Cells.Add(c2);

            TableCell c3 = new TableCell();
            c3.Text = "Last Name";
            header.Cells.Add(c3);

            TableCell c4 = new TableCell();
            c4.Text = "Email";
            header.Cells.Add(c4);

            TableCell c5 = new TableCell();
            c5.Text = "Start Date";
            header.Cells.Add(c5);

            TableCell c6 = new TableCell();
            c6.Text = "End Date";
            header.Cells.Add(c6);
        }
    }
}