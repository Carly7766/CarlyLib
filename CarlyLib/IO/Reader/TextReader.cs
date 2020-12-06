using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class TextReader : IReadable<string>, IDisposable
    {
        private Stream Stream;
        private Encoding Encoding;
        
        
        public　void Dispose() => Stream?.Close();

        public TextReader(string path)
        {
            Stream = File.OpenRead(path);

            Encoding = Encoding.Default;
        }

        public TextReader(string path, Encoding encoding)
        {
            Stream = File.OpenRead(path);

            Encoding = encoding;
        }

        public TextReader(Stream stream)
        {
            Stream = stream;

            Encoding = Encoding.Default;
        }

        public TextReader(Stream stream, Encoding encoding)
        {
            Stream = stream;

            Encoding = encoding;
        }


        public string Read()
        {
            byte[] buffer = new byte[Stream.Length];
            Stream.Read(buffer, 0, buffer.Length);

            string text = Encoding.GetString(buffer);

            return text;
        }

        public async Task<string> ReadAsync()
        {
            byte[] buffer = new byte[Stream.Length];
            await Stream.ReadAsync(buffer, 0, buffer.Length);

            string text = Encoding.GetString(buffer);

            return text;
        }
    }
}
