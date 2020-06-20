using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject ballIncreasePrefab;
    public GameObject coinPrefab;
    public GameObject ECoinPrefab;

    public ShopManager shopSc;
    GameObject shopObj;

    private void Awake()
    {
        float getAspect;

        getAspect = (float)Screen.width / (float)Screen.height;
        if (getAspect == (9 / 16))
        {
            gameObject.transform.localScale = new Vector2(4.6f, 4.6f);
        }
        else if (getAspect == (9 / 19))
        {
            gameObject.transform.localScale = new Vector2(3.8f, 3.8f);
        }
    }

    void Start()
    {
        BoxObject.spawnersChecked = 0;
    }

    public void spawner()
    {
        float checkSpawn;
        GameObject littleBox;

        checkSpawn = Random.Range(0f, 3.5f);

        if(checkSpawn <= 1f) //Spawns box
        {
            littleBox = Instantiate(boxPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            checkSpawn = Random.Range(0f, 10f);

            if(checkSpawn / shopSc.ballDropRate <= 1f) //Spawns ballIncrease Object
            {
                Instantiate(ballIncreasePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                checkSpawn = Random.Range(0f, 15f);

                if (checkSpawn / shopSc.coinDropRate <= 1f) //Spawns Coins (gold)
                {
                    Instantiate(coinPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    checkSpawn = Random.Range(0f, 50f); //Spawns e-Coins (pink)

                    if (checkSpawn / shopSc.eCoinDropRate <= 1f)
                    {
                        Instantiate(ECoinPrefab, transform.position, Quaternion.identity);
                    }
                }
            }
        }
        BoxObject.spawnersChecked++;
    }

}
