using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePanelControl : MonoBehaviour
{
    [SerializeField]
    private GameObject coverPanel;
    [SerializeField]
    private GameObject[] chatButtons;
    //both of these are length of chatButtons
    private bool[] chatButtonVisible;
    private bool[] chatButtonNewMessage;
    private float[] topOfCoverPanel;
    private float[] bottomOfCoverPanel;

    private float posXOfChatButtonOn = 0.50002f;
    private float posXOfChatButtonOff = -271.4999f;

    private float widthOfCoverPanelOn = 544f;
    private float widthOfCoverPanelOff = 0f;

    public static int gameState = 0;


    void Start()
    {
        topOfCoverPanel[0] = -1.522526f;
        topOfCoverPanel[1] = 134f;
        bottomOfCoverPanel[0] = 1f;
        bottomOfCoverPanel[1] = 0.04997257f;

        for(int i = 0; i < chatButtons.Length; i++)
        {
            chatButtonVisible[i] = false;
            chatButtonNewMessage[i] = false;
        }
        StartCoroutine(moveDownPanel(0, 1));
    }

    private IEnumerator moveDownPanel(int firstPoint, int secondPoint)
    {
        float timer = 0;
        while (timer < 1)
        {
            
            timer = timer + .001f;
            yield return null;
        }
        yield return null;
    } 

}
