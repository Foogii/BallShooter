using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eShopManager : MonoBehaviour
{
    private int goldCoins;

    public GameObject menuShop;
    public GameObject[] Locks;

    public Image shopImage;

    // Start is called before the first frame update
    void Start()
    {
        checkSkinUnlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlockSkin(Button button)
    {
        goldCoins = PlayerPrefs.GetInt("eCoins");
        Debug.Log(goldCoins);
        if (goldCoins >= 25)
        {
            button.gameObject.SetActive(false);
            goldCoins -= 25;
            PlayerPrefs.SetInt("eCoins", goldCoins);
            PlayerPrefs.SetString(button.name, "unlocked");
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

    public void getSkinImage(Button image, Button imageLock)
    {
        shopImage.sprite = image.image.sprite;
    }

    public void setBackground(Button button)
    {
        string background;
        background = button.image.sprite.name;
        PlayerPrefs.SetString("Background", background);
        Debug.Log(PlayerPrefs.GetString("Background"));
    }

    public void setBlock(Button button)
    {
        string block;
        block = button.image.sprite.name;
        PlayerPrefs.SetString("Block", block);
        Debug.Log(PlayerPrefs.GetString("Block"));
    }

    public void setBall(Button button)
    {
        string ball;
        ball = button.image.sprite.name;
        PlayerPrefs.SetString("Ball", ball);
        Debug.Log(PlayerPrefs.GetString("Ball"));
    }

    public void setCharacter(Button button)
    {
        string character;
        character = button.image.sprite.name;
        PlayerPrefs.SetString("Character", character);
        Debug.Log(PlayerPrefs.GetString("Character"));
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
