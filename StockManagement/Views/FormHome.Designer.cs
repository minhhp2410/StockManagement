namespace StockManagement
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbStock = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.rbHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnStockinPlan = new DevExpress.XtraBars.BarButtonItem();
            this.btnStockoutPlan = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnInventory = new DevExpress.XtraBars.BarButtonItem();
            this.btnStockin = new DevExpress.XtraBars.BarButtonItem();
            this.btnStockout = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // rbStock
            // 
            this.rbStock.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.rbStock.Name = "rbStock";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 5;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "    Stock";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // rbHome
            // 
            this.rbHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.rbHome.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("rbHome.ImageOptions.Image")));
            this.rbHome.Name = "rbHome";
            this.rbHome.Text = "Trang chủ";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnStockinPlan);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnStockoutPlan);
            this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tạo kế hoạch";
            // 
            // btnStockinPlan
            // 
            this.btnStockinPlan.Caption = "Kế hoạch nhập";
            this.btnStockinPlan.Id = 12;
            this.btnStockinPlan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStockinPlan.ImageOptions.Image")));
            this.btnStockinPlan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStockinPlan.ImageOptions.LargeImage")));
            this.btnStockinPlan.Name = "btnStockinPlan";
            this.btnStockinPlan.SmallWithTextWidth = 100;
            this.btnStockinPlan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStockinPlan_ItemClick);
            // 
            // btnStockoutPlan
            // 
            this.btnStockoutPlan.Caption = "Kế Hoạch Xuất";
            this.btnStockoutPlan.Id = 16;
            this.btnStockoutPlan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStockoutPlan.ImageOptions.Image")));
            this.btnStockoutPlan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStockoutPlan.ImageOptions.LargeImage")));
            this.btnStockoutPlan.Name = "btnStockoutPlan";
            this.btnStockoutPlan.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnStockoutPlan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStockoutPlan_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnInventory);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnStockin);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnStockout);
            this.ribbonPageGroup2.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Kho";
            // 
            // btnInventory
            // 
            this.btnInventory.Caption = "Xem Kho";
            this.btnInventory.Id = 20;
            this.btnInventory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.ImageOptions.Image")));
            this.btnInventory.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInventory.ImageOptions.LargeImage")));
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnInventory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // btnStockin
            // 
            this.btnStockin.Caption = "Nhập kho";
            this.btnStockin.Id = 17;
            this.btnStockin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStockinReceipt.ImageOptions.Image")));
            this.btnStockin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStockinReceipt.ImageOptions.LargeImage")));
            this.btnStockin.Name = "btnStockin";
            this.btnStockin.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnStockin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStockinReceipt_ItemClick);
            // 
            // btnStockout
            // 
            this.btnStockout.Caption = "Xuất kho";
            this.btnStockout.Id = 18;
            this.btnStockout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStockoutReceipt.ImageOptions.Image")));
            this.btnStockout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStockoutReceipt.ImageOptions.LargeImage")));
            this.btnStockout.Name = "btnStockout";
            this.btnStockout.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnStockout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStockoutReceipt_ItemClick);
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup3.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Báo cáo thống kê";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Báo Cáo";
            this.barButtonItem4.Id = 19;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnStockinPlan,
            this.btnStockoutPlan,
            this.btnStockin,
            this.btnStockout,
            this.barButtonItem4,
            this.btnInventory,
            this.barButtonItem6});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbHome});
            this.ribbonControl1.Size = new System.Drawing.Size(1050, 173);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Đóng tab";
            this.barButtonItem6.Id = 21;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 173);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1050, 465);
            this.panelControl1.TabIndex = 11;
            // 
            // FormHome
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 638);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FormHome.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MinimumSize = new System.Drawing.Size(550, 4);
            this.Name = "FormHome";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rbStock;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnStockinPlan;
        private DevExpress.XtraBars.BarButtonItem btnStockoutPlan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnStockin;
        private DevExpress.XtraBars.BarButtonItem btnStockout;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnInventory;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        public  DevExpress.XtraEditors.PanelControl panelControl1;
    }
}

