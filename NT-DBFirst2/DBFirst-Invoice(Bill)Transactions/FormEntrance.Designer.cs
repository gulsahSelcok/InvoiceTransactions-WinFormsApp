namespace DBFirst_Invoice_Bill_Transactions
{
    partial class FormEntrance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderCreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelOrder = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.btnOrderShow = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderCreateToolStripMenuItem,
            this.orderShowToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // orderCreateToolStripMenuItem
            // 
            this.orderCreateToolStripMenuItem.Name = "orderCreateToolStripMenuItem";
            this.orderCreateToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.orderCreateToolStripMenuItem.Text = "Order Create";
            this.orderCreateToolStripMenuItem.Click += new System.EventHandler(this.orderCreateToolStripMenuItem_Click);
            // 
            // orderShowToolStripMenuItem
            // 
            this.orderShowToolStripMenuItem.Name = "orderShowToolStripMenuItem";
            this.orderShowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.orderShowToolStripMenuItem.Text = "Order Show";
            this.orderShowToolStripMenuItem.Click += new System.EventHandler(this.orderShowToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.btnOrderShow);
            this.panelOrder.Controls.Add(this.tbOrderID);
            this.panelOrder.Controls.Add(this.label1);
            this.panelOrder.Location = new System.Drawing.Point(12, 37);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(776, 306);
            this.panelOrder.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "OrderID";
            // 
            // tbOrderID
            // 
            this.tbOrderID.Location = new System.Drawing.Point(351, 161);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.Size = new System.Drawing.Size(100, 20);
            this.tbOrderID.TabIndex = 5;
            // 
            // btnOrderShow
            // 
            this.btnOrderShow.Location = new System.Drawing.Point(296, 205);
            this.btnOrderShow.Name = "btnOrderShow";
            this.btnOrderShow.Size = new System.Drawing.Size(155, 23);
            this.btnOrderShow.TabIndex = 6;
            this.btnOrderShow.Text = "Show Order";
            this.btnOrderShow.UseVisualStyleBackColor = true;
            this.btnOrderShow.Click += new System.EventHandler(this.btnOrderShow_Click);
            // 
            // FormEntrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormEntrance";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormEntrance_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderCreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderShowToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOrderShow;
    }
}

