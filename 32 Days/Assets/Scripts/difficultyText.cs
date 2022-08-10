using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class difficultyText : MonoBehaviour
{
    [SerializeField] private global Global;
    [SerializeField] private TMP_Text text;
    [SerializeField] private string[] difficulty;
    [SerializeField] private Color[] color;

    private void Update()
    {
        text.text = difficulty[Global.difficulty];
        text.color = color[Global.difficulty];
    }
}
