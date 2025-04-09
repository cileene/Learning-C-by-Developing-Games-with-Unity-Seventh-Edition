using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace PMAData
{
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
        
        public static void SaveXmlToFile(string fileName, GroupMember groupMember)
        {
            string filePath = Path.Combine(DataPath, $"{fileName}.xml");
            string xml = SerializeToXML(groupMember);
            File.WriteAllText(filePath, xml);
            Debug.Log($"Saved data to {filePath}");
        }
        
        public static void SaveJsonToFile(string fileName, GroupMember groupMember)
        {
            string json = DataManager.SerializeToJson(groupMember);
            string jsonFilePath = Path.Combine(DataManager.DataPath, $"{fileName}.json");
            File.WriteAllText(jsonFilePath, json);
            Debug.Log("Saved JSON to " + jsonFilePath);
        }
        
        public static GroupMember LoadFromFile(string fileName)
        {
            string filePath = Path.Combine(DataPath, fileName);
            if (!File.Exists(filePath))
            {
                Debug.LogError($"File not found: {filePath}");
                return null;
            }

            string xml = File.ReadAllText(filePath);
            GroupMember groupMember = DeserializeFromXML(xml);
            Debug.Log($"Loaded data from {filePath}");
            return groupMember;
        }

        public static string SerializeToXML(GroupMember groupMember)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupMember));
            StringWriter stringWriter = new StringWriter();
            
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
            {
                serializer.Serialize(xmlWriter, groupMember);
            }
            
            string xmlString = stringWriter.ToString();
            stringWriter.Close();
            return xmlString;
        }
        
        public static GroupMember DeserializeFromXML(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupMember));
            StringReader stringReader = new StringReader(xmlString);
            GroupMember groupMember = (GroupMember)serializer.Deserialize(stringReader);
            stringReader.Close();
            return groupMember;
        }
        
        public static string SerializeToJson(GroupMember groupMember)
        {
            return JsonUtility.ToJson(groupMember, true);
        }
    }
}