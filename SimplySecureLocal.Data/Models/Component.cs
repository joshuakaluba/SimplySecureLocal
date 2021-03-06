﻿using Newtonsoft.Json;
using System;

namespace SimplySecureLocal.Data.Models
{
    public abstract class Component : Auditable
    {
        [JsonProperty("moduleId")]
        public Guid ModuleId { get; set; }

        [JsonProperty("state")]
        public bool State { get; set; }
    }
}