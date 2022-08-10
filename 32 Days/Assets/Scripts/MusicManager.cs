using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource start; // intro audio clip
    [SerializeField] private AudioSource looped; // looped audio source
    [SerializeField] private float delayOffset = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        float timeToWait = start.clip.length; // gets length of start
        StartCoroutine(WaitForLoop(timeToWait)); // executes coroutine
    }

    IEnumerator WaitForLoop(float delay) // delay
    {
        yield return new WaitForSeconds(delay - delayOffset); // waits a delay
        looped.Play();
    }
}
