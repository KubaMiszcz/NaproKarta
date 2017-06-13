using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaproKarta
{
	public partial class FileIOForm : Form
	{
		public FileIOForm()
		{
			InitializeComponent();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rb = sender as RadioButton;
			if (rb!=null)
			{
				if (rb.Checked)
				{
					rb.BackColor = Color.LimeGreen;
				}
				else
				{
					rb.BackColor = base.BackColor;
				}
			}
		}
	}
}
