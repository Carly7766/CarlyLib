using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public interface IWritable<in TSource>
    {
        void Write(TSource source);
        Task WriteAsync(TSource source);
    }
}
