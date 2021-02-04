using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChatGenerator
{
    private List<Chat> allChats;
    private int chatGeneratorID;

    public ChatGenerator(int chatGeneratorID)
    {
        this.chatGeneratorID = chatGeneratorID;
        this.allChats = new List<Chat>();
        Debug.Log("1: New chat generator "+chatGeneratorID+" constructed.");
    }


    //Format for chatID:
    //whichChatItShowsUpIn(leftlabel#)_submissionNumberFilledToShow
    //Information = 00, Profiles = 01, etc.
    public void GenerateChat(string leftNumber, string submissionParam)
    {
        Chat newChat = new Chat(leftNumber + "_" + submissionParam, int.Parse(submissionParam), leftNumber); 

        allChats.Add(newChat);
        
        Debug.Log("3: Chat " + newChat.ChatID + " added to allChats at spot " + allChats.Count + ".");
        MessageGenerator messageGenerator = new MessageGenerator(newChat);
        messageGenerator.GenerateMessageInPreChat();

        //newChat.MessagesInPreChat.Enqueue(messageGenerator.MessagesInChat[messageGenerator.MessagesInChat.Count]);
    }

}
