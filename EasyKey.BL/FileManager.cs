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

        public bool AppendToEasyKeyFile(string path)
        {
            // TODO: append

            return true;
        }
    }
}
