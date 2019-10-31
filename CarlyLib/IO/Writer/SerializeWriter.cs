using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class SerializeWriter : IWritable<ISerializable>
    {
        public IWritable<string> writer;

        public SerializeWriter(IWritable<string> writer)
        {
            this.writer = writer;
        }

        public void Write(ISerializable serializer)
        {
            string text = serializer.Serialize();

            writer.Write(text);
        }

        public async Task WriteAsync(ISerializable serializer)
        {
            string text = serializer.Serialize();

            await writer.WriteAsync(text);
        }
    }
}
