using System;
using System.IO;
using System.Xml;

namespace ExchangeRates.SaveLoad
{
    public class SaveLoadXml
    {
        public const string Path = @"D:\financeData\";
        private const string XmlExtension = ".xml";
        public SaveLoadXml()
        {
            Directory.CreateDirectory(Path);
        }
        public void Save(XmlDocument document)
        {
            var date = DateTime.Now.ToString().Replace(':', '.');
            Directory.CreateDirectory(Path);
            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create(Path + date + XmlExtension, settings);
            document.Save(writer);
            writer.Close();
        }
        public string Load(string name)
        {
            using (var reader = new StreamReader(Path + name + XmlExtension))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
