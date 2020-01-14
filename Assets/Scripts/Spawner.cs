using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject ballIncreasePrefab;
    public GameObject coinPrefab;
    public GameObject ECoinPrefab;

    void Start()
    {
        BoxObject.spawnersChecked = 0;
    }

    public void spawner()
    {
        float checkSpawn;
        GameObject littleBox;

        checkSpawn = Random.Range(0f, 4f);

        if(checkSpawn <= 1)
        {
            littleBox = Instantiate(boxPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            checkSpawn = Random.Range(0f, 10f);

            if(checkSpawn <= 1)
            {
                Instantiate(ballIncreasePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                checkSpawn = Random.Range(0f, 15f);

                if (checkSpawn <= 1)
                {
                    Instantiate(coinPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    checkSpawn = Random.Range(0f, 25f);

                    if (checkSpawn <= 1)
                    {
                        Instantiate(ECoinPrefab, transform.position, Quaternion.identity);
                    }
                }
            }
        }
        BoxObject.spawnersChecked++;
    }

}
