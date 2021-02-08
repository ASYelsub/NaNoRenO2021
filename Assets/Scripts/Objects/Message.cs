using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    private string username;
    private string messageText;
    private int messageLineAmount;

    private bool hasBeenSent;
    private bool mostRecentMessage;
    private Vector2 positionOnScreen;

    private Sprite characterSprite;

    private GameSetup gameSetup;

    private GameObject messagePrefab;

    private Image messageProfilePic;
    private Text messageProfileName;
    private Text messageProfileText;




    public Message(int userID, string messageText, int messageLineAmount, bool hasBeenSent)
    {
        gameSetup = FindObjectOfType<GameSetup>();
        this.messagePrefab = gameSetup.messagePrefab;
        switch(userID)
        {
            case 0 :
                this.username = "keeperofFeederof";
                this.characterSprite = gameSetup.characterProfile[0];
                break;
            case 1 :
                this.username = "zman70";
                this.characterSprite = gameSetup.characterProfile[1];
                break;
            case 2 :
                this.username = "reach0000000000";
                this.characterSprite = gameSetup.characterProfile[2];
                break;
        }
        this.messageText = messageText;
        this.messageLineAmount = messageLineAmount;

        this.hasBeenSent = hasBeenSent;
        this.mostRecentMessage = true;

        Debug.Log("5: Message created: " + messageText);
    }


    /// <summary>
    /// Getters & Setters
    /// </summary>
    public string Username{
        get { return username; }
        set { username = value; }
    }
    public string MessageText{
        get { return messageText; }
        set { messageText = value; }
    }
    public int MessageLineAmount{
        get { return messageLineAmount; }
        set { messageLineAmount = value; }
    }
}
