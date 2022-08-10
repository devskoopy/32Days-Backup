using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySlider : MonoBehaviour
{
    [SerializeField] private global Global;

    public void OnValueChange(float value)
    {
        Global.difficulty = (int)value;
    }
}
