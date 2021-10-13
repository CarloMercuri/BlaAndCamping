using BlaAndCamping.LogicControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

namespace BlaAndCamping.BlueDuck
{
    public partial class Booking : System.Web.UI.Page
    {
        private DataProcessor _processor;

        private List<CheckBox> checkBoxes;

        private SessionDataControl _sessionControl;

        private DateTime SelectedStartDate
        {
            get { return _sessionControl.GetReservationStartDate(); }
            set { _sessionControl.SetReservationStartDate(value); }
        }

        private DateTime SelectedEndDate
        {
            get { return _sessionControl.GetReservationEndDate(); }
            set { _sessionControl.SetReservationEndDate(value); }
        }

        private int SelectedType
        {
            get { return _sessionControl.GetReservationSelectedType(); }
            set { _sessionControl.SetReservationSelectedType(value); }
        }

        private int SelectedSpotNumber
        {
            get { return _sessionControl.GetReservationSpotNumber(); }
            set { _sessionControl.SetReservationSpotNumber(value); }
        }

        // 0 = start date, 1 = end date

        public int CalendarSelectionState
        {
            get { return (int)Session["calendarSelectState"]; }
            set { ApplyStateChange(value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _sessionControl = new SessionDataControl();
            _processor = new DataProcessor();

            if (!IsPostBack)
            {
                _sessionControl.SetSessionVariable("calendarSelectState", 0);
                _sessionControl.ResetReservation();
            }
                     

            InitializeCheckboxes();
            InitializeCalendar();
            CheckValidSelection();
        }

        private void InitializeCheckboxes()
        {
            checkBoxes = new List<CheckBox>();



            List<CampingSpotTypeInformation> spots = _processor.GetSpotTypesInformation();

            foreach (CampingSpotTypeInformation spot in spots)
            {
                HtmlGenericControl customDiv = new HtmlGenericControl("DIV");

                customDiv.Attributes.Add("class", "booking-row-container");

                CheckBox checkBox = new CheckBox();
                checkBox.CssClass = "asp-checkbox";
                checkBox.Text = spot.SpotName;
                checkBox.AutoPostBack = true;
                //checkBox.CheckedChanged += CheckBoxesChanged;



                checkBox.CheckedChanged += (checkSender, args) =>
                {
                    for (int i = 0; i < checkBoxes.Count; i++)
                    {
                        checkBoxes[i].Checked = false;
                    }

                    SelectedType = spot.SpotType;

                    checkBox.Checked = true;

                    CheckValidSelection();
                };

                checkBoxes.Add(checkBox);

                customDiv.Controls.Add(checkBox);

                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                img.ImageUrl = "../Images/vogn_small.png";
                img.CssClass = "booking-radio-img";

                customDiv.Controls.Add(img);

                bookingRadioSection.Controls.Add(customDiv);

            }
        }

        private void CheckBoxesChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                checkBoxes[i].Checked = false;
            }

            
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

            }
            else
            {

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
            calendar_Main.Style.Add(HtmlTextWriterStyle.MarginLeft, "250px");
            calendar_Main.TitleStyle.Font.Bold = true;
            calendar_Main.TitleStyle.Font.Size = 14;
            calendar_Main.TitleStyle.Font.Name = "Arial";

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

            CheckValidSelection();
        }

        private void CheckValidSelection()
        {
            if(SelectedStartDate > DateTime.MinValue &&
                SelectedEndDate > DateTime.MinValue &&
                SelectedEndDate > SelectedStartDate &&
                SelectedType != -1)
            {
                ShowAvailableSpots();
            }

        }

        private void ShowAvailableSpots()
        {
            _processor.SetReservationStartDate(SelectedStartDate);
            _processor.SetReservationEndDate(SelectedEndDate);
            List<int> aviableSpotNumbers = _processor.GetAvailableSpotsDateType(SelectedStartDate, SelectedEndDate, SelectedType);
            AddSpotSelectionButtons(aviableSpotNumbers);
            
        }

        private void AddSpotSelectionButtons(List<int> aviableSpotNumbers)
        {
            foreach (int number in aviableSpotNumbers)
            {
                Button btn = new Button();
                btn.Text = number.ToString();
                btn.CssClass = "booking-spot-button";
                ButtonsMidSection.Controls.Add(btn);

                btn.Click += (sender, args) =>
                {
                    SelectedSpotNumber = number;

                    _processor.SetReservationStartDate(SelectedStartDate);
                    _processor.SetReservationEndDate(SelectedEndDate);
                    _processor.UpdateReservationSpotNumber(SelectedSpotNumber);

                    Response.Redirect("ReservationConfirm.aspx");
                };
            }


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

        }
    }
}