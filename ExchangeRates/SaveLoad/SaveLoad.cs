using System;
using System.IO;
using System.Xml;

namespace ExchangeRates.SaveLoad
{
    public static class SaveLoadXml
    {
        public const string Path = @"D:\financeData\";
        private const string XmlExtension = ".xml";
        public static void Save(XmlDocument document)
        {
            var date = DateTime.Now.ToString().Replace(':', '.');
            Directory.CreateDirectory(Path);
            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create(Path + date + XmlExtension, settings);
            document.Save(writer);
        }
        public static string Load(string name)
        {
            using (var reader = new StreamReader(Path + name + XmlExtension))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
