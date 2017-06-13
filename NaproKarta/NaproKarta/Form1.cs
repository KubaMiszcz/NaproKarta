using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaproKarta
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

			//Brush borderBrush = new SolidBrush(borderColor);
			int thickness = 4;
			Pen borderPen = new Pen(Color.Maroon, thickness);
			Graphics g = e.Graphics;

			g.DrawRectangle(borderPen, 0, 0, 200, 200);

		}
	}
}
