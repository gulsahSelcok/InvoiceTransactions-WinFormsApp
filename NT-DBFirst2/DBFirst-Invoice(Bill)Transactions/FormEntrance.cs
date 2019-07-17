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
    public partial class FormEntrance : Form
    {
        public FormEntrance()
        {
            InitializeComponent();
        }
        FormOrder frmOrder = new FormOrder();
        NorthwindEntities db = new NorthwindEntities();

        private void FormEntrance_Load(object sender, EventArgs e)
        {
            panelOrder.Visible = false;
        }
        private void orderCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrder.Show();
            this.Hide();
        }

        private void btnOrderShow_Click(object sender, EventArgs e)
        {
            int orderID=Convert.ToInt32(tbOrderID.Text);
            var order = db.Orders.Where(x => x.OrderID == orderID).FirstOrDefault();
            FormOrderDetail frmDetails = new FormOrderDetail(order.OrderID);
            frmDetails.Show();
            //this.Hide();
        }

        private void orderShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelOrder.Visible = true;
        }

      
    }
}
