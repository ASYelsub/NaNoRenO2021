using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    private ChatGenerator chatGenerator;
    private QuestionGenerator questionGenerator;


    [Header("For Chats")]
    public Sprite[] characterProfile;
    public GameObject messagePrefab;

    private void Awake()
    {
        chatGenerator = new ChatGenerator(0);
        questionGenerator = new QuestionGenerator(0);
        chatGenerator.GenerateChat("02", "00");
    }
}
