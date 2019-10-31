using System;
namespace CarlyLib.IO
{
    public class JsonReaderFactory : ReaderFactory
    {
        public override IReadable<T> Create<T>(string path)
        {
            TextReader textReader = new TextReader(path);
            JsonReader<T> jsonReader = new JsonReader<T>(textReader); 
            return jsonReader;
        }
    }
}
