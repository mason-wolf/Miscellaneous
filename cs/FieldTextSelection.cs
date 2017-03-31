using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using MySql.Data.MySqlClient;

namespace Base_Oversight_Accumulator
{

    public partial class UserLogin : Form
    {
        public bool PasswordFocused;

        public UserLogin()
        {
            InitializeComponent();

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            PasswordField.GotFocus += PasswordFieldFocus;
            PasswordField.MouseUp += PasswordFieldMouseUp;
            PasswordField.Leave += PasswordFieldLeave;
        }

        void PasswordFieldFocus(object sender, EventArgs e)
        {
            if(MouseButtons == MouseButtons.None)
            {
                PasswordField.SelectAll();
                PasswordFocused = true;
            }
        }

        void PasswordFieldMouseUp(object sender, MouseEventArgs e)
        {
            if(!PasswordFocused && PasswordField.SelectionLength == 0)
            {
                PasswordFocused = true;
                PasswordField.SelectAll();
            }
        }

        void PasswordFieldLeave(object sender, EventArgs e)
        {
            PasswordFocused = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton.PerformClick();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            string username = UsernameField.Text;
            string password = PasswordField.Text;

            dbconnect mysql = new dbconnect();
            try
            {
                mysql.OpenConnection();
            }
            catch(MySqlException LoginException)
            {
                MessageBox.Show(LoginException.ToString());
            }
            if (mysql.OpenConnection() == false)
            {
                mysql.CloseConnection();
            }
            else
            {
                mysql.SelectQuery("SELECT * FROM users where username='" + username + "'");

                if (mysql.Result.Read() == false)
                {
                    FailedLoginLabel.Visible = true;
                }
                else
                {
                    mysql.CloseConnection();
                    mysql.OpenConnection();
                    mysql.SelectQuery("SELECT * FROM users where username='" + username + "'");

                    while (mysql.Result.Read())
                    {
                        string userPassword = mysql.Reader("password");
                        string UserRank = mysql.Reader("rank");
                        string UserLastName = mysql.Reader("lastname");
                        string UserFirstNamae = mysql.Reader("firstname");
                        string BOAUser = UserRank + " " + UserLastName + ", " + UserFirstNamae;

                        if (password != userPassword)
                        {
                            FailedLoginLabel.Visible = true;
                        }
                        else
                        {
                            var t = new Thread(() => Application.Run(new MainWindow(BOAUser.ToUpper())));
                            t.SetApartmentState(ApartmentState.STA);
                            t.Start();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            ServerAddressField.Text = Properties.Settings.Default.ServerAddress;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerAddress = ServerAddressField.Text;
            Properties.Settings.Default.Save();
        }

        private void PasswordField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}
