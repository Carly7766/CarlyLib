namespace CarlyLib.IO
{
    public class JsonSerializer : ISerializable
    {
        public object target;

        public JsonSerializer(object target)
        {
            this.target = target;
        }

        public string Serialize()
        {
            return UnityEngine.JsonUtility.ToJson(target);
        }
    }
}
