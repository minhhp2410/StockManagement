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
    public partial class FormStockoutPlan : DevExpress.XtraEditors.XtraForm
    {
        Services.StockoutPlanServices stockoutPlanServices = new Services.StockoutPlanServices();
        public FormStockoutPlan()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormCreateStockoutPlan createStockoutPlan = new FormCreateStockoutPlan();
            createStockoutPlan.StartPosition = FormStartPosition.CenterScreen;
            createStockoutPlan.f = this;
            createStockoutPlan.ShowDialog();
        }

        private void btnAdd_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        public void reLoad()
        {
            gridControl1.DataSource = stockoutPlanServices._getStockoutPlans();
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["isDeleted"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
        }
        private void stockoutplan_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //StockoutPlanData data = gridView1.GetFocusedRow() as StockoutPlanData;
            //FormCreateStockoutPlan createStockoutPlan = new FormCreateStockoutPlan();
            //createStockoutPlan.planID = data.planID;
            //createStockoutPlan.note = data.note;
            //createStockoutPlan.poNumber = data.poNumber;
            //createStockoutPlan.StartPosition = FormStartPosition.CenterScreen;
            //createStockoutPlan.Show();
        }
    }
}