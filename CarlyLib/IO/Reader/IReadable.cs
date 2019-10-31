using System.Threading.Tasks;
namespace CarlyLib.IO
{
    public interface IReadable<T>
    {
        T Read();
        Task<T> ReadAsync(); 
    }
}
