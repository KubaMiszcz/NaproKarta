using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaproKarta.Properties;

namespace NaproKarta
{
    public partial class ObservationForm : Form
    {
        private ObservationCtrl _currentObservationCtrl;
        private CardChartClass _myChart;
        //private Image _curMarkerImage;
        //private String _curData;
        //private String _curLiterki;
        //private String _curCyferki;
        //private String _curIleRazy;
        //private String _curUwagi;
        //private String _curNotkiZaczniki;
        //private String _curNotkiTresc;
        private List<RadioButton> _rbEnablesCdList;//3 radiobuttony wlaczajace dodatkowe cyferki
        private List<CheckBox> _checkboxUwagiList;//3 radiobuttony wlaczajace dodatkowe cyferki
        private List<TextBox> _textboxNoteMarksList;//3 radiobuttony wlaczajace dodatkowe cyferki
        private List<RichTextBox> _richtextNotesList;//3 radiobuttony wlaczajace dodatkowe cyferki
        private List<MarkerCtrl> _markerCtrlsListList;//3 radiobuttony wlaczajace dodatkowe cyferki
        private String _pathToUserPicture;

        public ObservationForm()
        {
            InitializeComponent();
        }

        private void PomiarForm_Load(object sender, EventArgs e)
        {
            _myChart = SharedObjects.MyChart;

            dateTimePickerDataObserwacji.Value=DateTime.Today;
            this.Text = "Obserwacja dla dnia " + DateTime.Today.ToShortDateString();
            _rbEnablesCdList=new List<RadioButton>();
            _rbEnablesCdList.Add(radioButtonCD6);
            _rbEnablesCdList.Add(radioButtonCD8);
            _rbEnablesCdList.Add(radioButtonCD10);

            _checkboxUwagiList=new List<CheckBox>();
            _checkboxUwagiList.Add(checkBoxWizyta);
            _checkboxUwagiList.Add(checkBoxBadania);
            _checkboxUwagiList.Add(checkBoxLupucupu);

            _textboxNoteMarksList = new List<TextBox>()
            {
                textBoxNoteMarkA,
                textBoxNoteMarkB,
                textBoxNoteMarkC
            };

            _richtextNotesList = new List<RichTextBox>()
            {
                richTextBoxNoteA,
                richTextBoxNoteB,
                richTextBoxNoteC
            };

            _markerCtrlsListList = new List<MarkerCtrl>()
            {
                markerCtrlRed,
                markerCtrlGreen,
                markerCtrlYellow,
                markerCtrlWhitewBaby,
                markerCtrlGreenwBaby,
                markerCtrlYellowwBaby,
                markerCtrlGreyConfused
            };
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            //sprqawdzanie czy w grupbocxie cyferki zaznaczono 6 albo 8 albo 10
            //jak tak wlaczanie panelu cyferkiCD 
            //dodatkowo malowanie tla na zolto a nie systemControl
            //chyba ze zaznaczoen to na zielono
            RadioButton rb = sender as RadioButton;
            if ((rb != null) && ((rb.Parent as GroupBox)!=null))
            {
                RadioButton_CheckedChange(rb.Parent as GroupBox);
            }
        }


        private void MarkerCtrl_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var VARIABLE in _markerCtrlsListList)
            {
                if (sender==VARIABLE)
                {
                    VARIABLE.Checked = true;
                    VARIABLE.BackColor = Color.Blue;
                }
                else
                {
                    VARIABLE.BackColor = SystemColors.Control;
                    VARIABLE.Checked = false;
                }
            }
        }

        private void LoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp";
            openFileDialog1.FilterIndex = 1;
            //if (!(Directory.Exists(Directory.GetCurrentDirectory() + "\\Saved Transistors"))) //jesli nie istnieje
            //{
            //    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Saved Transistors");
            //}
            //openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\Saved Transistors";
            //openFileDialog1.RestoreDirectory = true;
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1UserPicture.Image = Image.FromFile(openFileDialog1.FileName);
                    _pathToUserPicture = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
            //String AktualnyPlikDoZapisu_nazwa = System.IO.Path.GetFileNameWithoutExtension(AktualnyPlikDoZapisu);
            //_currentSavedFileName = openFileDialog1.FileName;
            //if (_currentSavedFileName != "")
            //{
            //    this.Text = _titleBar + " - " + System.IO.Path.GetFileNameWithoutExtension(_currentSavedFileName);
            //}
        }

        private void HelpOpiska_Click(object sender, EventArgs e)
        {
            OpiskaForm frm = new OpiskaForm();

            Form fc = Application.OpenForms["Opiska"];

            if (fc != null) fc.Close();
            else frm.Show();
        }

        private void HelpOpiska_MouseHover(object sender, EventArgs e)
        {
            OpiskaForm frm = new OpiskaForm();
            frm.Show();
        }

        private void HelpOpiska_MouseLeave(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["OpiskaForm"];
            if (fc != null) fc.Close();
        }

        private void btnSavenClose_Click(object sender, EventArgs e)
        {
            ExitAndSaveObservationControl();
            _currentObservationCtrl.IsNew = false;
            this.Close();
        }

        /// <summary>
        /// ################## Zapis danych do karty po zamknieciu 
        /// </summary>
