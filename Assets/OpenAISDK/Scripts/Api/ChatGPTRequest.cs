using System;

namespace ChatGPT
{
    [Serializable]
    public class ChatGPTRequest
    {
        public string model;
        public string prompt;
        public int max_tokens;
        public int temperature;
    }
}