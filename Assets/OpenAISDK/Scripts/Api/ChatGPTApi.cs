using System;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace ChatGPT
{
    public static class ChatGPTApi
    {
        private static string openAIUrl = "https://api.openai.com/v1/completions";
        private static string token = "TOKEN";
        public static Action<ChatGPTResponse> OnMessageReceived;

        public static void SendChatRequest(ChatGPTRequest chatRequest)
        {
            // Convert ChatGPTRequest object to JSON string
            string json = JsonConvert.SerializeObject(chatRequest);
            DownloadHandlerBuffer downloadHandler = new DownloadHandlerBuffer();

            // Set up the request
            UnityWebRequest request = new UnityWebRequest(openAIUrl, UnityWebRequest.kHttpVerbPOST);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + token);
            request.downloadHandler = downloadHandler;
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);

            // Send the request
            request.SendWebRequest().completed += (AsyncOperation obj) =>
            {
                Debug.Log($"{request.downloadProgress}");
                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.LogError(request.error);
                }
                if (obj.isDone && request.isDone)
                {
                    string result = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);
                    Debug.Log($"Received: {result}");
                    ChatGPTResponse chatGPTResponse = JsonConvert.DeserializeObject<ChatGPTResponse>(result);
                    OnMessageReceived.Invoke(chatGPTResponse);
                }
            };
        }
    }
}
