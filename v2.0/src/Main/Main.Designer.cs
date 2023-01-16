namespace Janda
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mnuMain;

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
			  System.Windows.Forms.MenuItem mnuLine;
			  System.Windows.Forms.MenuItem menuItem1;
			  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			  this.mnuMain = new System.Windows.Forms.MainMenu();
			  this.mnuDictionary = new System.Windows.Forms.MenuItem();
			  this.mnuEnglish = new System.Windows.Forms.MenuItem();
			  this.mnuGerman = new System.Windows.Forms.MenuItem();
			  this.mnuFrench = new System.Windows.Forms.MenuItem();
			  this.mnuAbout = new System.Windows.Forms.MenuItem();
			  this.mnuExit = new System.Windows.Forms.MenuItem();
			  this.pnlInput = new Microsoft.WindowsCE.Forms.InputPanel();
			  this.cbxMain = new System.Windows.Forms.ComboBox();
			  this.btnGo = new System.Windows.Forms.Button();
			  this.webBrowser = new Janda.WebBrowserPanel();
			  mnuLine = new System.Windows.Forms.MenuItem();
			  menuItem1 = new System.Windows.Forms.MenuItem();
			  this.SuspendLayout();
			  // 
			  // mnuMain
			  // 
			  this.mnuMain.MenuItems.Add(this.mnuDictionary);
			  // 
			  // mnuDictionary
			  // 
			  this.mnuDictionary.MenuItems.Add(this.mnuEnglish);
			  this.mnuDictionary.MenuItems.Add(this.mnuGerman);
			  this.mnuDictionary.MenuItems.Add(this.mnuFrench);
			  this.mnuDictionary.MenuItems.Add(mnuLine);
			  this.mnuDictionary.MenuItems.Add(this.mnuAbout);
			  this.mnuDictionary.MenuItems.Add(menuItem1);
			  this.mnuDictionary.MenuItems.Add(this.mnuExit);
			  this.mnuDictionary.Text = "&Dictionary";
			  // 
			  // mnuEnglish
			  // 
			  this.mnuEnglish.Checked = true;
			  this.mnuEnglish.Text = "&English";
			  this.mnuEnglish.Click += new System.EventHandler(this.mnuEnglish_Click);
			  // 
			  // mnuGerman
			  // 
			  this.mnuGerman.Text = "&German";
			  this.mnuGerman.Click += new System.EventHandler(this.mnuEnglish_Click);
			  // 
			  // mnuFrench
			  // 
			  this.mnuFrench.Text = "&French";
			  this.mnuFrench.Click += new System.EventHandler(this.mnuEnglish_Click);
			  // 
			  // mnuLine
			  // 
			  mnuLine.Text = "-";
			  // 
			  // mnuAbout
			  // 
			  this.mnuAbout.Text = "&About...";
			  this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			  // 
			  // menuItem1
			  // 
			  menuItem1.Text = "-";
			  // 
			  // mnuExit
			  // 
			  this.mnuExit.Text = "E&xit";
			  this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			  // 
			  // cbxMain
			  // 
			  this.cbxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.cbxMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			  this.cbxMain.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			  this.cbxMain.Location = new System.Drawing.Point(3, 3);
			  this.cbxMain.Name = "cbxMain";
			  this.cbxMain.Size = new System.Drawing.Size(166, 20);
			  this.cbxMain.TabIndex = 0;
			  this.cbxMain.SelectedIndexChanged += new System.EventHandler(this.cbxMain_SelectedIndexChanged);
			  this.cbxMain.LostFocus += new System.EventHandler(this.cbxMain_LostFocus);
			  this.cbxMain.GotFocus += new System.EventHandler(this.cbxMain_GotFocus);
			  this.cbxMain.TextChanged += new System.EventHandler(this.cbxMain_TextChanged);
			  // 
			  // btnGo
			  // 
			  this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			  this.btnGo.Enabled = false;
			  this.btnGo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			  this.btnGo.Location = new System.Drawing.Point(172, 3);
			  this.btnGo.Name = "btnGo";
			  this.btnGo.Size = new System.Drawing.Size(65, 20);
			  this.btnGo.TabIndex = 1;
			  this.btnGo.Text = "Translate";
			  this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			  // 
			  // webBrowser
			  // 
			  this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							  | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.webBrowser.Location = new System.Drawing.Point(4, 27);
			  this.webBrowser.Name = "webBrowser";
			  this.webBrowser.Size = new System.Drawing.Size(232, 237);
			  this.webBrowser.TabIndex = 2;
			  // 
			  // frmMain
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			  this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			  this.BackColor = System.Drawing.Color.WhiteSmoke;
			  this.ClientSize = new System.Drawing.Size(240, 268);
			  this.Controls.Add(this.webBrowser);
			  this.Controls.Add(this.btnGo);
			  this.Controls.Add(this.cbxMain);
			  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			  this.KeyPreview = true;
			  this.Menu = this.mnuMain;
			  this.Name = "frmMain";
			  this.Text = "Slowniki Mobile";
			  this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.WindowsCE.Forms.InputPanel pnlInput;
        private System.Windows.Forms.ComboBox cbxMain;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.MenuItem mnuDictionary;
        private System.Windows.Forms.MenuItem mnuEnglish;
        private System.Windows.Forms.MenuItem mnuGerman;
        private System.Windows.Forms.MenuItem mnuFrench;
		 private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.MenuItem mnuExit;
		 private WebBrowserPanel webBrowser;
    }
}

