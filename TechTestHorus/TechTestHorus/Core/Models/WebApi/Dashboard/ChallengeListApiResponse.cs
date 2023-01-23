using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechTestHorus.Core.Models.WebApi.Dashboard
{
    public class ChallengeListApiResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currentPoints")]
        public int CurrentPoints { get; set; }

        [JsonProperty("totalPoints")]
        public int TotalPoints { get; set; }
    }
}
