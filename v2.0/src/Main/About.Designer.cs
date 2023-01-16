namespace Janda
{
    partial class frmAbout
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
			  System.Windows.Forms.Label lblAbout;
			  System.Windows.Forms.Label label2;
			  System.Windows.Forms.Label label3;
			  System.Windows.Forms.Label label1;
			  System.Windows.Forms.Label label4;
			  System.Windows.Forms.Label label5;
			  System.Windows.Forms.Label label6;
			  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
			  lblAbout = new System.Windows.Forms.Label();
			  label2 = new System.Windows.Forms.Label();
			  label3 = new System.Windows.Forms.Label();
			  label1 = new System.Windows.Forms.Label();
			  label4 = new System.Windows.Forms.Label();
			  label5 = new System.Windows.Forms.Label();
			  label6 = new System.Windows.Forms.Label();
			  this.SuspendLayout();
			  // 
			  // lblAbout
			  // 
			  lblAbout.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			  lblAbout.Location = new System.Drawing.Point(52, 12);
			  lblAbout.Name = "lblAbout";
			  lblAbout.Size = new System.Drawing.Size(131, 32);
			  lblAbout.Text = "Slowniki Mobile client version 2.0";
			  // 
			  // label2
			  // 
			  label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			  label2.Location = new System.Drawing.Point(14, 52);
			  label2.Name = "label2";
			  label2.Size = new System.Drawing.Size(73, 18);
			  label2.Text = "powered by";
			  // 
			  // label3
			  // 
			  label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			  label3.Location = new System.Drawing.Point(14, 72);
			  label3.Name = "label3";
			  label3.Size = new System.Drawing.Size(199, 18);
			  label3.Text = "copyright © Matthew Janda 2008";
			  // 
			  // label1
			  // 
			  label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			  label1.Location = new System.Drawing.Point(14, 131);
			  label1.Name = "label1";
			  label1.Size = new System.Drawing.Size(144, 17);
			  label1.Text = "Check for new version at:";
			  // 
			  // label4
			  // 
			  label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
			  label4.ForeColor = System.Drawing.Color.Blue;
			  label4.Location = new System.Drawing.Point(73, 52);
			  label4.Name = "label4";
			  label4.Size = new System.Drawing.Size(113, 15);
			  label4.Text = "www.slowniki.onet.pl";
			  // 
			  // label5
			  // 
			  label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
			  label5.ForeColor = System.Drawing.Color.Blue;
			  label5.Location = new System.Drawing.Point(14, 90);
			  label5.Name = "label5";
			  label5.Size = new System.Drawing.Size(169, 15);
			  label5.Text = "matt@programming-days.com";
			  // 
			  // label6
			  // 
			  label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
			  label6.ForeColor = System.Drawing.Color.Blue;
			  label6.Location = new System.Drawing.Point(14, 148);
			  label6.Name = "label6";
			  label6.Size = new System.Drawing.Size(180, 15);
			  label6.Text = "http://www.programming-days.com";
			  // 
			  // frmAbout
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			  this.AutoScroll = true;
			  this.BackColor = System.Drawing.Color.WhiteSmoke;
			  this.ClientSize = new System.Drawing.Size(240, 294);
			  this.Controls.Add(label6);
			  this.Controls.Add(label5);
			  this.Controls.Add(label4);
			  this.Controls.Add(label1);
			  this.Controls.Add(label3);
			  this.Controls.Add(label2);
			  this.Controls.Add(lblAbout);
			  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			  this.Name = "frmAbout";
			  this.Text = "About...";
			  this.ResumeLayout(false);

        }

        #endregion

	  }
}