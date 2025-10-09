using System.IO;
using UnityEngine;

namespace DarkGravityGames.Task5
{
    public static class JsonDataService
    {
        public static void SaveData(object data, string filePath, bool prettyPrint = true)
        {
            string jsonData = JsonUtility.ToJson(data, prettyPrint);
            filePath = Path.Combine(Application.persistentDataPath, filePath);
            File.WriteAllText(filePath, jsonData);
        }

        public static T LoadData<T>(string filePath)
        {
            filePath = Path.Combine(Application.persistentDataPath, filePath);
            string jsonData = File.ReadAllText(filePath);
            T data = JsonUtility.FromJson<T>(jsonData);

            return data;
        }
    }
}