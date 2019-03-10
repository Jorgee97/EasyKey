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
        public int AccountID { get; set; } = StringManager.GenerateID();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Account()
        {
        }

        public OperationResult AddAccount(User userInformation)
        {
            var op = new OperationResult
            {
                Success = true
            };
            var fileManager = new FileManager();
            var doesEasyKeyFileExist = fileManager.ValidateFileExist(userInformation.FilePath);

            try
            {
                if (!doesEasyKeyFileExist) fileManager.CreateEasyKeyFile(userInformation.FilePath);
                fileManager.AppendToEasyKeyFile(userInformation.FilePath, this);
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

            return op;
        }

        public IEnumerable<Account> GetAccounts(User userInformation)
        {
            // TODO: Validate the argument exeption
            return new FileManager().ReadEasyKeyFile(userInformation.FilePath);
        }

        public OperationResult DeleteAccount(User userInformation, Account account)
        {
            var op = new OperationResult
            {
                Success = true
            };

            try
            {
                var fileManager = new FileManager();
                fileManager.DeleteAccountFromEasyKeyFile(userInformation.FilePath, account);
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

            return op;
        }

    }
}
