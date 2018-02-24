using System;
using System.Threading.Tasks;
using Entrio.Services.Entries.Domain.Models;
using Entrio.Services.Entries.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Entrio.Services.Entries.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly IMongoDatabase _database;

        public EntryRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public Task AddAsync(Entry entry)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Entry> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}