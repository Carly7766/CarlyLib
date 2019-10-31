using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public class TextWriter : IWritable<string>, IDisposable
    {
        private Stream Stream;
        private Encoding Encoding;
        

        public TextWriter(string path)
        {
            Stream = File.OpenWrite(path);

            Encoding = Encoding.Default;
        }

        public TextWriter(string path, Encoding encoding)
        {
            Stream = File.OpenWrite(path);

            Encoding = encoding;
        }

        public TextWriter(Stream stream)
        {
            Stream = stream;
            Encoding = Encoding.Default;
        }

        public TextWriter(Stream stream, Encoding encoding)
        {
            Stream = stream;

            Encoding = encoding;
        }


        public void Write(string text)
        {
            byte[] buffer = Encoding.GetBytes(text);

            Stream.Write(buffer, 0, buffer.Length);
        }

        public async Task WriteAsync(string text)
        {
            byte[] buffer = Encoding.GetBytes(text);

            await Stream.WriteAsync(buffer, 0, buffer.Length);
        }

        public void Dispose() {
            if(Stream != null)
            {
                Stream.Dispose();
            }
        }
    }
}
