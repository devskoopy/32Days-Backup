using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    // create queues
    private Queue<string> nameList;
    private Queue<string> sentenceList;
    private Queue<Sprite> spriteList;
    private Queue<Sprite> backList;

    [SerializeField] private TMP_Text _name; // The name text(TMP)
    [SerializeField] private TMP_Text _words; // The dialogue text(TMP)
    [SerializeField] private Image _renderer; // The Image renderer
    [SerializeField] private Image backGround; // The background renderer

    [SerializeField] private Animator animator;

    private UnityEvent unityEvents;

    // Start is called before the first frame update
    void Awake()
    {
        // creates Queues(to store all the dialogue components)
        nameList = new Queue<string>();
        sentenceList = new Queue<string>();
        spriteList = new Queue<Sprite>();
        backList = new Queue<Sprite>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue[] dialogues, UnityEvent events) // starts dialogue
    {
        unityEvents = events;
        animator.SetBool("IsOpen", true);
        // resets all the queues
        nameList.Clear();
        sentenceList.Clear();
        spriteList.Clear();
        backList.Clear();

        foreach (Dialogue dialogue in dialogues)
        {
            // go through all the dialogue and enqueues all the name components
            nameList.Enqueue(dialogue.name);
        }
        foreach (Dialogue dialogue in dialogues)
        {
            // go through all the dialogue and enqueues all the sentence components
            string tempSent = dialogue.posSentence[Random.Range(0, dialogue.posSentence.Length - 1)];
            sentenceList.Enqueue(tempSent);
        }
        foreach (Dialogue dialogue in dialogues)
        {
            // go through all the dialogue and enqueues all the sprite components
            spriteList.Enqueue(dialogue.sprite);
        }
        foreach (Dialogue dialogue in dialogues)
        {
            // go through all the dialogue and enqueues all the sprite components
            backList.Enqueue(dialogue.backG);
        }
        // finish setting up and display first sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence() // called when dialogue starts and when you press next
    {
        // checks if there are actually any names or sentences(if not, then quit)
        if (sentenceList.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (nameList.Count == 0)
        {
            EndDialogue();
            return;
        }

        string name = nameList.Dequeue(); // dequeues the first name in queue and store in variable
        string sentence = sentenceList.Dequeue(); // dequeues the first sentence in queue and store in variable
        Sprite sprite = spriteList.Dequeue(); // dequeues the first sprite in queue and store in variable
        Sprite ground = backList.Dequeue(); // dequeues the first sprite in queue and store in variable

        // sets name(tmp) and sentence(tmp) and also sprites
        _name.text = name;
        _words.text = sentence;
        _renderer.sprite = sprite;
        backGround.sprite = ground;
    }

    public void EndDialogue() // will also called when you press "skip button"
    {
        animator.SetBool("IsOpen", false);
        unityEvents.Invoke();
    }
}
