using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFirst_Invoice_Bill_Transactions
{
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }
        NorthwindEntities db = new NorthwindEntities();
        
        private void FormOrder_Load(object sender, EventArgs e)
        {
            CustomerFill();
            EmployeeFill();
            ShipViaFill();
        }

        private void CustomerFill()
        {
            var customer = db.Customers.Select(x => new
            {
                x.CustomerID,
                x.CompanyName
            }).ToList() ;
            cbCustomer.DisplayMember = "CompanyName";
            cbCustomer.ValueMember = "CustomerID";
            cbCustomer.DataSource = customer;
        }
        private void EmployeeFill()
        {
            var employee = db.Employees.Select(x => new {
                EmpID=x.EmployeeID,
                FullName=x.FirstName +" "+x.LastName
            }).ToList();
            cbEmployee.DisplayMember = "FullName";
            cbEmployee.ValueMember = "EmpID";
            cbEmployee.DataSource = employee;
        }
        private void ShipViaFill()
        {
            var shipVia = db.Shippers.Select(x => new {
                x.CompanyName,
                x.ShipperID
            }).ToList();
            cbShipVia.DisplayMember = "CompanyName";
            cbShipVia.ValueMember = "ShipperID";
            cbShipVia.DataSource = shipVia;
        }
        
        private void cbCustomer_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cbCustomer.SelectedValue != null)
            {
                string customerId = cbCustomer.SelectedValue.ToString();
                var customer = db.Customers.Where(x => x.CustomerID == customerId).Select(x => x);
                foreach (var item in customer)
                {
                    tbAddress.Text = item.Address;
                    tbCity.Text = item.City;
                }
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.CustomerID = cbCustomer.SelectedValue.ToString();
            order.EmployeeID = (int) cbEmployee.SelectedValue;
            order.OrderDate = dtpOrderDate.Value;
            order.RequiredDate = dtpOrderDate.Value;
            order.ShipVia = (int) cbShipVia.SelectedValue;
            order.Freight =Convert.ToDecimal(tbFreight.Text);
            db.Orders.Add(order);
            db.SaveChanges();

            FormOrderDetail frmDetails = new FormOrderDetail(order.OrderID);
            frmDetails.Show();
            //this.Hide();
        }
    }
}
