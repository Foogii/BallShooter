using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Increase : MonoBehaviour
{

    bool roundEnd = false;

    // Update is called once per frame
    void Update()
    {
        if (roundEnd == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.78f);
            roundEnd = false;
        }
    }

    public void moveDown()
    {

        roundEnd = true;

    }

}
