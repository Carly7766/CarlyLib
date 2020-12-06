using System;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class JsonReader<T> : IReadable<T>, IDisposable
    {
        public readonly IReadable<string> Reader;

        
        public void Dispose() => (Reader as IDisposable)?.Dispose();

        public JsonReader(IReadable<string> Reader)
        {
            this.Reader = Reader;
        }

        
        public T Read()
        {
            string text = Reader.Read();

            T readedObject = new JsonDeserializer().Deserialize<T>(text);

            return readedObject;
        }

        public async Task<T> ReadAsync()
        {
            string text = await Reader.ReadAsync();

            T readedObject = new JsonDeserializer().Deserialize<T>(text);

            return readedObject;
        }
    }
}
