using DatabaseProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject.StudentsProcess
{
    public partial class students : Form
    {
        tutorsystemEntities1 db = new tutorsystemEntities1();
        public students()
        {
            InitializeComponent();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Uploadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select A Image";
            opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = opFile.FileName;

                    File.Copy(iName, Path.Combine(@"../../Resources", Path.GetFileName(iName)));
                    pictureBox1.Image = new Bitmap(opFile.OpenFile());

                    label5.Text = "../../Resources" + Path.GetFileName(iName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Open File" + ex.Message);
                    label5.Text = "-1";
                }
            }
            else
            {
                opFile.Dispose();
            }
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            student std = new student();
            std.student_name = txtname.Text;
            std.CNIC = txtcnic.Text;
            std.phone = txtphone.Text;
            std.DOB = dateTimePicker1.Value;
            db.students.Add(std);
            db.SaveChanges();
            MessageBox.Show("Records Inserted");
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idtoupdate.Text);
            student std = db.students.Where(x => x.student_id == id).SingleOrDefault();

            if(std != null)
            {
                utxtname.Text = std.student_name;
                utxtcnic.Text = std.CNIC;
                utxtphone.Text = std.phone;
                dateTimePicker2.Value = (DateTime)std.DOB;
            }
            else
            {
                MessageBox.Show("No Record Found");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idtoupdate.Text);
            student std = db.students.Where(x => x.student_id == id).SingleOrDefault();
            std.student_name = utxtname.Text;
            std.CNIC = utxtcnic.Text;
            std.phone = utxtphone.Text;
            std.DOB = dateTimePicker2.Value;
            db.SaveChanges();
            MessageBox.Show("Records Updated");
        }

        private void Showthis_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtshowone.Text);
            student std = db.students.Where(x => x.student_id == id).ToList().SingleOrDefault();
            dataGridView1.DataSource = std;
        }

        private void Showall_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.students.ToList();
        }
    }
}
