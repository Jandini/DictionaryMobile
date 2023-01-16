using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Janda
{
	public partial class WebBrowserPanel : UserControl
	{

		/// <summary>
		/// 
		/// </summary>
		private string statusText = null;

		/// <summary>
		/// 
		/// </summary>
		private Brush brush = new SolidBrush(SystemColors.WindowText);

		/// <summary>
		/// 
		/// </summary>
		private Pen pen = new Pen(SystemColors.WindowFrame);


		/// <summary>
		/// 
		/// </summary>
		public WebBrowserPanel()
		{
			InitializeComponent();
		}




		/// ---------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// ---------------------------------------------------------------------
		public System.Windows.Forms.WebBrowser Browser
		{
			get
			{
				return this.pnlBrowser;
			}
		}


		/// ---------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// ---------------------------------------------------------------------
		public string StatusText
		{
			get
			{
				return statusText;
			}

			set
			{
				statusText = value;

				pnlStatus.Visible = (value != null);
				pnlStatus.Invalidate();
			}
		}


		/// ---------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// ---------------------------------------------------------------------
		private void pnlStatus_Paint(object sender, PaintEventArgs e)
		{
			if (statusText != null)
			{
				const int textXY = 5;

				e.Graphics.DrawLine(pen, 0, 0, e.ClipRectangle.Width, 0);
				e.Graphics.DrawString(statusText, Font, brush, textXY, textXY);
			}
		}
	}
}
