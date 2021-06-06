using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace App {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			this.Paint += Form_Paint;
			this.Width = 300;
			this.Height = 330;
		}
		private void Form_Paint(object sender, PaintEventArgs e) {
			DateTime dt = DateTime.Now;
			int width = this.Width-this.Width/10;
			int height = this.Height-this.Height/10;
			Pen cir_pen = new Pen(Color.Black, 2);
			Brush brush = new SolidBrush(Color.Indigo);
			Graphics g = e.Graphics;
			GraphicsState gs;
			g.TranslateTransform(this.Width / 2f, this.Height/ 2f);
			g.ScaleTransform(this.Width / 200, this.Height / 200);
			g.DrawEllipse(cir_pen, -120, -120, 240, 240);
			for(int i = 1; i<= 60; i++) {
				g.RotateTransform(6);
				if (i % 5 == 0) {
					g.DrawLine(cir_pen, 0, 120, 0, 100);
				} else
					g.DrawLine(cir_pen, 0, 120, 0, 110);
			}
			ResetTransform(g);
			gs = g.Save();
			g.RotateTransform(6 * (float)dt.Second);
			g.DrawLine(new Pen(new SolidBrush(Color.Brown), 4), 0, 0, 0, -90);
			ResetTransform(g);
			g.RotateTransform(6 * ((float)dt.Minute + dt.Second / 60));
			g.DrawLine(new Pen(new SolidBrush(Color.Aqua), 4), 0, 0, 0, -80);
			ResetTransform(g);
			g.RotateTransform(30 * (((float)dt.Hour)+(float)dt.Minute/60));
			g.DrawLine(new Pen(new SolidBrush(Color.Black), 6), 0, 0, 0, -40);
			g.Restore(gs);
		}
		private void ResetTransform(Graphics g) {
			g.ResetTransform();
			g.TranslateTransform(this.Width / 2f, this.Height / 2f);
		}

		private void timer1_Tick(object sender, EventArgs e) {
			Invalidate();
		}
	}
}
