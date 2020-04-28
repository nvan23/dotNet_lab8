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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Handle_Login()
        {
            string query = "SELECT * FROM teacher WHERE id = '" + textUsername.Text.Trim() + "' AND password = '" + textPassword.Text.Trim() + "'";
            List<string> data = Database.Instance.ReadData(query);
            if (data.Count > 0)
            {
                Home home = new Home(textUsername.Text, data[0]);
                home.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Handle_Login();
        }

        private void LoginForm_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Handle_Login();
            }
        }
    }
}
