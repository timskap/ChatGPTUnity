using Newtonsoft.Json;

namespace ChatGPT
{
    public class ChatGPTResponse
    {
        public string id;
        [JsonProperty("object")] public string responseObject;
        public int created;
        public string model;
        public Choice[] choices;
        public Usage usage;

        public class Choice
        {
            public string text;
            public int index;
            public object logprobs;
            public string finish_reason;
        }

        public class Usage
        {
            public int prompt_tokens;
            public int completion_tokens;
            public int total_tokens;
        }
    }
}