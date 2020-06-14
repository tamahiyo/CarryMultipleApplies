using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryMultipleAppliesCommon.Log
{
    public class Logger
    {

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void Write(int logLevel, string message)
        {
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            switch (logLevel)
            {
                case (int)LogLevel.Debug:
                    logger.Info(message);
                    break;
                case (int)LogLevel.Error:
                    logger.Error(message);
                    break;
                default:
                    logger.Debug(message);
                    break;
            }
            
        }
    }
}
