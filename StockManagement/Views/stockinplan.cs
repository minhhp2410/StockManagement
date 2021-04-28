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
    public partial class stockinplan : DevExpress.XtraEditors.XtraForm
    {
        public stockinplan()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateStockinPlan createStockinPlan = new CreateStockinPlan();
            createStockinPlan.f = this;
            createStockinPlan.ShowDialog();
        }

        private void btnAdd_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        public void reLoad()
        {
            gridControl1.DataSource = StockinPlans.getPlans();
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
        }
        private void stockinplan_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StockinPlanData data = gridView1.GetFocusedRow() as StockinPlanData;
            CreateStockinPlan createStockinPlan = new CreateStockinPlan();
            createStockinPlan.planID = data.planID;
            createStockinPlan.note = data.note;
            createStockinPlan.quotationNumber = data.quotationNumber;
            createStockinPlan.StartPosition = FormStartPosition.CenterScreen;
            createStockinPlan.Show();
        }
    }
}