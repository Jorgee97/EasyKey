using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using EasyKey.Common;
using System.Xml.Linq;

namespace EasyKey.BL
{
    public class FileManager
    {
        public bool CreateConfigFile(string path, User user)
        {
            StringManager.ValidateString(path, nameof(path));

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineOnAttributes = true
            };

            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Configuration");
                writer.WriteStartElement("Parameters");
                writer.WriteElementString("Username", user.Username);
                writer.WriteElementString("Password", user.Password);
                writer.WriteElementString("Hash", user.Hash);
                writer.WriteElementString("FilePath", user.FilePath);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return true;
        }

        public User UpdateConfigFile(string path, User user, string newPassword)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);

            xmlDocument.SelectSingleNode("Configuration/Parameters/Password").InnerText = newPassword;
            xmlDocument.Save(path);

            return ReadConfigFile(path);
        }

        public bool ValidateFileExist(string path)
        {
            return File.Exists(path);
        }

        public User ReadConfigFile(string path)
        {
            StringManager.ValidateString(path, nameof(path));
            User user = new User();

            XElement configFile = XElement.Load(path);
            var select = (from parameter in configFile.Elements("Parameters") select parameter);

            foreach (var item in select)
            {
                user.Username = item.Element("Username").Value;
                user.Password = item.Element("Password").Value;
                user.Hash = item.Element("Hash").Value;
                user.FilePath = item.Element("FilePath").Value;
            }

            return user;
        }

        public bool CreateEasyKeyFile(string path)
        {
            StringManager.ValidateString(path, nameof(path));

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineOnAttributes = true
            };

            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Accounts");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return true;
        }

        public bool AppendToEasyKeyFile(string path, Account accountInformation)
        {
            StringManager.ValidateString(path, nameof(path));

            XDocument easyKeyFile = XDocument.Load(path);
            XElement root = new XElement("Account");
            root.Add(new XElement("ID", accountInformation.AccountID),
                new XElement("Name", accountInformation.Name),
                new XElement("Email", accountInformation.Email),
                new XElement("Username", accountInformation.Username),
                new XElement("Password", accountInformation.Password));
            easyKeyFile.Element("Accounts").Add(root);
            easyKeyFile.Save(path);

            return true;
        }

        public IEnumerable<Account> ReadEasyKeyFile(string path)
        {
            StringManager.ValidateString(path, nameof(path));
            List<Account> accounts = new List<Account>();

            XElement easyKeyFile = XElement.Load(path);
            var accountsInfo = (from account in easyKeyFile.Elements("Account") select account);

            foreach (var account in accountsInfo)
            {
                accounts.Add(new Account
                {
                    AccountID = Int32.Parse(account.Element("ID").Value),
                    Name = account.Element("Name").Value,
                    Username = account.Element("Username").Value,
                    Email = account.Element("Email").Value,
                    Password = account.Element("Password").Value
                });
            }

            return accounts;
        }

        public void DeleteAccountFromEasyKeyFile(string path, Account account)
        {
            StringManager.ValidateString(path, nameof(path));

            XElement easyFile = XElement.Load(path);
            easyFile.Descendants("Account")
                .Where(x => x.Element("ID").Value == account.AccountID.ToString())
                .Single<XElement>()
                .Remove();
            easyFile.Save(path);
        }
    }
}
