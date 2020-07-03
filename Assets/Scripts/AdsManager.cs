using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public GameManager gm;

    string GooglePlayID = "3669343";
    bool testMode = true;

    public string myPlacementId = "rewardedVideo";
    public string whatButton;
    public LayerMask whatIsBox;

    void Awake()
    {
        GameObject[] adsManager = GameObject.FindGameObjectsWithTag("ads");
        if (adsManager.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlayID, testMode);
    }

    public void DisplayVidAd(Button button)
    {
        Advertisement.Show(myPlacementId);
        whatButton = button.name;
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (whatButton == "EarnMoreBalls")
            {
                PlayerController.numberOfBalls += 3;
                PlayerPrefs.SetInt("NumOfBalls", PlayerController.numberOfBalls);
                Debug.Log("You got a reward!");
                Debug.Log(PlayerController.numberOfBalls);
            }
            else if (whatButton == "EarnMoreGoldCoins")
            {
                gm.eCoinsNum += Random.Range(2, 4);
                PlayerPrefs.SetInt("eCoins", gm.eCoinsNum);
                Debug.Log("You got a reward!");
            }
            else if (whatButton == "ContinuePlaying")
            {
                GameObject overlayObj;
                GameObject overlayObj2;
                overlayObj = GameObject.Find("OverlayCorner3");
                overlayObj2 = GameObject.Find("OverlayCorner4");

                Collider2D[] boxes = Physics2D.OverlapAreaAll(overlayObj.transform.position, overlayObj2.transform.position, whatIsBox);

                Debug.Log(boxes.Length);

                for (int i = 0; i < boxes.Length; i++)
                {
                    Destroy(boxes[i].gameObject);
                }

                gm.gameContinued = true;
                Debug.Log("You got a reward!");
            }
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            Debug.Log("You did not get a reward!");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}
