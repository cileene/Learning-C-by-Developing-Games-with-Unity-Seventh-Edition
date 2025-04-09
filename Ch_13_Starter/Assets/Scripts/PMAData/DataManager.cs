using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace PMAData
{
    // this class was refactored to be more generic and reusable
    public static class DataManager
    {
        public static string DataPath;
        public static string DataPathName;
        
        public static void InitFileSystem()
        {
            DataPath = Application.persistentDataPath + $"/{DataPathName}/";
            Debug.Log(DataPath);

            if (Directory.Exists(DataPath))
            {
                Debug.Log($"Found directory at {DataPath}");
                return;
            }

            Directory.CreateDirectory(DataPath);
            Debug.Log($"New directory created at {DataPath}");
        }
        
        public static void SaveXmlToFile<T>(string fileName, T obj)
        {
            string filePath = Path.Combine(DataPath, $"{fileName}.xml");
            string xml = SerializeToXML(obj);
            File.WriteAllText(filePath, xml);
            Debug.Log($"Saved data to {filePath}");
        }
        
        public static void SaveJsonToFile<T>(string fileName, T obj)
        {
            string json = SerializeToJson(obj);
            string jsonFilePath = Path.Combine(DataManager.DataPath, $"{fileName}.json");
            File.WriteAllText(jsonFilePath, json);
            Debug.Log("Saved JSON to " + jsonFilePath);
        }
        
        public static T LoadFromFile<T>(string fileName)
        {
            string filePath = Path.Combine(DataPath, fileName);
            if (!File.Exists(filePath))
            {
                Debug.LogError($"File not found: {filePath}");
                return default;
            }

            string xml = File.ReadAllText(filePath);
            T obj = DeserializeFromXML<T>(xml);
            Debug.Log($"Loaded data from {filePath}");
            return obj;
        }

        // this xml aint exactly human readable.
        public static string SerializeToXML<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringWriter stringWriter = new StringWriter();
            
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
            {
                serializer.Serialize(xmlWriter, obj);
            }
            
            string xmlString = stringWriter.ToString();
            stringWriter.Close();
            return xmlString;
        }
        
        public static T DeserializeFromXML<T>(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(xmlString);
            T obj = (T)serializer.Deserialize(stringReader);
            stringReader.Close();
            return obj;
        }
        
        public static string SerializeToJson<T>(T obj)
        {
            return JsonUtility.ToJson(obj, true);
        }
    }
}