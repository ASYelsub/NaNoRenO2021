using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidePanelControl : MonoBehaviour
{

    [SerializeField]
    private GameObject[] leftChatButton;
    [SerializeField]
    private GameObject coverPanel;
    int leftChatState;
    RectTransform rt;

   
    private bool chatIsOpening;
    private void Start()
    {
        chatIsOpening = false;
        leftChatState = 0;
        for (int i = 0; i < leftChatButton.Length; i++)
        {
            leftChatButton[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(leftChatState < leftChatButton.Length && !chatIsOpening)
            StartCoroutine(addLeftChat(leftChatState));
        }
    }

    private IEnumerator addLeftChat(int activatingThis)
    {
        chatIsOpening = true;
        
        float timer2 = 0;
        RectTransform rt2 = coverPanel.GetComponent<RectTransform>();
        Vector2 size2 = new Vector2(rt2.sizeDelta.x, rt2.sizeDelta.y);


        while (timer2 < 1)
        {
            if (activatingThis == 0)
            {
                coverPanel.GetComponent<RectTransform>().sizeDelta = Vector3.Lerp(size2, new Vector2(size2.x, size2.y - 140), timer2);
            }
            else
            {
                coverPanel.GetComponent<RectTransform>().sizeDelta = Vector3.Lerp(size2, new Vector2(size2.x, size2.y - 80), timer2);
            }
            timer2 = timer2 + .01f;
            yield return null;
        }


        leftChatButton[activatingThis].SetActive(true);
        float timer = 0;
        rt = leftChatButton[activatingThis].GetComponent<RectTransform>();
        Vector2 size = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y);



        Text activeText = rt.gameObject.GetComponentInChildren<Text>();
        string savedText = activeText.text;
        activeText.text = "";

        while (timer < 1)
        {
            // TODO: come back to figuring out how to expand from left
            leftChatButton[activatingThis].GetComponent<RectTransform>().sizeDelta = Vector3.Lerp(new Vector2(0,rt.sizeDelta.y),size, timer);
            timer = timer + .01f;
            yield return null;
        }

        leftChatState++;
        chatIsOpening = false;
        activeText.text = savedText;
        yield return null;
    }
}
