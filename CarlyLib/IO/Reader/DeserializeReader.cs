using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class DeserializeReader<T> : IReadable<T>
    {
        public IReadable<string> StringReader;
        public IDeserializable<string> Deserializer;

        public DeserializeReader(IReadable<string> stringReader, IDeserializable<string> deserializer)
        {
            StringReader = stringReader;
            Deserializer = deserializer;
        }

        public T Read()
        {
            string text = StringReader.Read();

            return Deserializer.Deserialize<T>(text);
        }

        public async Task<T> ReadAsync()
        {
            string text = await StringReader.ReadAsync();

            return Deserializer.Deserialize<T>(text);
        }
    }
}
