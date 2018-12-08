using Newtonsoft.Json;
using System;

namespace SimplySecureLocal.Data.Models
{
    public sealed class Module : Auditable
    {
        public Module()
        {
        }

        public Module(Guid id, bool state)
        {
            Id = id;
            State = state;
        }

        [JsonProperty("lastHeartbeat")]
        public DateTime LastHeartbeat { get; set; } = DateTime.Now;

        [JsonProperty("state")]
        public bool State { get; set; }
    }
}