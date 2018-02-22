using System.Threading.Tasks;

namespace Entrio.Common.Mongo
{
    public interface IDatabaseSeeder
    {
         Task SeedAsync();
    }
}