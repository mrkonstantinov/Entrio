using System.Collections.Generic;
using System.Threading.Tasks;
using Entrio.Services.Entries.Domain.Models;

namespace Entrio.Services.Entries.Domain.Repositories
{
    public interface IIndicatorRepository
    {
        Task<Indicator> GetAsync(string name);
         Task<IEnumerable<Indicator>> BrowseAsync();
         Task AddAsync(Indicator category);
    }
}