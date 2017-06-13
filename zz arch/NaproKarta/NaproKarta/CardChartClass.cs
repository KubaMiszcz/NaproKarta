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
        public List<List<ObservationClass>> ChartElementsToExport;
        [JsonIgnore]
        public Point ChartSize;
        [JsonIgnore]
        public List<List<ObservationCtrl>> ChartElements; //caly wiersz
        private int _cols;//35;   //liczba obserasvji
        private int _rows;//6;  //licbza wierszy
        private int _cellWidth;
        private int _cellHeight;
        private int _gridThickness = 2;
        //public Pen pBlack;
        //public SolidBrush brWhite;
        private ObservationCtrl _currentObservationCtrl;
        private Panel _chartPanel;

        public CardChartClass(){}

        public CardChartClass(Panel ChartPanel,int cols,int rows,int cellwidth, int cellheight)
        {
            this._cols = cols;
            this._rows = rows;
            this._cellWidth = cellwidth;
            this._cellHeight = cellheight;
            this._chartPanel = ChartPanel;
            PopulateChart();
       }

        void PopulateChart()
        {
            ChartElements = new List<List<ObservationCtrl>>();
            //zapelnianie karty
           int xcoord = 0;
            int ycoord = 0;
            ChartSize=new Point();

            for (int i = 0; i < _rows; i++)
            {
                List<ObservationCtrl> observationsList = new List<ObservationCtrl>();
                for (int j = 0; j < _cols; j++)
                {
                    ObservationCtrl obs = new ObservationCtrl();
                    obs.Location = new Point(xcoord, ycoord);
                    obs.IsNew = true;
                    obs.MarkerImage = null;
                    obs.MarkerImageDescriptionTag = "";
                    obs.Date = DateTime.Parse("1753-01-01");
                    obs.Literki = "";
                    obs.Cyferki = "";
                    obs.CyferkiCD = "";
                    obs.IleRazy = "";
                    obs.Uwagi = new List<string>() {"","",""};
                    obs.NoteMarks = new List<string>() { "", "", "" };
                    obs.NotesContent = new List<string>() { "", "", "" };
                    obs.row = i;
                    obs.col = j;
                    obs.Click += observationCtrl_Click;
                    //obs.MouseHover += observationCtrl_MouseHover;
                    //obs.MouseLeave += observationCtrl_MouseLeave;
                    observationsList.Add(obs);
                    _chartPanel.Controls.Add(obs);
                    xcoord += _cellWidth - _gridThickness;
                    if ((j + 1) % 7 == 0)
                    {
                        xcoord += _gridThickness;
                    }
                }
                ChartSize.X = xcoord + _gridThickness; 
                ChartElements.Add(observationsList);
                xcoord = 0;
                ycoord += _cellHeight;
            }
            ChartSize.Y = ycoord;
        }

        public void CleanCard()
        {
            //_chartPanel.Controls.Clear();
            foreach (var VARIABLE in ChartElements)
            {
                if (VARIABLE != null)
                {
                    foreach (ObservationCtrl ctrl in VARIABLE)
                    {
                        _chartPanel.Controls.Remove(ctrl);
                    }
                }
            }
        }

        public void MakeChartToExport()
        {
            ChartElementsToExport=new List<List<ObservationClass>>();
            foreach (List<ObservationCtrl> observationCtrls in ChartElements)
            {
                List<ObservationClass> observationClassesRow=new List<ObservationClass>();
                foreach (ObservationCtrl ctrl in observationCtrls)
                {
                    ObservationClass SingleCtrlToExport=new ObservationClass(ctrl);
                    observationClassesRow.Add(SingleCtrlToExport);
                }
                ChartElementsToExport.Add(observationClassesRow);
            }
        }

        private void observationCtrl_Click(object sender, EventArgs e)
        {
            ObservationForm frm=new ObservationForm();
            _currentObservationCtrl = sender as ObservationCtrl;
            frm.Show(_currentObservationCtrl,SharedObjects.MyChart);
        }

        private void observationCtrl_MouseHover(object sender, EventArgs e)
        {
            //NotkiForm frm=new NotkiForm();
            //frm.Show();
        }

        private void observationCtrl_MouseLeave(object sender, EventArgs e)
        {
            //Form fc = Application.OpenForms["NotkiForm"];
            //if (fc != null) fc.Close();
        }
    }
}
