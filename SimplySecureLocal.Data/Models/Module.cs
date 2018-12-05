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

        public DateTime LastHeartBeat { get; set; } = DateTime.Now;

        [JsonProperty("state")]
        public bool State { get; set; }
    }
}