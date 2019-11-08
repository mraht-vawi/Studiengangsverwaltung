﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Universitätsverwaltung.controller
{
    public class CloneController
    {
        public static T DeepClone<T>(T obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Position = 0;

                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }
}