using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue[] dialogues; // A list of "Dialogue" class(with name, sprites and sentences to speak)
    [SerializeField] private UnityEvent eventU;
    public void TriggerDialogue()
    {
        if (eventU == null)
        {
            eventU = new UnityEvent();
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues, eventU); // starts dialogue
    }
}
