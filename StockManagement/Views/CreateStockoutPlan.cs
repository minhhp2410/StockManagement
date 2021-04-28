using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;
using StockManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Views
{
    public partial class CreateStockoutPlan : DevExpress.XtraEditors.XtraForm
    {
        public string note = "", planID = "", poNumber = "";
        public stockoutplan f = new stockoutplan();
        List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        List<Model.PlanDetail> planDetails = new List<Model.PlanDetail>();
        public CreateStockoutPlan()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Model.PlanDetail.insertStockoutPlanDetail(gridView1, "stockoutplandetails", textBox1.Text, textEdit1.Text, comboBoxEdit1.Text);
            f.reLoad();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text != "")
            {
                string partNumber = comboBoxEdit2.Text.Split('-')[0];
                Model.DataInventory data = inventories.Where(w => w.partNumber == partNumber).FirstOrDefault();
                List<Model.PlanDetail> planDetailss = new List<Model.PlanDetail>();
                planDetailss.AddRange(planDetails.ToArray());
                if (planDetails.FindIndex(a => a.partNumber == data.partNumber) < 0)
                {

                    planDetailss.Add(new Model.PlanDetail
                    {
                        partName = data.partName,
                        partNumber = data.partNumber,
                        position = data.position,
                        price = data.price,
                        quantity = 0,
                        currency = data.currency,
                        unit = data.unit
                    });
                    gridControl1.DataSource = planDetailss;
                    planDetails.Clear();
                    planDetails.AddRange(planDetailss.ToArray());
                    return;
                }
                MessageBox.Show("Săn phẩm đã tồn tại");
            }
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                object row = gridView1.GetFocusedRow();
                gridView1.DeleteRow(gridView1.FindRow(row));
                planDetails.Remove(row as PlanDetail);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            planDetails = new List<PlanDetail>();
            string res = Model.RestSharpC.execCommand5("poitems", RestSharp.Method.GET, int.Parse(textEdit1.Text));
            JsonHeadPOItem poItems = JsonConvert.DeserializeObject<JsonHeadPOItem>(res);
            poItems.Data.ToList().ForEach(i =>
            {
                planDetails.Add(new Model.PlanDetail()
                {
                    partNumber = i.PartNumber,
                    partName = i.PartName,
                    position = i.Position,
                    price = i.UnitPrice,
                    currency = i.Currency,
                    quantity = i.Quantity,
                    unit = i.Unit
                });
            });
            gridControl1.DataSource = planDetails;
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["planID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
        }

        private void CreateStockoutPlan_Load(object sender, EventArgs e)
        {
            if (planID != "")
            {
                gridControl1.DataSource = Model.PlanDetail.getPlanList("stockoutplandetails", planID);
                groupControl1.Text = "thông tin chi tiết " + planID;
                this.Text = "thông tin chi tiết " + planID;
                button1.Enabled = false;
                simpleButton1.Enabled = false;
                textBox1.Text = note;
                textEdit1.Text = poNumber;
            }
            else
            {
                gridControl1.DataSource = planDetails;
            }
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["planID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
            ComboBoxItemCollection collection = comboBoxEdit2.Properties.Items;
            inventories = Model.Inventory.getInventories();
            collection.AddRange(inventories.Select(s => s.partNumber + "-" + s.partName as object).ToArray());
        }
    }
}