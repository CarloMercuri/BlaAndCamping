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

        private Dictionary<string, int> EventIDToType;

        private DateTime SelectedStartDate
        {
            get { return _processor.GetReservationStartDate(); }
            set { _processor.SetReservationStartDate(value); }
        }

        private DateTime SelectedEndDate
        {
            get { return _processor.GetReservationEndDate(); }
            set { _processor.SetReservationEndDate(value); }
        }

        private int SelectedType
        {
            get { return _processor.GetReservationSelectedType(); }
            set { _processor.SetReservationSelectedType(value); }
        }

        private int SelectedSpotNumber
        {
            get { return _processor.GetReservationSpotNumber(); }
            set { _processor.SetReservationSpotNumber(value); }
        }

        private int stage = 0;

        // 0 = start date, 1 = end date

        public int CalendarSelectionState
        {
            get { return (int)Session["calendarSelectState"]; }
            set { ApplyStateChange(value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            stage = 0;
            _processor = new DataProcessor();

            tBox_Selection.TextChanged += (snd, args) =>
            {
                _processor.SetReservationSelectedType(Int32.Parse(tBox_Selection.Text));
                Response.Redirect("BookingSelectSlot.aspx");
            };
 

            if (!IsPostBack)
            {
                _processor.SetSessionVariable("calendarSelectState", 0);
                _processor.InitializeReservation();
            }

            if (stage == 1)
            {
                //if (IsPostBack && EventIDToType.ContainsKey(Request["__EVENTTARGET"]))
                //{
                //    SlotTypeclick(EventIDToType[Request["__EVENTTARGET"]]);
                //}
            }



            //InitializeCheckboxes();
            InitializeCalendar();
            //CheckValidSelection();
        }

        protected void clickArea_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("clicked the div");
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

                //bookingRadioSection.Controls.Add(customDiv);

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
            calendar_Main.Width = Unit.Pixel(700);
            calendar_Main.Height = Unit.Pixel(400);
            calendar_Main.CssClass = "calendar-main";
            calendar_Main.SelectionMode = CalendarSelectionMode.Day;
            calendar_Main.TitleStyle.BackColor = Color.FromArgb(255, 4, 94, 188);
            calendar_Main.TitleStyle.ForeColor = Color.White;
            //calendar_Main.NextMonthText
            //calendar_Main.Style.Add(HtmlTextWriterStyle.MarginLeft, "250px");
            calendar_Main.Style.Add(HtmlTextWriterStyle.Margin, "auto");
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
                SelectedEndDate > SelectedStartDate)
            {
                ShowTypeSelection();
            }

        }

        private void ShowTypeSelection()
        {
            stage = 1;
            EventIDToType = new Dictionary<string, int>();
            List<CampingSpotTypeInformation> spots = _processor.GetAvaibleSpotTypesInDates(SelectedStartDate, SelectedEndDate);

            spots.Add(new CampingSpotTypeInformation("Telt plads", "Bruge vores telt", 6, 300, 0, "camping_tent1.jfif"));  
            
            foreach (CampingSpotTypeInformation spot in spots)
            {
                HtmlGenericControl div_RowContainer = new HtmlGenericControl("DIV");

                div_RowContainer.Attributes.Add("class", "selection-row-container");

                selectionMainDiv.Controls.Add(div_RowContainer);



                HtmlGenericControl div_RowBody = new HtmlGenericControl("DIV");

                div_RowBody.Attributes.Add("class", "selection-row-body");
                div_RowBody.Attributes.Add("runat", "server");

                //div_RowBody.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(div_RowBody, string.Empty));
                //EventIDToType.Add(div_RowBody.ClientID, spot.SpotType);



                div_RowContainer.Controls.Add(div_RowBody);

                // row

                HtmlGenericControl div_RowOne = new HtmlGenericControl("DIV");

                div_RowOne.Attributes.Add("class", "row");

                div_RowBody.Controls.Add(div_RowOne);

                // col8

                HtmlGenericControl div_ColEightOne = new HtmlGenericControl("DIV");

                div_ColEightOne.Attributes.Add("class", "col-8");

                div_RowOne.Controls.Add(div_ColEightOne);

                // row

                HtmlGenericControl div_RowTwo = new HtmlGenericControl("DIV");

                div_RowTwo.Attributes.Add("class", "row");

                div_ColEightOne.Controls.Add(div_RowTwo);

                // col3

                HtmlGenericControl div_ColThreeOne = new HtmlGenericControl("DIV");

                div_ColThreeOne.Attributes.Add("class", "col-3");

                div_RowTwo.Controls.Add(div_ColThreeOne);

                // col5

                HtmlGenericControl divColFiveContent = new HtmlGenericControl("DIV");

                divColFiveContent.Attributes.Add("class", "col-5 content");

                div_RowTwo.Controls.Add(divColFiveContent);

                // h3

                HtmlGenericControl h3one = new HtmlGenericControl("H3");

                h3one.InnerText = spot.SpotName;

                divColFiveContent.Controls.Add(h3one);

                // col4

                HtmlGenericControl div_ColFourOne = new HtmlGenericControl("DIV");

                div_ColFourOne.Attributes.Add("class", "col-4");

                div_RowTwo.Controls.Add(div_ColFourOne);

                // row

                HtmlGenericControl div_RowThree = new HtmlGenericControl("DIV");

                div_RowThree.Attributes.Add("class", "row");

                div_ColEightOne.Controls.Add(div_RowThree);

                // h4

                HtmlGenericControl h4One = new HtmlGenericControl("H4");

                div_RowTwo.Controls.Add(h4One);

                h4One.InnerText = spot.SpotDescription;

                // col4

                HtmlGenericControl div_ColFourTwo = new HtmlGenericControl("DIV");

                div_ColFourTwo.Attributes.Add("class", "col-3");

                div_RowOne.Controls.Add(div_ColFourTwo);

                // img

                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();

                img.ImageUrl = $"../Images/{spot.SpotImage}";

                img.Attributes.Add("style", "height: 100%; width: 104%; margin-top: 3px;");

                div_ColFourTwo.Controls.Add(img);



                Button btn = new Button();
                btn.ID = "btn_type0";
                div_ColFourTwo.Controls.Add(btn);
                
               // btn.Click += new EventHandler(this.GreetingBtn_Click);

                btn.Click += (sender, args) =>
                {
                    Debug.WriteLine("original");
                    SlotTypeclick(spot.SpotType);
                };

            }


        }

        private void GreetingBtn_Click(Object sender,
                           EventArgs e)
        {
            // When the button is clicked,
            // change the button text, and disable it.

            Debug.WriteLine("hallo");
        }

        private void clicki()
        {
            Debug.WriteLine("Clicked!!");
        }

        private void SlotTypeclick(int type)
        {
            _processor.SetReservationSelectedType(type);
            Response.Redirect("BookingSelectSlot.aspx");
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
                //ButtonsMidSection.Controls.Add(btn);

                btn.Click += (sender, args) =>
                {
                    SelectedSpotNumber = number;

                    _processor.SetReservationStartDate(SelectedStartDate);
                    _processor.SetReservationEndDate(SelectedEndDate);
                    _processor.SetReservationSpotNumber(SelectedSpotNumber);

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

        protected void btn_type0_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("haha");
        }
    }
}