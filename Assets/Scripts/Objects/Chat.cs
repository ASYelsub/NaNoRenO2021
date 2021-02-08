using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{


    private string chatID; //Format:
                            //whichChatItShowsUpIn(leftlabel#)_submissionNumberFilledToShow
    private int showTime; //when the chat is showed depending on submissions
    private string showLocation; //where the chat is showed

    private int amountOfMessagesInChat;
    private Queue<Message> messagesInChat;
    private Queue<Message> messagesInPreChat; //before sent into chat
    private Message messageBeingTyped;
    private Message lastSentMessage;

    private bool chatTypingNotification;

    public Chat(string chatID, int showTime, string showLocation)
    {
        this.messagesInPreChat = new Queue<Message>();
        this.chatID = chatID;
        this.showTime = showTime;
        this.showLocation = showLocation;

        this.messageBeingTyped = null;
        Debug.Log("2: New chat " + chatID + " constructed.");

    }

    public void SendMessageToTyped()
    {
        this.messageBeingTyped = messagesInPreChat.Dequeue();
    }
    public void SendMessageToChat()
    {
        messagesInChat.Enqueue(messageBeingTyped);
    }

    public string ChatID{
        get { return chatID; }
        set { chatID = value; }
    }
    public Queue<Message> MessagesInPreChat{
        get { return messagesInPreChat; }
        set { messagesInPreChat = value; }
    }
}
