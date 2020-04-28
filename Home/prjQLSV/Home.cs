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
    public partial class Home : Form
    {
        private string teacher_id;
        private string current_subject_id;
        public Home(string id, string name)
        {
            InitializeComponent();
            this.teacher_id = id;
            teacherNameLabel.Text = name;
            InitialData();
        }

        private void InitialData()
        {
            stateLabel.Text = "Đang tải...";
            string query = "SELECT DISTINCT s.id AS id, s.name AS name " +
                "FROM subject AS s " +
                "JOIN course AS c ON s.id = c.subject_id " +
                "WHERE c.teacher_id = '" + teacher_id + "';";
            DataTable data = Database.Instance.LoadData(query);

            if (data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    Button btn = new Button();
                    btn.Text = row["id"].ToString() + " " +
                        row["name"].ToString();
                    btn.Name = row["id"].ToString();
                    btn.Click += new EventHandler(Course_Click);
                    btn.AutoSize = true;
                    btn.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    container.Controls.Add(btn);
                }
                stateLabel.Text = "Đã tải thành công " + data.Rows.Count.ToString() + " môn học.";
            }
            else
            {
                stateLabel.Text = "Không có dữ liệu.";
            }
        }

        private DataTable Load_Students(string subject_id)
        {
            string query = "SELECT s.id as 'MSSV', s.lastname as 'Họ', s.firstname as 'Tên', " +
                "l.name as 'Lớp', CONCAT(c.subject_id, '-', c.id) as 'Mã HP', " +
                "p.value as 'Điểm' " +
                "FROM student AS s " +
                "JOIN course AS c ON c.class_id = s.class_id " +
                "JOIN class AS l ON l.id = c.class_id " +
                "LEFT JOIN point AS p ON (p.student_id = s.id AND p.course_id = c.id) " +
                "WHERE c.subject_id = '" + subject_id + "';";

            return Database.Instance.LoadData(query);
        }

        private void Course_Click(object sender, EventArgs args)
        {
            Button btn = sender as Button;
            string subject_id = btn.Name;
            current_subject_id = subject_id;


            dataTable.DataSource = null;
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            dataTable.Refresh();

            stateLabel.Text = "Đang tải...";
            DataTable dataSourse = Load_Students(subject_id);
            stateLabel.Text = "Đã tải thành công " + dataSourse.Rows.Count.ToString() + " sinh viên.";

            dataTable.DataSource = dataSourse;

            DataGridViewButtonColumn actionsCol = new DataGridViewButtonColumn();
            actionsCol.HeaderText = "Thao tác";
            actionsCol.Name = "actions";
            actionsCol.Text = "Cập nhật";
            actionsCol.UseColumnTextForButtonValue = true;
            dataTable.Columns.Add(actionsCol);
            this.dataTable.Visible = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.dataTable.Visible = false;
        }

        private void dataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataTable.Columns[e.ColumnIndex].Name == "actions")
            {
                DataGridViewRow row = dataTable.Rows[e.RowIndex];
                List<DataGridViewColumn> cols = dataTable.Columns.Cast<DataGridViewColumn>().ToList();

                int mssvIndex = cols.FindIndex(c => c.Name == "MSSV");
                int firstnameIndex = cols.FindIndex(c => c.Name == "Tên");
                int lastnameIndex = cols.FindIndex(c => c.Name == "Họ");
                int courseIndex = cols.FindIndex(c => c.Name == "Mã HP");
                int pointIndex = cols.FindIndex(c => c.Name == "Điểm");

                string rMSSV = row.Cells[mssvIndex].Value.ToString();
                string rFirstname = row.Cells[firstnameIndex].Value.ToString();
                string rLastname = row.Cells[lastnameIndex].Value.ToString();
                string rCourse = row.Cells[courseIndex].Value.ToString();
                string rPoint = row.Cells[pointIndex].Value.ToString();

                UpdatePoint updatePoint = new UpdatePoint(rMSSV, rFirstname, rLastname, rCourse, rPoint);
                updatePoint.Disposed += new EventHandler(Point_FormClosed);
                updatePoint.Visible = true;
            }
        }

        private void Point_FormClosed(object sender, EventArgs e)
        {
            dataTable.DataSource = Load_Students(current_subject_id);
            dataTable.Refresh();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login();
            login.Visible = true;
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
