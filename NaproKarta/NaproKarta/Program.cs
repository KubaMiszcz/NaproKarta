using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaproKarta
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			SharedObjects.MyChart= new CardChartClass(SharedObjects.NumRows,SharedObjects.NumCols);
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
			//Application.Run(new ObservationForm());
			//Application.Run(new Form1());

		}
    }
}
