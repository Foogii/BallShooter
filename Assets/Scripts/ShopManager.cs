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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseBallDropRate()
    {
        if (ballDropRate < 2f)
        {
            ballDropRate += 0.25f;
        }
    }

    public void increaseCoinDropRate()
    {
        if (coinDropRate < 2f)
        {
            coinDropRate += 0.25f;
        }
    }

    public void increaseECoinDropRate()
    {
        if (eCoinDropRate < 2f)
        {
            eCoinDropRate += 0.25f;
        }
    }

    public void increaseBallDamage()
    {
        if (ballDamage < 2)
        {
            ballDamage++;
        }
    }

    public void increaseScoreMultiplier()
    {
        if (scoreMultiplier < 2f)
        {
            scoreMultiplier =+ 0.25f;
        }
    }

    public void setBackground(Button button)
    {
        string background;
        background = button.image.sprite.name;
        PlayerPrefs.SetString("Background", background);
        Debug.Log(PlayerPrefs.GetString("Background"));
    }

    public void setBouncyBlocks()
    {
        Collider2D[] boxes = Physics2D.OverlapAreaAll(pos1.position, pos2.position, whatIsBox);

        if (blocksPrefab.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
        {
            blocksPrefab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            for (int i = 0; i < boxes.Length; i++)
                boxes[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            blocksPrefab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            for (int i = 0; i < boxes.Length; i++)
                boxes[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
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

}
