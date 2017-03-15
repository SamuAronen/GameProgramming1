using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameProgramming1.Systems.SaveLoad
{
    public class BinaryFormatterSaveLoad<T> : ISaveLoad<T> where T : class
    {
        public string FileExtension
        {
            get { return ".dat"; }
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
            BinaryFormatter formatter = new BinaryFormatter();

            // Binary formatter stores serialixation result into stream
            using (MemoryStream stream = new MemoryStream())
            {

                formatter.Serialize(stream, objectToSave);

                File.WriteAllBytes(GetSaveFilePath(fileName), stream.GetBuffer());
            }
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
            if(DoesSaveExist(fileName))
            {
                byte[] data = File.ReadAllBytes(GetSaveFilePath(fileName));

                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream(data))
                {
                     return (T) formatter.Deserialize(stream);
                }
            }

            return default(T);
        }
    }
}