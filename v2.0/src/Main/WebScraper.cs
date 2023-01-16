using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;


namespace Scraper
{

    class WebScraper : ScraperObject
    {
        /// <summary>
        /// Request Uniform Resource Identifier object
        /// </summary>
        private Uri requestUri = null;

        /// <summary>
        /// Request Uniform Resource Locator string
        /// </summary>
        private string requestUrl = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        private WebRequest webRequest = null;


        /// <summary>
        /// 
        /// </summary>
        private WebResponse webResponse = null;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnConnect = null;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnReceive = null;




        /// -------------------------------------------------------------------
        /// <summary>
        /// Class constructor without parameters
        /// </summary>
        /// -------------------------------------------------------------------
        public WebScraper()
        {
            
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// -------------------------------------------------------------------
        public WebScraper(string requestUrl)
        {
            RequestUrl = requestUrl;
        }




        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        protected virtual bool DoConnect()
        {
            CallEvent(OnConnect);

            bool result = false;

            try
            {                
                this.webRequest = WebRequest.Create(requestUri);
                this.webResponse = this.webRequest.GetResponse();

                result = this.webResponse != null;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            return result;
        }



        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        protected virtual bool DoReceive()
        {
            CallEvent(OnReceive);

            bool result = false;            

            try
            {   
                base.result = string.Empty;

                Stream webStream = this.webResponse.GetResponseStream();

                if (webStream != null)
                {
                    using (StreamReader sr = new StreamReader(webStream))
                    {
                        base.result = sr.ReadToEnd();
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            return result;
        }



        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        protected virtual void DoClose()
        {
            try
            {                
                if (webResponse != null)
                {
                    webResponse.Close();
                }

                webResponse = null;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        protected override void DoScrape()
        {
            try
            {
                if (DoConnect())
                {
                    if (DoReceive())
                    {
                        DoResult();
                    }

                    DoClose();
                }

                DoFinish();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }            
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Abort()
        {
            if (scraperState == ScraperState.Running)
            {
                if (webRequest != null)
                {
                    webRequest.Abort();
                    webRequest = null;
                }

                DoClose();
                DoFinish();
            }
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// Request Uniform Resource Identifier
        /// </summary>
        /// -------------------------------------------------------------------
        public Uri RequestUri
        {
            get
            {
                return this.requestUri;
            }

            set
            {
                this.requestUri = value;
            }
        }



        /// -------------------------------------------------------------------
        /// <summary>
        /// Request Uniform Resource Locator
        /// </summary>
        /// -------------------------------------------------------------------
        public string RequestUrl
        {
            get
            {
                return this.requestUrl;
            }

            set
            {
                this.requestUrl = value;
                this.requestUri = new Uri(value);
            }
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public string RequestResult
        {
            get
            {
                string result = string.Empty;

                if (base.result != null)
                {
                    result = base.result as string;
                }

                return result;
            }
        }
    }
}
