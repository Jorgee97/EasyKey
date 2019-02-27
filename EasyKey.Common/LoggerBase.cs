﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKey.Common
{
    public abstract class LoggerBase
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message);
    }
}
