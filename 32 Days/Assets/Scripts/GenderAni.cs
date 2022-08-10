using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderAni : MonoBehaviour
{
    [SerializeField] private GameObject emma;
    [SerializeField] private GameObject evan;
    [SerializeField] private global Global;

    private void Update()
    {
        if (Global.IsMale)
        {
            emma.SetActive(false);
            evan.SetActive(true);
        }
        else
        {
            emma.SetActive(true);
            evan.SetActive(false);
        }
    }
}
