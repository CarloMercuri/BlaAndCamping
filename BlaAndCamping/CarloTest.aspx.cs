using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BlaAndCamping.Models;
using BlaAndCamping.LogicControl;

namespace BlaAndCamping
{
    public partial class CarloTest : System.Web.UI.Page
    {
        public DateTime SelectedStartDate
        {
            get { return DateTime.Parse(Session["calendarStartDate"].ToString()); }
            set { Session["calendarStartDate"] = value.ToString(); }
        }

        public DateTime SelectedEndDate
        {
            get { return DateTime.Parse(Session["calendarEndDate"].ToString()); }
            set { Session["calendarEndDate"] = value.ToString(); }
        }

        // 0 = start date, 1 = end date

        public int CalendarSelectionState
        {
            get { return (int)Session["calendarSelectState"]; }
            set { ApplyStateChange(value); }
        }


        private List<Reservation> currentReservations;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reservation r = new Reservation();
                r.Adults = 9;
                Session["TestingPermanence"] = r;
                Session["calendarSelectState"] = 0;
                Session["calendarStartDate"] = DateTime.MinValue.ToString();
                Session["calendarEndDate"] = DateTime.MinValue.ToString();
            }

            currentReservations = new List<Reservation>();
            label_ClendarInstruction.Enabled = false;
            InitializeCalendar();

            btn_SelectStartDate.Click += (sendobj, args) =>
            {
                ChangeCalendarSelectionState(0);
            };

            btn_SelectEndDate.Click += (sendobj, args) =>
            {
                ChangeCalendarSelectionState(1);
            };


        }

        private void ApplyStateChange(int state)
        {
            Session["calendarSelectState"] = state;
            //label_State.Text = state.ToString();
        }

        private void ChangeCalendarSelectionState(int sel)
        {
            CalendarSelectionState = sel;

            if (sel == 0)
            {
                label_ClendarInstruction.Text = "Select your arrival day";
            }
            else
            {
                label_ClendarInstruction.Text = "Select your departure day";
            }

        }



        private void InitializeCalendar()
        {
            calendar_Main.DayRender += CalendarDayRenderer;
            calendar_Main.SelectionChanged += CalendarSelectionChanged;
            calendar_Main.Height = Unit.Pixel(400);
            calendar_Main.Width = Unit.Pixel(500);
            calendar_Main.SelectionMode = CalendarSelectionMode.Day;
            calendar_Main.TitleStyle.BackColor = Color.FromArgb(255, 4, 94, 188);
            calendar_Main.TitleStyle.ForeColor = Color.White;
            //calendar_Main.NextMonthText

            calendar_Main.TitleStyle.Font.Bold = true;
            calendar_Main.TitleStyle.Font.Size = 14;
            calendar_Main.TitleStyle.Font.Name = "Arial";





            label_ClendarInstruction.Enabled = true;
            label_ClendarInstruction.Text = "Select your arrival day";
        }

        private void GetReservationsDates()
        {
            Reservation r = new Reservation();
            r.StartDate = DateTime.Parse("2021-10-05");
            r.EndDate = DateTime.Parse("2021-10-20");
            currentReservations.Add(r);
        }

        private void CalendarSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarSelectionState == 0) // arrival date
            {
                SelectedStartDate = calendar_Main.SelectedDate;

                ChangeCalendarSelectionState(1);
            }
            else
            {
                SelectedEndDate = calendar_Main.SelectedDate;
                ChangeCalendarSelectionState(0);
            }

            label_StartDate.Text = SelectedStartDate.ToString(); //calendar_Main.SelectedDate.ToString("yyyy-MM-dd");
            label_EndDate.Text = SelectedEndDate.ToString();
        }

        private void CalendarDayRenderer(object sender, DayRenderEventArgs e)
        {
            e.Cell.CssClass = "no-underline";

            if (e.Day.Date.DayOfYear < DateTime.Now.DayOfYear)
            {
                e.Day.IsSelectable = false;
                e.Cell.Font.Bold = true;
                e.Cell.Font.Size = 12;

                e.Cell.ForeColor = Color.Gray;
            }
            else
            {
                e.Cell.Font.Bold = true;
                e.Cell.Font.Size = 12;
                e.Cell.ForeColor = Color.FromArgb(255, 4, 94, 188);
            }

            e.Cell.Font.Name = "Verdana";

            //e.Cell.BorderStyle = BorderStyle.Ridge;
            //e.Cell.BorderWidth = Unit.Pixel(1);
            //e.Cell.BorderColor = Color.FromArgb(80, 200, 200, 200);



            if (SelectedEndDate > SelectedStartDate)
            {
                if (e.Day.Date >= SelectedStartDate && e.Day.Date <= SelectedEndDate)
                {
                    e.Cell.BorderStyle = BorderStyle.Ridge;
                    e.Cell.BorderWidth = 2;
                    e.Cell.BorderColor = Color.FromArgb(80, 180, 180, 180);
                    e.Cell.BackColor = Color.FromArgb(255, 100, 100, 255);
                    e.Cell.ForeColor = Color.FromArgb(255, 200, 200, 200);
                }
            }

            if (e.Day.Date == calendar_Main.SelectedDate)
            {
                //e.Cell.ForeColor = Color.White;
                e.Cell.BackColor = Color.FromArgb(255, 100, 100, 255);
                e.Cell.ForeColor = Color.FromArgb(255, 200, 200, 200);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestPermanence.aspx");
        }

    }
}