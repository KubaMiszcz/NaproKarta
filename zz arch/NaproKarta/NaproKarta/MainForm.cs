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
        private int cellHeight;
        private int cellWidth;
        private const int NumCols = 8;
        private const int NumRows = 2;

        public MainForm()
        {
            InitializeComponent();
            _title = "NaproKarta " + Assembly.GetEntryAssembly().GetName().Version;
            SetDoubleBuffered(this);
            SetDoubleBuffered(tabControl1);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {   this.Text = _title;
            cellHeight = 144;
            cellWidth = 42;
            SharedObjects.MyChart = new CardChartClass(ChartPanel,NumCols,NumRows,cellWidth,cellHeight);
        }
        private void button5_Click(object sender, EventArgs e)
        {

            //using (Bitmap bitmap = new Bitmap(panel2.ClientSize.Width,
            //                      panel2.ClientSize.Height))
            //{
            //    panel2.DrawToBitmap(bitmap, panel2.ClientRectangle);
            //    bitmap.Save("C:\\" + "asdasd" + ".bmp", ImageFormat.Bmp);
            //}
            Panel panel = ChartPanel;
            Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            panel.DrawToBitmap(bmp, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            bmp.Save("C:\\panel.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


            //using (Bitmap bitmap = new Bitmap(panel1.ClientSize.Width,
            //                      panel1.ClientSize.Height))
            //{
            //    panel1.DrawToBitmap(bitmap, panel1.ClientRectangle);
            //    bitmap.Save("C:\\" + pagAtual + ".bmp", ImageFormat.Bmp);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void NewCardtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            SharedObjects.MyChart.CleanCard();
            SharedObjects.MyChart = new CardChartClass(ChartPanel, NumCols, NumRows, cellWidth, cellHeight);
        }


        /// <summary>
        /// ################JAKIES INNE POZOSTALOSCI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#region jakies pierdoly
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //foreach (var row in myChart.ChartElements)
            //{
            //    foreach (var item in row)
            //    {
            //        ObservationCtrl obs = new ObservationCtrl();
            //        obs.Show();
            //        //obs.Location.X=120;
            //        //obs.Location.X=item.xCoord;
            //        //obs.Location.Y=item.yCoord;
            //    }
            //}
        }


        private void drawWeeksBorderEtc_Paint(object sender, PaintEventArgs e)
        {
            //Dorysuj opiski , i pozostale ramki wokol tygodni itp
            //base.OnPaint(e);   //to jak robie override to zeby dopsiac a nie zastapic
            int PenThickness = 4;
            Pen myPen = new Pen(Color.Black, PenThickness);
            //Brush myBrush = myChart.brWhite;
            // Create rectangle. 
            //Rectangle rect = new Rectangle(0, 0, myChart.cellWidth, myChart.cellHeight);
            // Draw rectangle to screen. 
            int xCoord = 0;
            int yCoord = 2;
            for (int i = 0; i < NumCols; i++)
            {
                Rectangle rect = new Rectangle(xCoord, yCoord, cellWidth, 50);
                e.Graphics.DrawRectangle(myPen, rect);
                xCoord += cellWidth - PenThickness / 2;
            }

            //foreach (var row in myChart.ChartElements)
            //{
            //    foreach (var item in row)
            //    {
            //        Rectangle rect = new Rectangle(item.xCoord, item.yCoord, myChart.cellWidth, myChart.cellHeight);
            //        //e.Graphics.FillRectangle(myBrush, rect);
            //        e.Graphics.DrawRectangle(myPen, rect);
            //    }
            //}
        }

        #endregion

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
                   // if(File.Exists(saveFileDialog1.FileName))File.Delete(saveFileDialog1.FileName);
                    ZapiszDoPliku(myStream);
                    #region
                    //using (StreamWriter writer = new StreamWriter(myStream, System.Text.Encoding.UTF8))
                    //{
                    //    // Add some text to the file.
                    //    //writer.Write("This is the ");
                    //    //writer.WriteLine("header for the file.");
                    //    //writer.WriteLine("-------------------");
                    //    // Arbitrary objects can also be written to the file.
                    //    //var json = new JavaScriptSerializer().Serialize(_petriNet);
                    //    SharedObjects.MyChart.MakeChartToExport();
                    //    String json = JsonConvert.SerializeObject(SharedObjects.MyChart.ChartElementsToExport,
                    //        Formatting.Indented,
                    //        new JsonSerializerSettings()
                    //        {
                    //            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    //        });
                    //    writer.WriteLine(json);
                    //}
                    //myStream.Close();
                    //SaveToJpeg();
                    //this.Text = _title + " - " + _currentSavedFileName;
                    ////String AktualnyPlikDoZapisu_nazwa = System.IO.Path.GetFileNameWithoutExtension(AktualnyPlikDoZapisu);
                    ////_currentSavedFileName = saveFileDialog1.FileName;
#endregion
                }
            }
        }


        private void ZapiszDoPliku(Stream myStream)
        {
            _myChart = SharedObjects.MyChart;
            //pozaspisuj zdjeica userpictere do katalogu i uaktualnij sciezki w kontrolkach
            foreach (List<ObservationCtrl> row in _myChart.ChartElements)
            {
                foreach (ObservationCtrl ctrl in row)
                {
                    if (ctrl.UserPictureFileInfo != "")
                    {
                        String srcPath = ctrl.UserPictureFileInfo;
                        String tgtPath = _currentSavedPath + "\\" + _currentSavedFileName + " - Zdjecia\\";
                        String tgtExt = Path.GetExtension(srcPath);
                        String tgtFilename = _currentSavedFileName + " " + ctrl.Date.ToShortDateString() + tgtExt;
                        if (!Directory.Exists(tgtPath))
                        {
                            Directory.CreateDirectory(tgtPath);
                        }
                        //zeby nie kopiowal plikow na same siebie
                        if (!(ctrl.UserPictureFileInfo.Equals(tgtPath + tgtFilename)))
                        {
                            File.Copy(ctrl.UserPictureFileInfo, tgtPath + tgtFilename, true);
                        }
                        ctrl.UserPictureFileInfo = tgtPath + tgtFilename;
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(myStream, System.Text.Encoding.UTF8))
                {
                    // Add some text to the file.
                    //writer.Write("This is the ");
                    //writer.WriteLine("header for the file.");
                    //writer.WriteLine("-------------------");
                    // Arbitrary objects can also be written to the file.
                    //var json = new JavaScriptSerializer().Serialize(_petriNet);
                    SharedObjects.MyChart.MakeChartToExport();
                    String json = JsonConvert.SerializeObject(SharedObjects.MyChart.ChartElementsToExport,
                        Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });
                    writer.WriteLine(json);
                }
                myStream.Close();
                SaveToJpeg();
                this.Text = _title + " - " + _currentSavedFileName;
                //String AktualnyPlikDoZapisu_nazwa = System.IO.Path.GetFileNameWithoutExtension(AktualnyPlikDoZapisu);
                //_currentSavedFileName = saveFileDialog1.FileName;
        }


        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentSavedFileName == null)
            {
                zapiszJakoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                FileStream myStream = new FileStream(_currentSavedPath+"\\"+_currentSavedFileName+".npr", FileMode.Create);
                ZapiszDoPliku(myStream);
            }
        }


        void SaveToJpeg()
        {
            Panel panel = ChartPanel;

            Bitmap img = new Bitmap(_myChart.ChartSize.X, _myChart.ChartSize.Y);
            this.WindowState = FormWindowState.Maximized;
            panel.DrawToBitmap(img, new Rectangle(0, 0,_myChart.ChartSize.X, _myChart.ChartSize.Y));
            this.WindowState = FormWindowState.Normal;

            String path = _currentSavedPath + "\\" + _currentSavedFileName + ".jpg";
            if (File.Exists(path))File.Delete(path);

            //bmp.Save(_currentSavedPath + "\\" + _currentSavedFileName + ".jpg", ImageFormat.Jpeg);
            img.Save(_currentSavedPath + "\\" + _currentSavedFileName + ".jpg", img.RawFormat);

            //Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            //panel.DrawToBitmap(bmp, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            //bmp.Save(directoryName + "\\" + fileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //bmp.Save("C:\\panel.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                                    SharedObjects.MyChart.CleanCard();
                                    SharedObjects.MyChart= new CardChartClass(ChartPanel, NumCols, NumRows, cellWidth, cellHeight); 
                                    SharedObjects.MyChart.ChartElementsToExport = JsonConvert.DeserializeObject<List<List<ObservationClass>>>(json);
                                    List<List<ObservationClass>> ImportedObs=new List<List<ObservationClass>>();
                                    ImportedObs = SharedObjects.MyChart.ChartElementsToExport;
                                    foreach (List<ObservationClass> observationClassesList in ImportedObs)
                                    {
                                        int i = ImportedObs.IndexOf(observationClassesList);
                                        foreach (ObservationClass observation in observationClassesList)
                                        {
                                            int j = observationClassesList.IndexOf(observation);
                                            ObservationCtrl ctrl =
                                                SharedObjects.MyChart.ChartElements.ElementAt(i).ElementAt(j);
                                            observation.ObservationClassToCtrl(ctrl);
                                        }
                                    }
                                }
                                myStream.Close();
                                _currentSavedPath = Path.GetDirectoryName(openFileDialog1.FileName);
                                _currentSavedFileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                                this.Text =  _title+" - "+ _currentSavedFileName;
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

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
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

    }
}
