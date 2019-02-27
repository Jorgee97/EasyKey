using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKey.Common
{
    public class FileLogger : LoggerBase
    {
        public override void Log(string message)
        {
            var filePath = Environment.CurrentDirectory + "/EasyKey.log";
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }
}
