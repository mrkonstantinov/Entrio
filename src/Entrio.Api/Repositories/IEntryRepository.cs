using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrio.Api.Models;

namespace Entrio.Api.Repositories
{
    public interface IEntryRepository
    {
        Task<Entry> GetAsync(Guid id);
        Task<IEnumerable<Entry>> BrowseAsync(Guid userId);
        Task AddAsync(Entry entry);
    }
}