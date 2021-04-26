﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagement.Model;

namespace StockManagement.Views
{
    public partial class inventory : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public inventory()
        {
            InitializeComponent();
            
        }
        void loadInventory()
        {
            gridControl1.DataSource = Inventory.getInventories();
            gridView1.Columns[0].Visible = false;
            gridView1.Columns["createdAt"].Visible = false;
        }
        private void inventory_Load(object sender, EventArgs e)
        {
            loadInventory();
        }
    }
}
