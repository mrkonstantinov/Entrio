using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrio.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Entrio.Api.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly IMongoDatabase _database;

        public EntryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Entry> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Entry>> BrowseAsync(Guid userId)
            => await Collection
                .AsQueryable()
                .Where(x => x.UserId == userId)
                .ToListAsync();

        public async Task AddAsync(Entry entry)
            => await Collection.InsertOneAsync(entry);

        private IMongoCollection<Entry> Collection 
            => _database.GetCollection<Entry>("Entries");
    }
}