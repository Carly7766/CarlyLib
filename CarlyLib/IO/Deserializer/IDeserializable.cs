using System;
namespace CarlyLib.IO
{
    public interface IDeserializable<TSource>
    {
        T Deserialize<T>(TSource source);
    }
}
