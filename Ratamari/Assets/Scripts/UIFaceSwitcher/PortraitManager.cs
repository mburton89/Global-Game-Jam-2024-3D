using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitManager : MonoBehaviour
{
    public static PortraitManager Instance;

    public List<GameObject> portraitSets = new List<GameObject>();
    
    public GameObject portraitHolder;
    public GameObject defaultSet;
    public GameObject defaultFace;
    public GameObject currentSet;
    public GameObject currentFace;
    public string currentFaceID;

    [HideInInspector] public bool importantFaceEvent;
    [HideInInspector] public bool thinkingFaceOn;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        importantFaceEvent = false;
        thinkingFaceOn = false;

        currentSet = defaultSet;
        currentFace = defaultFace;

        SetAllSetsToInactive();
        SetAllFacesToInactive();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    void RatFaceEventsHappened()
    {
        
    }

    public void CheckRatHatId(string hatId)
    {
        switch (hatId)
        {
            default:
            currentSet.SetActive(false);
            currentSet = portraitSets[0];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("miku"):
            currentSet.SetActive(false);
            currentSet = portraitSets[1];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("bass"):
            currentSet.SetActive(false);
            currentSet = portraitSets[2];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("chef"):
            currentSet.SetActive(false);
            currentSet = portraitSets[3];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("cone"):
            currentSet.SetActive(false);
            currentSet = portraitSets[4];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("dunce"):
            currentSet.SetActive(false);
            currentSet = portraitSets[5];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("fez"):
            currentSet.SetActive(false);
            currentSet = portraitSets[6];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("link"):
            currentSet.SetActive(false);
            currentSet = portraitSets[7];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("mario"):
            currentSet.SetActive(false);
            currentSet = portraitSets[8];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("mohawk"):
            currentSet.SetActive(false);
            currentSet = portraitSets[9];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("pikachu"):
            currentSet.SetActive(false);
            currentSet = portraitSets[10];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("pikmin"):
            currentSet.SetActive(false);
            currentSet = portraitSets[11];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("spinny"):
            currentSet.SetActive(false);
            currentSet = portraitSets[12];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("sonic"):
            currentSet.SetActive(false);
            currentSet = portraitSets[13];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("strawhat"):
            currentSet.SetActive(false);
            currentSet = portraitSets[14];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("supersaiyan"):
            currentSet.SetActive(false);
            currentSet = portraitSets[15];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("tophat"):
            currentSet.SetActive(false);
            currentSet = portraitSets[16];
            currentSet.SetActive(true);
            NeutralFace();
            break;
            case ("wizard"):
            currentSet.SetActive(false);
            currentSet = portraitSets[17];
            currentSet.SetActive(true);
            NeutralFace();
            break;
        }

    }

    public void GoingSlow()
    {
        currentFace.SetActive(false);
        currentFace = currentSet.transform.GetChild(1).gameObject;
        currentFace.SetActive(true);
    }

    public void GoingFast()
    {
        currentFace.SetActive(false);
        currentFace = currentSet.transform.GetChild(2).gameObject;
        currentFace.SetActive(true);
    }

    public void InAirFace()
    {
        importantFaceEvent = true;
        currentFace.SetActive(false);
        currentFace = currentSet.transform.GetChild(3).gameObject;
        currentFace.SetActive(true);
    }

    public void HitCarFace()
    {
        if (importantFaceEvent == false)
        {
            importantFaceEvent = true;
            currentFace.SetActive(false);
            currentFace = currentSet.transform.GetChild(4).gameObject;
            currentFace.SetActive(true);
            StartCoroutine(TurnOffBoolAfterDelay(0.5f));
        }
    }

    public void HitPersonFace()
    {
        if (importantFaceEvent == false)
        {
            importantFaceEvent = true;
            currentFace.SetActive(false);
            currentFace = currentSet.transform.GetChild(5).gameObject;
            currentFace.SetActive(true);
            StartCoroutine(TurnOffBoolAfterDelay(1.5f));
        }
    }

    public void HitRoadblockFace()
    {
        if (importantFaceEvent == false)
        {
            importantFaceEvent = true;
            currentFace.SetActive(false);
            currentFace = currentSet.transform.GetChild(6).gameObject;
            currentFace.SetActive(true);
            StartCoroutine(TurnOffBoolAfterDelay(0.5f));
        }
    }

    public void CollectCheeseFace()
    {
        if (importantFaceEvent == false)
        {
            importantFaceEvent = true;
            currentFace.SetActive(false);
            currentFace = currentSet.transform.GetChild(7).gameObject;
            currentFace.SetActive(true);
            StartCoroutine(TurnOffBoolAfterDelay(3f));
        }
    }

    public void ThinkingFace()
    {
        if (!thinkingFaceOn)
        {
            importantFaceEvent = true;
            currentFace.SetActive(false);
            currentFace = currentSet.transform.GetChild(8).gameObject;
            currentFace.SetActive(true);
            thinkingFaceOn = true;
        }
    }

    void SetAllSetsToInactive()
    {
        for (int i = 0; i < portraitHolder.transform.childCount; i++)
        {
            var child = portraitHolder.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }

    void SetAllFacesToInactive()
    {
        for (int i = 0; i < currentSet.transform.childCount; i++)
        {
            var child = currentSet.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }

    IEnumerator TurnOffBoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        importantFaceEvent = false;
    }

    public void NeutralFace()
    {
        currentFace.SetActive(false);
        currentFace = currentSet.transform.GetChild(0).gameObject;
        currentFace.SetActive(true);
    }

    public void SwitchPortrait(GameObject faceToSwapIn)
    {
        currentFace.SetActive(false);
        currentFace = faceToSwapIn;
        currentFace.SetActive(true);
    }
}