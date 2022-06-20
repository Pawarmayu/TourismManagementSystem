using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tourism
{
    public partial class Home : Form
    {
        private DataAccess Da { get; set; }
        public Home()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSignup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSignIn = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.btnSignin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlSignIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnSignup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pnlSignIn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1124, 576);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sign Up today!";
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(567, 423);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(94, 29);
            this.btnSignup.TabIndex = 4;
            this.btnSignup.Text = "Sign up now.";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Magneto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(289, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to Sparrows Tourism";
            // 
            // pnlSignIn
            // 
            this.pnlSignIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSignIn.Controls.Add(this.label3);
            this.pnlSignIn.Controls.Add(this.txtPass);
            this.pnlSignIn.Controls.Add(this.txtUname);
            this.pnlSignIn.Controls.Add(this.btnSignin);
            this.pnlSignIn.Controls.Add(this.label4);
            this.pnlSignIn.Controls.Add(this.label2);
            this.pnlSignIn.Location = new System.Drawing.Point(366, 167);
            this.pnlSignIn.Name = "pnlSignIn";
            this.pnlSignIn.Size = new System.Drawing.Size(364, 221);
            this.pnlSignIn.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sign In:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(128, 108);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(199, 27);
            this.txtPass.TabIndex = 2;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(128, 48);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(199, 27);
            this.txtUname.TabIndex = 1;
            // 
            // btnSignin
            // 
            this.btnSignin.Location = new System.Drawing.Point(128, 173);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(94, 29);
            this.btnSignin.TabIndex = 3;
            this.btnSignin.Text = "Sign in";
            this.btnSignin.UseVisualStyleBackColor = true;
            this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "User ID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password: ";
            // 
            // Home
            // 
            this.ClientSize = new System.Drawing.Size(1124, 576);
            this.Controls.Add(this.panel1);
            this.Name = "Home";
            this.Text = "Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closeProject);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSignIn.ResumeLayout(false);
            this.pnlSignIn.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();

            this.Hide();
            reg.Show();

        }

        private void closeProject(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string sql = "select * from Login_Table where UserName = '" + this.txtUname.Text + "' and Password = '" + this.txtPass.Text + "'";
            var ds = this.Da.ExecuteQuery(sql);

            if (ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Login Valid!");

                this.ClearData();
                this.Hide();

                string name = ds.Tables[0].Rows[0][3].ToString();
                string userId = ds.Tables[0].Rows[0][0].ToString();

                if (ds.Tables[0].Rows[0][2].ToString().ToLower() == "traveller")
                {
                    FormTraveller traveller = new FormTraveller(this, name, userId);
                    traveller.Show();
                }

                else if (ds.Tables[0].Rows[0][2].ToString().ToLower() == "admin")
                {
                    FormAdmin admin = new FormAdmin(this, name, userId);
                    admin.Show();
                }

                else if (ds.Tables[0].Rows[0][2].ToString().ToLower() == "guide")
                {
                    FormGuide guide = new FormGuide(this, name, userId);
                    guide.Show();
                }
            }
            else
            {
                MessageBox.Show("The User ID or Password is Invalid!");
                ClearData();
            }
        }
        private void ClearData()
        {
            this.txtUname.Clear();
            this.txtPass.Clear();
        }
    }
}
