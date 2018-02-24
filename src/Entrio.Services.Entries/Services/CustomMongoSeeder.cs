using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrio.Common.Mongo;
using Entrio.Services.Entries.Domain.Models;
using Entrio.Services.Entries.Domain.Repositories;
using MongoDB.Driver;

namespace Entrio.Services.Entries.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly IIndicatorRepository _indicatorRepository;

        public CustomMongoSeeder(IMongoDatabase database,
            IIndicatorRepository indicatorRepository)
            : base(database)
        {
            _indicatorRepository = indicatorRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var indicators = new List<string>
            {
                "alligator",
                "envelopes",
                "parabolic"
            };
            await Task.WhenAll(indicators.Select(x => _indicatorRepository
                        .AddAsync(new Indicator(x))));
        }
    }
}