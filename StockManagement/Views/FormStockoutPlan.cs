using System;
using System.Windows.Forms;

namespace StockManagement.Views
{
    public partial class FormStockoutPlan : DevExpress.XtraEditors.XtraForm
    {
        private Services.StockoutPlanServices stockoutPlanServices = new Services.StockoutPlanServices();

        public FormStockoutPlan()
        {
            InitializeComponent();
        }

        public void reLoad()
        {
            gridControl1.DataSource = stockoutPlanServices._getStockoutPlans();
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["isDeleted"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
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

        private void stockoutplan_Load(object sender, EventArgs e)
        {
            reLoad();
        }
    }
}