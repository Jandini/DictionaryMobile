using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Scraper;

namespace Janda
{
	public partial class frmMain : Form
	{

		/// <summary>
		/// 
		/// </summary>
		private WebScraperThread webScrapper = null;


		/// <summary>
		/// 
		/// </summary>
		public frmMain()
		{
			InitializeComponent();

			webScrapper = new WebScraperThread(this);

			webScrapper.OnStart += new ScraperObject.EventHandler(webScrapper_OnStart);
			webScrapper.OnFinish += new ScraperObject.EventHandler(webScrapper_OnFinish);
			webScrapper.OnConnect += new ScraperObject.EventHandler(webScrapper_OnConnect);
			webScrapper.OnReceive += new ScraperObject.EventHandler(webScrapper_OnReceive);
			webScrapper.OnResult += new ScraperObject.EventHandler(webScrapper_OnResult);
			webScrapper.OnError += new ScraperObject.EventHandler(webScrapper_OnError);

			cbxMain.Text = Strings.strTypeWordsHere;
		}



		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// -------------------------------------------------------------------
		private void Havigate(string query)
		{
			webScrapper.Abort();

			if (webScrapper.ScraperState == ScraperState.Stopped)
			{

				webScrapper.RequestUrl = "http://lajt.onet.pl/slowniki/"
					 + (mnuGerman.Checked ? "2" : (mnuFrench.Checked ? "3" : "1"))
					 + ",index.html?qs=" + query;

				webScrapper.Run(query);
			}
		}



		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// -------------------------------------------------------------------
		void webScrapper_OnError(ScraperObject sender)
		{
			MessageBox.Show(sender.Exception.Message, "Error",
				 MessageBoxButtons.OK, MessageBoxIcon.Hand,
				 MessageBoxDefaultButton.Button1);
		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// -------------------------------------------------------------------
		void webScrapper_OnStart(ScraperObject sender)
		{
			pnlInput.Enabled = false;
			cbxMain.Enabled = false;

			btnGo.Text = Strings.strStop;
			btnGo.Enabled = true;
		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// -------------------------------------------------------------------
		void webScrapper_OnConnect(ScraperObject sender)
		{
			webBrowser.StatusText = Strings.strConnecting;
		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// -------------------------------------------------------------------
		void webScrapper_OnReceive(ScraperObject sender)
		{
			webBrowser.StatusText = Strings.strReceivingData;
		}



		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// -------------------------------------------------------------------
		void webScrapper_OnFinish(ScraperObject sender)
		{
			webBrowser.StatusText = null;

			cbxMain.Enabled = true;
			btnGo.Enabled = true;
			btnGo.Text = Strings.strTranslate;

		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// -------------------------------------------------------------------
		void webScrapper_OnResult(ScraperObject sender)
		{
			string webContent = sender.Result as string;

			webBrowser.StatusText = Strings.strProcessingData;
			
			webContent = Regex.Replace(webContent, "<body\\b[^>]*><div\\b[^>]*>(.*?)</a></div>", "<body>");
			webContent = Regex.Replace(webContent, "<div\\b[^>]*><form\\b[^>]*>(.*?)</form></div><br>", string.Empty);
			webContent = Regex.Replace(webContent, "<a\\b[^>]*>(.*?)</a>", string.Empty);
			webContent = Regex.Replace(webContent, "<hr\\b[^>]*>(.*?)</body>", "</body>");
			
			string margin0 = "margin-top:0px;margin-bottom:0px;margin-left:0px;margin-right:0px;";
			string margin5 = "margin-top:5px;margin-bottom:5px;margin-left:5px;margin-right:5px;";

			webContent = webContent.Replace(margin0, margin5);

			webBrowser.StatusText = null;

			webBrowser.Browser.DocumentText = webContent;
		}




		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// -------------------------------------------------------------------
		private void AddRecent(string text)
		{
			bool exists = false;

			int i = 0;

			text = text.Trim();

			while (!exists && i < cbxMain.Items.Count)
			{
				exists = cbxMain.Items[i].ToString().ToUpper() == text.ToUpper();
				i++;
			}

			if (!exists)
			{
				cbxMain.Items.Add(text);
			}
		}




		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.DrawRectangle(new Pen(Color.Black),
				 webBrowser.Left - 1,
				 webBrowser.Top - 1,
				 webBrowser.Width + 1,
				 webBrowser.Height + 1);
		}



		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		private void btnGo_Click(object sender, EventArgs e)
		{
			btnGo.Enabled = false;

			if (webScrapper.ScraperState == ScraperState.Running)
			{
				webScrapper.Abort();
			}
			else
			{
				string query = cbxMain.Text.Trim();

				if (query != string.Empty)
				{
					Havigate(query);
					AddRecent(query);
				}
			}
		}



		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);

			if (e.KeyChar == 0x0D)
			{
				e.Handled = true;

				if (cbxMain.Text.Trim() != string.Empty)
				{
					string query = cbxMain.Text;

					Havigate(query);
					AddRecent(query);
				}
			}
		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		private void cbxMain_GotFocus(object sender, EventArgs e)
		{
			pnlInput.Enabled = true;
		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		private void cbxMain_LostFocus(object sender, EventArgs e)
		{
			pnlInput.Enabled = false;
		}




		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		private void cbxMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = cbxMain.SelectedIndex;

			if (index != -1)
			{
				Havigate(cbxMain.Items[index].ToString());
			}
		}


		

		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		private void mnuAbout_Click(object sender, EventArgs e)
		{
			frmAbout aboutForm = new frmAbout();	
			aboutForm.ShowDialog();
		}



		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		private void cbxMain_TextChanged(object sender, EventArgs e)
		{
			string text = cbxMain.Text.Trim();

			btnGo.Enabled = (text != string.Empty
				&& text != Strings.strTypeWordsHere);
		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		private void mnuExit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(Strings.strExitConfirm, Strings.strExitCaption,
				 MessageBoxButtons.YesNo, MessageBoxIcon.Question,
				 MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				Close();
			}
		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		private void mnuEnglish_Click(object sender, EventArgs e)
		{
			mnuEnglish.Checked = false;
			mnuFrench.Checked = false;
			mnuGerman.Checked = false;

			MenuItem item = sender as MenuItem;
			item.Checked = true;

			string text = cbxMain.Text.Trim();

			if (text != string.Empty && text != Strings.strTypeWordsHere)
			{
				Havigate(text);
				AddRecent(text);
			}
		}


		/// -------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		/// -------------------------------------------------------------------
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			webScrapper.Abort();
		}

	}
}