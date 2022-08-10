using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnStart : MonoBehaviour
{
    [SerializeField] private GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(true);   
    }
}
