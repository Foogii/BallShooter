using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject ballIncreasePrefab;
    public GameObject coinPrefab;
    public GameObject ECoinPrefab;

    ShopManager shopSc;
    GameObject shopObj;

    void Start()
    {
        BoxObject.spawnersChecked = 0;
        shopObj = GameObject.Find("ShopManager");
        shopSc = (ShopManager)shopObj.GetComponent<ShopManager>();
    }

    public void spawner()
    {
        float checkSpawn;
        GameObject littleBox;

        checkSpawn = Random.Range(0f, 3.5f);

        if(checkSpawn <= 1) //Spawns box
        {
            littleBox = Instantiate(boxPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            checkSpawn = Random.Range(0f, 10f);

            if(checkSpawn / shopSc.ballDropRate <= 1) //Spawns ballIncrease Object
            {
                Instantiate(ballIncreasePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                checkSpawn = Random.Range(0f, 15f);

                if (checkSpawn / shopSc.coinDropRate <= 1) //Spawns Coins (gold)
                {
                    Instantiate(coinPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    checkSpawn = Random.Range(0f, 50f); //Spawns e-Coins (pink)

                    if (checkSpawn / shopSc.eCoinDropRate <= 1)
                    {
                        Instantiate(ECoinPrefab, transform.position, Quaternion.identity);
                    }
                }
            }
        }
        BoxObject.spawnersChecked++;
    }

}
