namespace StockManagement
{
    using DevExpress.Office.Utils;
    using DevExpress.XtraReports.UI;
    using StockManagement.Model;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="rpStockIn" />.
    /// </summary>
    public partial class rpStockIn : DevExpress.XtraReports.UI.XtraReport
    {
        /// <summary>
        /// Defines the total.
        /// </summary>
        int total = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="rpStockIn"/> class.
        /// </summary>
        /// <param name="qt">The qt<see cref="List{QuoationItem}"/>.</param>
        /// <param name="sup">The sup<see cref="string"/>.</param>
        /// <param name="rp">The rp<see cref="string"/>.</param>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="number">The number<see cref="string"/>.</param>
        public rpStockIn(/*QuoationItems LS*/List<QuoationItem>qt, string sup,string rp,string name,string number)
        {
            InitializeComponent();
            objectDataSource1.DataSource = qt /*LS*/;
            xrLabel16.Text = sup;
            xrLabel50.Text = rp;
            xrLabel52.Text = name;
            xrLabel54.Text = number;        
            foreach (QuoationItem i in qt)
            {
                total += i.ActualNumber * i.UnitPrice;
            }
            xrLabel55.Text = ConvertNumbers.ChuyenSoSangChuoi(double.Parse(total.ToString()));
        }

        /// <summary>
        /// The xrLabel2_BeforePrint.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="System.Drawing.Printing.PrintEventArgs"/>.</param>
        private void xrLabel2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
    }
}
