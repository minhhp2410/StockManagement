using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zen.Barcode;

namespace StockManagement.Model
{
    class BarcodeGeneration
    {
        public static Image drawBarCode128(string barcodeValues, int maxHeight, int scale)
        {
            int barCodeResHeight = 18, yCoordidate=11;

            Code128BarcodeDraw code128 = BarcodeDrawFactory.Code128WithChecksum;
            Image barcodeImage=code128.Draw(barcodeValues, maxHeight, scale);
            Image res = (Image)new Bitmap(barcodeImage.Width, barcodeImage.Height+barCodeResHeight);
            using (var graphics = Graphics.FromImage(res))
            using (var font = new Font("Times New Roman", 11)) // Any font you want
            using (var brush = new SolidBrush(Color.Black))
            using (var format = new StringFormat() { LineAlignment = StringAlignment.Center }) // To align text above the specified point
            {
                // Print a string at the left bottom corner of image
                graphics.DrawImage(barcodeImage,new Rectangle(0,0,barcodeImage.Width,barcodeImage.Height));
                SizeF sizeF = graphics.MeasureString(barcodeValues, font);
                graphics.DrawString(barcodeValues, font, brush, barcodeImage.Width/2 - sizeF.Width/2, barcodeImage.Height+yCoordidate, format);
            }
            return res;
        }
    }
}
