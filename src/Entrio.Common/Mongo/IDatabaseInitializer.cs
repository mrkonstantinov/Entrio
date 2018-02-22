using System.Threading.Tasks;

namespace Entrio.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}