using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // makes it serializable(so other classes can use it)
public class Dialogue
{
    public string name; // Name of boss speaking
    public Sprite sprite; // sprite of speaker
    public Sprite backG; // sprite of background

    [TextArea(2, 4)]
    public string[] posSentence; // Array of sentences(picks a random one)
}
