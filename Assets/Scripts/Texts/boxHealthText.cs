using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var text = GetComponent<TextMesh>();
        var pos = spriteTransform.position;


        text.text = "" + box.health;
    }
}
