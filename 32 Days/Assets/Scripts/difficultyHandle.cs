using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyHandle : MonoBehaviour
{
    [SerializeField] private global Global;
    [SerializeField] private Image renderer;
    [SerializeField] private Sprite[] difficulty;

    private void Update()
    {
        renderer.sprite = difficulty[Global.difficulty];
    }
}
