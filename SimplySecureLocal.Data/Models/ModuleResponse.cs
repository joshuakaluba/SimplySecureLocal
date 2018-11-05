﻿using Newtonsoft.Json;

namespace SimplySecureLocal.Data.Models
{
    public class ModuleResponse
    {
        public static readonly string AlarmFlag = "ALARM_FLAG";

        public ModuleResponse()
        {
        }

        public ModuleResponse(bool triggered, bool armed)
        {
            Triggered = triggered;
        }

        [JsonProperty("triggered")]
        public bool Triggered { get; set; }

        [JsonProperty("armed")]
        public bool Armed { get; set; }

        public string Action => Triggered ? ModuleResponse.AlarmFlag : "";
    }
}