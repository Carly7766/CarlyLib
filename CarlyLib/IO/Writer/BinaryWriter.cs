using System;
using System.IO;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class BinaryWriter : IWritable<byte[]>, IDisposable
    {
        private Stream Stream;


        public BinaryWriter(string path)
        {
            this.Stream = File.OpenWrite(path);
        }

        public BinaryWriter(Stream stream)
        {
            this.Stream = stream;
        }


        public void Write(byte[] buffer)
        {
            Stream.Write(buffer, 0, buffer.Length);
        }

        public async Task WriteAsync(byte[] buffer)
        {
            await Stream.WriteAsync(buffer, 0, buffer.Length);
        }


        public void Dispose()
        {
            if(Stream != null)
            {
                Stream.Dispose();
            }
        }
    }
}
