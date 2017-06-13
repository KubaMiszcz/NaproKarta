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
    public partial class MarkerCtrl : UserControl
    {
        private bool _checked;
	    //private Image MarkerImage;
		[Category("Misc")]
		public bool Checked {
            get { return this._checked; }
            set
            {
                _checked = value;
                if (_checked)
                {
                    this.BackColor = Color.Blue;
                }
                else
                {
                    this.BackColor = SystemColors.Control;
                }
                
            }
        }
		[Category("Misc")]
		public Image MarkerImage
		{
			get { return this.button1.BackgroundImage; }
			set { button1.BackgroundImage = value; }
		}


		public MarkerCtrl()
        {
            InitializeComponent();
            WireAllControls(this);
            _checked = false;
        }

	    public String ButtonText {
		    get { return button1.Text; }
		    set { button1.Text = value; }
	    }

	    private void button1_Click(object sender, EventArgs e)
        {
            //_checked = !_checked;
			//if (Checked)
			//{
			//	this.BackColor = Color.Blue;
			//}
			//else
			//{
			//	//button2.BackColor = SystemColors.Control;
			//	this.BackColor = SystemColors.Control;
			//}
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

        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }
    }
}
