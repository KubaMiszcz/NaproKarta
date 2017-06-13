using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using System.Windows.Forms.VisualStyles;


namespace NaproKarta
{
	public partial class MainForm : Form
	{
		private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = "NaproCard files (*.npr)|*.npr";
			saveFileDialog1.FilterIndex = 1;
			saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory(); //zrob podkatalog jakis
			saveFileDialog1.RestoreDirectory = true;
			saveFileDialog1.DefaultExt = ".npr";
			saveFileDialog1.FileName = "NaproKarta1"; //dodaj date albo jakis ciag
			Stream myStream;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				_currentSavedPath = Path.GetDirectoryName(saveFileDialog1.FileName);
				_currentSavedFileName = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
				if ((myStream = saveFileDialog1.OpenFile()) != null)
				{
					ZapiszDoPliku(myStream);
				}
			}
		}

		private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_currentSavedFileName == null)
			{
				zapiszJakoToolStripMenuItem_Click(sender, e);
			}
			else
			{
				FileStream myStream = new FileStream(_currentSavedFileName + ".npr", FileMode.Create);
				ZapiszDoPliku(myStream);
			}
		}

		private void ZapiszDoPliku(Stream myStream)
		{
			_myChart = SharedObjects.MyChart;
			//pozaspisuj zdjeica userpictere do katalogu i uaktualnij sciezki w kontrolkach

			//####ZAPISYWANIE ZDJEC
			foreach (List<ObservationClass> row in _myChart.ChartElements)
			{
				foreach (ObservationClass ctrl in row)
				{
					List<String> lstr=new List<string>();
					foreach (String str in ctrl.UserPicturesFileInfoList)
					{
						String srcPath = str;
						String tgtPath = _currentSavedFileName + "\\" + _currentSavedFileName + " - Zdjecia\\";
						String tgtExt = Path.GetExtension(srcPath);
						if (!Directory.Exists(tgtPath))
						{
							Directory.CreateDirectory(tgtPath);
						}
						int i = ctrl.UserPicturesFileInfoList.IndexOf(str);
						String tgtFilename = _currentSavedFileName + " " + ctrl.Date.ToShortDateString() + " " + (i+1) + tgtExt;
						//zeby nie kopiowal plikow na same siebie
						if (!(str.Equals(tgtPath + tgtFilename)))
						{
							File.Copy(str, tgtPath + tgtFilename, true);
						}
						lstr.Add(tgtPath + tgtFilename);
					}
					ctrl.UserPicturesFileInfoList = lstr;
				}
			}

			//zapisywanie wykresu
			SaveChartToJpeg();

			//zapisywanie pliku .npr
			using (StreamWriter writer = new StreamWriter(myStream, System.Text.Encoding.UTF8))
			{
				// Add some text to the file.
				//writer.Write("This is the ");
				//writer.WriteLine("header for the file.");
				//writer.WriteLine("-------------------");
				// Arbitrary objects can also be written to the file.
				//var json = new JavaScriptSerializer().Serialize(_petriNet);
				String json = JsonConvert.SerializeObject(_myChart.ChartElements,
					Formatting.Indented);
				//,new JsonSerializerSettings()
				//{
				//	ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
				//});
				writer.WriteLine(json);
			}
			myStream.Close();
			if (File.Exists(_currentSavedFileName + ".npr"))
			{
				File.Copy(_currentSavedFileName + ".npr", _currentSavedFileName + "\\" + _currentSavedFileName + ".npr", true);
				File.Delete(_currentSavedFileName + ".npr");
			}


			this.Text = _title + " - " + _currentSavedFileName;
			//String AktualnyPlikDoZapisu_nazwa = System.IO.Path.GetFileNameWithoutExtension(AktualnyPlikDoZapisu);
			//_currentSavedFileName = saveFileDialog1.FileName;
		}

		void SaveChartToJpeg()
		{
			Panel panel = panelChart;
			Point prevLocation = this.Location;
			this.WindowState = FormWindowState.Maximized;
			Bitmap img = new Bitmap(ChartSize.X, ChartSize.Y);
			panel.DrawToBitmap(img, new Rectangle(0, 0, ChartSize.X, ChartSize.Y));
			this.WindowState = FormWindowState.Normal;
			this.Location = prevLocation;


			//String path = _currentSavedPath + "\\" + _currentSavedFileName + ".jpg";
			//relative path
			String path = _currentSavedFileName + "\\" + _currentSavedFileName + ".png";
			if (!Directory.Exists(Path.GetDirectoryName(path)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));
			}
			if (File.Exists(path)) File.Delete(path);
			//bmp.Save(_currentSavedPath + "\\" + _currentSavedFileName + ".jpg", ImageFormat.Jpeg);
			img.Save(path, img.RawFormat);

			//Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
			//panel.DrawToBitmap(bmp, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
			//bmp.Save(directoryName + "\\" + fileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
			//bmp.Save("C:\\panel.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
		}

		private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
		{

			Stream myStream = null;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			//openFileDialog1.InitialDirectory = "c:\\";
			openFileDialog1.Filter = "NaproCard files (*.npr)|*.npr";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((myStream = openFileDialog1.OpenFile()) != null)
					{
						using (StreamReader reader = new StreamReader(myStream, System.Text.Encoding.UTF8))
						{
							// Insert code to read the stream here.
							while (!reader.EndOfStream)
							{
								String json = reader.ReadToEnd();
								//SharedObjects.MyChart.ClearWholeChart();
								List<List<ObservationClass>> importedChart = JsonConvert.DeserializeObject<List<List<ObservationClass>>>(json);
								SharedObjects.NumRows = importedChart.Count;
								SharedObjects.NumCols = importedChart.ElementAt(0).Count;
								SharedObjects.MyChart = new CardChartClass(SharedObjects.NumRows, SharedObjects.NumCols);
								_myChart = SharedObjects.MyChart;
								_myChart.ChartElements = importedChart;
							}
							myStream.Close();

							//okienko postepu
							panelChart.Visible = false;
							FileIOForm frm = new FileIOForm();
							ProgressBar progressBar = frm.Controls.Find("progressBar", false).First() as ProgressBar;
							Label messaLabel = frm.Controls.Find("labelMessage", false).First() as Label;
							progressBar.Maximum = SharedObjects.NumRows * SharedObjects.NumCols;
							progressBar.Value = 0;
							frm.Show();

							MakeNewClearPanelChart();
							foreach (Control ctrl in panelChart.Controls)
							{
								ObservationCtrl obsCtrl = ctrl as ObservationCtrl;
								if (obsCtrl != null)
								{
									ObservationClass cellData = _myChart.ChartElements.ElementAt(obsCtrl.Row).ElementAt(obsCtrl.Col);
									obsCtrl.PopulateObservationCtrl(cellData);
									progressBar.Value++;
								}
							}
							messaLabel.Text = "Wczytano";
							frm.Close();
							panelChart.Visible = true;

							_currentSavedPath = Path.GetDirectoryName(openFileDialog1.FileName);
							_currentSavedFileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
							this.Text = _title + " - " + _currentSavedFileName;
							//if (_currentSavedFileName != "")
							//{
							//    this.Text = _currentSavedFileName + " - " + _title;
							//}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message + ex.StackTrace);
				}
			}

		}



		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

	}
}
