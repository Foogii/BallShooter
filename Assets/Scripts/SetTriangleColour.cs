using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTriangleColour : MonoBehaviour
{
    public GameObject PlayerTriangle;
    public Image handle;
    public Slider colourSlider;

    // Start is called before the first frame update
    void Start()
    {
        colourSlider.value = PlayerPrefs.GetFloat("PlayerColour"); 
    }

    public void changeColour(float slider)
    {
        slider = colourSlider.value;

        handle.color = Color.HSVToRGB(slider, 1, 1);
        if(PlayerTriangle.activeInHierarchy)
            PlayerTriangle.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(slider, 1, 1);

        PlayerPrefs.SetFloat("PlayerColour", slider);
    }

}
