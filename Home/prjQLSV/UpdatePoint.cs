using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjQLSV
{
    public partial class UpdatePoint : Form
    {
        private string Student_id;
        private string Student_name;
        private string Course_name;
        private string Course_id;
        private string Point_value;
        public UpdatePoint(string id, string firstname, string lastname, string Course, string Point)
        {
            InitializeComponent();
            this.Student_id = id;
            this.Student_name = lastname + " " + firstname;
            this.Course_name = Course;
            this.Course_id = Course.Split('-')[1];
            this.Point_value = Point;
            FillTextBox();
        }

        // mấy chỗ fill giống như này là để set value vô.
        public void FillTextBox()
        {
            textBoxMSSV.Text = Student_id;
            textBoxName.Text = Student_name;
            textBoxCourse.Text = Course_name;
            textBoxPoint.Text = Point_value;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // Chỗ này là event click update và insert điểm
        private void buttonUpdatePoint_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            float point = float.Parse(textBoxPoint.Text);

            if (Point_value.Length > 0)
            {
                try
                {
                    string queryUpdate = "UPDATE point SET value = '" + point + "' " +
                        "WHERE student_id = '" + Student_id + "' AND course_id = '" + Course_id + "';";
                    Database.Instance.Exec(queryUpdate);
                    MessageBox.Show("Cập nhật điểm thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật điểm thất bại, kiểm tra lại dữ liệu nhập vào." + ex.Message);
                }
            }
            else
            {

                try
                {
                    string queryInsert = "INSERT INTO point (student_id, course_id, value) " +
                        "VALUES ('" + Student_id + "', '" + Course_id + "', " + point + ")";

                    int result = Database.Instance.Exec(queryInsert);
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật điểm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật điểm thất bại, kiểm tra lại dữ liệu nhập vào.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật điểm thất bại, kiểm tra lại dữ liệu nhập vào." + ex.Message);
                }

            }
        }
    }
}
