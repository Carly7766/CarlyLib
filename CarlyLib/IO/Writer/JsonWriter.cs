using System;
using CarlyLib.Text;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class JsonWriter : IWritable<object>, IDisposable
    {
        public readonly IWritable<string> Writer;
        private readonly JsonFormatter JsonFormatter;

        public void Dispose() => (Writer as IDisposable)?.Dispose();

        public JsonWriter(IWritable<string> writer)
        {
            this.Writer = writer;

            this.JsonFormatter = new JsonFormatter();
        }


        public void Write(object target)
        {
            string text = new JsonSerializer(target).Serialize();

            string formattedText = JsonFormatter.Format(text);

            Writer.Write(formattedText);
        }

        public async Task WriteAsync(object target)
        {
            string text = new JsonSerializer(target).Serialize();

            string formattedText = JsonFormatter.Format(text);

            await Writer.WriteAsync(formattedText);
        }
    }
}
