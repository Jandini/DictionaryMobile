using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Scraper
{

    public enum ScraperState
    {
        Running,
        Stopped,
    }

    /// <summary>
    /// ScraperObject
    /// </summary>
    abstract class ScraperObject
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public delegate void EventHandler(ScraperObject sender);

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public delegate void StateHandler(ScraperObject sender, ScraperState state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public delegate void ExceptionHandler(ScraperObject sender, Exception ex);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public delegate void ResultHander(ScraperObject sender, object result);
        */



        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnStart = null;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnFinish = null;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnStateChanged = null;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnError = null;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnResult = null;


        /// <summary>
        /// 
        /// </summary>
        protected ScraperState scraperState = ScraperState.Stopped;


        /// <summary>
        /// 
        /// </summary>
        private object parameters = null;



        /// <summary>
        /// 
        /// </summary>
        private Exception exception = null;


        /// <summary>
        /// 
        /// </summary>
        protected object result = null;


        /// -------------------------------------------------------------------
        /// <summary>
        /// This method checks is event assigned and call it. This method
        /// is virtual because threads must invoke the handler instead of 
        /// directly call it.
        /// </summary>
        /// <param name="eventHandler">Event handler</param>
        /// -------------------------------------------------------------------
        protected virtual void CallEvent(EventHandler eventHandler)
        {
            if (eventHandler != null)
            {
                eventHandler(this);
            }
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// -------------------------------------------------------------------
        protected virtual void DoScrape()
        {

        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        protected virtual void Execute()
        {
            DoScrape();
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        protected virtual void DoFinish()
        {
            if (scraperState == ScraperState.Running)
            {                
                CallEvent(OnFinish);
                ScraperState = ScraperState.Stopped;
            }
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        protected virtual void DoResult()
        {
            CallEvent(OnResult);
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// -------------------------------------------------------------------
        protected virtual void HandleError(Exception ex)
        {
            this.exception = ex;            
            CallEvent(OnError);         
        }



        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public void Run(object parameters)
        {
            this.ScraperState = ScraperState.Running;
            this.parameters = parameters;
            this.exception = null;

            CallEvent(OnStart);
            Execute();            
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public void Run()
        {
            Run(null);
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public ScraperState ScraperState
        {
            get
            {
                return scraperState;
            }

            set
            {
                if (value != scraperState)
                {
                    scraperState = value;

                    CallEvent(OnStateChanged);
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public object Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public Exception Exception
        {
            get
            {
                return this.exception;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public object Result
        {
            get
            {
                return this.result;
            }
        }
    }
}
