using BlaAndCamping.LogicControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class BookingExtras : System.Web.UI.Page
    {
        private int Adults
        {
            get { return _processor.GetReservationMembers(0); }
            set { _processor.SetReservationMember(0, value); }
        }

        private int Children
        {
            get { return _processor.GetReservationMembers(1); }
            set { _processor.SetReservationMember(1, value); }
        }

        private int TotalPeople
        {
            get { return Adults + Children; }
        }

        private int Dogs
        {
            get { return _processor.GetReservationMembers(2); }
            set { _processor.SetReservationMember(2, value); }
        }

        private int Bycicles
        {
            get { return _processor.GetReservationExtra(0); }
            set { _processor.SetReservationExtra(0, value); }
        }

        private int Bedsheets
        {
            get { return _processor.GetReservationExtra(1); }
            set { _processor.SetReservationExtra(1, value); }
        }

        private int EndCleaning
        {
            get { return _processor.GetReservationExtra(2); }
            set { _processor.SetReservationExtra(2, value); }
        }

        private int WaterAdult
        {
            get { return _processor.GetReservationExtra(3); }
            set { _processor.SetReservationExtra(3, value); }
        }

        private int WaterChild
        {
            get { return _processor.GetReservationExtra(4); }
            set { _processor.SetReservationExtra(4, value); }
        }



        public DataProcessor _processor;
        public SessionDataControl _session;

        protected void Page_Load(object sender, EventArgs e)
        {
            tBox_Adults.ReadOnly = true;
            tBox_Children.ReadOnly = true;
            tBox_Dogs.ReadOnly = true;

            tBox_Bedsheets.ReadOnly = true;
            tBox_Bikes.ReadOnly = true;
            tBox_WaterAdult.ReadOnly = true;
            tBox_WaterChild.ReadOnly = true;

            _session = new SessionDataControl();
            _processor = new DataProcessor();

            if(_processor.GetReservationSelectedType() == 4 || _processor.GetReservationSelectedType() == 5) 
            {
                row_Bedsheet.Visible = true;
                row_EndCleaning.Visible = true;
            }
            else
            {
                row_Bedsheet.Visible = false;
                row_EndCleaning.Visible = false;
            }

            btn_Submit.Click += (but, args) =>
            {
                Response.Redirect("Confirmation.aspx");
            };

            btn_AdultsPlus.Click += (but, args) =>
            {
                AddRemoveButtonClick(0, 1);
            };

            btn_AdultsMinus.Click += (but, args) =>
            {
                AddRemoveButtonClick(0, -1);
            };

            btn_ChildrenPlus.Click += (but, args) =>
            {
                AddRemoveButtonClick(1, 1);
            };

            btn_ChildrenMinus.Click += (but, args) =>
            {
                AddRemoveButtonClick(1, -1);
            };

            btn_DogsPlus.Click += (but, args) =>
            {
                AddRemoveButtonClick(2, 1);
            };

            btn_DogsMinus.Click += (but, args) =>
            {
                AddRemoveButtonClick(2, -1);
            };

            // EXTRAS

            btn_BikesPlus.Click += (but, args) =>
            {
                AddRemoveButtonClick(3, 1);
            };

            btn_BikesMinus.Click += (but, args) =>
            {
                AddRemoveButtonClick(3, -1);
            };

            btn_BedsheetsPlus.Click += (but, args) =>
            {
                AddRemoveButtonClick(4, 1);
            };

            btn_BedsheetsMinus.Click += (but, args) =>
            {
                AddRemoveButtonClick(4, -1);
            };

            btn_WaterAdultPlus.Click += (but, args) =>
            {
                AddRemoveButtonClick(5, 1);
            };

            btn_WaterAdultMinus.Click += (but, args) =>
            {
                AddRemoveButtonClick(5, -1);
            };

            btn_WaterChildPlus.Click += (but, args) =>
            {
                AddRemoveButtonClick(6, 1);
            };

            btn_WaterChildMinus.Click += (but, args) =>
            {
                AddRemoveButtonClick(6, -1);
            };

            check_EndCleaning.CheckedChanged += (but, args) =>
            {
                if (check_EndCleaning.Checked)
                {
                    EndCleaning = 1;
                }
                else
                {
                    EndCleaning = 0;
                }
            };



            if (!IsPostBack)
            {
                tBox_Adults.Text = "0";
                tBox_Children.Text = "0";
                tBox_Dogs.Text = "0";

                tBox_Bikes.Text = "0";
                tBox_Bedsheets.Text = "0";
                tBox_WaterAdult.Text = "0";
                tBox_WaterChild.Text = "0";

                

            }

            

            tBox_Adults.Text = _processor.GetReservationMembers(0).ToString(); ;
            tBox_Children.Text = _processor.GetReservationMembers(1).ToString();
            tBox_Dogs.Text = _processor.GetReservationMembers(2).ToString();

        }

        private void AddRemoveButtonClick(int id, int amount)
        {
            switch (id)
            {
                case 0:
                    Adults = Adults + amount;
                    tBox_Adults.Text = Adults.ToString();
                    break;

                case 1:
                    Children = Children + amount;
                    tBox_Children.Text = Children.ToString();
                    break;

                case 2:
                    Dogs = Dogs + amount;
                    tBox_Dogs.Text = Dogs.ToString();
                    break;

                case 3:
                    Bycicles = Bycicles + amount;
                    if (Bycicles > TotalPeople) Bycicles = TotalPeople;
                    tBox_Bikes.Text = Bycicles.ToString();
                    break;

                case 4:
                    Bedsheets = Bedsheets+ amount;
                    if (Bedsheets > TotalPeople) Bedsheets = TotalPeople;
                    tBox_Bedsheets.Text = Bedsheets.ToString();
                    break;

                case 5:
                    WaterAdult = WaterAdult+ amount;
                    if (WaterAdult > Adults) WaterAdult = Adults;
                    tBox_WaterAdult.Text = WaterAdult.ToString();
                    break;

                case 6:
                    WaterChild = WaterChild+ amount;
                    if (WaterChild > Children) WaterChild = Children;
                    tBox_WaterChild.Text = WaterChild.ToString();
                    break;



            }

            _processor.SetReservationMembers(Adults, Children, Dogs);

        }
    }
}