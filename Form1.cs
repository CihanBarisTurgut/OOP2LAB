using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace _1Prelab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Default username and passwords
        private void btnadmin_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "admin"; 
            txtusername.Text = "admin";
        }

        // Default username and passwords
        private void btnuser_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "user";
            txtusername.Text = "user";
        }

        // Clear username
        private void txtusername_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
        }

        // Clear passwords 
        // Password field show the characters as ‘******’
        private void txtpassword_Click(object sender, EventArgs e)
        {
            txtpassword.Clear();
            txtpassword.PasswordChar = '*';
        }

        // Login button checks the entered information if info true shows main game window else show warning message
        private void btnlogin_Click(object sender, EventArgs e)
        {
            Hide();
            MainGame form2 = new MainGame();
            form2.ShowDialog();
        }

        // Pressing the “Enter” key has the same functionality as clicking on the login button
        // Pressing the “Tab” key focuses login button
        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnlogin.PerformClick();
            }
            if (e.KeyChar == (char)Keys.Tab)
            {
                btnlogin.Focus();
            }
        }

        // At the first run, the username field focused
        private void Form1_Load(object sender, EventArgs e)
        {
            ActiveControl = txtusername;
        }

        // Pressing the “Tab” key focuses password field
        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
                txtpassword.Focus();
            }
        }

    }
}
