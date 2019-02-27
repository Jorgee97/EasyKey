using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKey.BL
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FilePath { get; set; } = Environment.CurrentDirectory + "/EasyKey.cpm";
        public string Hash { get; set; }
    }
}
