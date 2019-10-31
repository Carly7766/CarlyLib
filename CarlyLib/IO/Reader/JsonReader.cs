using System;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class JsonReader<T> : IReadable<T>, IDisposable
    {
        public IReadable<string> reader;


        public JsonReader(IReadable<string> reader)
        {
            this.reader = reader;
        }


        public T Read()
        {
            string text = reader.Read();

            T readedObject = new JsonDeserializer().Deserialize<T>(text);

            return readedObject;
        }

        public async Task<T> ReadAsync()
        {
            string text = await reader.ReadAsync();

            T readedObject = new JsonDeserializer().Deserialize<T>(text);

            return readedObject;
        }


        public void Dispose()
        {
            if (reader is IDisposable)
            {
                ((IDisposable)reader).Dispose();
            }
        }
    }
}
