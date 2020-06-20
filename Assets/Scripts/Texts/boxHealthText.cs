using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boxHealthText : MonoBehaviour
{
    private BoxObject box;

    // Start is called before the first frame update
    void Start()
    {
        
        


    }

    // Update is called once per frame
    void Update()
    {
        var parent = transform.parent;

        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();

        box = GetComponentInParent<BoxObject>();

        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder + 1;

        var spriteTransform = parent.transform;
        var text = GetComponent<TextMeshPro>();
        var pos = spriteTransform.position;

        if (box.health < 100)
        {
            text.fontSize = 250;
        }
        else if (box.health >= 100)
        {
            text.fontSize = 200;
        }
        else if(box.health >= 1000)
        {
            text.fontSize = 165;
        }
        else if(box.health >= 10000)
        {
            text.fontSize = 150;
        }

        if (box.health >= 1000)
        {
            var floating = (float)box.health / 1000;
            text.text = "" + floating.ToString("f1") + "K";
        }
        else
            text.text = "" + box.health;
    }
}