#region Zapis danych do karty po zamknieciu 
        private void ExitAndSaveObservationControl()
        {
            List<String> lstr;
            //String str = "";
            //markerImage
            _currentObservationCtrl.MarkerImage = GetCurrentMarkerImage();
            _currentObservationCtrl.MarkerImageDescriptionTag = GetCurrentMarkerImageTag();
            //Date
                _currentObservationCtrl.Date = dateTimePickerDataObserwacji.Value;//tylko miesiac i dzien

            
       //literki
            _currentObservationCtrl.Literki = GetRadioButtonTextFromGroupBox(groupBoxLiterki);
       //cyferki
            _currentObservationCtrl.Cyferki = GetRadioButtonTextFromGroupBox(groupBoxCyferki);
       //cyferki CD
            //str = "";
            if (groupBoxCyferkiCD.Enabled){
                _currentObservationCtrl.CyferkiCD = GetRadioButtonTextFromGroupBox(groupBoxCyferkiCD);
            }
      //ilerazy
            _currentObservationCtrl.IleRazy = GetRadioButtonTextFromGroupBox(groupBoxIleRazy);
      //uwagi
            _currentObservationCtrl.Uwagi = GetCheckboxTextFromGroupBox(_checkboxUwagiList);
      //notki-pierwsze litery 
            lstr = new List<string>();
            foreach (var VARIABLE in _textboxNoteMarksList)
            {
                lstr.Add(VARIABLE.Text.Trim()); //tylko pierwsze litery robi setter w kontrolce
            }
            _currentObservationCtrl.NoteMarks = lstr;
      //notkiTresc
            lstr = new List<string>();
            foreach (var VARIABLE in _richtextNotesList)
            {
                lstr.Add(VARIABLE.Text);
            }
            _currentObservationCtrl.NotesContent=lstr;
       //zdjecie uzytkownika
            if (_pathToUserPicture != null)
            {
                    _currentObservationCtrl.UserPictureFileInfo = _pathToUserPicture;
                }
            }

        private Image GetCurrentMarkerImage()
        {
            Image img = null;
            foreach (var VARIABLE in _markerCtrlsListList)
            {
                if(VARIABLE.Checked)    img = VARIABLE.MarkerImage;
            }
            return img;
        }

        private String GetCurrentMarkerImageTag()
        {
            String str = "";
            foreach (var VARIABLE in _markerCtrlsListList)
            {
                if (VARIABLE.Checked) str = VARIABLE.Tag.ToString();
            }
            return str;
        }

        private String GetRadioButtonTextFromGroupBox(GroupBox gb)
        {
            String str = "";
            foreach (var VARIABLE in gb.Controls)
            {
                RadioButton rb=VARIABLE as RadioButton;
                if (rb!=null)
                {
                    if (rb.Checked)
                    {
                        str = rb.Text;
                    }
                }
            }
            return str;
        }

        private List<String> GetCheckboxTextFromGroupBox(List<CheckBox> lcb)
        {
            List<String> lstr = new List<string>();
            foreach (var VARIABLE in _checkboxUwagiList)
            {
                if (VARIABLE.Checked)
                {
                    lstr.Add(VARIABLE.Text.Trim().Substring(0, 1));
                }
                else
                {
                    lstr.Add("");
                }
            }
            return lstr;
        }

        #endregion

        /// <summary>
        /// ################## Wczytywanie danych podczas otwarcia
        /// </summary>
