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
using System.IO;

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
			// need to convert into binary wave to be read
			byte[] binaryWave = new byte[SAMPLE_RATE * sizeof(short)];
			// Example frequency for testing
			float frequency = 220f;
			/*
				Sin Loop. Sample = Amplitude * sin(t * i) where t is angular frequency, i is unit of time 
			*/
			for (int i = 0; i < SAMPLE_RATE; i++)
			{
				wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i));
			}
			//split each short into 2 bytes and write them into the binary wave
			Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
			// The next section follows the WAV format standards to play audio
			using (MemoryStream memoryStream = new MemoryStream())
			using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			{
				short blockAlign = BITS_PER_SAMPLE / 8;
				int subChunkTwoSize = SAMPLE_RATE * blockAlign;
				// make an array for each individual character following ASCII specifications
				binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
				binaryWriter.Write(36 + subChunkTwoSize);
				binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
				binaryWriter.Write(16);
				binaryWriter.Write((short)1);
				binaryWriter.Write((short)1);
				binaryWriter.Write(SAMPLE_RATE);
				binaryWriter.Write(SAMPLE_RATE * blockAlign);
				binaryWriter.Write(blockAlign);
				binaryWriter.Write(BITS_PER_SAMPLE);
				binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
				binaryWriter.Write(subChunkTwoSize);
				binaryWriter.Write(binaryWave);
				// set memoryStream to 0 so it reads the start of the sound instead of the where it left off
				memoryStream.Position = 0;
				new SoundPlayer(memoryStream).Play();
			}

		}
	}

	public enum WaveForm
	{ 
		Sine, Square, Saw, Triangle, Noise
 }
}
