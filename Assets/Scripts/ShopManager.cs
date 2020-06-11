using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject menuShop;
    public GameObject blocksPrefab;

    public Transform pos1;
    public Transform pos2;
    public LayerMask whatIsBox;

    public float ballDropRate = 1f;
    public float coinDropRate = 1f;
    public float eCoinDropRate = 1f;
    public int ballDamage = 1;
    public float scoreMultiplier = 1f;
    public bool isBouncy = false;

    GameManager gm;
    GameObject gameM;
    private bool bouncyIsPurchased = false;

    private int eCoins;

    // Start is called before the first frame update
    void Start()
    {
        eCoins = PlayerPrefs.GetInt("eCoins");

        gameM = GameObject.Find("GameManager");
        gm = (GameManager)gameM.GetComponent<GameManager>();

        if (PlayerPrefs.GetInt("Round") > 1)
        {
            ballDropRate = PlayerPrefs.GetFloat("BallDropRate");
            coinDropRate = PlayerPrefs.GetFloat("CoinDropRate");
            eCoinDropRate = PlayerPrefs.GetFloat("eCoinDropRate");
            ballDamage = PlayerPrefs.GetInt("BallDamage");
            scoreMultiplier = PlayerPrefs.GetFloat("ScoreMultiplier");

            if(PlayerPrefs.GetString("IsBouncy") == "IsBouncy")
            {
                isBouncy = true;
            }
            else
            {
                isBouncy = false;
            }

            if(PlayerPrefs.GetString("bouncyIsPurchased") != "True")
            {
                bouncyIsPurchased = false;
            }
            else
            {
                bouncyIsPurchased = true;
            }

        }
        else
        {
            ballDropRate = 1f;
            coinDropRate = 1f;
            eCoinDropRate = 1f;
            ballDamage = 1;
            scoreMultiplier = 1f;
            isBouncy = false;


            PlayerPrefs.SetFloat("BallDropRate", ballDropRate);
            PlayerPrefs.SetFloat("CoinDropRate", coinDropRate);
            PlayerPrefs.SetFloat("eCoinDropRate", eCoinDropRate);
            PlayerPrefs.SetInt("BallDamage", ballDamage);
            PlayerPrefs.SetFloat("ScoreMultiplier", scoreMultiplier);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseBallDropRate() //Can be increased 4 times
    {
        if (ballDropRate < 2f) //Costs: 8, 16, 24, 32
        {
            if(ballDropRate == 1f && gm.coinsNum >= 8)
            {
                gm.coinsNum -= 8;
                ballDropRate += 0.25f;
            }
            else if(ballDropRate == 1.25f && gm.coinsNum >= 16)
            {
                gm.coinsNum -= 16;
                ballDropRate += 0.25f;
            }
            else if (ballDropRate == 1.5f && gm.coinsNum >= 24)
            {
                gm.coinsNum -= 24;
                ballDropRate += 0.25f;
            }
            else if (ballDropRate == 1.75f && gm.coinsNum >= 32)
            {
                gm.coinsNum -= 32;
                ballDropRate += 0.25f;
            }

            PlayerPrefs.SetFloat("BallDropRate", ballDropRate);
        }

    }

    public void increaseCoinDropRate() //Can be increased 4 times
    {
        if (coinDropRate < 2f) //Costs: 8, 16, 24, 32
        {
            if (coinDropRate == 1f && gm.coinsNum >= 8)
            {
                gm.coinsNum -= 8;
                coinDropRate += 0.25f;
            }
            else if (coinDropRate == 1.25f && gm.coinsNum >= 16)
            {
                gm.coinsNum -= 16;
                coinDropRate += 0.25f;
            }
            else if (coinDropRate == 1.5f && gm.coinsNum >= 24)
            {
                gm.coinsNum -= 24;
                coinDropRate += 0.25f;
            }
            else if (coinDropRate == 1.75f && gm.coinsNum >= 32)
            {
                gm.coinsNum -= 32;
                coinDropRate += 0.25f;
            }

            PlayerPrefs.SetFloat("CoinDropRate", coinDropRate);
        }
    }

    public void increaseECoinDropRate() //Can be increased 4 times
    {
        if (eCoinDropRate < 2f) //Costs: 8, 16, 24, 32
        {
            if (eCoinDropRate == 1f && gm.coinsNum >= 8)
            {
                gm.coinsNum -= 8;
                eCoinDropRate += 0.25f;
            }
            else if (eCoinDropRate == 1.25f && gm.coinsNum >= 16)
            {
                gm.coinsNum -= 16;
                eCoinDropRate += 0.25f;
            }
            else if (eCoinDropRate == 1.5f && gm.coinsNum >= 24)
            {
                gm.coinsNum -= 24;
                eCoinDropRate += 0.25f;
            }
            else if (eCoinDropRate == 1.75f && gm.coinsNum >= 32)
            {
                gm.coinsNum -= 32;
                eCoinDropRate += 0.25f;
            }

            PlayerPrefs.SetFloat("eCoinDropRate", eCoinDropRate); //I'm an e-girl UwU
        }
    }

    public void increaseBallDamage() //Can be increased once
    {
        if (ballDamage < 2) //Costs: 30
        {
            if (ballDamage == 1 && gm.coinsNum >= 30)
            {
                gm.coinsNum -= 30;
                ballDamage++;
            }

            PlayerPrefs.SetInt("BallDamage", ballDamage);
        }
    }

    public void increaseScoreMultiplier() //Can be increased 4 times
    {
        if (scoreMultiplier < 2f) //Costs: 8, 16, 24, 32
        {
            if (scoreMultiplier == 1f && gm.coinsNum >= 8)
            {
                gm.coinsNum -= 8;
                scoreMultiplier += 0.25f;
            }
            else if (scoreMultiplier == 1.25f && gm.coinsNum >= 16)
            {
                gm.coinsNum -= 16;
                scoreMultiplier += 0.25f;
            }
            else if (scoreMultiplier == 1.5f && gm.coinsNum >= 24)
            {
                gm.coinsNum -= 24;
                scoreMultiplier += 0.25f;
            }
            else if (scoreMultiplier == 1.75f && gm.coinsNum >= 32)
            {
                gm.coinsNum -= 32;
                scoreMultiplier += 0.25f;
            }

            PlayerPrefs.SetFloat("ScoreMultiplier", scoreMultiplier);
        }
    }

    public void setBouncyBlocks()
    {
        if(!bouncyIsPurchased && gm.coinsNum >= 15)
        {
            gm.coinsNum -= 25;
            bouncyIsPurchased = true;
            PlayerPrefs.SetString("bouncyIsPurchased", "True");
        }

        if (bouncyIsPurchased)
        {
            Collider2D[] boxes = Physics2D.OverlapAreaAll(pos1.position, pos2.position, whatIsBox);

            if (blocksPrefab.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
            {
                blocksPrefab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                for (int i = 0; i < boxes.Length; i++)
                    boxes[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                isBouncy = false;
                PlayerPrefs.SetString("IsBouncy", "IsNotBouncy");
            }
            else
            {
                blocksPrefab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                for (int i = 0; i < boxes.Length; i++)
                    boxes[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                isBouncy = true;
                PlayerPrefs.SetString("IsBouncy", "IsBouncy");
            }
        }
           
    }

    public void OpenMenuShop()
    {
        if(!menuShop.activeInHierarchy)
            menuShop.SetActive(true);
        else
            menuShop.SetActive(false);
    }
    public void CloseMenuShop()
    {
        menuShop.SetActive(false);
    }

    ///////////////////// Main Menu Shop Section //////////////////////////////////////////

    public void unlockSkin(Button button)
    {
        Debug.Log(eCoins);
        if(eCoins >= 25)
        {
            button.gameObject.SetActive(false);
            eCoins -= 25;
            PlayerPrefs.SetInt("eCoins", eCoins);
        }
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
}
