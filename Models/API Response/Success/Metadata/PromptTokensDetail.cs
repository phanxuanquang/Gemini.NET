﻿using Newtonsoft.Json;

namespace Models.API_Response
{
    public class PromptTokensDetail
    {
        [JsonProperty("modality")]
        public string Modality { get; set; }

        [JsonProperty("tokenCount")]
        public int? TokenCount { get; set; }
    }
}
