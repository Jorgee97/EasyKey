using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EasyKey.Common;

namespace EasyKey.BL
{
    public class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public User UserInformation { get; set; }
        public Account(User userInformation, string email)
        {
            UserInformation = userInformation;
            Email = email;
        }

        public bool ValidateEasyKeyFileExist()
        {
            return File.Exists(UserInformation.FilePath);
        }

        public OperationResult AddAccount()
        {
            var op = new OperationResult
            {
                Success = true
            };
            var fileManager = new FileManager();

            if (!ValidateEasyKeyFileExist())
            {
                try
                {
                    fileManager.CreateEasyKeyFile(UserInformation.FilePath);
                }
                catch (ArgumentException e)
                {
                    op.Success = false;
                    op.Message = e.Message;
                }
                catch (DirectoryNotFoundException e)
                {
                    op.Success = false;
                    op.Message = e.Message;
                    LoggerHelper.Log(LoggerTarget.File, e.Message);
                }
            }

            if (op.Success)
            {

            }

            return op;
        }

    }
}
