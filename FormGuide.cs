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
    public partial class FormGuide : Form
    {
        private DataAccess Da { get; set; }
        private string CurrentUserID { get; set; }
        private Home form1 { set; get; }
        public FormGuide()
        {
            InitializeComponent();
        }
        public FormGuide(Home form, string name, string id) : this()
        {
            this.form1 = form;
            //this.lblWelcome.Text += name.ToUpper();
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
                SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-DLM6IFTJ\SQLEXPRESS;Initial Catalog=TourismDbs;Integrated Security=True");
                conn.Open();
                string query = "select * from Guide";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                dataGridView1.AutoGenerateColumns = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
