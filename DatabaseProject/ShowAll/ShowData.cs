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

namespace DatabaseProject.ShowAll
{
    public partial class ShowData : Form
    {
        tutorsystemEntities1 db = new tutorsystemEntities1();
        public ShowData()
        {
            InitializeComponent();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ShowData_Load(object sender, EventArgs e)
        {
            string[] items = { "students", "teachers", "admin", "course", "registration",
                "month", "teacher_course","complaints","attendance", "fees","teacher_salaries","fees_details" };

            for (int i = 0; i < items.Length; i++)
            {
                comboBox2.Items.Add(items[i]);
            }

           
        }

        private void Showbtn_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "students")
            {
                dataGridView1.DataSource = db.vw_students.ToList();
            }
            else if(comboBox2.SelectedItem.ToString() == "teachers")
            {
                dataGridView1.DataSource = db.vw_teachers.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "admin")
            {
                dataGridView1.DataSource = db.admins.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "fees")
            {
                dataGridView1.DataSource = db.vw_fees.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "month")
            {
                dataGridView1.DataSource = db.vw_month.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "teacher_salaries")
            {
                dataGridView1.DataSource = db.vw_teacher_salaries.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "complaints")
            {
                dataGridView1.DataSource = db.vw_complaints.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "attendance")
            {
                dataGridView1.DataSource = db.vw_attendance.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "course")
            {
                dataGridView1.DataSource = db.courses.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "registration")
            {
                dataGridView1.DataSource = db.vw_registrations.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "teacher_course")
            {
                dataGridView1.DataSource = db.vw_teacher_courses.ToList();
            }
            else if (comboBox2.SelectedItem.ToString() == "fees_details")
            {
                dataGridView1.DataSource = db.vw_fees_details.ToList();
            }


        }
    }
}
