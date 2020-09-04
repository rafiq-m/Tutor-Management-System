using DatabaseProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DatabaseProject
{
    public partial class Form1 : Form
    {
        tutorsystemEntities1 db = new tutorsystemEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string logintxt = txtlogin.Text;
            string pass = txtpass.Text;

            admin ad = db.admins.Where(x => x.login_id == logintxt).SingleOrDefault();
            if (ad == null)
            {
                MessageBox.Show("No Record Found");
            }
            else if (ad.login_id == logintxt && ad.login_password == pass)
            {
                MessageBox.Show("You've loged in your database");
                StudentsProcess.students std = new StudentsProcess.students();
                ShowAll.ShowData sd = new ShowAll.ShowData();
                sd.Show();
                std.Show();
            }
            else
            {
                MessageBox.Show("Username or Password Invalid");
            }
        }
    }
}
