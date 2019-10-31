using UnityEngine;
namespace CarlyLib.IO
{
    public class JsonDeserializer : IDeserializable<string>
    {
        public T Deserialize<T>(string source)
        {
            return UnityEngine.JsonUtility.FromJson<T>(source);
        }
    }
}
