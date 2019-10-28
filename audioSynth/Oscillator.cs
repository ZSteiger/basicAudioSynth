﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace audioSynth
{
	public class Oscillator : GroupBox
	{
		public Oscillator()
		{
			this.Controls.Add(new Button()
			{
				Name = "Sine",
				Location = new Point(10, 15),
				Text = "Sine",
			});
			this.Controls.Add(new Button()
			{
				Name = "Square",
				Location = new Point(65, 15),
				Text = "Square",
			});
			this.Controls.Add(new Button()
			{
				Name = "Saw",
				Location = new Point(120, 15),
				Text = "Saw",
			});
			this.Controls.Add(new Button()
			{
				Name = "Triangle",
				Location = new Point(10, 50),
				Text = "Triangle",
			});
			this.Controls.Add(new Button()
			{
				Name = "Noise",
				Location = new Point(65, 50),
				Text = "Noise",
			});
			foreach (Control control in this.Controls)
			{
				control.Size = new Size(50, 30);
				control.Font = new Font("Microsoft Sans Serif", 6.75f);
				control.Click += WaveButton_Click;
			}
		}
		public WaveForm WaveForm { get; private set; }

		private void WaveButton_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text);
			MessageBox.Show($"The button you pressed was {this.WaveForm}");
  }
	}

}
