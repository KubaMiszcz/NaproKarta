using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NaproKarta
{
	public partial class MainForm : Form
	{
		private String _title;
		private CardChartClass _myChart;
		private String _currentSavedFileName;
		private String _currentSavedPath;
		//private CardChartClass myChart;

		//lokalne pola
		private Point ChartSize;
		private int _gridThickness = 2;
		private int _upperOffset = 20;
		private int _leftOffset = 20;


		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SetDoubleBuffered(this);
			SetDoubleBuffered(tabControl1);
			_title = "NaproKarta " + Assembly.GetEntryAssembly().GetName().Version;
			_myChart = SharedObjects.MyChart;
			this.Text = _title;
			MakeNewClearPanelChart();
		}

		private void MakeNewClearPanelChart()
		{
			//populate panelChart
			panelChart.Controls.Clear();
			int _rows = SharedObjects.NumRows;
			int _cols = SharedObjects.NumCols;
			SharedObjects.MyChart = new CardChartClass(_rows, _cols);
			int _cellWidth = SharedObjects.CellWidth;
			int _cellHeight = SharedObjects.CellHeight;
			int xcoord = 0 + _leftOffset + _gridThickness+_cellWidth;
			int ycoord = 0 + _upperOffset + _gridThickness;

			button1.Location = new Point(0 + _leftOffset + _gridThickness, _upperOffset + _gridThickness);
			button1.Size = new Size(_cellWidth, _cellHeight);
			for (int row = 0; row < _rows; row++)
			{
				for (int col = 0; col < _cols; col++)
				{
					ObservationCtrl obsCtrl = new ObservationCtrl(row, col);
					obsCtrl.Location = new Point(xcoord, ycoord);
					//obs.Click += observationCtrl_Click;
					panelChart.Controls.Add(obsCtrl);
					xcoord += _cellWidth - _gridThickness;
					if ((col + 1) % 7 == 0)
					{
						xcoord += _gridThickness;
					}
				}
				xcoord = _leftOffset + _gridThickness+_cellWidth;//x poczatkowe
				ycoord += _cellHeight;
			}
		}

		private void NewCardtoolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MakeNewClearPanelChart();
		}
		public static void SetDoubleBuffered(System.Windows.Forms.Control c)
		{
			//Taxes: Remote Desktop Connection and painting
			//http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
			if (System.Windows.Forms.SystemInformation.TerminalServerSession)
				return;

			System.Reflection.PropertyInfo aProp =
				  typeof(System.Windows.Forms.Control).GetProperty(
						"DoubleBuffered",
						System.Reflection.BindingFlags.NonPublic |
						System.Reflection.BindingFlags.Instance);

			aProp.SetValue(c, true, null);
		}

		private void textBoxCols_TextChanged(object sender, EventArgs e)
		{
			NumericUpDown nud = sender as NumericUpDown;
			SharedObjects.NumCols = (int)nud.Value;
			MakeNewClearPanelChart();
		}

		private void textBoxRows_TextChanged(object sender, EventArgs e)
		{
			NumericUpDown nud = sender as NumericUpDown;
			SharedObjects.NumRows = (int)nud.Value;
			MakeNewClearPanelChart();
		}

		private void panelChart_Paint(object sender, PaintEventArgs e)
		{
			//Brush borderBrush = new SolidBrush(borderColor);
			Brush textBrush = new SolidBrush(Color.Maroon);
			Pen borderPen = new Pen(Color.Maroon, _gridThickness);
			borderPen.Alignment = PenAlignment.Inset;

			float fontSize = _upperOffset * 0.5f;
			StringFormat sf = new StringFormat();
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;

			Graphics g = e.Graphics;
			g.Clear(this.BackColor);

			//ChartSize = new Point();
			int _rows = SharedObjects.NumRows;
			int _cols = SharedObjects.NumCols;
			int _cellWidth = SharedObjects.CellWidth;
			int _cellHeight = SharedObjects.CellHeight;

			g.DrawRectangle(borderPen, 0 + _gridThickness, 0 + _gridThickness, _leftOffset, _upperOffset);//kwadracik w lewym gornym rogu

			//naglowki kolumn
			int xcoord = 0 + _leftOffset + _gridThickness;
			int ycoord = 0 + _gridThickness;
			for (int col = 0; col < _cols; col++)
			{
				g.DrawRectangle(borderPen, xcoord, ycoord, _cellWidth, _upperOffset);
				g.DrawString((col + 1).ToString(), new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold),
					textBrush, xcoord + _cellWidth / 2, ycoord + _upperOffset / 2, sf);
				xcoord += _cellWidth - _gridThickness;
				if ((col + 1) % 7 == 0)
				{
					xcoord += _gridThickness;
				}
			}
			ChartSize.X = xcoord + 2 * _gridThickness;

			//naglowki wierszy
			sf.FormatFlags = StringFormatFlags.DirectionVertical;
			xcoord = 0 + _gridThickness;
			ycoord = 0 + _gridThickness + _upperOffset;
			for (int row = 0; row < _rows; row++)
			{
				g.DrawRectangle(borderPen, xcoord, ycoord, _leftOffset, _cellHeight);
				g.FillRectangle(new SolidBrush(Color.Bisque), xcoord + _gridThickness, ycoord + _gridThickness, _leftOffset - 2 * _gridThickness, _cellHeight - 2 * _gridThickness);
				Rectangle rect = new Rectangle(xcoord, ycoord, _leftOffset, _cellHeight);

				//PictureBox pb = new PictureBox();
				//pb.Location = new Point(xcoord+_gridThickness,ycoord+_gridThickness);
				//pb.BackColor=Color.Bisque;
				//pb.Size=new Size(_leftOffset-2*_gridThickness,_cellHeight-2*_gridThickness);
				//panelChart.Controls.Add(pb);
				e.Graphics.TranslateTransform(rect.Right, rect.Bottom);//zeby rysowalo tekxt pionow w gore a nei w dol
				e.Graphics.RotateTransform(180);
				g.DrawString("opis, data, znaczek", new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold),
					textBrush, _leftOffset / 2, _cellHeight / 2, sf);
				e.Graphics.ResetTransform();

				ycoord += _cellHeight;
			}

			ChartSize.Y = ycoord + _gridThickness;
			g.DrawRectangle(borderPen, 0, 0,
				ChartSize.X, ChartSize.Y);//ramka dookola panelu calego

		}

	}
}
