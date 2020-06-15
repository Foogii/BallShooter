using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSizeManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
