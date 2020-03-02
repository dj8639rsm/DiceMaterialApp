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
        //x軸,y軸の始点の決定
        int x = 100;
        int y = 100;
        //基準モデルの箱の大きさ
        int wid = 1000;
        int depth = 400;
        //
        double w1 = 0;
        double d1 = 0;
        double t1 = 0;
        double a = 0;
        double w3 = 0;
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
                d1 = Convert.ToDouble(textBox1.Text);
                w1 = Convert.ToDouble(textBox2.Text);
                t1 = Convert.ToDouble(textBox3.Text);
                a = Convert.ToDouble(textBox4.Text);

                return true;
            }

            //int型に変換できないときはメッセージを送信
            //falseを返す
            catch
            {
                MessageBox.Show("すべて半角数字を入力してください。", "エラー");
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
            if (checkValue())
            {
                //picturBox1をクリア
                var g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
  

                w3 = (w1 - (t1 + t1));

                label4.Text = Convert.ToString(w3);
                label5.Text = Convert.ToString(d1);


                //横幅の寸法線
                g.DrawLine(Pens.Blue, x, (y - 20), (wid + x), (y - 20));
                g.DrawLine(Pens.Blue, x, (y - 30), x, (y - 10));
                g.DrawLine(Pens.Blue, (x + wid), (y - 30), (x + wid), (y - 10));

                //縦線の寸法線
                g.DrawLine(Pens.Blue, (x - 20), y, (x - 20), (y + depth));
                g.DrawLine(Pens.Blue, (x - 30), y, (x - 10), y);
                g.DrawLine(Pens.Blue, (x - 30), (y + depth), (x - 10), (y + depth));

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

                //カット線を追加
                var points1 = new Point[3];
                points1[0] = new Point((x + 3), y);
                points1[1] = new Point((x + 3), (y + 40));
                points1[2] = new Point((x + 40), (y + 40));
                g.DrawLines(Pens.Red, points1);

                var points2 = new Point[3];
                points2[0] = new Point((x + wid - 3), y);
                points2[1] = new Point((x + wid - 3), (y + 40));
                points2[2] = new Point((x + wid - 40), (y + 40));
                g.DrawLines(Pens.Red, points2);

                var points3 = new Point[3];
                points3[0] = new Point((x + 3), (y + depth));
                points3[1] = new Point((x + 3), (y + depth - 40));
                points3[2] = new Point((x + 40), (y + depth - 40));
                g.DrawLines(Pens.Red, points3);

                var points4 = new Point[3];
                points4[0] = new Point((x + wid - 3), (y + depth));
                points4[1] = new Point((x + wid - 3), (y + depth - 40));
                points4[2] = new Point((x + wid - 40), (y + depth - 40));
                g.DrawLines(Pens.Red, points4);




            }

        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
