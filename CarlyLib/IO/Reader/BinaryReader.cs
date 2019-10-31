using System;
using System.IO;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class BinaryReader : IReadable<byte[]>, IDisposable
    {
        private Stream Stream;


        public BinaryReader(string path)
        {
            Stream = File.OpenRead(path);
            
        }

        public BinaryReader(Stream stream)
        {
            this.Stream = stream;
        }


        public byte[] Read()
        {
            byte[] buffer = new byte[Stream.Length];
            Stream.Read(buffer, 0, buffer.Length);

            return buffer;
        }

        public async Task<byte[]> ReadAsync()
        {
            byte[] buffer = new byte[Stream.Length];
            await Stream.ReadAsync(buffer, 0, buffer.Length);

            return buffer;
        }

        public　void Dispose()
        {
            if(Stream != null)
            {
                Stream.Dispose();
            }
        }
    }
}
