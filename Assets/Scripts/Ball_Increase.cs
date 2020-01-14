using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Increase : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    public void moveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.78f);
    }

}
