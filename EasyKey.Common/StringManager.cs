using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyKey.Common
{
    public class StringManager
    {
        public Boolean ValidatePassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (String.IsNullOrWhiteSpace(password)) throw new ArgumentException("The password cannot be empty.");
            if (!hasUpperChar.IsMatch(password)) throw new ArgumentException("The password must contain atleast one Uppercase letter.");
            if (!hasNumber.IsMatch(password)) throw new ArgumentException("The password must contain atleast one number.");
            if (!hasMinimum8Chars.IsMatch(password)) throw new ArgumentException("The password must have atleast 8 characters.");

            return true;
        }

    }
}
