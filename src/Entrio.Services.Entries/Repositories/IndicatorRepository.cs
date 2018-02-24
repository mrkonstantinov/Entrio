using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrio.Services.Entries.Domain.Models;
using Entrio.Services.Entries.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Entrio.Services.Activities.Repositories
{
    public class IndicatorRepository : IIndicatorRepository
    {
        private readonly IMongoDatabase _database;

        public IndicatorRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Indicator> GetAsync(string name)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());

        public async Task<IEnumerable<Indicator>> BrowseAsync()
            => await Collection
                .AsQueryable()
                .ToListAsync();

        public async Task AddAsync(Indicator category)
            => await Collection.InsertOneAsync(category);

        private IMongoCollection<Indicator> Collection
            => _database.GetCollection<Indicator>("Indicators");
    }
}