using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public Canvas canvas;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        //canvas.enabled = false;
        sentences = new Queue<string>();
    }

    public void StartDialogue(dialogue d)
    {
        if (d is dialogue_choices)
        {
            StartChoiceDialogue(d);
            return;
        }

        //Debug.Log("starting conversation with " + d.name);

        nameText.text = d.name;

        //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        //GameObject.Find("Player").GetComponent<shooting>().enabled = false;

        sentences.Clear();

        foreach(string sentence in d.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

        animator.SetBool("isOpen", true);
        //canvas.enabled = true;
    }

    public TMP_Text c2_speaker, c2_text, c2_button1, c2_button2;
    public int[] choice_handling = new int[4];
    public Animator c2_animator, c3_animator, c4_animator;

    public void StartChoiceDialogue(dialogue d)
    {
        if (!(d is dialogue_choices))
            return;

        dialogue_choices dc = (dialogue_choices)d;
        Debug.Log("choice dialogue started");
        
        if(dc.choices.Length == 2)
        {
            Start2cDialogue(dc);
        }
    }

    public void Start2cDialogue(dialogue_choices dc)
    {
        c2_speaker.SetText(dc.name);
        c2_text.SetText(dc.sentences[0]);
        c2_button1.SetText(dc.choices[0]);
        c2_button2.SetText(dc.choices[1]);
        choice_handling[0] = dc.choice_results[0];
        choice_handling[1] = dc.choice_results[1];
        c2_animator.SetBool("isOpen", true);
    }

    public void choice_clicked(int i)
    {
        Debug.Log("choice clicked: " + i);
        if (c2_animator != null) c2_animator.SetBool("isOpen", false);
        if (c3_animator != null) c3_animator.SetBool("isOpen", false);
        if (c4_animator != null) c4_animator.SetBool("isOpen", false);
        dialogue_result.handle_result(choice_handling[i]);
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
        //Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {
        //Debug.Log("End of conversation");
        animator.SetBool("isOpen", false);
        //canvas.enabled = false;
        //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        //GameObject.Find("Player").GetComponent<shooting>().enabled = true;
    }



}
