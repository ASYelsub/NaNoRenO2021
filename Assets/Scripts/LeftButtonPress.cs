using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeftButtonPress : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dataPanel;

    [SerializeField]
    private AudioClip buttonPressSound;

    private AudioSource asource;

    private void Start()
    {
        asource = gameObject.GetComponent<AudioSource>();
        for(int i = 0; i < dataPanel.Length; i++)
        {
            dataPanel[i].SetActive(false);
        }
    }
   
    public void PressPanel(int panelID)
    {
        for(int i = 0; i < dataPanel.Length; i++)
        {
            if (i != panelID)
                dataPanel[i].SetActive(false);
            else
                dataPanel[i].SetActive(true);
        }
        asource.PlayOneShot(buttonPressSound);
    }
}
