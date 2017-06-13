using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaproKarta
{
    public partial class ObservationCtrl : UserControl, ICloneable //UserControl
    {
        private bool _isNew;
        private Image _markerImage;
        private String _markerImageDescriptionTag;
        private DateTime _date;
        private String _literki;
        private String _cyferki;
        private String _cyferkiCD;
        private String _ilerazy;
        private List<String> _uwagi;
        private List<String> _noteMarks;
        private List<String> _notesContent;
        public int col, row;
        private List<String> Tags;
        private List<Image> MarkerImagesList;
        private String _userPictureFileInfo;

        #region properties gettery settery
        [Category("aObservationProperties")]
        public bool IsNew
        {
            get { return _isNew; }
            set
            {
                _isNew = value;
                if (_isNew) //reset card
                {
                    MarkerImage = null;
                    MarkerImageDescriptionTag = "";
                    Date = DateTime.Parse("1753-01-01");
                    Literki = "";
                    Cyferki = "";
                    CyferkiCD = "";
                    IleRazy = "";
                    Uwagi = new List<string>();
                    Uwagi.Add(""); Uwagi.Add(""); Uwagi.Add("");
                    NoteMarks = new List<string>();
                    NoteMarks.Add(""); NoteMarks.Add(""); NoteMarks.Add("");
                    NotesContent = new List<string>();
                    NotesContent.Add(""); NotesContent.Add(""); NotesContent.Add("");
                }
            }
        }
        [Category("aObservationProperties")]
        public Image MarkerImage
        {
            get { return _markerImage; }
            set
            {
                _markerImage = value;
                pictureBoxMarker.BackgroundImage = value;
            }
        }
        [Category("aObservationProperties")]
        public String MarkerImageDescriptionTag
        {
            get { return this._markerImageDescriptionTag; }
            set
            {
                this._markerImageDescriptionTag = value;
                int i = Tags.IndexOf(value);
                if (i>=0 && i<=6) //7 znaczkow
                {
                    
                    MarkerImage = MarkerImagesList.ElementAt(i);
                }
            }
        }
        [Category("aObservationProperties")]
        public DateTime Date
        {
            get { return this._date; }
            set
            {
                this._date = value;
                if (value.ToShortDateString()== "1753-01-01")labelDate.Text = "";
                else labelDate.Text = value.ToShortDateString().Substring(5);
            }
        }
        [Category("aObservationProperties")]
        public String Literki
        {
            get { return this._literki; }
            set
            {
                this._literki = value;
                labelLiterki.Text = value;
            }
        }
        [Category("aObservationProperties")]
        public String Cyferki {
            get { return this._cyferki; }
            set
            {
                this._cyferki = value;
                label3cyferki.Text = value+this._cyferkiCD;
            }
        }
        [Category("aObservationProperties")]
        public String CyferkiCD
        {
            get { return this._cyferkiCD; }
            set
            {
                this._cyferkiCD = value;
                label3cyferki.Text = this._cyferki+value;
            }
        }
        [Category("aObservationProperties")]
        public String IleRazy
        {
            get { return this._ilerazy; }
            set
            {
                this._ilerazy = value;
                label2ilerazy.Text = value;
            }
        }
        [Category("aObservationProperties")]
        public List<String> Uwagi
        {
            get { return this._uwagi; }
            set
            {
                List<String>lstr=new List<String>();
                if (value != null)
                {
                    foreach (var VARIABLE in value)
                    {
                        if (VARIABLE.Length > 0) lstr.Add(VARIABLE.Trim().Substring(0, 1));
                        else lstr.Add("");
                    }
                }
                else
                {
                    lstr = new List<string>();
                    lstr.Add(""); lstr.Add(""); lstr.Add("");
                }
                this._uwagi = lstr;

                String str = "";
                foreach (var VARIABLE in this._uwagi)
                {
                    str += VARIABLE + " ";
                }
                label1uwagi.Text = str.Trim();
            }
        }
        [Category("aObservationProperties")]
        public List<String> NoteMarks
        {
            get { return this._noteMarks; }
            set
            {
                List<String> lstr=new List<String>();
                if (value != null)
                {
                    foreach (var VARIABLE in value)
                    {
                        if (VARIABLE.Length > 0) lstr.Add(VARIABLE.Trim().Substring(0, 1));
                        else lstr.Add("");
                    }
                }
                else
                {
                    lstr=new List<string>();
                    lstr.Add(""); lstr.Add(""); lstr.Add("");
                }
                this._noteMarks = lstr;

                String str = "";
                foreach (var VARIABLE in this._noteMarks)
                {
                    str += VARIABLE + " ";
                }
                label1Notki.Text = str.Trim();
            }
        }
        [Category("aObservationProperties")]
        public List<String> NotesContent
        {
            get { return this._notesContent; }
            set
            {
                List<String> lstr=new List<String>();
                if (value != null)
                {
                    foreach (var VARIABLE in value)
                    {
                        lstr.Add(VARIABLE.Trim());
                    }
                }
                else
                {
                    lstr = new List<string>();
                    lstr.Add(""); lstr.Add(""); lstr.Add("");
                }
                this._notesContent = lstr;

                //String str = "";
                //foreach (var VARIABLE in value)
                //{
                //    int i = value.IndexOf(VARIABLE);
                //    str += _noteMarks.ElementAt(i) + " - " + VARIABLE + Environment.NewLine;
                //    toolTip1.Show(str, this);
                //}
                
            }
        }

        public String UserPictureFileInfo {
            get
            {
                if (_userPictureFileInfo==null)
                {
                    return "";
                }
                else
                {
                    return _userPictureFileInfo;
                }
            }
            set {
                if (value == null)
                {
                    _userPictureFileInfo="";
                }
                else
                {
                    _userPictureFileInfo = value;
                }
            }
        }
        #endregion


        /// <summary>
        /// KONSTRUKTOR
        /// </summary>
        public ObservationCtrl()
        {
           InitializeComponent();
            WireAllControls(this);
            Tags = new List<string>() {"Red", "Green", "Yellow", "WhiteBaby", "GreenBaby", "YellowBaby", "GreyConfused"};
            MarkerImagesList = new List<Image>()
            {
                Properties.Resources.markerRed,
                Properties.Resources.markerGreen,
                Properties.Resources.markerYellow,
                Properties.Resources.markerWhiteBaby,
                Properties.Resources.markerGreenBaby,
                Properties.Resources.markerYellowBaby,
                Properties.Resources.markerGreyConfused
            };
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
                //ctl.MouseHover += ctl_MouseHover;
                //if (ctl.HasChildren)
                //{
                //    WireAllControls(ctl);
                //}
                //ctl.MouseLeave += ctl_MouseLeave;
                //if (ctl.HasChildren)
                //{
                //    WireAllControls(ctl);
                //}
            }
        }

        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }

        private void ObservationCtrl_Load(object sender, EventArgs e)
        {
            //ObservationCtrl o=sender as ObservationCtrl;
            //o.Parent.Visible = false;
            //if (o.row == 5 && o.col == 34)
            //{
            //    o.Parent.Visible = true;
            //}

        }

        //private void ctl_MouseHover(object sender, EventArgs e)
        //{

        //}

        //private void ctl_MouseLeave(object sender, EventArgs e)
        //{

        //}

        public object Clone()
        {
            ////base.OnPaint(e);   //to jak robie override to zeby dopsiac a nie zastapic
            throw new NotImplementedException();
        }


        //private void ObservationCtrl_Paint(object sender, PaintEventArgs e)
        //{
        //    //base.OnPaint(e);   //to jak robie override to zeby dopsiac a nie zastapic
        //    Pen pBlack = new Pen(Color.Black, gridThickness);
        //    Brush brWhite = new SolidBrush(Color.White);
        //    // Create rectangle. 
        //    //Rectangle rect = new Rectangle(0, 0, myChart.cellWidth, myChart.cellHeight);
        //    // Draw rectangle to screen. 
        //    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
        //    e.Graphics.FillRectangle(brWhite, rect);
        //    e.Graphics.DrawRectangle(pBlack, rect);
        //}
    }
}


