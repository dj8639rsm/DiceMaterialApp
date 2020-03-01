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
        int x = 100;
        int y = 100;
        int wid = 1000;
        int depth = 400;
        double w1 = 0;
        double d1 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private bool checkValue()
        {

            //テキストボックスの値をint型に変換してフィールドに格納
            //成功すればtrueを返す
            try
            {
                w1 = Convert.ToInt32(textBox1.Text);
                d1 = Convert.ToInt32(textBox2.Text);
                return true;
            }

            //int型に変換できないときはメッセージを送信
            //falseを返す
            catch
            {
                MessageBox.Show("Ａ欄とＢ欄に数字を入力してください。", "エラー");
                return false;
            }

            //テキストボックスをクリアする。
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();

            //練習の線
            g.DrawLine(Pens.Red, 0, 0, pictureBox1.Width, 0);

            //横幅の寸法線
            g.DrawLine(Pens.Blue, x, (y - 20), (wid + x), (y - 20));
            g.DrawLine(Pens.Blue, x, (y - 30), x, (y - 10));
            g.DrawLine(Pens.Blue, (x + wid), (y - 30), (x + wid), (y - 10));

            //縦線の寸法線
            g.DrawLine(Pens.Blue, (x - 20), y, (x - 20), (y + depth));
            g.DrawLine(Pens.Blue, (x - 30), y, (x - 10), y);
            g.DrawLine(Pens.Blue, (x - 30), (y + depth), (x - 10), (y + depth));


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

        private void button2_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);


        }
    }
}
