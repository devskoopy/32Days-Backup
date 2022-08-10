using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setValues : MonoBehaviour
{
    [SerializeField] private global Global;

    public void SwitchGender(bool value)
    {
        Global.IsMale = value;
        SceneManager.LoadScene(2);
    }
}
