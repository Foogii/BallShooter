using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eShopManager : MonoBehaviour
{
    private int goldCoins;

    public GameObject menuShop;
    public GameObject[] Locks;
    public GameObject[] selectedBorder;

    public Image shopImage;
    Button lockedButton;

    // Start is called before the first frame update
    void Start()
    {
        checkSkinUnlocks();
    }

    // Update is called once per frame
    void Update()
    {
        if(menuShop)
        {
            selectedBorder[0].transform.position = new Vector2(PlayerPrefs.GetFloat("CharBorderX"), PlayerPrefs.GetFloat("CharBorderY")); //This will get the saved border position, and set it where it needs to be
            selectedBorder[1].transform.position = new Vector2(PlayerPrefs.GetFloat("BallBorderX"), PlayerPrefs.GetFloat("BallBorderY"));
            selectedBorder[2].transform.position = new Vector2(PlayerPrefs.GetFloat("BlockBorderX"), PlayerPrefs.GetFloat("BlockBorderY"));
            selectedBorder[3].transform.position = new Vector2(PlayerPrefs.GetFloat("BackBorderX"), PlayerPrefs.GetFloat("BackBorderY"));
        }
    }

    public void unlockSkin()
    {
        goldCoins = PlayerPrefs.GetInt("eCoins");
        if (goldCoins >= 25)
        {
            lockedButton.gameObject.SetActive(false);
            goldCoins -= 25;
            PlayerPrefs.SetInt("eCoins", goldCoins);
            PlayerPrefs.SetString(lockedButton.name, "unlocked");
        }
    }

    public void checkSkinUnlocks()
    {
        for (int i = 0; i < Locks.Length; i++)
        {
            if (PlayerPrefs.GetString(Locks[i].name) == "unlocked")
            {
                Locks[i].gameObject.SetActive(false);
            }
            else
            {
                Locks[i].gameObject.SetActive(true);
            }
        }

    }

    public void getSkinImage(Button image)
    {
        shopImage.sprite = image.image.sprite;     
    }

    public void getAssociatedLock(Button imageLock)
    {
        lockedButton = imageLock;
    }

    public void setBackground(Button button)
    {
        string background;
        background = button.image.sprite.name;
        PlayerPrefs.SetString("Background", background);
        Debug.Log(PlayerPrefs.GetString("Background"));

        selectedBorder[3].transform.position = button.gameObject.transform.position;
        PlayerPrefs.SetFloat("BackBorderX", selectedBorder[3].transform.position.x);
        PlayerPrefs.SetFloat("BackBorderY", selectedBorder[3].transform.position.y);
    }

    public void setBlock(Button button)
    {
        string block;
        block = button.image.sprite.name;
        PlayerPrefs.SetString("Block", block);
        Debug.Log(PlayerPrefs.GetString("Block"));

        selectedBorder[2].transform.position = button.gameObject.transform.position;
        PlayerPrefs.SetFloat("BlockBorderX", selectedBorder[2].transform.position.x);
        PlayerPrefs.SetFloat("BlockBorderY", selectedBorder[2].transform.position.y);
    }

    public void setBall(Button button)
    {
        string ball;
        ball = button.image.sprite.name;
        PlayerPrefs.SetString("Ball", ball);
        Debug.Log(PlayerPrefs.GetString("Ball"));

        selectedBorder[1].transform.position = button.gameObject.transform.position;
        PlayerPrefs.SetFloat("BallBorderX", selectedBorder[1].transform.position.x);
        PlayerPrefs.SetFloat("BallBorderY", selectedBorder[1].transform.position.y);
    }

    public void setCharacter(Button button)
    {
        string character;
        character = button.image.sprite.name;
        PlayerPrefs.SetString("Character", character);
        Debug.Log(PlayerPrefs.GetString("Character"));

        selectedBorder[0].transform.position = button.gameObject.transform.position;
        PlayerPrefs.SetFloat("CharBorderX", selectedBorder[0].transform.position.x);
        PlayerPrefs.SetFloat("CharBorderY", selectedBorder[0].transform.position.y);
    }

    public void OpenMenuShop()
    {
        if (!menuShop.activeInHierarchy)
            menuShop.SetActive(true);
        else
            menuShop.SetActive(false);
    }

    public void CloseMenuShop()
    {
        menuShop.SetActive(false);
    }
}
