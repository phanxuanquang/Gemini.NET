﻿using Newtonsoft.Json;

namespace GeminiDotNET.ApiModels.Response.Success.FunctionCalling
{
    public class FunctionCall
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("args")]
        public object? Args;
    }
}
