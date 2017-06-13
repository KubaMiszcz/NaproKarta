using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaproKarta
{
	public partial class ObservationCtrl : UserControl
	{

		private int _col;
		private int _row;
		private List<Label> lbNoteMarksList;

		[Browsable(true), Category("Customizations"), DisplayName("Row")]
		public int Row
		{
			get
			{
				return _row;
			}

			set
			{
				_row = value;
			}
		}

		[Browsable(true), Category("Customizations"), DisplayName("Col")]
		public int Col
		{
			get
			{
				return _col;
			}

			set
			{
				_col = value;
			}
		}

		public ObservationCtrl()
		{
			InitializeComponent();
			WireAllControls(this);
			_row = 1;
			_col = 1;
		}
		public ObservationCtrl(int row, int col)
		{
			InitializeComponent();
			WireAllControls(this);
			this._row = row;
			this._col = col;
		}
		private void ObservationCtrl_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode)
			{
				lbNoteMarksList = new List<Label>() { lbNoteMarkA, lbNoteMarkB, lbNoteMarkC };
				ObservationClass cellData = SharedObjects.MyChart.ChartElements.ElementAt(_row).ElementAt(_col);
				PopulateObservationCtrl(cellData);
			}
		}

		public void PopulateObservationCtrl(ObservationClass cellData)
		{
			//private bool _isNew;
			//ObservationClass cellData = SharedObjects.MyChart.ChartElements.
			//	ElementAt(row).
			//	ElementAt(col);

			//obrazek
			if (cellData.MarkerDescription != "")
			{
				pictureBoxMarker.BackgroundImage = SharedObjects.MarkerImagesList.
					ElementAt(SharedObjects.MarkerDescriptionsList.IndexOf(cellData.MarkerDescription));
			}
			else pictureBoxMarker.BackgroundImage = base.BackgroundImage;

			//data
			if (cellData.Date > SharedObjects.NoDateTime)
				labelDate.Text = cellData.Date.ToShortDateString().Substring(5);
			else labelDate.Text = "";

			//literki
			labelLiterki.Text = cellData.Literki;
			labelLiterkiCD.Text = cellData.LiterkiCD;

			//cyferki
			label3cyferki.Text = cellData.Cyferki + cellData.CyferkiCD;

			//ilerazy
			label2ilerazy.Text = cellData.IleRazy;

			//uwagi
			String str = "";
			foreach (String s in cellData.Uwagi)
			{
				if (s.Length > 0)
				{
					str = str + s.Substring(0, 1).ToUpper() + " "; //pierwsze litery
				}
			}
			label1uwagi.Text = str.Trim();

			//notemarks
			str = "";
			int i = 0;
			foreach (String s in cellData.NotesContent)
			{
				Label lb = lbNoteMarksList.ElementAt(i);
				bool isImportant = cellData.IsNotesImportant.ElementAt(i);
				if (isImportant) lb.BackColor = Color.Red;
				else lb.BackColor = base.BackColor;
				if (s.Length > 0)
				{
					str = s.Substring(0, 1).ToUpper() + " "; //pierwsze litery
					lb.Text = str;
				}
				else lb.Text = "";
				i++;
			}
		}

		private void WireAllControls(Control cont)
		{
			foreach (Control ctl in cont.Controls)
			{
				ctl.Click += ctl_Click;
				if (ctl.HasChildren)
				{
					WireAllControls(ctl);
				}
			}
		}

		private void ObservationCtrl_Click(object sender, EventArgs e)
		{
			ObservationForm frm = new ObservationForm();
			ObservationCtrl oc = sender as ObservationCtrl;
			if (oc != null) frm.Show(oc, _row, _col);

		}

		private void ctl_Click(object sender, EventArgs e)
		{
			this.InvokeOnClick(this, EventArgs.Empty);
		}

	}
}
