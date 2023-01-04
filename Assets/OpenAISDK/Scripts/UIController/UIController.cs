using System;
using ChatGPT;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private int tokens = 16;
    [SerializeField] private string chatModel = "text-davinci-003";
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button sendMessage;

    void Start()
    {
        sendMessage.onClick.AddListener(SendMessage);
        ChatGPTApi.OnMessageReceived += ResultAction;
    }

    private void ResultAction(ChatGPTResponse resultMessage)
    {
        string messageText = String.Empty;
        foreach (var choice in resultMessage.choices)
        {
            messageText += $"{choice.text}\n";
        }
        resultText.text = messageText;
    }

    private void SendMessage()
    {
        var message = new ChatGPTRequest()
        {
            model = chatModel,
            max_tokens = tokens,
            prompt = inputField.text,
            temperature = 0
        };
        ChatGPTApi.SendChatRequest(message);
    }
}
