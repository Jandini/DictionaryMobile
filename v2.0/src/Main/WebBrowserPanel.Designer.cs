namespace Janda
{
    partial class WebBrowserPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			  this.pnlBrowser = new System.Windows.Forms.WebBrowser();
			  this.pnlStatus = new System.Windows.Forms.Panel();
			  this.SuspendLayout();
			  // 
			  // pnlBrowser
			  // 
			  this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.pnlBrowser.Location = new System.Drawing.Point(0, 0);
			  this.pnlBrowser.Name = "pnlBrowser";
			  this.pnlBrowser.Size = new System.Drawing.Size(150, 127);
			  // 
			  // pnlStatus
			  // 
			  this.pnlStatus.BackColor = System.Drawing.SystemColors.Control;
			  this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			  this.pnlStatus.Location = new System.Drawing.Point(0, 127);
			  this.pnlStatus.Name = "pnlStatus";
			  this.pnlStatus.Size = new System.Drawing.Size(150, 23);
			  this.pnlStatus.Visible = false;
			  this.pnlStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatus_Paint);
			  // 
			  // WebBrowser
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			  this.BackColor = System.Drawing.SystemColors.Window;
			  this.Controls.Add(this.pnlBrowser);
			  this.Controls.Add(this.pnlStatus);
			  this.Name = "WebBrowser";
			  this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser pnlBrowser;
        private System.Windows.Forms.Panel pnlStatus;
    }
}
