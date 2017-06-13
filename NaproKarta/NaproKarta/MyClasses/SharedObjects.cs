using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaproKarta
{
	public class SharedObjects
	{

		public static DateTime NoDateTime = DateTime.Parse("1900-01-01");
		public const int CellHeight = 144;
		public const int CellWidth = 42;
		public static int NumCols = 8;//liczba kolumn od 1-n (nie od 0)
		public static int NumRows = 2;

		public static CardChartClass MyChart; //= new CardChartClass(SharedObjects.NumRows,SharedObjects.NumCols);
											  /// <summary>
											  /// stale dane i niezmienne
											  /// </summary>
		public enum MarkerEnum
		{ Red = 0, Green, Yellow, WhiteBaby, GreenBaby, YellowBaby, GreyConfused }
		public static readonly List<String> MarkerDescriptionsList = new List<string>() { "Red", "Green", "Yellow", "WhiteBaby", "GreenBaby", "YellowBaby", "GreyConfused" };
		public static readonly List<String> PeakMarkers = new List<string>() { "PP", "P1", "P2", "P3" };
		public static readonly List<Image> MarkerImagesList = new List<Image>()
			{
				Properties.Resources.markerRed,
				Properties.Resources.markerGreen,
				Properties.Resources.markerYellow,
				Properties.Resources.markerWhiteBaby,
				Properties.Resources.markerGreenBaby,
				Properties.Resources.markerYellowBaby,
				Properties.Resources.markerGreyConfused
	};

		public static void Report(Exception ex)
		{
			MessageBox.Show(
				"\r\n\r\nMessage: " + ex.Message +
				"\r\n\r\nType: " + ex.GetType() +
				 "\r\n\r\nMethod: " + ex.TargetSite +
				 "\r\n\r\nStackTrace:\r\n" + ex.StackTrace,
				ex.Source,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
				);
			//MessageBox.Show(ex.Message + "\n\n" + ex.GetType()+"\n\n"+ ex.StackTrace);
		}

		public static void Report(Exception ex, Form sender)
		{
			MessageBox.Show(
				"Message: " + ex.Message +
				"\r\n\r\nType: " + ex.GetType() +
				"\r\n\r\nSource: " + ex.Source +
				 "\r\n\r\nMethod: " + ex.TargetSite +
				 "\r\n\r\nStackTrace:\r\n" + ex.StackTrace,
				sender.Text,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
				);

			//MessageBox.Show(ex.Message + "\n\n" + ex.GetType() + "\n\n" + ex.StackTrace);
		}



	}
}
