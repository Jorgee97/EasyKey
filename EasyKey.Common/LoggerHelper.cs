using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKey.Common
{
    public class LoggerHelper
    {
        public static LoggerBase loggerBase = null;
        public static void Log(LoggerTarget target, string message)
        {
            switch(target)
            {
                case LoggerTarget.File:
                    loggerBase = new FileLogger();
                    loggerBase.Log(message);
                    break;
                default:
                    return;
            }
        }

    }
}
