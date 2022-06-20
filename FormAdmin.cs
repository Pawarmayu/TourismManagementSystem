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
    public partial class FormAdmin : Form
    {
        private DataAccess Da { get; set; }
        private string CurrentUserID { get; set; }
        private Home form1 { set; get; }
        public FormAdmin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            panelGuide.Hide();
            panelTraveller.Hide();
            panelTripInfo.Hide();
            panelDestination.Hide();
        }
        public FormAdmin(Home form, string name, string id) : this()
        {
            this.form1 = form;
            // this.lblWelcome.Text += name.ToUpper();
            this.CurrentUserID = id;

        }

        private void closeProject(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {


            try
            {

                string query = "select * from GuideTable";

                var ds = this.Da.ExecuteQuery(query);
                dgvGuide.DataSource = ds.Tables[0];


                panelGuide.Show();
                panelTraveller.Hide();
                panelTripInfo.Hide();
                panelDestination.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        private void btnShowTraveller_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-DLM6IFTJ\SQLEXPRESS;Initial Catalog=TourismDbs;Integrated Security=True");
                //conn.Open();
                string query = "select * from TravellerRegistration_Table";
                //SqlCommand cmd = new SqlCommand(query, conn);
                //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //adp.Fill(ds);
                //DataTable dt = ds.Tables[0];
                var ds = this.Da.ExecuteQuery(query);
                dgvTraveller.DataSource = ds.Tables[0];
                //dataGridView1.Refresh();
                //dataGridView1.AutoGenerateColumns = false;
                panelGuide.Hide();
                panelTraveller.Show();
                panelTripInfo.Hide();
                panelDestination.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e) //insert Guide
        {
            if (txtName.Text == "" || txtEmail.Text == "")
                MessageBox.Show("Please provide a value");
            else
            {
                string name = "", email = "", gender = "", address = "";



                if (txtName.Text != "")
                    name = txtName.Text;
                else
                {
                    label9.Text = "Name Required!";
                }
                if (txtEmail.Text != "")
                    email = txtEmail.Text;
                else
                {
                    label10.Text = "Email Required!";
                }

                gender = txtGender.Text;


                address = txtAddress.Text;

                //MessageBox.Show("Name:" + name + "\nUsername:" + username + "\nPassword:" + password + "\nGender:" + gender + "\nSkills:" + skills + "\nDepartment:" + department + "\nAddress:" + address + "\nDate of Birth:" + dob.ToString());

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HR04UUE;Initial Catalog=TourismDbs;Integrated Security=True");
                conn.Open();
                string query = "Delete from TravellerRegistration_Table where UserID=102";
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("User deleted successfully");
                else
                {
                    MessageBox.Show("Error Occured");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //string name = "", email = "", gender = "", address = "";
            ////DateTime dob;
            //if (txtName.Text != "")
            //    name = txtName.Text;
            //else
            //{
            //    label1.Text = "Name Required!";
            //}
            //if (txtEmail.Text != "")
            //{

            //    email = txtEmail.Text;
            //}
            //else
            //{
            //    label1.Text = "Email Required!";
            //}





            //address = txtAddress.Text;

            //try
            //{
            //    SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-DLM6IFTJ\SQLEXPRESS;Initial Catalog=TourismDbs;Integrated Security=True");
            //    conn.Open();
            //    string query = "UPDATE TravellerRegistration_Table SET Name ='" + name + "',Email='" + email + "',DateOfBirth='" + Convert.ToDateTime(this.txtDOB.Text) + "',Gender='" + gender + "',Address='" + address + "'";
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    int result = cmd.ExecuteNonQuery();
            //    if (result > 0)
            //        MessageBox.Show("User updated successfully");
            //    else
            //    {
            //        MessageBox.Show("Error Occured");

            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)// Traveller
        {
            dgvTraveller.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnShowTraveller.Enabled = true;
            this.txtID.Text = dgvTraveller.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
            this.txtName.Text = dgvTraveller.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            this.txtEmail.Text = dgvTraveller.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            this.txtDOB.Text = dgvTraveller.Rows[e.RowIndex].Cells["DateOfBirth"].Value.ToString();
            this.txtGender.Text = dgvTraveller.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
            this.txtAddress.Text = dgvTraveller.Rows[e.RowIndex].Cells["Address"].Value.ToString();






        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HR04UUE;Initial Catalog=TourismDbs;Integrated Security=True");
            string query = "select * from TravellerRegistration_Table";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTraveller.DataSource = dt;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnShowTripInfo_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-DLM6IFTJ\SQLEXPRESS;Initial Catalog=TourismDbs;Integrated Security=True");
            //conn.Open();
            string query = "select * from TripTable";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //DataTable dt = ds.Tables[0];
            var ds = this.Da.ExecuteQuery(query);
            dgvTripInfo.DataSource = ds.Tables[0];
            //dataGridView1.Refresh();
            //dataGridView1.AutoGenerateColumns = false;
            panelGuide.Hide();
            panelTraveller.Hide();
            panelTripInfo.Show();
            panelDestination.Hide();
        }

        private void btnShowDesInfo_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-DLM6IFTJ\SQLEXPRESS;Initial Catalog=TourismDbs;Integrated Security=True");
            //conn.Open();
            string query = "select * from Destination_Table";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //DataTable dt = ds.Tables[0];
            var ds = this.Da.ExecuteQuery(query);
            dgvDestination.DataSource = ds.Tables[0];
            //dataGridView1.Refresh();
            //dataGridView1.AutoGenerateColumns = false;
            panelGuide.Hide();
            panelTraveller.Hide();
            panelTripInfo.Hide();
            panelDestination.Show();
        }

        private void dgvGuide_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvGuide.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnShowGuide.Enabled = true;
            this.txtGid.Text = dgvGuide.Rows[e.RowIndex].Cells["GuideID"].Value.ToString();
            this.txtGName.Text = dgvGuide.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            this.txtGEmail.Text = dgvGuide.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            this.txtGDOB.Text = dgvGuide.Rows[e.RowIndex].Cells["DateOfBirth"].Value.ToString();
            this.txtGGender.Text = dgvGuide.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
            this.txtGContact.Text = dgvGuide.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
            this.txtNetBalance.Text = dgvGuide.Rows[e.RowIndex].Cells["Net Balance"].Value.ToString();
        }

        private void dgvDestination_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDestination.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnShowDesInfo.Enabled = true;
            this.txtDid.Text = dgvDestination.Rows[e.RowIndex].Cells["DestinationId"].Value.ToString();
            this.txtDPlace.Text = dgvDestination.Rows[e.RowIndex].Cells["Place"].Value.ToString();
            this.txtDHotel.Text = dgvDestination.Rows[e.RowIndex].Cells["Hotel"].Value.ToString();
            this.txtDPerNightCharge.Text = dgvDestination.Rows[e.RowIndex].Cells["PerNightCharge"].Value.ToString();
            this.txtDCapacity.Text = dgvDestination.Rows[e.RowIndex].Cells["Capacity"].Value.ToString();
            this.txtDFarePlane.Text = dgvDestination.Rows[e.RowIndex].Cells["FarePlane"].Value.ToString();
            this.txtFareAcBus.Text = dgvDestination.Rows[e.RowIndex].Cells["FareAcBus"].Value.ToString();
            this.txtDFareNonAcBus.Text = dgvDestination.Rows[e.RowIndex].Cells["FareNonAcBus"].Value.ToString();
            this.txtDFareTrain.Text = dgvDestination.Rows[e.RowIndex].Cells["FareTrain"].Value.ToString();


        }

        private void dgvTripInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTripInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnShowTripInfo.Enabled = true;
            this.txtOrderId.Text = dgvTripInfo.Rows[e.RowIndex].Cells["OrderId"].Value.ToString();
            this.txtPlaceTrip.Text = dgvTripInfo.Rows[e.RowIndex].Cells["Place"].Value.ToString();
            this.txtHotelTrip.Text = dgvTripInfo.Rows[e.RowIndex].Cells["Hotel"].Value.ToString();
            this.txtDOA.Text = dgvTripInfo.Rows[e.RowIndex].Cells["DateArrival"].Value.ToString();
            this.txtDOD.Text = dgvTripInfo.Rows[e.RowIndex].Cells["DateDeparture"].Value.ToString();
            this.txtPeople.Text = dgvTripInfo.Rows[e.RowIndex].Cells["NumberOfPeople"].Value.ToString();
            this.txtTotalCost.Text = dgvTripInfo.Rows[e.RowIndex].Cells["TotalCost"].Value.ToString();

        }

        private void btnGUpdate_Click(object sender, EventArgs e)
        {
        }
        private void btnGDelete_Click(object sender, EventArgs e)
        {

        }
       
       

            private void btnGRefresh_Click(object sender, EventArgs e)
            {

                
            }
        }
    }


