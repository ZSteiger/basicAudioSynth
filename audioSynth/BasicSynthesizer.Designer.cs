namespace audioSynth
{
	partial class BasicSynthesizer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.oscillator1 = new audioSynth.Oscillator();
			this.SuspendLayout();
			// 
			// oscillator1
			// 
			this.oscillator1.Location = new System.Drawing.Point(12, 12);
			this.oscillator1.Name = "oscillator1";
			this.oscillator1.Size = new System.Drawing.Size(300, 211);
			this.oscillator1.TabIndex = 0;
			this.oscillator1.TabStop = false;
			// 
			// BasicSynthesizer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 450);
			this.Controls.Add(this.oscillator1);
			this.KeyPreview = true;
			this.Name = "BasicSynthesizer";
			this.Text = "Basic Synth";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BasicSynthesizer_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private Oscillator oscillator1;
	}
}

