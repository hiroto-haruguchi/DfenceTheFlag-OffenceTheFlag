using System.IO;
using System.Xml.Serialization;
using Assets.Scripts.Save;
using UnityEngine;
using System.Runtime.Serialization;

public class DataUtil: MonoBehaviour
{
    public static T serialize<T>(string filename,T data)
    {
        using(var stream = new FileStream(filename, FileMode.Create))
        {
            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(stream, data);

        }

        return data;
    }

    public static T deserialize<T>(string filename)
    {
        using (var stream = new FileStream(filename, FileMode.Open))
        {
            var serializer = new DataContractSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }

    public static void  saveXML(string filepath,ManagementData data)
    {
        serialize(filepath, data);
    }


}
