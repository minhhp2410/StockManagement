using DevExpress.XtraEditors;
using System;
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
    public partial class stockoutplan : DevExpress.XtraEditors.XtraForm
    {
        public stockoutplan()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateStockoutPlan createStockoutPlan = new CreateStockoutPlan();
            createStockoutPlan.ShowDialog();
        }

        private void btnAdd_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        void reLoad()
        {
            gridControl1.DataSource = Model.StockoutPlans.getPlans();
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
        }
        private void stockoutplan_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StockoutPlanData data = gridView1.GetFocusedRow() as StockoutPlanData;
            CreateStockoutPlan createStockoutPlan = new CreateStockoutPlan();
            createStockoutPlan.planID = data.planID;
            createStockoutPlan.note = data.note;
            createStockoutPlan.poNumber = data.poNumber;
            createStockoutPlan.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            reLoad();
        }
    }
}