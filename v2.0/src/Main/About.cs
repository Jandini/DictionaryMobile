using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Janda
{
	public partial class frmAbout : Form
	{
		public frmAbout()
		{
			InitializeComponent();
		}


		/// <summary>
		/// 
		/// </summary>
		private Pen pen = new Pen(Color.Black);



		/// ---------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		/// ---------------------------------------------------------------------
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.DrawIcon(Icon, 14, 10);
			e.Graphics.DrawLine(pen, 14, 45, 200, 45);

			Rectangle rectangle = e.ClipRectangle;

			rectangle.Inflate(-3, -3);
			rectangle.Width -= 1;

			e.Graphics.DrawRectangle(pen, rectangle);
		}
	}
}