using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using GameProgramming1.Data;
using UnityEngine;

namespace GameProgramming1.Systems.SaveLoad
{
    public class JSONSaveLoad<T> : ISaveLoad<T> where T : class
    {
        public string FileExtension
        {
            get { return ".json"; }
        }

        /// <summary>
        /// Returns full path of the savefile .
        /// </summary>
        /// <param name="saveFileName">Name of the save file without the extension</param>
        /// <returns></returns>
        public string GetSaveFilePath(string saveFileName)
        {
            return Path.Combine(Application.persistentDataPath, saveFileName) + FileExtension;
        }

        /// <summary>
        /// Serializes the object and saves it to disk;
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="fileName"></param>
        public void Save(T objectToSave, string fileName)
        {
            var jsonObject = JsonUtility.ToJson(objectToSave, true);

            File.WriteAllText(GetSaveFilePath(fileName), jsonObject, Encoding.UTF8);
        }

        public bool DoesSaveExist(string fileName)
        {
            return File.Exists(GetSaveFilePath(fileName));
        }

        /// <summary>
        /// Loads saved data from save file path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T Load(string fileName)
        {
            // We can only load the file if it exists
            if (DoesSaveExist(fileName))
            {
                var jsonObject = File.ReadAllText(GetSaveFilePath(fileName), Encoding.UTF8);
                return JsonUtility.FromJson<T>(jsonObject);
            }

            return default(T);
        }
    }
}