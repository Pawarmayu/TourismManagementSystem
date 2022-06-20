using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace tourism
{
    public partial class FormTraveller : Form
    {
        private DataAccess Da { get; set; }
        private string CurrentUserID { get; set; }
        private Home form1 { set; get; }
        public FormTraveller()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            
            string sql = "select * from Destination_Table";
            var ds = this.Da.ExecuteQuery(sql);
            this.dgvDestination.DataSource = ds.Tables[0];

            btnOK.Enabled = false;
            lblTrip.Hide();
            txtTrip.Hide();
            pnlChangePass.Hide();
        }
        public FormTraveller(Home form, string name, string id) : this()
        {
            this.form1 = form;
            this.lblWelcome.Text += name.ToUpper();
            this.CurrentUserID = id;

        }

        private void closeProject(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string guide = "", rtn = "";
            bool checkg = false;
            bool checkr = false;
            if (rbtGyes.Checked == true)
            {
                checkg = true;
                guide = "YES";
            }
            if (rbtGno.Checked == true)
            {
                checkg = true;
                guide = "NO";
            }

            if (rbtRyes.Checked == true)
            {
                rtn = "YES";
                checkr = true;
            }
            else if (rbtRno.Checked == true)
            {
                checkr = true;
                rtn = "NO";
            }


            try
            {
                if (this.dtpArrival.Checked == false || this.dtpDeparture.Checked == false || this.txtPeople.Text == "" || checkg == false || checkr==false || this.comboBox1.Text == "")
                {
                    MessageBox.Show("Please Fill up form properly");
                    Clear();
                }
                else
                {
                    decreaseCapacity();
                    var sql = "insert into TripTable values('" + this.txtTrip.Text + "','" + this.txtPlace.Text + "','" + this.txtHotel.Text + "','" + Convert.ToDateTime(this.dtpArrival.Text) + "','" + Convert.ToDateTime(this.dtpDeparture.Text) + "','" + Convert.ToInt32(this.txtDuration.Text) + "','" + Convert.ToInt32(this.txtPeople.Text) + "','" + rtn + "','" + guide + "','" + comboBox1.SelectedItem.ToString() + "','" + Convert.ToInt32(this.txtBill.Text) + "', 'Pending')";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Your Trip is Confirmed");
                        Clear();
                        //dgvDestination.Refresh();
                    }

                    else
                    {
                        MessageBox.Show("Please try again.");
                        Clear();
                    }
                       
                }
                     
                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDestination_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AutoGenerateOrderID();
            lblTrip.Show();
            txtTrip.Show();

            dgvDestination.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnOK.Enabled = true;
            this.txtPlace.Text = dgvDestination.Rows[e.RowIndex].Cells["Place"].Value.ToString();
            this.txtHotel.Text = dgvDestination.Rows[e.RowIndex].Cells["Hotel"].Value.ToString();
            this.txtCost.Text = dgvDestination.Rows[e.RowIndex].Cells["PerNightCharge"].Value.ToString();

            this.lblAcBus.Text = dgvDestination.Rows[e.RowIndex].Cells["FareAcBus"].Value.ToString();
            this.lblNonAcBus.Text = dgvDestination.Rows[e.RowIndex].Cells["FareNonAcBus"].Value.ToString();
            this.lblPlane.Text = dgvDestination.Rows[e.RowIndex].Cells["FarePlane"].Value.ToString();
            this.lblTrain.Text = dgvDestination.Rows[e.RowIndex].Cells["FareTrain"].Value.ToString();

            this.txtId.Text = dgvDestination.Rows[e.RowIndex].Cells["DestinationId"].Value.ToString(); 

            //= dgvDestination.Rows[e.RowIndex].Cells["Place"].Value.ToString();
            //string Id = dgvDestination.Rows[e.RowIndex].Cells["DestinationId"].Value.ToString();



        }

        
        //confirmation
        private void btnCalc_Click(object sender, EventArgs e)
        {
            Sum();                 

        }

        private void dtpArrival_ValueChanged(object sender, EventArgs e)
        {
            this.dtpArrival.Checked = true;
        }

        private void dtpDeparture_ValueChanged(object sender, EventArgs e)
        {
            this.dtpDeparture.Checked = true;

            TimeSpan t = this.dtpDeparture.Value - this.dtpArrival.Value;
            string temp = t.ToString();

            string[] d = temp.Split('.');
            string f = d[0];
            this.txtDuration.Text = f;
        }

        void Clear()
        {
            this.txtCurrentPass.Text = "";
            this.txtConfirmPass.Text = "";
            this.txtNewPass.Text = "";

            this.txtCost.Text = "";
            this.txtBill.Text = "";
            this.txtDuration.Text = "";
            this.txtHotel.Text = "";
            this.txtId.Text = "";
            this.txtPeople.Text = "";
            this.txtPlace.Text = "";
            this.txtSearch.Text = "";
            this.txtTrip.Text = "";
            this.lblAcBus.Text = "";
            this.lblNonAcBus.Text = "";
            this.lblPlane.Text = "";
            this.lblTrain.Text = "";
            this.lblTrip.Text = "";

            this.rbtGno.Checked = false;
            this.rbtGyes.Checked = false;
            this.rbtRno.Checked = false;
            this.rbtRyes.Checked = false;

            this.dgvDestination.ClearSelection();
            this.dgvDestination.Refresh();
        }

        private void AutoGenerateOrderID() //for autogenerating Order id
        {
            var sql = "select OrderId from TripTable order by OrderId desc;";
            DataSet ds = this.Da.ExecuteQuery(sql);
            string previousId = ds.Tables[0].Rows[0]["OrderId"].ToString();
            string[] temp = previousId.Split('-');
            int number = Convert.ToInt32(temp[1]);
            string newUserID = "O-" + (++number).ToString("d3");
            this.txtTrip.Text = newUserID;
        }
        void decreaseCapacity() //update capacity of destination
        {
            string sql = "select Capacity from Destination_Table where DestinationId like '" + this.txtId.Text + "' ;";
            var ds = this.Da.ExecuteQuery(sql);

            int capacity = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) - Convert.ToInt32(this.txtPeople.Text);

            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) <= 0)
                MessageBox.Show("Sorry the trip is full");
            else
            {
                string update = "update Destination_Table set Capacity = '" + capacity + "' where DestinationId like '"+ this.txtId.Text +"';";
                var x = this.Da.ExecuteQuery(update);
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            pnlChangePass.Show();
           
        }

        private void btnPassConfirm_Click(object sender, EventArgs e)
        {
            string sql = "select Password from TravellerRegistrationTable where UserName like '" + this.CurrentUserID + "';";
            var ds = this.Da.ExecuteQuery(sql);

            if (this.txtCurrentPass.Text == ds.Tables[0].Rows[0][0].ToString())
            {
                if (this.txtNewPass.Text == this.txtConfirmPass.Text)
                {
                    string updateT = "update TravellerRegistrationTable set Password = '" + this.txtConfirmPass.Text + "' where UserName like '" + this.CurrentUserID + "';"; 
                    string updateL = "update Login_Table set Password = '" + this.txtConfirmPass.Text + "' where UserName like '" + this.CurrentUserID + "';";
                    int dsT = this.Da.ExecuteDMLQuery(updateT);
                    int dsL = this.Da.ExecuteDMLQuery(updateL);

                        MessageBox.Show("Password changed Successfully");
                        pnlChangePass.Hide();
                    this.txtCurrentPass.Text = "";
                    this.txtConfirmPass.Text = "";
                    this.txtNewPass.Text = "";

                }
                else
                {
                    MessageBox.Show("Password does not match");
                    this.txtConfirmPass.Text = "";
                    this.txtNewPass.Text = "";
                    this.txtCurrentPass.Text = "";
                }
                    
            }
            else
            {
                MessageBox.Show("Password Incorrect");
                this.txtConfirmPass.Text = "";
                this.txtNewPass.Text = "";
                this.txtCurrentPass.Text = "";
            }

        }

        void Sum()
        {
            int sum = 0;
            int transport=0;

            int perNight = Convert.ToInt32(this.txtCost.Text);
            int duration = Convert.ToInt32(this.txtDuration.Text);
            int num = Convert.ToInt32(this.txtPeople.Text);
            int guide = 0;

            bool r = false;
            bool g = false;

            

            if (this.comboBox1.SelectedItem.ToString() == "AC Bus")
            {
                transport = Convert.ToInt32(this.lblAcBus.Text);
            }
            else if (this.comboBox1.SelectedItem.ToString() == "Plane")
            {
                transport = Convert.ToInt32(this.lblPlane.Text);
            }
            else if (this.comboBox1.SelectedItem.ToString() == "Train")
            {
                transport = Convert.ToInt32(this.lblTrain.Text);
            }
            else if (this.comboBox1.SelectedItem.ToString() == "Non-AC Bus")
            {
                transport = Convert.ToInt32(this.lblNonAcBus.Text);
            }

            if (this.rbtRyes.Checked == true)
            {
                transport += transport;
            }
            if (this.rbtGyes.Checked == true)
            {
                guide += 2000;
            }

            sum += (((perNight * duration) + transport) * num) + guide;

            

            this.txtBill.Text = sum.ToString();


        }
    }
}
