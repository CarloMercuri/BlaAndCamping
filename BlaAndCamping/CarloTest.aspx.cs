using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BlaAndCamping.Models;

namespace BlaAndCamping
{
    public partial class CarloTest : System.Web.UI.Page
    {
        private DateTime selectedStartDate;
        private DateTime selectedEndDate;

         // 0 = start date, 1 = end date

        private int calendarSelectionState;

        public int CalendarSelectionState
        {
            get { return calendarSelectionState; }
            set { ApplyStateChange(value); }
        }


        private List<Reservation> currentReservations;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            currentReservations = new List<Reservation>();
            label_ClendarInstruction.Enabled = false;
            InitializeCalendar();

            //btn_SelectStartDate.Click += (sendobj, args) =>
            //{
            //    ChangeCalendarSelectionState(0);
            //};

            //btn_SelectEndDate.Click += (sendobj, args) =>
            //{
            //    ChangeCalendarSelectionState(1);
            //};
        }

        private void ApplyStateChange(int state)
        {
            calendarSelectionState = state;
            label_State.Text = state.ToString();
        }
        
        private void ChangeCalendarSelectionState(int sel)
        {
            CalendarSelectionState = sel;
            
            if(sel == 0)
            {
                label_ClendarInstruction.Text = "Select your arrival day";
            } else
            {
                label_ClendarInstruction.Text = "Select your departure day";
            }

        }



        private void InitializeCalendar()
        {
            calendar_Main.DayRender += CalendarDayRenderer;
            calendar_Main.SelectionChanged += CalendarSelectionChanged;
            calendar_Main.Height = Unit.Pixel(300);
            calendar_Main.Width = Unit.Pixel(300);
            calendar_Main.SelectionMode = CalendarSelectionMode.Day;
            calendar_Main.TitleStyle.BackColor = Color.FromArgb(150, 100, 100, 220);
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
            if(CalendarSelectionState == 0) // arrival date
            {
                selectedStartDate = calendar_Main.SelectedDate;
                label_StartDate.Text = calendar_Main.SelectedDate.ToString("yyyy-MM-dd");
                ChangeCalendarSelectionState(1);
            } 
            else
            {
                selectedEndDate = calendar_Main.SelectedDate;
                label_EndDate.Text = calendar_Main.SelectedDate.ToString("yyyy-MM-dd");
            }


        }

        private void CalendarDayRenderer(object sender, DayRenderEventArgs e)
        {
            e.Cell.BorderStyle = BorderStyle.Ridge;
            e.Cell.BorderWidth = Unit.Pixel(1);
            e.Cell.BorderColor = Color.FromArgb(80, 200, 200, 200);

            if(selectedEndDate > selectedStartDate)
            {
                if(e.Day.Date >= selectedStartDate && e.Day.Date <= selectedEndDate)
                {
                    e.Cell.BackColor = Color.LightBlue;
                }
            }

            if(e.Day.Date == calendar_Main.SelectedDate)
            {
                e.Cell.ForeColor = Color.White;
            }
        }

       
    }
}