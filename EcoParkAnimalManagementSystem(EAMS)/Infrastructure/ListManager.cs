using EcoParkAnimalManagementSystem_EAMS_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EcoParkAnimalManagementSystem_EAMS_.Infrastructure
{
    // <summary>
    /// This is a generic list manager that provides standard operations for managing different collection of items.
    /// Uses an internal List<T> for storage and provides methods for adding, removing, and modifying items.
    /// </summary>
    /// <typeparam name="T">The type of elements to store in the list</typeparam>
    public class ListManager<T> : IListManager<T>
    {
        // Internal list that stores all items
        private List<T> list;

        // Gets the number of items currently in the list.
        public int Count
        {
            get { return list.Count; }
        }

        // Initializes a new instance of the ListManager class with an empty list.
        public ListManager()
        {
            list = new List<T>();
        }

        // Adds an item to the end of the list.
        public bool Add(T type)
        {
            if (type == null)
            {
                return false;
            }

            list.Add(type);
            return true;
        }

        // Replaces the item at the specified index with a new item.
        public bool ChangeAt(T type, int index)
        {
            if (type == null || !CheckIndex(index))
            {
                return false;
            }

            list[index] = type;
            return true;
        }

        // Checks whether the specified index is within the valid range for this list.
        public bool CheckIndex(int index)
        {
            return index >= 0 && index < list.Count;
        }

        // Removes all items from the list.
        public void DeleteAll()
        {
            list.Clear();
        }

        // Removes the item at the specified index from the list.
        public bool DeleteAt(int index)
        {
            if (!CheckIndex(index))
            {
                return false;
            }

            list.RemoveAt(index);
            return true;
        }

        // Retrieves the item at the specified index.
        public T GetAt(int index)
        {
            if (!CheckIndex(index))
            {
                return default(T);
            }

            return list[index];
        }


        // Creates an array containing the string representation of each item in the list.
        public string[] ToStringArray()
        {
            string[] stringArray = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                stringArray[i] = list[i].ToString();
            }

            return stringArray;
        }

        // Creates a list containing the string representation of each item in the list.
        public List<string> ToStringList()
        {
            List<string> stringList = new List<string>();

            foreach (T item in list)
            {
                stringList.Add(item.ToString());
            }

            return stringList;
        }

        // Writes each item as a line in a plain text file.
        public virtual bool SaveToTextFile(string fileName)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName);
                foreach (T item in list)
                    writer.WriteLine(item.ToString());

                return true;
            }
            finally
            {
                writer?.Close();
            }
        }

        // Reads lines from a plain text file — concrete parsing is handled by AnimalManager.
        public virtual bool LoadFromTextFile(string fileName)
        {
          
            using (StreamReader reader = new StreamReader(fileName))
            {
                try
                {
                    list.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // T must be string for the base implementation to store lines directly.
                        // AnimalManager overrides this method to reconstruct typed Animal objects.
                        if (line is T typedLine)
                            list.Add(typedLine);
                    }
                    return true;
                }
                catch (IOException)
                {
                   
                    throw;
                }
            }
        }

        // Serializes the list to a JSON file using System.Text.Json.
        public bool JsonSerialize(string fileName)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(list, options);
            // using guarantees the file is closed even if an exception is thrown.
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(json);
            }
            return true;
        }

        // Deserializes the list from a JSON file.
        // Clears the existing list before loading.
        public bool JsonDeserialize(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string json = reader.ReadToEnd();
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<T> loaded = JsonSerializer.Deserialize<List<T>>(json, options);
                if (loaded == null)
                    return false;

                list.Clear();
                foreach (T item in loaded)
                    list.Add(item);

                return true;
            }
        }

        // Serializes the list to a well-formed XML file using XmlSerializer.
        public bool XmlSerialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            // using guarantees the stream closes cleanly.
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, list);
            }
            return true;
        }
    }
}
