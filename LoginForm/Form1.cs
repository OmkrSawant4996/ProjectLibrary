using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ProjectLibrary;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        UsersDataStore usersDataStore;
        public Form1()
        {
            InitializeComponent();
            usersDataStore = new UsersDataStore(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            bool count = false;
            try
            {
                count = usersDataStore.ValidateUser(userName, password);
                if (count == true)
                {
                    MessageBox.Show("User Valid");
                    formLbl Formlbl = new formLbl();
                    Form1.ActiveForm.Hide();
                    Formlbl.Show();


                }
                else
                {
                    MessageBox.Show("Invalid Valid");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
