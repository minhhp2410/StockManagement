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
using System.Threading;

namespace StockManagement.Views
{
    public partial class FormStockinPlan : DevExpress.XtraEditors.XtraForm
    {
        Services.StockinPlanServices stockinPlanServices = new Services.StockinPlanServices();
        public FormStockinPlan()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormCreateStockinPlan createStockinPlan = new FormCreateStockinPlan();
            createStockinPlan.f = this;
            createStockinPlan.StartPosition = FormStartPosition.CenterScreen;
            createStockinPlan.ShowDialog();
        }

        private void btnAdd_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        public void reLoad()
        {
            gridControl1.DataSource = stockinPlanServices._getStockinPlans();
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["isDeleted"]);
        }
        private void stockinplan_Load(object sender, EventArgs e)
        {
                reLoad();   
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //StockinPlanData data = gridView1.GetFocusedRow() as StockinPlanData;
            //FormCreateStockinPlan createStockinPlan = new FormCreateStockinPlan();
            //createStockinPlan.planID = data.planID;
            //createStockinPlan.note = data.note;
            //createStockinPlan.quotationNumber = data.quotationNumber;
            //createStockinPlan.StartPosition = FormStartPosition.CenterScreen;
            //createStockinPlan.Show();
        }
    }
}