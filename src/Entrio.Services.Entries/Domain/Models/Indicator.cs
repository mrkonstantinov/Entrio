using System;

namespace Entrio.Services.Entries.Domain.Models
{
    public class Indicator
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        protected Indicator()
        {
        }

        public Indicator(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();
        }
    }
}