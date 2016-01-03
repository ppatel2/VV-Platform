using log4net;
using log4net.Config;
using System;

namespace VV.Utilities
{

     /// <summary>
     /// Generic logging singleton
     /// 
     /// Requires log4net configuration in the app.config file.
     /// </summary>
     public class Logger
    {
        public static readonly ILog Log = LogManager.GetLogger("VV");

        static Logger()
        {
            try
            {
                XmlConfigurator.Configure();
            }
            catch (Exception)
            {
                // Trap all exceptions!
            }
        }

        		/// <summary>
		/// Logs the exception.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="message">The message.</param>
		public static void LogException( Exception e, string message ) {
			LogException( e, message, true, true );
		}

		/// <summary>
		/// Logs the exception.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="message">The message.</param>
		/// <param name="includeNestedExceptions">if set to <c>true</c> [include nested exceptions].</param>
		/// <param name="includeStacktrace">if set to <c>true</c> [include stacktrace].</param>
		public static void LogException( Exception e, string message, bool includeNestedExceptions, bool includeStacktrace ) {
			Logger.Log.FatalFormat("{0}: {1}", message, e.Message);

			Exception currentException = e.InnerException;
			int nestedExceptionCount = 0;
			while (currentException != null)
			{
				if (nestedExceptionCount++ > 10)
				{
					Logger.Log.FatalFormat("Reached maximum depth(10) for nested exceptions.");
					break;
				}

				Logger.Log.FatalFormat("Nested Exception {0}: {1}", nestedExceptionCount, currentException.Message);
				currentException = currentException.InnerException;
			}

			Logger.Log.DebugFormat( "Stacktrace: {0}", e.StackTrace);
		}

          
    }
}
