using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using RndomTests.Models;
using System.Runtime.Serialization.Json;

namespace RndomTests
{
    public class Utility
    {
        const string PATH = @"C:\Logs\Random Tests";

        public static void SerializeString(Person p)
        {
            string xmlString = string.Empty;
            try
            {
                string valsPath = PATH + "\\Values";
                if (!Directory.Exists(valsPath))
                {
                    Directory.CreateDirectory(valsPath);
                }

                // serializing to an XML file
                using (StreamWriter sw = new StreamWriter(valsPath + "\\value.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(p.GetType());

                    serializer.Serialize(sw, p);
                }

                using(StringWriter stringWriter = new StringWriter())
                {
                    XmlSerializer serializer = new XmlSerializer(p.GetType());
                    serializer.Serialize(stringWriter, p);
                    xmlString = stringWriter.ToString();
                    Log(xmlString, valsPath);
                }

                DataContractJsonSerializer djs = new DataContractJsonSerializer(p.GetType());
                Stream s = new MemoryStream();
                djs.WriteObject(s, p);
                s.Position = 0;//important!

                string jsonStr = string.Empty;

                using (StreamReader sr = new StreamReader(s))
                {
                    jsonStr = sr.ReadToEnd();
                }
                Log(jsonStr, valsPath);
            }
            catch (Exception ex)
            {
                string errsPath = PATH + "\\Errors";
                if (!Directory.Exists(errsPath))
                {
                    Directory.CreateDirectory(errsPath);
                }
                using (StreamWriter sw = new StreamWriter(errsPath + "\\err.txt",true))
                {
                    sw.WriteLine($"Exception message: {ex.Message}, exception stack trace: {ex.StackTrace}");
                    sw.WriteLine("_____________________________________");
                }
            }           
        }

        public static Person DeserializeXML(string xml)
        {
            Person p;
            using (StringReader sRead = new StringReader(xml))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
                p = (Person)xmlSerializer.Deserialize(sRead);
            }

            return p;
        }

        public static Person DeserializeJSON(string json)
        {
            Person p;
            
            using (StringReader sRead = new StringReader(json))
            {
                DataContractJsonSerializer djs = new DataContractJsonSerializer(typeof(Person));
                Stream s = new MemoryStream(Encoding.UTF8.GetBytes(json));
                p = (Person)djs.ReadObject(s);
            }
            return p;
        }

        private static void Log(string message, string path)
        {
            using (StreamWriter sw = new StreamWriter(path + "\\valStr.txt",true))
            {
                sw.WriteLine($"{message}");
            }
        }
    }
}
