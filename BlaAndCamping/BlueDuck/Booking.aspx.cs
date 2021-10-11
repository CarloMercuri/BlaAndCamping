using BlaAndCamping.LogicControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class Booking : System.Web.UI.Page
    {
        private DataProcessor _processor;

        private List<CheckBox> checkBoxes;

        private DateTime SelectedStartDate
        {
            get { return DateTime.Parse(Session["calendarStartDate"].ToString()); }
            set { Session["calendarStartDate"] = value.ToString(); }
        }

        private DateTime SelectedEndDate
        {
            get { return DateTime.Parse(Session["calendarEndDate"].ToString()); }
            set { Session["calendarEndDate"] = value.ToString(); }
        }

        private int SelectedType
        {
            get { return (int)Session["selectedType"]; }
            set { Session["selectedType"] = value; }
        }

        // 0 = start date, 1 = end date

        public int CalendarSelectionState
        {
            get { return (int)Session["calendarSelectState"]; }
            set { ApplyStateChange(value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["selectedType"] = -1;
                Session["calendarSelectState"] = 0;
                Session["calendarStartDate"] = DateTime.MinValue.ToString();
                Session["calendarEndDate"] = DateTime.MinValue.ToString();
            }

            checkBoxes = new List<CheckBox>();

            _processor = new DataProcessor();

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

                    checkBox.Checked = true;

                    TypesCheckChanged();
                };

                checkBoxes.Add(checkBox);

                customDiv.Controls.Add(checkBox);

                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                img.ImageUrl = "../Images/vogn_small.png";
                img.CssClass = "booking-radio-img";

                customDiv.Controls.Add(img);

                bookingRadioSection.Controls.Add(customDiv);

            }

           



            DataProcessor p = new DataProcessor();

            calendar_Main.Width = Unit.Pixel(400);
            calendar_Main.Height = Unit.Pixel(400);
            calendar_Main.Style.Add(HtmlTextWriterStyle.MarginLeft, "250px");
            //FirstNameTextBox.Width = Unit.Pixel(300);
            //LastNameTextBox.Width = Unit.Pixel(300);
            //AddressTextBox.Width = Unit.Pixel(300);
            //ZipCodeTextBox.Width = Unit.Pixel(300);
            //CityTextBox.Width = Unit.Pixel(300);
            //TelephoneTextBox.Width = Unit.Pixel(300);
            //EmailTextBox.Width = Unit.Pixel(300);

            InitializeCalendar();
        }

        private void CheckBoxesChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                checkBoxes[i].Checked = false;
            }

            
        }

        private void TypesCheckChanged()
        {

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
    }
}