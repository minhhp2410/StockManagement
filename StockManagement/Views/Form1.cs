using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Model.BarcodeGeneration.drawBarCode128("11052021 p369875 1", 60, 1);
            Image image= Model.BarcodeGeneration.drawBarCode128("11052021 p369875 1", 60, 1);
            image.Save("bar.png");
        }
    }
}
