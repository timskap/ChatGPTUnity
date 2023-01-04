# ChatGPTUnity

This Unity script allows you to send chat requests to OpenAI's GPT-3 API and receive responses. It is composed of a single static class, `ChatGPTApi`, which has the following features:

- A `SendChatRequest` function that sends a chat request to the GPT-3 API and invokes a callback with the response.
- An `OnMessageReceived` action that you can subscribe to in order to receive chat responses.
- A `token` field that you should set to your OpenAI API key in order to authenticate your requests.

## Usage

To use the `ChatGPTApi` class, you will need to do the following:

1. Obtain an API key from [here](https://beta.openai.com/account/api-keys).
2. Set the `token` field to your API key: private static string token = "TOKEN";
3. Subscribe to the `OnMessageReceived` action in order to receive chat responses:

ChatGPTApi.OnMessageReceived += OnMessageReceived;

void OnMessageReceived(ChatGPTResponse chatResponse)
{
// Handle the chat response here
}
Certainly! Here is the documentation text as a Markdown source:

# ChatGPTUnity

This Unity script allows you to send chat requests to OpenAI's GPT-3 API and receive responses. It is composed of a single static class, `ChatGPTApi`, which has the following features:

- A `SendChatRequest` function that sends a chat request to the GPT-3 API and invokes a callback with the response.
- An `OnMessageReceived` action that you can subscribe to in order to receive chat responses.
- A `token` field that you should set to your OpenAI API key in order to authenticate your requests.

## Usage

To use the `ChatGPTApi` class, you will need to do the following:

1. Obtain an API key from [here](https://beta.openai.com/account/api-keys).
2. Set the `token` field to your API key:

private static string token = "TOKEN";


3. Subscribe to the `OnMessageReceived` action in order to receive chat responses:

ChatGPTApi.OnMessageReceived += OnMessageReceived;

void OnMessageReceived(ChatGPTResponse chatResponse)
{
// Handle the chat response here
}


4. Create a `ChatGPTRequest` object and send it to the GPT-3 API using the `SendChatRequest` function:

ChatGPTRequest chatRequest = new ChatGPTRequest
{
prompt = "Hello, how are you?",
max_tokens = 1024
};

ChatGPTApi.SendChatRequest(chatRequest);

## Notes

- The `SendChatRequest` function sends a POST request to the OpenAI API and expects a JSON response.
- The `ChatGPTRequest` and `ChatGPTResponse` objects are serialized and deserialized using Newtonsoft.Json. You will need to have the Newtonsoft.Json package installed in your Unity project in order to use this script.
- The `SendChatRequest` function uses Unity's `UnityWebRequest` class to send the request and receive the response. It is asynchronous and invokes a callback when the request is completed.

