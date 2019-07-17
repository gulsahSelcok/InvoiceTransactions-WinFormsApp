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
    public partial class FormOrderDetail : Form
    {
        public FormOrderDetail()
        {
            InitializeComponent();
        }
        NorthwindEntities db = new NorthwindEntities();
        private static int choosenOrderID;
        private Order order;
        private static int choosenOrderDetailOrderID;
        private static int choosenOrderDetailProductID;
        public FormOrderDetail(int orderID)
        {
            choosenOrderID = orderID;
            order = db.Orders.Find(choosenOrderID);
            InitializeComponent();
        }

        private void FormOrderDetail_Load(object sender, EventArgs e)
        {
            CustomerFill();// Bu metodlar comboboxların içini dolduruyor.
            EmployeeFill();// Doldurma işlemini yapmadığımıza önceki sayfada seçilen verileri tekrar bu alanlara doldurmuyor.
            ShipViaFill(); // O yüzden önceki verileri almadan önce bu alanların verilerini doldurmamız gerekir.
            OrderDetailDataFill();
            ProductFill();
            tbOrderID.Text = order.OrderID.ToString();
            cbCustomer.SelectedValue = order.CustomerID;   
            cbEmployee.SelectedValue = order.EmployeeID;
            cbShipVia.SelectedValue = order.ShipVia;
            dtpOrderDate.Value = order.OrderDate.Value;
            dtpRequiredDate.Value = order.RequiredDate.Value;            
            tbFreight.Text = order.Freight.ToString();
            var customer = db.Customers.Where(x => x.CustomerID == order.CustomerID).Select(x => x);
            foreach (var item in customer)
            {
                tbAddress.Text = item.Address;
                tbCity.Text = item.City;
            }
        }
        private void OrderEmpty()
        {
            tbOrderID.Text = " ";
            cbCustomer.SelectedValue = " ";
            cbEmployee.SelectedValue = " ";
            dtpOrderDate.Value = DateTime.Now;
            dtpRequiredDate.Value = DateTime.Now;
            tbFreight.Text = " ";
            cbShipVia.SelectedValue = " ";
            tbAddress.Text = " ";
            tbCity.Text = " ";
        }
        private void CustomerFill()
        {
            var customer = db.Customers.Select(x => new
            {
                x.CustomerID,
                x.CompanyName
            }).ToList();
            cbCustomer.DisplayMember = "CompanyName";
            cbCustomer.ValueMember = "CustomerID";
            cbCustomer.DataSource = customer;
        }
        private void EmployeeFill()
        {
            var employee = db.Employees.Select(x => new {
                EmpID = x.EmployeeID,
                FullName = x.FirstName + " " + x.LastName
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
        private void ProductFill()
        {
            var products = db.Products.Select(x => new {
                x.ProductID,
                x.ProductName
            }).ToList();
            cbProducts.DisplayMember = "ProductName";
            cbProducts.ValueMember = "ProductID";
            cbProducts.DataSource = products;
        }
        private void OrderDetailDataFill()
        {
            var orderDetail = db.Order_Details.Where(x => x.OrderID == choosenOrderID).Select(x=>x).ToList();
            dataGridView1.DataSource = orderDetail;
            decimal sum=0;
            foreach (var item in orderDetail)
            {
                sum += (item.Quantity) * (item.UnitPrice);
            }
            tbSumOrder.Text = sum.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Order_Detail orderDetail = db.Order_Details.Where(X => X.OrderID == choosenOrderDetailOrderID && X.ProductID==choosenOrderDetailProductID).Select(x=>x).FirstOrDefault();
            orderDetail.Quantity =Convert.ToInt16(tbQuantity.Text);
            db.SaveChanges();
            OrderDetailDataFill();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Order_Detail orderDetail = new Order_Detail();
            orderDetail.Quantity = Convert.ToInt16(tbQuantity.Text);
            orderDetail.ProductID = (int)cbProducts.SelectedValue;
            orderDetail.OrderID = choosenOrderID;
            orderDetail.UnitPrice = 10;
            orderDetail.Discount = 0;
            db.Order_Details.Add(orderDetail);
            db.SaveChanges();
            OrderDetailDataFill();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            choosenOrderDetailOrderID= (int)dataGridView1.CurrentRow.Cells["OrderID"].Value;
            choosenOrderDetailProductID = (int)dataGridView1.CurrentRow.Cells["ProductID"].Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var orderDetail = db.Order_Details.Where(X => X.OrderID == choosenOrderDetailOrderID && X.ProductID == choosenOrderDetailProductID).FirstOrDefault();
            db.Order_Details.Remove(orderDetail);
            db.SaveChanges();
            OrderDetailDataFill();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            Order order = db.Orders.Where(x => x.OrderID == choosenOrderID).Select(x=>x).FirstOrDefault();
            order.CustomerID = cbCustomer.SelectedValue.ToString();
            order.EmployeeID = (int)cbEmployee.SelectedValue;
            order.OrderDate = dtpOrderDate.Value;
            order.RequiredDate = dtpRequiredDate.Value;
            order.ShipVia = (int)cbShipVia.SelectedValue;
            order.Freight = Convert.ToDecimal(tbFreight.Text);
            db.SaveChanges();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            var order = db.Orders.Where(x => x.OrderID == choosenOrderID).Select(x=>x).FirstOrDefault();
            db.Orders.Remove(order);
            db.SaveChanges();
            OrderEmpty();
        }

        private void cbCustomer_SelectedValueChanged(object sender, EventArgs e)
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
    }
}
