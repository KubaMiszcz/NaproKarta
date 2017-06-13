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
		///new version
		private CardChartClass _myChart;
		private int _currentObservationRow;
		private int _currentObservationColumn;
		private ObservationClass _currentObservation;

		//zmienne pomocnicze
		private List<RadioButton> _rbEnablingLiterkiCDList; //3 radiobuttony wlaczajace dodatkowe cyferki
		private List<CheckBox> _checkboxUwagiList;
		private List<TextBox> _textboxNoteMarksList;
		private List<CheckBox> _checkboxNoteImportantMarksList;
		private List<RichTextBox> _richtextNotesList;
		private List<MarkerCtrl> _markerCtrlsList;
		//private String _pathToUserPicture;
		//private List<String> _pathToUserPicturesList;
		private ObservationCtrl _currentObservationCtrl;
		private int _currentPictureIndex;
		private List<String> _currentUserPicturesList;
		//private ObservationCtrl _currentObservationCtrl;

		public ObservationForm()
		{
			InitializeComponent();
		}

		private void PomiarForm_Load(object sender, EventArgs e)
		{
			#region Wczytywanie paramterow okienka

			_markerCtrlsList = new List<MarkerCtrl>()
			{
				markerCtrlRed,
				markerCtrlGreen,
				markerCtrlYellow,
				markerCtrlWhitewBaby,
				markerCtrlGreenwBaby,
				markerCtrlYellowwBaby,
				markerCtrlGreyConfused
			};
			_rbEnablingLiterkiCDList = new List<RadioButton>()
			{
				radioButtonCD6,
				radioButtonCD8,
				radioButtonCD10
			};

			_checkboxUwagiList = new List<CheckBox>()
			{
				checkBoxWizyta,
				checkBoxBadania,
				checkBoxLupucupu,
			};

			_textboxNoteMarksList = new List<TextBox>()
			{
				textBoxNoteMarkA,
				textBoxNoteMarkB,
				textBoxNoteMarkC
			};

			_checkboxNoteImportantMarksList = new List<CheckBox>()
			{
				cbImportantNoteA,
				cbImportantNoteB,
				cbImportantNoteC
			};

			_richtextNotesList = new List<RichTextBox>()
			{
				richTextBoxNoteA,
				richTextBoxNoteB,
				richTextBoxNoteC
			};
			_currentUserPicturesList = new List<string>();
			PopulateFormFromChart();
			#endregion Wczytywanie paramterow okienka
		}

		private void PopulateFormFromChart()
		{
			_myChart = SharedObjects.MyChart;
			_currentObservation = _myChart.ChartElements.ElementAt
				(_currentObservationRow).ElementAt
				(_currentObservationColumn);
			//_currentObservationRow i Col mam przekazane  w wywolaniu przez sender

			//markerImage
			foreach (MarkerCtrl marker in _markerCtrlsList)
			{
				if (marker.Tag.ToString() == _currentObservation.MarkerDescription)
				{
					marker.Checked = true;
				}
				else marker.Checked = false;
			}

			//DATA
			if (_currentObservation.Date > SharedObjects.NoDateTime)
			{
				//data ok istnieje
				dateTimePickerDataObserwacji.Value = _currentObservation.Date;
				this.Text = "Obserwacja dla dnia " + _currentObservation.Date.ToShortDateString();
			}
			else //czyli nei ma daty
			{
				this.Text = "Nowa Obserwacja";
				if (_currentObservation.col > 0)
				{
					//czyli nie jest pierwsza komorka w wierszu
					int row = _currentObservationRow;
					int col = _currentObservationColumn;
					DateTime DateFromPrevCtrl = _myChart.ChartElements.ElementAt(row).ElementAt(col - 1).Date;
					if (DateFromPrevCtrl != SharedObjects.NoDateTime)
					{
						//jest data poprawna w poprzedniej komorce
						dateTimePickerDataObserwacji.Value = DateFromPrevCtrl.AddDays(1); //dodaj jeden dzien
						this.Text = "Nowa obserwacja dla dnia " + DateFromPrevCtrl.AddDays(1).ToShortDateString();
					}
				}
				else //nowa data nowa obserwacja
				{
					dateTimePickerDataObserwacji.Value = DateTime.Today;
					this.Text = "Nowa obserwacja dla dnia " + DateTime.Today.ToShortDateString();
				}
			}

			//literki
			foreach (Control ctrl in groupBoxLiterki.Controls)
			{
				RadioButton rb = ctrl as RadioButton;
				if (rb != null)
				{
					if (rb.Text == _currentObservation.Literki)
					{
						rb.Checked = true;
					}
					else rb.Checked = false;
				}
			}
			foreach (Control ctrl in groupBoxLiterki.Controls)
			{
				CheckBox cb = ctrl as CheckBox;
				if (cb != null)
				{
					if (cb.Text == _currentObservation.LiterkiCD)
					{
						cb.Checked = true;
					}
					else cb.Checked = false;
				}
			}

			//cyferki
			foreach (var v in groupBoxCyferki.Controls) //tutaj tak bo oporocz radiobox jest ten zolty panel
			{
				RadioButton rb = v as RadioButton;
				if (rb != null)
				{
					if (rb.Text == _currentObservation.Cyferki)
					{
						rb.Checked = true;
					}
					else rb.Checked = false;
				}
			}

			//cyferkiCD
			foreach (RadioButton rb in groupBoxCyferkiCD.Controls)
			{
				if (rb != null)
				{
					if (rb.Text == _currentObservation.CyferkiCD)
					{
						rb.Checked = true;
					}
					else rb.Checked = false;
				}
			}

			//IleRazy
			foreach (RadioButton rb in groupBoxIleRazy.Controls)
			{
				if (rb != null)
				{
					if (rb.Text == _currentObservation.IleRazy)
					{
						rb.Checked = true;
					}
					else rb.Checked = false;
				}
			}

			//Uwagi
			foreach (CheckBox cb in _checkboxUwagiList)
			{
				int i = _checkboxUwagiList.IndexOf(cb);
				if (cb.Text.Substring(0, 1) == _currentObservation.Uwagi.ElementAt(i))
				{
					cb.Checked = true;
				}
				else cb.Checked = false;
			}

			//noteMarks and notes
			foreach (RichTextBox rtb in _richtextNotesList)
			{
				int i = _richtextNotesList.IndexOf(rtb);
				bool isImportant = _currentObservation.IsNotesImportant.ElementAt(i);
				if (isImportant) _textboxNoteMarksList.ElementAt(i).BackColor = Color.Red;
				_checkboxNoteImportantMarksList.ElementAt(i).Checked = isImportant;
				rtb.Text = _currentObservation.NotesContent.ElementAt(i); //tresc
				if (rtb.Text.Length > 0)
				{
					_textboxNoteMarksList.ElementAt(i).Text = rtb.Text.Substring(0, 1).ToUpper(); //pierwsze litery
				}
				else
				{
					_textboxNoteMarksList.ElementAt(i).Text = "";
				}

			}

			//zdjecie
			_currentUserPicturesList = _currentObservation.UserPicturesFileInfoList;
			if (_currentUserPicturesList.Count > 0) //zaladuj pierwsze zdjecie jesli istnieje
			{
				_currentPictureIndex = 0;
				String path = _currentUserPicturesList.ElementAt(_currentPictureIndex);
				if (File.Exists(path))
				{
					FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
					pictureBox1UserPicture.Image = Image.FromStream(stream);
					stream.Close();
				}
			}
		}


		public void Show(ObservationCtrl sender, int row, int col)
		{
			_currentObservationRow = row;
			_currentObservationColumn = col;
			_myChart = SharedObjects.MyChart;
			_currentObservationCtrl = sender;
			base.Show();
			PopulateFormFromChart();
		}

		private void ResetRadioButtons(GroupBox gb)
		{
			foreach (RadioButton rb in gb.Controls)
			{
				if (rb != null) rb.Checked = false;
			}
		}

		private void RadioButton_CheckedChangeInGroupBox(GroupBox gb)
		{
			//sprqawdzanie czy w grupbocxie cyferki zaznaczono 6 albo 8 albo 10
			//jak tak wlaczanie panelu cyferkiCD 
			//dodatkowo malowanie tla na zolto a nie systemControl
			//chyba ze zaznaczoen to na zielono

			foreach (var v in gb.Controls) //updateujemy tylko jednego aktualnego gruboxa
			{
				RadioButton rb = v as RadioButton;
				if (rb != null)
				{
					Color bColor = SystemColors.Control;
					foreach (RadioButton rbENA in _rbEnablingLiterkiCDList) //jesli jedna z {6 8 10}
					{
						if (rbENA == rb)
						{
							bColor = Color.LightYellow;
						}
					}
					if (rb.Checked)
					{
						//wlaczanie tla na zolto
						rb.BackColor = Color.LimeGreen;
					}
					else
					{
						rb.BackColor = bColor;
					}
				}
			}


			//jesli zanznaczoen 6 8 10 to zalacz cyferki CD
			bool enaCD = false;
			foreach (RadioButton rbEna in _rbEnablingLiterkiCDList)
			{
				if (rbEna.Checked)
				{
					enaCD = true;
				}
			}


			if (!enaCD)//kasowanie wszystki rb w literkiCD
			{
				foreach (RadioButton rb in groupBoxCyferkiCD.Controls)
				{
					if (rb != null) rb.Checked = false;
				}
			}
			groupBoxCyferkiCD.Enabled = enaCD;
		}



		//##########		EVENTS
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void radioButton_CheckedChangedEvent(object sender, EventArgs e)
		{
			//sprqawdzanie czy w grupbocxie cyferki zaznaczono 6 albo 8 albo 10
			//jak tak wlaczanie panelu cyferkiCD 
			//dodatkowo malowanie tla na zolto a nie systemControl
			//chyba ze zaznaczoen to na zielono
			RadioButton rb = sender as RadioButton;
			if ((rb != null) && ((rb.Parent as GroupBox) != null))
			{
				RadioButton_CheckedChangeInGroupBox(rb.Parent as GroupBox);//aktulaizuj tla w grupbopxie
			}
		}

		private void MarkerCtrl_CheckedChanged(object sender, EventArgs e)
		{
			foreach (MarkerCtrl marker in _markerCtrlsList)
			{
				if (sender == marker)
				{
					marker.Checked = true;
					marker.BackColor = Color.Blue;
				}
				else
				{
					marker.Checked = false;
					marker.BackColor = SystemColors.Control;
				}
			}
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
			_currentObservationCtrl.PopulateObservationCtrl(_currentObservation);
			//_currentObservationCtrl.IsNew = false;
			this.Close();
		}

		/// <summary>
		/// ################## Zapis danych do karty po zamknieciu 
		/// </summary>
		#region Zapis danych do karty po zamknieciu 
		private void ExitAndSaveObservationControl()
		{
			List<String> lstr;
			//markerDescription
			_currentObservation.MarkerDescription = GetCurrentMarkerDescription();

			//Date
			_currentObservation.Date = dateTimePickerDataObserwacji.Value;//tylko miesiac i dzien

			//literki
			_currentObservation.Literki = GetRadioButtonTextFromGroupBox(groupBoxLiterki);
			_currentObservation.LiterkiCD = GetCheckBoxTextFromGroupBox(groupBoxLiterki);
			//cyferki
			_currentObservation.Cyferki = GetRadioButtonTextFromGroupBox(groupBoxCyferki);
			//cyferki CD
			if (groupBoxCyferkiCD.Enabled)
			{
				_currentObservation.CyferkiCD = GetRadioButtonTextFromGroupBox(groupBoxCyferkiCD);
			}
			else _currentObservation.CyferkiCD = "";
			//ilerazy
			_currentObservation.IleRazy = GetRadioButtonTextFromGroupBox(groupBoxIleRazy);
			//uwagi
			_currentObservation.Uwagi = GetCheckboxTextFromGroupBox(_checkboxUwagiList);
			//notkiTresc
			lstr = new List<string>();
			foreach (RichTextBox rtb in _richtextNotesList)
			{
				lstr.Add(rtb.Text);
			}
			_currentObservation.NotesContent = lstr;

			//notki czy wazne
			List<bool> lbool = new List<bool>();
			foreach (CheckBox cb in _checkboxNoteImportantMarksList)
			{
				lbool.Add(cb.Checked);
			}
			_currentObservation.IsNotesImportant = lbool;

			//zdjecie uzytkownika
			if (_currentUserPicturesList != null)
			{
				_currentObservation.UserPicturesFileInfoList = _currentUserPicturesList;
			}



		}

		private String GetCurrentMarkerDescription()
		{
			String str = "";
			foreach (MarkerCtrl ctrl in _markerCtrlsList)
			{
				if (ctrl.Checked) str = ctrl.Tag.ToString();
			}
			return str;
		}

		private String GetRadioButtonTextFromGroupBox(GroupBox gb)
		{
			String str = "";
			foreach (var v in gb.Controls)
			{
				RadioButton rb = v as RadioButton;
				if (rb != null)
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

		private String GetCheckBoxTextFromGroupBox(GroupBox gb)
		{
			String str = "";
			foreach (Control ctrl in gb.Controls)
			{
				CheckBox cb = ctrl as CheckBox;
				if (cb != null)
				{
					if (cb.Checked)
					{
						str = cb.Text;
					}
				}
			}
			return str;
		}

		#endregion


		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			DateTimePicker dt = (DateTimePicker)sender;
			this.Text = "Obserwacja dla dnia " + dt.Value.ToShortDateString();
		}

		private void btnResetObservation_Click(object sender, EventArgs e)
		{
			//markerImage
			foreach (MarkerCtrl marker in _markerCtrlsList)
			{
				marker.Checked = false;
			}

			//DATA
			if (_currentObservation.Date > SharedObjects.NoDateTime)
			{
				//data ok istnieje
				dateTimePickerDataObserwacji.Value = _currentObservation.Date;
				this.Text = "Obserwacja dla dnia " + _currentObservation.Date.ToShortDateString();
			}
			else //czyli nei ma daty
			{
				this.Text = "Nowa Obserwacja";
				if (_currentObservation.col > 0)
				{
					//czyli nie jest pierwsza komorka w wierszu
					int row = _currentObservationRow;
					int col = _currentObservationColumn;
					DateTime DateFromPrevCtrl = _myChart.ChartElements.ElementAt(row).ElementAt(col - 1).Date;
					if (DateFromPrevCtrl != SharedObjects.NoDateTime)
					{
						//jest data poprawna w poprzedniej komorce
						dateTimePickerDataObserwacji.Value = DateFromPrevCtrl.AddDays(1); //dodaj jeden dzien
						this.Text = "Nowa obserwacja dla dnia " + DateFromPrevCtrl.AddDays(1).ToShortDateString();
					}
				}
				else //nowa data nowa obserwacja
				{
					dateTimePickerDataObserwacji.Value = DateTime.Today;
					this.Text = "Nowa obserwacja dla dnia " + DateTime.Today.ToShortDateString();
				}
			}

			//literki
			foreach (Control ctrl in groupBoxLiterki.Controls)
			{
				RadioButton rb = ctrl as RadioButton;
				if (rb != null) rb.Checked = false;
			}
			foreach (Control ctrl in groupBoxLiterki.Controls)
			{
				CheckBox cb = ctrl as CheckBox;
				if (cb != null) cb.Checked = false;
			}

			//cyferki
			foreach (var v in groupBoxCyferki.Controls) //tutaj tak bo oporocz radiobox jest ten zolty panel
			{
				RadioButton rb = v as RadioButton;
				if (rb != null) rb.Checked = false;
			}

			//cyferkiCD
			foreach (RadioButton rb in groupBoxCyferkiCD.Controls)
			{
				if (rb != null) rb.Checked = false;
			}

			//IleRazy
			foreach (RadioButton rb in groupBoxIleRazy.Controls)
			{
				if (rb != null) rb.Checked = false;
			}

			//Uwagi
			foreach (CheckBox cb in _checkboxUwagiList)
			{
				int i = _checkboxUwagiList.IndexOf(cb);
				cb.Checked = false;
			}

			//noteMarks and notes
			foreach (RichTextBox rtb in _richtextNotesList)
			{
				int i = _richtextNotesList.IndexOf(rtb);
				_textboxNoteMarksList.ElementAt(i).BackColor = Color.PaleGreen;//xxxxxxxxxxx
				_checkboxNoteImportantMarksList.ElementAt(i).Checked = false;
				rtb.Text = ""; //tresc
				_textboxNoteMarksList.ElementAt(i).Text = "";
			}

			//zdjecie
			_currentUserPicturesList = new List<String>();
			pictureBox1UserPicture.Image = Properties.Resources.emptyPhoto;
		}




		private void dateTimePickerDataObserwacji_Enter(object sender, EventArgs e)
		{

		}

		private void dateTimePickerDataObserwacji_MouseHover(object sender, EventArgs e)
		{
		}

		private void richTextBoxNote_TextChanged(object sender, EventArgs e)
		{
			RichTextBox rtb = sender as RichTextBox;
			if (rtb.Text.Length > 0)
			{
				int i = _richtextNotesList.IndexOf(rtb);
				TextBox tb = _textboxNoteMarksList.ElementAt(i) as TextBox;
				tb.Text = rtb.Text.Substring(0, 1).ToUpper();
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
			dateTimePickerDataObserwacji.Value = dateTimePickerDataObserwacji.Value.AddDays(-1);
		}

		private void btnNextDay_Click(object sender, EventArgs e)
		{
			dateTimePickerDataObserwacji.Value = dateTimePickerDataObserwacji.Value.AddDays(+1);
		}

		private void checkBoxNoteImportantMark_CheckedChanged(object sender, EventArgs e)
		{
			foreach (CheckBox cb in _checkboxNoteImportantMarksList)
			{
				int i = _checkboxNoteImportantMarksList.IndexOf(cb);
				if (cb.Checked)
					_textboxNoteMarksList.ElementAt(i).BackColor = Color.Red;
				else
					_textboxNoteMarksList.ElementAt(i).BackColor = Color.PaleGreen;
			}
		}

		private void btnNextObservation_Click(object sender, EventArgs e)
		{
			//_currentObservationRow += row;
			_currentObservationColumn += 1;
			int maxCol = _myChart.ChartElements.ElementAt(_currentObservationRow).Count;
			if (_currentObservationColumn >= maxCol)
			{
				_currentObservationColumn = maxCol - 1;
				MessageBox.Show("Ostatnia obserwacja w wierszu!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			else
			{
				_currentObservation = _myChart.ChartElements.ElementAt(_currentObservationRow)
					.ElementAt(_currentObservationColumn);
				PopulateFormFromChart();
			}
		}

		private void btnPrevObservation_Click(object sender, EventArgs e)
		{
			//_currentObservationRow += row;
			_currentObservationColumn -= 1;
			if (_currentObservationColumn < 0)
			{
				_currentObservationColumn = 0;
				MessageBox.Show("Pierwsza obserwacja w wierszu!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			else
			{
				_currentObservation = _myChart.ChartElements.ElementAt(_currentObservationRow)
					.ElementAt(_currentObservationColumn);
				PopulateFormFromChart();
			}
		}

		private void btnPrevPicture_Click(object sender, EventArgs e)
		{
			if (_currentUserPicturesList.Count > 0)
			{
				_currentPictureIndex -= 1;
				if (_currentPictureIndex < 0)
				{
					_currentPictureIndex = 0;
				}
				String path = _currentUserPicturesList.ElementAt(_currentPictureIndex);
				if (File.Exists(path))
				{
					FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
					pictureBox1UserPicture.Image = Image.FromStream(stream);
					stream.Close();
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
					//_pathToUserPicture = openFileDialog1.FileName;
					//_currentUserPicturesList.Add((openFileDialog1.FileName));
					int maxPictures = _currentUserPicturesList.Count;
					if (maxPictures <= 0 || _currentPictureIndex >= maxPictures)
					{//gdy lista jeszcze nie isntnieje, lub zdjecie dod dodanai na koncu
						_currentUserPicturesList.Add(openFileDialog1.FileName);
					}
					else { _currentUserPicturesList[_currentPictureIndex] = openFileDialog1.FileName; }
					pictureBox1UserPicture.Image = Image.FromFile(openFileDialog1.FileName);
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

		private void btnNextPicture_Click(object sender, EventArgs e)
		{
			if (_currentUserPicturesList.Count > 0)
			{
				int maxPictures = _currentUserPicturesList.Count;
				_currentPictureIndex += 1;
				if (_currentPictureIndex >= maxPictures)
				{
					_currentPictureIndex = maxPictures;
					pictureBox1UserPicture.Image = Properties.Resources.emptyPhoto;
				}
				else
				{
					String path = _currentUserPicturesList.ElementAt(_currentPictureIndex);
					if (File.Exists(path))
					{
						FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
						pictureBox1UserPicture.Image = Image.FromStream(stream);
						stream.Close();
					}
				}
			}
		}

		private void btnRemovePicture_Click(object sender, EventArgs e)
		{
			if (_currentUserPicturesList.Count > 0)
			{
				_currentUserPicturesList.RemoveAt(_currentPictureIndex);
				int maxPictures = _currentUserPicturesList.Count;
				if (_currentPictureIndex >= maxPictures)
				{
					_currentPictureIndex = maxPictures;
					pictureBox1UserPicture.Image = Properties.Resources.emptyPhoto;
				}
				else
				{
					String path = _currentUserPicturesList.ElementAt(_currentPictureIndex);
					if (File.Exists(path))
					{
						FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
						pictureBox1UserPicture.Image = Image.FromStream(stream);
						stream.Close();
					}
				}
			}
		}

		private void groupBox_Paint(object sender, PaintEventArgs e)
		{
			GroupBox box = sender as GroupBox;
			DrawGroupBoxBorder(box, e.Graphics, Color.Black, Color.MediumPurple);
		}

		private void groupBoxSmall_Paint(object sender, PaintEventArgs e)
		{

		}

		private void DrawGroupBoxBorder(GroupBox box, Graphics g, Color textColor, Color borderColor)
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
				g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left + Fillet, 0);


				// Drawing Border
				Point ptUL = new Point(box.ClientRectangle.X, box.ClientRectangle.Y + (int)(strSize.Height / 2));//upper left
				Point ptUR = new Point(box.ClientRectangle.Width - 1, box.ClientRectangle.Y + (int)(strSize.Height / 2));
				Point ptBL = new Point(box.ClientRectangle.X, box.ClientRectangle.Height - 2);
				Point ptBR = new Point(box.ClientRectangle.Width - 1, box.ClientRectangle.Height - 2);
				//Left
				g.DrawLine(borderPen, ptUL.X, ptUL.Y + Fillet, ptBL.X, ptBL.Y - Fillet);
				//Right
				g.DrawLine(borderPen, ptUR.X, ptUR.Y + Fillet, ptBR.X, ptBR.Y - Fillet);
				//Bottom
				g.DrawLine(borderPen, ptBL.X + Fillet, ptBL.Y, ptBR.X - Fillet, ptBR.Y);
				////Top1 before string
				g.DrawLine(borderPen, ptUL.X + Fillet, ptUL.Y, ptUL.X + box.Padding.Left + Fillet, ptUL.Y);
				////Top2 after string
				g.DrawLine(borderPen, ptUL.X + 3 * box.Padding.Left + (int)(strSize.Width), ptUL.Y, ptUR.X - Fillet, ptUR.Y);
				//Drawin Arcs
				//kierunek CW, mierzone od osi X, kat poczatkowy, kat rysowany (nie koncowy)
				//i pamietaj o 2*fillet bo to rysuje prostokat i srodek luku jest w srodku prostokata
				Point pt = new Point();
				//UL
				pt = ptUL;
				g.DrawArc(borderPen, pt.X, pt.Y, 2 * Fillet, 2 * Fillet, 180, 90);
				//UR
				pt = ptUR;
				//g.DrawArc(borderPen, pt.X-2*Fillet, pt.Y, pt.X, pt.Y+2* Fillet, 270, 90);
				g.DrawArc(borderPen, pt.X - 2 * Fillet, pt.Y, 2 * Fillet, 2 * Fillet, -90, 90);
				//BL
				pt = ptBL;
				g.DrawArc(borderPen, pt.X, pt.Y - 2 * Fillet, 2 * Fillet, 2 * Fillet, 90, 90);
				//BR
				pt = ptBR;
				g.DrawArc(borderPen, pt.X - 2 * Fillet, pt.Y - 2 * Fillet, 2 * Fillet, 2 * Fillet, 0, 90);
			}
		}
	}
}

