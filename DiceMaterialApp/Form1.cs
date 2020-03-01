using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceMaterialApp
{
    public partial class Form1 : Form
    {
        int x = 50;
        int y = 50;
        int wid = 1000;
        int depth = 400;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();

            //練習の線
            g.DrawLine(Pens.Red, 0, 0, pictureBox1.Width, 0);

            //横幅の寸法線
            g.DrawLine(Pens.Blue, x, (y - 20), (wid + x), (y - 20));
            g.DrawLine(Pens.Blue, x, (y - 30), x, (y - 10));
            g.DrawLine(Pens.Blue, (wid + x), (y - 30), (wid + x), (y - 10));

            //縦線の寸法線


            //太線の宣言
            var bold = new Pen(Color.Black, 2);

            //四角形を出力
            g.DrawRectangle(bold, x, y, wid, depth);
            g.DrawRectangle(bold, (x + 40), (y + 40), (wid - 80), (depth - 80));

            //点線を出力
            var dot = new Pen(Color.Black)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            };
            g.DrawRectangle(dot, (x + 3), (y + 3), (wid - 6), (depth - 6));
        }
    }
}
