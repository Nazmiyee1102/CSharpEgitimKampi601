using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CustomerOperations customerOperations = new CustomerOperations();

        private void btn_listele_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                Firstname = txt_firstname.Text,
                Lastname = txt_lastname.Text,
                City = txt_city.Text,
                Balance = Convert.ToDecimal(txt_balance.Text),
                ShoppingCount = Convert.ToInt32(txt_shoppingcount.Text)
            };

            customerOperations.AddCustomer(customer);
            MessageBox.Show("Müşteri Ekleme İşlemi Başarılı!","Uyarı",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