#region Wczytywanie danych podczas otwarcia
        void PopulateObservationForm(ObservationCtrl obs)
        {
            //obrazek
            foreach (var VARIABLE in _markerCtrlsListList)
            {
                if (VARIABLE.Tag.ToString() == obs.MarkerImageDescriptionTag)
                {
                    VARIABLE.Checked = true;
                }
            }

            //data
            if(obs.Date==DateTime.Parse("1753 - 01 - 01"))
                if (_currentObservationCtrl.col>0)//czyli nie jest pierwsza
                {
                    int r = _currentObservationCtrl.row;
                    int c = _currentObservationCtrl.col;
                    DateTime prevCtrlDate = _myChart.ChartElements.ElementAt(r).ElementAt(c-1).Date;
                    if (prevCtrlDate!= DateTime.Parse("1753 - 01 - 01"))
                    {
                        dateTimePickerDataObserwacji.Value= prevCtrlDate.AddDays(1);
                    }
                }
                else
                {
                    dateTimePickerDataObserwacji.Value = DateTime.Today;
                }
            else dateTimePickerDataObserwacji.Value=obs.Date;

            //literki
            foreach (var VARIABLE in groupBoxLiterki.Controls)
            {
                RadioButton rb = VARIABLE as RadioButton;
                if (rb != null)
                {
                    if (rb.Text == obs.Literki)
                    {
                        rb.Checked = true;
                    }
                }
            }

            //cyferki
            foreach (var VARIABLE in groupBoxCyferki.Controls)
            {
                RadioButton rb = VARIABLE as RadioButton;
                if (rb != null)
                {
                    if (rb.Text == obs.Cyferki)
                    {
                        rb.Checked = true;
                    }
                }
            }

            //cyferkiCD
            foreach (var VARIABLE in groupBoxCyferkiCD.Controls)
            {
                RadioButton rb = VARIABLE as RadioButton;
                if (rb != null)
                {
                    if (rb.Text == obs.Cyferki)
                    {
                        rb.Checked = true;
                    }
                }
            }

            //IleRazy
            foreach (var VARIABLE in groupBoxIleRazy.Controls)
            {
                RadioButton rb = VARIABLE as RadioButton;
                if (rb != null)
                {
                    if (rb.Text == obs.IleRazy)
                    {
                        rb.Checked = true;
                    }
                }
            }

            //Uwagi
            foreach (var VARIABLE in _checkboxUwagiList)
            {
                int i = _checkboxUwagiList.IndexOf(VARIABLE);
                if (VARIABLE.Text.Substring(0, 1) == obs.Uwagi.ElementAt(i))
                {
                    VARIABLE.Checked = true;
                }
            }
            //noteMarks and notes
            foreach (var VARIABLE in _textboxNoteMarksList)
            {
                int i = _textboxNoteMarksList.IndexOf(VARIABLE);
                VARIABLE.Text = obs.NoteMarks.ElementAt(i);     //pierwsze litery
                _richtextNotesList.ElementAt(i).Text = obs.NotesContent.ElementAt(i); //tresc
            }
            //zdjecie
            if (_currentObservationCtrl.UserPictureFileInfo != "")
            {
                if(File.Exists(_currentObservationCtrl.UserPictureFileInfo))
                pictureBox1UserPicture.Image = Image.FromFile(_currentObservationCtrl.UserPictureFileInfo);
            }

        }
        #endregion
        public void Show(ObservationCtrl sender, CardChartClass cardChart)
        {
            base.Show();
            _currentObservationCtrl = sender;
            _myChart = cardChart;
            PopulateObservationForm(_currentObservationCtrl);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dt = (DateTimePicker) sender;
            this.Text = "Obserwacja dla dnia " + dt.Value.ToShortDateString();
        }

        private void btnResetObservation_Click(object sender, EventArgs e)
        {
            _currentObservationCtrl.IsNew = true;
 
            ResetRadioButtons(groupBoxLiterki);
            ResetRadioButtons(groupBoxCyferki);
            ResetRadioButtons(groupBoxCyferkiCD);
            ResetRadioButtons(groupBoxIleRazy);

            RadioButton_CheckedChange(groupBoxLiterki);
            RadioButton_CheckedChange(groupBoxCyferki);
            RadioButton_CheckedChange(groupBoxCyferkiCD);
            RadioButton_CheckedChange(groupBoxIleRazy);

            foreach (MarkerCtrl VARIABLE in _markerCtrlsListList)
            {
                VARIABLE.Checked = false;
            }

            foreach (CheckBox cb in groupBoxUwagi.Controls)
            {
                if (cb != null) cb.Checked = false;
            }

            foreach (TextBox tb in _textboxNoteMarksList)
            {
                int i = _textboxNoteMarksList.IndexOf(tb);
                tb.Text = "";
                _richtextNotesList.ElementAt(i).Text = "";
            }

            
        }

        private void ResetRadioButtons(GroupBox gb)
        {
            foreach (var VARIABLE in gb.Controls)
            {
                RadioButton rb=VARIABLE as RadioButton;
                if (rb != null) rb.Checked = false;
            }
        }




        private void RadioButton_CheckedChange(GroupBox gb)
        {
            //sprqawdzanie czy w grupbocxie cyferki zaznaczono 6 albo 8 albo 10
            //jak tak wlaczanie panelu cyferkiCD 
            //dodatkowo malowanie tla na zolto a nie systemControl
            //chyba ze zaznaczoen to na zielono
                foreach (var control in gb.Controls) //updateujemy tylko jednego aktualnego gruboxa
                {
                    RadioButton radio = control as RadioButton;
                    if (radio != null) //czy radio?
                    {
                        Color bColor = SystemColors.Control;
                        foreach (var VARIABLE in _rbEnablesCdList) //jesli jedna z {6 8 10}
                        {
                            if (radio == VARIABLE)
                            {
                                bColor = Color.LightYellow;
                            }
                        }
                        if (radio.Checked) //wlaczanie dodatkowych cyferek
                        {
                            radio.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            radio.BackColor = bColor;
                        }
                    }
                }

            //jesli zanznaczoen 6 8 10 to zalacz cyferki CD
            bool enaCD = false;
            foreach (var VARIABLE in _rbEnablesCdList)
            {
                if (VARIABLE.Checked)
                {
                    enaCD = true;
                }
            }

            if (!enaCD)
            {
                foreach (var VARIABLE in groupBoxCyferkiCD.Controls)
                {
                    RadioButton rb=VARIABLE as RadioButton;
                    if (rb!=null)rb.Checked = false;
                }
            }
            groupBoxCyferkiCD.Enabled = enaCD;
        }

        private void dateTimePickerDataObserwacji_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDataObserwacji_MouseHover(object sender, EventArgs e)
        {
        }

        private void richTextBoxNoteA_Leave(object sender, EventArgs e)
        {
            
        }

        private void richTextBoxNote_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb=sender as RichTextBox;
            if (rtb.Text.Length > 0)
            {
                int i = _richtextNotesList.IndexOf(rtb);
                TextBox tb = _textboxNoteMarksList.ElementAt(i) as TextBox;
                tb.Text = rtb.Text.Substring(0, 1).ToUpper();
            }
        }

        private void groupBoxMarkers_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.MediumPurple);
        }
        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                int Fillet = 5;
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                
                // Clear text and border
                g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left+Fillet, 0);


                // Drawing Border
                Point ptUL = new Point(box.ClientRectangle.X, box.ClientRectangle.Y+ (int)(strSize.Height / 2));//upper left
                Point ptUR = new Point(box.ClientRectangle.Width-1, box.ClientRectangle.Y+(int)(strSize.Height / 2));
                Point ptBL = new Point(box.ClientRectangle.X, box.ClientRectangle.Height-2);
                Point ptBR = new Point(box.ClientRectangle.Width-1, box.ClientRectangle.Height-2);
                //Left
                g.DrawLine(borderPen, ptUL.X, ptUL.Y +Fillet, ptBL.X, ptBL.Y-Fillet);
                //Right
                g.DrawLine(borderPen, ptUR.X, ptUR.Y +Fillet, ptBR.X, ptBR.Y-Fillet);
                //Bottom
                g.DrawLine(borderPen, ptBL.X +Fillet, ptBL.Y, ptBR.X -Fillet, ptBR.Y);
                ////Top1 before string
                g.DrawLine(borderPen, ptUL.X+Fillet, ptUL.Y, ptUL.X + box.Padding.Left+Fillet, ptUL.Y);
                ////Top2 after string
                g.DrawLine(borderPen, ptUL.X + 3*box.Padding.Left + (int)(strSize.Width) , ptUL.Y, ptUR.X - Fillet, ptUR.Y);
                //Drawin Arcs
                //kierunek CW, mierzone od osi X, kat poczatkowy, kat rysowany (nie koncowy)
                //i pamietaj o 2*fillet bo to rysuje prostokat i srodek luku jest w srodku prostokata
                Point pt=new Point();
                //UL
                pt = ptUL;
                g.DrawArc(borderPen,pt.X,pt.Y,2*Fillet,2*Fillet,180,90);
                //UR
                pt = ptUR;
                //g.DrawArc(borderPen, pt.X-2*Fillet, pt.Y, pt.X, pt.Y+2* Fillet, 270, 90);
                g.DrawArc(borderPen, pt.X-2*Fillet, pt.Y, 2 * Fillet, 2 * Fillet, -90, 90);
                //BL
                pt = ptBL;
                g.DrawArc(borderPen, pt.X, pt.Y-2*Fillet, 2* Fillet, 2*Fillet, 90, 90);
                //BR
                pt = ptBR;
                g.DrawArc(borderPen, pt.X-2*Fillet, pt.Y-2*Fillet, 2 * Fillet, 2 * Fillet, 0, 90);
            }
        }

        private void ObservationForm_KeyDown(object sender, KeyEventArgs e)
        {
            ////if (e.KeyCode == Keys.Enter && e.Shift)
            //if (e.KeyCode == Keys.Enter)btnSavenClose_Click(sender,e);
            //if (e.KeyCode == Keys.Escape) btnCancel_Click(sender, e);
        }

        private void btnPrevDay_Click(object sender, EventArgs e)
        {
            dateTimePickerDataObserwacji.Value=dateTimePickerDataObserwacji.Value.AddDays(-1);
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dateTimePickerDataObserwacji.Value = dateTimePickerDataObserwacji.Value.AddDays(+1);
        }
    }
}

