using EasyKey.Common;
using System;
using System.Collections.Generic;
using System.IO;
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
        public string FileConfigPath { get; set; } = Environment.CurrentDirectory + "/EasyKey.config";
        public string Hash { get; set; }

        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public OperationResult AttempLoginOrCreateConfigFile()
        {
            if (File.Exists(FileConfigPath)) return LoginUser();
            return CreateUserConfigFile();
        }

        public OperationResult LoginUser()
        {
            var op = new OperationResult
            {
                Success = true
            };
            var fileManager = new FileManager();

            try
            {
                var configFileParameters = fileManager.ReadConfigFile(FileConfigPath);

                if (Username == configFileParameters.Username && Password == configFileParameters.Password)
                {
                    op.Message = "The information you provided was right";
                }
                else
                {
                    op.Message = "The information you provided was wrong, please try again.";
                    op.Success = false;
                }
            }
            catch (ArgumentException e)
            {
                op.Success = false;
                op.Message = e.Message;
            }
            catch (DirectoryNotFoundException e)
            {
                op.Success = false;
                op.Message = "There was a problem trying to read the config file.";
                LoggerHelper.Log(LoggerTarget.File, $"{e.GetType()} --> {e.Message}");
            }

            return op;
        }


        public OperationResult CreateUserConfigFile()
        {
            var op = new OperationResult();
            var stringManager = new StringManager();
            var fileManager = new FileManager();

            op.Success = true;
            op = ValidateUserData();

            if (op.Success)
            {
                try
                {
                    var fileCreated = fileManager.CreateConfigFile(FileConfigPath, this);
                    if (fileCreated) op.Message = "The configuration file was successfuly created.";
                }
                catch (ArgumentException e)
                {
                    op.Success = false;
                    op.Message = e.Message;
                }
                catch (DirectoryNotFoundException e)
                {
                    op.Success = false;
                    op.Message = "There was a problem trying to create the config file.";
                    LoggerHelper.Log(LoggerTarget.File, $"{e.GetType()} --> {e.Message}");
                }
            }

            return op;
        }

        private OperationResult ValidateUserData()
        {
            var op = new OperationResult();
            op.Success = true;

            try
            {
                var validUsername = StringManager.ValidateString(Username, nameof(Username));
                var validPassword = StringManager.ValidatePassword(Password);
            }
            catch (ArgumentException e)
            {
                op.Success = false;
                op.Message = e.Message;
            }

            return op;
        }
    }
}
