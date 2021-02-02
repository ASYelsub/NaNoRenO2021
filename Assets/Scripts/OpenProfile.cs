using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This script has the function that opens the profiles for the characters when on the "profiles" page.
public class OpenProfile : MonoBehaviour{

    [Header("Tuning Variables")]
    [SerializeField]
    private float profileMoveSpeed; //I'd keep it around .5

    [SerializeField]
    private AudioClip profilePressSound;
    private AudioSource aSource;


    [SerializeField]
    private GameObject[] profilePanel;
    [SerializeField]
    private GameObject[] profileImage;
    [SerializeField]
    private GameObject[] profileText;


    private GameObject[] nonClickedProfileImages = new GameObject[2];
    private GameObject[] nonClickedProfileText = new GameObject[2];
    private GameObject[] nonClickedPanel = new GameObject[2];

    private Vector2 initialSize;
    private Vector2 finalSize;

    private Vector3 finalPos;
    private Vector3 initialPos;

    private float increment;
    bool profileHasBeenOpened = false;

    bool profileAnimating;
    private void Start()
    {
        aSource = gameObject.GetComponent<AudioSource>();
        profileAnimating = false;
    }

    //profileID Eve: 0, Zephyr: 1, Charlemagne: 2
    public void OpenAProfile(int profileID){
        if (!profileAnimating)
        {
            aSource.PlayOneShot(profilePressSound);
            profileAnimating = true;
            switch (profileID)
            {
                case 0:
                    OpenEve();
                    break;
                case 1:
                    OpenZephyr();
                    break;
                case 2:
                    OpenCharlemagne();
                    break;
            }
        }
    }

    void OpenEve(){
        
        nonClickedProfileImages[0] = profileImage[1]; 
        nonClickedProfileImages[1] = profileImage[2];

        nonClickedProfileText[0] = profileText[1];
        nonClickedProfileText[1] = profileText[2];

        nonClickedPanel[0] = profilePanel[1];
        nonClickedPanel[1] = profilePanel[2];

        if (!profileHasBeenOpened)
            StartCoroutine(FadeOthers(0, false));
        else
            StartCoroutine(ExpandProfile(0,true));
    }

    void OpenZephyr(){

        nonClickedProfileImages[0] = profileImage[0];
        nonClickedProfileImages[1] = profileImage[2];

        nonClickedProfileText[0] = profileText[0];
        nonClickedProfileText[1] = profileText[2];

        nonClickedPanel[0] = profilePanel[0];
        nonClickedPanel[1] = profilePanel[2];

        if (!profileHasBeenOpened)
            StartCoroutine(FadeOthers(1, false));
        else
           StartCoroutine(ExpandProfile(1,true));

    }

    void OpenCharlemagne(){

        nonClickedProfileImages[0] = profileImage[0];
        nonClickedProfileImages[1] = profileImage[1];

        nonClickedProfileText[0] = profileText[0];
        nonClickedProfileText[1] = profileText[1];

        nonClickedPanel[0] = profilePanel[0];
        nonClickedPanel[1] = profilePanel[1];

        if (!profileHasBeenOpened)
            StartCoroutine(FadeOthers(2, false));
        else
            StartCoroutine(ExpandProfile(2, true));
    }

    private IEnumerator FadeOthers(int profileIDClicked, bool inverse)
    {
        profileHasBeenOpened = true;
        //yield return new WaitForSeconds(1f);

        float timer = 0;
        Color c = new Color(profilePanel[profileIDClicked].GetComponent<Image>().color.r,
                            profilePanel[profileIDClicked].GetComponent<Image>().color.g,
                            profilePanel[profileIDClicked].GetComponent<Image>().color.b,
                            0);


        Color imageC = new Color(profileImage[profileIDClicked].GetComponent<Image>().color.r,
                                 profileImage[profileIDClicked].GetComponent<Image>().color.g,
                                 profileImage[profileIDClicked].GetComponent<Image>().color.b,
                                 0);

        Color textC = new Color(profileText[profileIDClicked].GetComponent<Text>().color.r,
                                profileText[profileIDClicked].GetComponent<Text>().color.g,
                                profileText[profileIDClicked].GetComponent<Text>().color.b,
                                0);


        float alpha;

        while (timer < 1)
        {
            if (!inverse)
                alpha = Mathf.Lerp(1, 0, timer);
            else
                alpha = Mathf.Lerp(0, 1, timer);
            
            c.a = alpha;
            imageC.a = alpha;
            textC.a = alpha;
            timer = timer + .01f;
            nonClickedPanel[0].GetComponent<Image>().color = c;
            nonClickedPanel[1].GetComponent<Image>().color = c;
            nonClickedProfileImages[0].GetComponent<Image>().color = imageC;
            nonClickedProfileImages[1].GetComponent<Image>().color = imageC;
            nonClickedProfileText[0].GetComponent<Text>().color = textC;
            nonClickedProfileText[1].GetComponent<Text>().color = textC;
            yield return null;
        }

        if (!inverse)
        {
            StartCoroutine(MoveSelected(profileIDClicked, false));
        }
        else
        {
            profileHasBeenOpened = false;
            profileAnimating = false;
        }
            
        yield return null;
    }

    private IEnumerator MoveSelected(int profileIDClicked, bool inverse)
    {
        RectTransform finalTransform = profilePanel[0].GetComponent<RectTransform>();
        RectTransform initialTransform = profilePanel[profileIDClicked].GetComponent<RectTransform>();
        if (!inverse)
        {
            finalPos = new Vector3(finalTransform.localPosition.x, finalTransform.localPosition.y, finalTransform.localPosition.z);
            initialPos = new Vector3(initialTransform.localPosition.x, initialTransform.localPosition.y, initialTransform.localPosition.z);
        }
        


        if (profileIDClicked != 0)
        {
            increment = Mathf.Abs(finalPos.y / initialPos.y);
            Debug.Log(increment);
            float timer = 0;
            while (timer < 1)
            {

                if (!inverse)
                    profilePanel[profileIDClicked].GetComponent<RectTransform>().localPosition = Vector3.Lerp(initialPos, finalPos, timer);
                else
                    profilePanel[profileIDClicked].GetComponent<RectTransform>().localPosition = Vector3.Lerp(finalPos, initialPos, timer);
                timer += Time.deltaTime * increment * profileMoveSpeed;
                yield return null;
            }
        }
        

        if (!inverse)
            StartCoroutine(ExpandProfile(profileIDClicked, false));
        else
            StartCoroutine(FadeOthers(profileIDClicked, true));
        yield return null;
    }

    private IEnumerator ExpandProfile(int profileIDClicked, bool inverse)
    {
        RectTransform initialTransform = profilePanel[0].GetComponent<RectTransform>();
        if (!inverse)
        {
            initialSize = new Vector2(initialTransform.sizeDelta.x, initialTransform.sizeDelta.y);
            finalSize = new Vector2(initialSize.x, initialSize.y + (830 - 265));
        }
        float timer = 0;
        while (timer < 1)
        {
            if(!inverse)
                profilePanel[profileIDClicked].GetComponent<RectTransform>().sizeDelta = Vector3.Lerp(initialSize, finalSize, timer);
            else
                profilePanel[profileIDClicked].GetComponent<RectTransform>().sizeDelta = Vector3.Lerp(finalSize, initialSize, timer);
            timer += 0.01f;
            yield return null;
        }
        if (inverse)
            StartCoroutine(MoveSelected(profileIDClicked, true));
        else
            profileAnimating = false;

        yield return null;
    }

}
