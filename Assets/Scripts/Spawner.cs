using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject ballIncreasePrefab;

    void Start()
    {
        BoxObject.spawnersChecked = 0;
    }

    // Update is called once per frame
    void Update()
    {

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
        }

        BoxObject.spawnersChecked++;
    }

}
