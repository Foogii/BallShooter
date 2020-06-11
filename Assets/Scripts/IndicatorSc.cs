using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorSc : MonoBehaviour
{
    public GameObject[] indicators;

    ShopManager shopSc;
    GameObject shopObj;

    private void Start()
    {
        shopObj = GameObject.Find("ShopManager");
        shopSc = (ShopManager)shopObj.GetComponent<ShopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "BallDropRate")
            TurnOnIndicator(shopSc.ballDropRate);

        if (gameObject.tag == "CoinDropRate")
            TurnOnIndicator(shopSc.coinDropRate);

        if (gameObject.tag == "eCoinDropRate")
            TurnOnIndicator(shopSc.eCoinDropRate);

        if (gameObject.tag == "BallDamageMultiplier")
            TurnOnDamageInd(shopSc.ballDamage);

        if (gameObject.tag == "ScoreMultiplier")
            TurnOnIndicator(shopSc.scoreMultiplier);

        if (gameObject.tag == "BouncyBlocks")
            TurnOnBouncyBlock(shopSc.isBouncy);
    }

    void TurnOnIndicator(float num)
    {
        if (num >= 1.25f)
        {
            indicators[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOn");
        }

        if (num >= 1.5f)
        {
            indicators[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOn");
        }

        if (num >= 1.75f)
        {
            indicators[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOn");
        }

        if (num >= 2f)
        {
            indicators[3].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOn");
        }
    }

    void TurnOnDamageInd(int num)
    {
        if(num > 1)
        {
            indicators[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOn");
        }
    }

    void TurnOnBouncyBlock(bool bounce)
    {
        if (bounce)
        {
            indicators[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOn");
        }
        else
        {
            indicators[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOff");
        }
    }
}
