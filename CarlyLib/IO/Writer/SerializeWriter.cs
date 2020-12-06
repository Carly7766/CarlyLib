using System;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class SerializeWriter : IWritable<ISerializable>, IDisposable
    {
        public readonly IWritable<string> Writer;


        public void Dispose() => (Writer as IDisposable)?.Dispose();

        public SerializeWriter(IWritable<string> writer)
        {
            this.Writer = writer;
        }

        
        public void Write(ISerializable serializer)
        {
            var text = serializer.Serialize();

            Writer.Write(text);
        }

        public async Task WriteAsync(ISerializable serializer)
        {
            string text = serializer.Serialize();

            await Writer.WriteAsync(text);
        }
    }
}
