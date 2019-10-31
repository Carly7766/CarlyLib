using System;
namespace CarlyLib.IO
{
    public abstract class ReaderFactory
    {
        public abstract IReadable<T> Create<T>(string path);
    }
}
