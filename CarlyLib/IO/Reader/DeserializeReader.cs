using System;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class DeserializeReader<T> : IReadable<T>, IDisposable
    {
        public readonly IReadable<string> Reader;
        public readonly IDeserializable<string> Deserializer;

        
        public void Dispose() => (Reader as IDisposable)?.Dispose();

        public DeserializeReader(IReadable<string> stringReader, IDeserializable<string> deserializer)
        {
            Reader = stringReader;
            Deserializer = deserializer;
        }

        
        public T Read()
        {
            var text = Reader.Read();

            return Deserializer.Deserialize<T>(text);
        }

        public async Task<T> ReadAsync()
        {
            string text = await Reader.ReadAsync();

            return Deserializer.Deserialize<T>(text);
        }
    }
}