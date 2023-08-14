using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            dgwCustomer.DataSource = customerManager.GetAll().Data;
        }
    }
}