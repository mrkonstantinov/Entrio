using System;
using System.Collections.Generic;

namespace Entrio.Services.Entries.Domain.Models
{
    public class Entry
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Currency { get; protected set; }
        public string Timeframe { get; protected set; }
        public IEnumerable<string> Indicators { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Entry()
        {

        }
        public Entry(Guid id, Guid userId, 
                    string currency, string timeframe, IEnumerable<string> indicators, 
                    string name, string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Currency = currency;
            Timeframe = timeframe;
            Indicators = indicators;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}