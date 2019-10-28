using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace audioSynth
{
	public partial class BasicSynthesizer : Form
	{
		private const int SAMPLE_RATE = 44100;
		public BasicSynthesizer()
		{
			InitializeComponent();
		}

		private void BasicSynthesizer_KeyDown(object sender, KeyEventArgs e)
		{
			MessageBox.Show("detected");
		}
	}
}
