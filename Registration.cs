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
    public partial class Registration : Form
    {
        private DataAccess Da { get; set; }
        Home obj = new Home();
        public Registration()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            Home obj = new Home();
        }

        private void closeProject(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            obj.Show();
        }

    

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            string gender = "";
            if (txtConPass.Text != txtPass.Text)
                lblIncorrect.Text = "Password does not match";
      
            else
            {
                if (radMale.Checked == true)
                    gender = "Male";
                else if (radFemale.Checked == true)
                    gender = "Female";
                else if (radnon.Checked == true)
                    gender = "Not Specified";
                
                
                try
                {
                    var sql = "INSERT INTO TravellerRegistrationTable VALUES('"+ this.txtUname.Text + "' , '" + this.txtName.Text + "','" + this.txtEmail.Text + "','" + this.txtPass.Text + "','" + Convert.ToDateTime(this.DOB.Text) + "','" + gender + "','" + this.txtAddress.Text + "')";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    var user = "INSERT INTO Login_Table VALUES('" + this.txtUname.Text + "' ,'" + this.txtPass.Text + "' , 'Traveller' ,'" + this.txtName.Text + "')";
                    int countL = this.Da.ExecuteDMLQuery(user);

                    if (count == 1 && countL == 1)
                    {
                        MessageBox.Show("Registration Successful.");
                        this.Hide();
                        obj.Show();
                    }
                    else
                        MessageBox.Show("Please Try Again.");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }

        private void editUname(object sender, EventArgs e)
        {
            AutoGenerateCustomerID();
        }
        private void AutoGenerateCustomerID() //for autogenerating customer id
        {
            var sql = "select UserName from TravellerRegistrationTable order by UserName desc;";
            DataSet ds = this.Da.ExecuteQuery(sql);
            string previousId = ds.Tables[0].Rows[0]["UserName"].ToString();
            string[] temp = previousId.Split('-');
            int number = Convert.ToInt32(temp[1]);
            string newUserID = "T-" + (++number).ToString("d3");
            this.txtUname.Text = newUserID;
        }
    }
}
