using System;
using CarlyLib.Text;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class JsonWriter : IWritable<object>, IDisposable
    {
        public IWritable<string> writer;
        private JsonFormatter jsonFormatter;


        public JsonWriter(IWritable<string> writer)
        {
            this.writer = writer;

            this.jsonFormatter = new JsonFormatter();
        }


        public void Write(object target)
        {
            string text = new JsonSerializer(target).Serialize();

            string formattedText = jsonFormatter.Format(text);

            writer.Write(formattedText);
        }

        public async Task WriteAsync(object target)
        {
            string text = new JsonSerializer(target).Serialize();

            string formattedText = jsonFormatter.Format(text);

            await writer.WriteAsync(formattedText);
        }


        public void Dispose()
        {
            if (writer is IDisposable)
            {
                ((IDisposable)writer).Dispose();
            }
        }
    }
}
