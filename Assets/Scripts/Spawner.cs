using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    static public bool roundEnd = false;
    public GameObject boxPrefab;
    public GameObject ballIncreasePrefab;

    public LayerMask whatIsBox;
    public LayerMask whatIsBall;
    public LayerMask whatIsBallIncrease;

    public Transform corner1;
    public Transform corner2;

    public Transform parentedObject;

    void Start()
    {
        roundEnd = true;
        roundDone();
        roundEnd = false;
        BoxObject.spawnersChecked = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D[] balls = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBall);

        if (roundEnd == true)
        {
            if (balls.Length == 0)
            {
                roundDone();

                if (BoxObject.spawnersChecked == 7)
                {
                    roundEnd = false;
                    currentRound.round++;
                    BoxObject.spawnersChecked = 0;
                }
            }
        }

    }


    void spawner()
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

    public void roundDone()
    {

        if(roundEnd == true)
        {
            spawner();

            Collider2D[] boxes = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBox);
            Collider2D[] ballIncrease = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBallIncrease);

            for (int i = 0; i < boxes.Length; i++)
                boxes[i].GetComponent<BoxObject>().moveDown();

            for (int i = 0; i < ballIncrease.Length; i++)
                ballIncrease[i].GetComponent<Ball_Increase>().moveDown();

        }


    }


}
