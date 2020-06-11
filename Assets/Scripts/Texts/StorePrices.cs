using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePrices : MonoBehaviour
{
    ShopManager shopSc;
    GameObject shopObj;

    Text price;

    // Start is called before the first frame update
    void Start()
    {
        price = GetComponent<Text>();

        shopObj = GameObject.Find("ShopManager");
        shopSc = (ShopManager)shopObj.GetComponent<ShopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "BallDropRate")
            DetermineBasePrice(shopSc.ballDropRate);

        if (gameObject.tag == "CoinDropRate")
            DetermineBasePrice(shopSc.coinDropRate);

        if (gameObject.tag == "eCoinDropRate")
            DetermineBasePrice(shopSc.eCoinDropRate);

        if (gameObject.tag == "BallDamageMultiplier")
            DetermineDamagePrice(shopSc.ballDamage);

        if (gameObject.tag == "ScoreMultiplier")
            DetermineBasePrice(shopSc.scoreMultiplier);

        //if (gameObject.tag == "BouncyBlocks")
        //    DeterminePrice(shopSc.isBouncy);
    }


    void DetermineBasePrice(float num)
    {
        if (num >= 1f)
        {
            price.text = " : 8";
        }

        if (num >= 1.25f)
        {
            price.text = " : 16";
        }

        if (num >= 1.5f)
        {
            price.text = " : 24";
        }

        if (num >= 1.75f)
        {
            price.text = " : 32";
        }

        if(num >= 2f)
        {
            price.text = "Maxed";
        }
    }

    void DetermineDamagePrice(int num)
    {
        if (num == 1)
        {
            price.text = " : 30";
        }
        else
        {
            price.text = "Maxed";
        }
    }

    //void DetermineBouncyPrice(bool bounce)
    //{
    //    if (bounce)
    //    {
    //        indicators[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOn");
    //    }
    //    else
    //    {
    //        indicators[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("ShopBoxOff");
    //    }
    //}

}
