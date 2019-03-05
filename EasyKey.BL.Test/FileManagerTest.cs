using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EasyKey.BL.Test
{
    [TestClass]
    public class FileManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The path cannot be empty")]
        public void CreateConfigFileInvalidPathEmptyTest()
        {
            User user = new User("Username", "Password0");
            FileManager fileManager = new FileManager();
            fileManager.CreateConfigFile("", user);
        }

        [TestMethod]   
        public void CreateConfigFileSuccessTest()
        {
            // Arrange
            User user = new User("Username", "Password0");
            FileManager fileManager = new FileManager();
            fileManager.CreateConfigFile(user.FileConfigPath, user);

            // I expect the file to exist after calling CreateConfigFile
            // With the right parameters
            var expect = true;
            var actual = File.Exists(user.FileConfigPath);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void CreateConfigFileInvalidPathTest()
        {
            User user = new User("Username", "Password0");
            FileManager fileManager = new FileManager();
            fileManager.CreateConfigFile($"{Environment.CurrentDirectory} /EasyKey.config", user);
        }

        [TestMethod]
        public void ReadConfigFileTestValidTest()
        {
            User expected = new User("Username", "Password0");
            expected.Hash = "";
            FileManager fileManager = new FileManager();

            var actual = fileManager.ReadConfigFile(expected.FileConfigPath);

            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.Hash, actual.Hash);
            Assert.AreEqual(expected.FilePath, actual.FilePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The path cannot be empty")]
        public void ReadConfigFileTestInvalidPathTest()
        {
            User expected = new User("Username", "Password0");
            FileManager fileManager = new FileManager();
            var actual = fileManager.ReadConfigFile("");
        }

        [TestMethod]
        public void CreateEasyKeyFileValidTest()
        {
            var user = new User();
            var fileManager = new FileManager();

            var expected = true;
            fileManager.CreateEasyKeyFile(user.FilePath);

            var actual = File.Exists(user.FilePath);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The path cannot be empty")]
        public void CreateEasyKeyFileInvalidPathEmptyTest()
        {
            var user = new User();
            user.FilePath = String.Empty;
            FileManager fileManager = new FileManager();
            fileManager.CreateEasyKeyFile(user.FilePath);            
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void CreateEasyKeyFileInvalidPathTest()
        {
            var user = new User();
            user.FilePath = $"{Environment.CurrentDirectory} /Somepath.cpm";
            FileManager fileManager = new FileManager();
            fileManager.CreateEasyKeyFile(user.FilePath);
        }

        [TestMethod]
        public void AppendToEasyKeyFileValidTest()
        {
            var user = new User();
            var account = new Account
            {
                Name = "Facebook",
                Email = "john@doe.com",
                Password = "Somepassword",
                Username = "John Doe"
            };

            FileManager fileManager = new FileManager();
            var expected = true;
            var actual = fileManager.AppendToEasyKeyFile(user.FilePath, account);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void AppendToEasyKeyFileInvalidPathTest()
        {
            var user = new User();
            user.FilePath = $"{Environment.CurrentDirectory} /Somepath.cpm";
            var account = new Account
            {
                Name = "Facebook",
                Email = "john@doe.com",
                Password = "Somepassword",
                Username = "John Doe"
            };
            
            FileManager fileManager = new FileManager();
            fileManager.AppendToEasyKeyFile(user.FilePath, account);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The path cannot be empty")]
        public void AppendToEasyKeyFileInvalidPathEmptyTest()
        {
            var user = new User();
            user.FilePath = "";
            var account = new Account
            {
                Name = "Facebook",
                Email = "john@doe.com",
                Password = "Somepassword",
                Username = "John Doe"
            };
            
            FileManager fileManager = new FileManager();
            fileManager.AppendToEasyKeyFile(user.FilePath, account);
        }
    }
}
