using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    private ChatGenerator chatGenerator;

    [Header("For Chats")]
    public Sprite[] characterProfile;
    public GameObject messagePrefab;

    private void Awake()
    {
        chatGenerator = new ChatGenerator(0);
        chatGenerator.GenerateChat("02", "00");
    }
}
