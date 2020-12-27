using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSizeManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            Vector2 spawnPos = new Vector2(((1f / spawners.Length) + (1f / spawners.Length) * i) - (1f / spawners.Length) / 2f, 0.96f);

            spawners[i].transform.position = Camera.main.ViewportToWorldPoint(spawnPos);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
