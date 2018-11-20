using Newtonsoft.Json;
using System;

namespace SimplySecureLocal.Data.Models
{
    public abstract class Auditable : IEquatable<Auditable>
    {
        [JsonProperty("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty("dateCreated")]
        public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public bool Equals(Auditable other)
        {
            return Id == other.Id;
        }
    }
}