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
    }
}
