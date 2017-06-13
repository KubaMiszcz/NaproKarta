using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NaproKarta
{
	/// <summary>
	/// singleton
	/// </summary>
	public class CardChartClass
	{
		public List<List<ObservationClass>> ChartElements;
		//[JsonIgnore]
		private int _rows; //6;  //licbza wierszy
		private int _cols; //35;   //liczba obserasvji

		public CardChartClass()
		{
			//this._rows = SharedObjects.NumRows;
			//this._cols = SharedObjects.NumCols;
			//PopulateChart();
		}

		public CardChartClass(int rows, int cols)
		{
			this._rows = rows;
			this._cols = cols;
			PopulateChart();
		}

		void PopulateChart()
		{
			ChartElements = new List<List<ObservationClass>>();
			for (int i = 0; i < _rows; i++)
			{
				List<ObservationClass> obsRow = new List<ObservationClass>();
				for (int j = 0; j < _cols; j++)
				{
					ObservationClass obs = new ObservationClass();
					obs.row = i;
					obs.col = j;
					obsRow.Add(obs);
				}
				ChartElements.Add(obsRow);
			}
		}

		//private void observationCtrl_MouseHover(object sender, EventArgs e)
		//{
		//	//NotkiForm frm=new NotkiForm();
		//	//frm.Show();
		//}

		//private void observationCtrl_MouseLeave(object sender, EventArgs e)
		//{
		//	//Form fc = Application.OpenForms["NotkiForm"];
		//	//if (fc != null) fc.Close();
		//}
	}
}
