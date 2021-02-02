using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidePanelControl : MonoBehaviour
{
    [Header("Tuning Variables")]
    [SerializeField]
    private float typeSpeed;//originally 0.125f, lower is faster
    [SerializeField]
    private float coverPanelSpeed; //originally 0.01f, higher is faster
    [SerializeField]
    private float leftChatSpeed; //originally 0.01f, higher is faster
    [SerializeField]
    private AudioClip[] typeBeep;


    private AudioSource audioSource;

    [SerializeField]
    private GameObject[] leftChatButton;
    [SerializeField]
    private GameObject coverPanel;
    int leftChatState;
    RectTransform rt;

   
    private bool chatIsOpening;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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
            timer2 = timer2 + coverPanelSpeed * Time.deltaTime;
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
            timer = timer + leftChatSpeed * Time.deltaTime;
            yield return null;
        }
        StartCoroutine(TypeWrite(savedText, activeText));
        leftChatState++;
        chatIsOpening = false;
        //activeText.text = savedText;
        yield return null;
    }

    private IEnumerator TypeWrite(string typeString, Text placeToType)
    {
        //int random = 0;
        foreach(char c in typeString)
        {
            /* It ended up sounding more how I wanted without multiple sounds.*/
            //random = Random.Range(0, typeBeep.Length - 1);
            placeToType.text += c;
            //audioSource.PlayOneShot(typeBeep[random]);
            audioSource.PlayOneShot(typeBeep[1]);            
            yield return new WaitForSeconds(typeSpeed);
        }
        yield return null;
    }
}
