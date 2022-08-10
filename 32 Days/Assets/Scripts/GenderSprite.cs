using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSprite : MonoBehaviour
{
    [SerializeField] private global Global;
    [SerializeField] private Sprite MaleSprite;
    [SerializeField] private Sprite FemaleSprite;
    [SerializeField] private SpriteRenderer renderer;
    
    // Update is called once per frame
    void Update()
    {
        if (Global.IsMale)
        {
            renderer.sprite = MaleSprite;
        }
        else
        {
            renderer.sprite = FemaleSprite;
        }
    }
}
