using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoldCoinTimer : MonoBehaviour
{
    [SerializeField]
    GameObject shopGO;
    public static float goldCoinTimer;
    Button button;
    Image Shop;

    void Awake()
    {
        GameObject[] goldCoinTimer = GameObject.FindGameObjectsWithTag("coinTimer");
        if (goldCoinTimer.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(shopGO.activeInHierarchy == true)
        {
            button = GetComponent<Button>();
            button = GameObject.Find("EarnMoreGoldCoins").GetComponent<Button>();
        }

        if (!PlayerPrefs.HasKey("coinTimer"))
        {
            goldCoinTimer = 0f; //Set to 300 for 5 min timer
        }
        else
        {
            goldCoinTimer = PlayerPrefs.GetFloat("coinTimer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Main Menu")
        {
            if (shopGO.activeInHierarchy == true)
            {
                if (button == null)
                {
                    button = GameObject.Find("EarnMoreGoldCoins").GetComponent<Button>();
                }
            }
        }

        if (goldCoinTimer >= 0)
        {
            goldCoinTimer -= Time.unscaledDeltaTime;
            PlayerPrefs.SetFloat("coinTimer", goldCoinTimer);

            if (scene.name == "Main Menu")
            {
                if (shopGO.activeInHierarchy == false)
                {
                    button.interactable = false;
                }
            }
        }
        else
        {           
            if (scene.name == "Main Menu")
            {
                if (shopGO.activeInHierarchy == true)
                {
                    button.interactable = true;
                }
            }            
        }
    }
}
