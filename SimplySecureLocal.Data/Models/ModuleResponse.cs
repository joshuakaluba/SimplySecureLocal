using Newtonsoft.Json;

namespace SimplySecureLocal.Data.Models
{
    public class ModuleResponse
    {
        public static readonly string AlarmFlag = "ALARM_FLAG";
        
        public static readonly string NoActionFlag = "NO_ACTION";

        public ModuleResponse()
        {
        }

        public ModuleResponse(bool triggered, bool armed)
        {
            Triggered = triggered;

            Armed = armed;
        }

        [JsonProperty("triggered")]
        public bool Triggered { get; set; }

        [JsonProperty("armed")]
        public bool Armed { get; set; }

        [JsonProperty("action")]
        public string Action => Triggered ? ModuleResponse.AlarmFlag : ModuleResponse.NoActionFlag;
    }
}