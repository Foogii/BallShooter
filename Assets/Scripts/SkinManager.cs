using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer background;
    public SpriteRenderer player;

    Resources Backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        background.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Background"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
