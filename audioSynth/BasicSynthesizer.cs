using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace audioSynth
{
	public partial class BasicSynthesizer : Form
	{
		// Every second, generate 44100 samples
		private const int SAMPLE_RATE = 44100;
		// Every sample, there are 16 bits binary storage, or a maximum of 16 1's
		private const short BITS_PER_SAMPLE = 16;
		public BasicSynthesizer()
		{
			InitializeComponent();
		}

		private void BasicSynthesizer_KeyDown(object sender, KeyEventArgs e)
		{
			// Samples stored into an array
			short[] wave = new short[SAMPLE_RATE];
			// Example frequency for testing
			float frequency = 440f;
			/*
				Sin Loop. Sample = Amplitude * sin(t * i) where t is angular frequency, i is unit of time 
			*/
			for (int i = 0; i < SAMPLE_RATE; i++)
			{
				wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i));
			}
		}
	}
}
