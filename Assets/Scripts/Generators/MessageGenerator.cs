using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MessageGenerator
{
    private Chat designatedChat; //the chat which these messages are added to
    public MessageGenerator(Chat designatedChat)
    {
        this.designatedChat = designatedChat;
        Debug.Log("4: MessageGenerator created for " + designatedChat.ChatID + ".");
    }

    public void GenerateMessageInPreChat()
    {
        Message message1 = new Message(1, "HELLO", 1, false);
        this.designatedChat.MessagesInPreChat.Enqueue(message1);
    }
   
}
