using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Click(this, new EventArgs());
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {


                OleDbConnection connect = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=users.mdb"); //access dosyasına bağlanılır
                connect.Open();
                OleDbCommand test = new OleDbCommand("select kullaniciadi,kullanicisifresi from kullaniciverileri where kullaniciadi=@user and kullanicisifresi=@password", connect);//veri dosyasından ad ve sifreleri ceker
                test.Parameters.AddWithValue("@user", Username.Text);
                test.Parameters.AddWithValue("@password", Password.Text);
                OleDbDataReader dr;
                dr = test.ExecuteReader();//user ve password verilerini dr içerisine koyar

                if (dr.Read()) //doğruysa giriş yapar
                {
                    Main form = new Main();
                    form.Show();//giriş yapıldıktan sonra yeni pencere açılır  
                    this.Visible = false;


                }
                else //yanlışsa hata verir
                {
                    MessageBox.Show("User not found ! Please try again.");
                }
            }
            catch
            {
                MessageBox.Show("Please login correctly !");


            }
            finally{
                Username.Clear();
                Password.Clear();

            }
        }
    }
}
