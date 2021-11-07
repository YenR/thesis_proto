using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public dialogue nextDialogue = null;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public Canvas canvas;

    public Animator animator;

    private Queue<string> sentences;

    public int[] choice_handling = new int[4];
    public Animator c2_animator, c3_animator, c4_animator;
    public bool choiceDialogueOpen = false;
    
    public TMP_Text c2_speaker, c2_text, c2_button1, c2_button2;
    public TMP_Text c3_speaker, c3_text, c3_button1, c3_button2, c3_button3;
    public TMP_Text c4_speaker, c4_text, c4_button1, c4_button2, c4_button3, c4_button4;

    // Start is called before the first frame update
    void Start()
    {
        //canvas.enabled = false;
        sentences = new Queue<string>();
    }

    public void StartDialogue(dialogue d, bool openInstantly = false)
    {
        hudscipt.instance.hide(); //.gameObject.SetActive(false);
        playerMovement.canMove = false;
        Debug.Log("henlO");

        if (d is dialogue_choices)
        {
            StartChoiceDialogue(d, openInstantly);
            return;
        }

        animator.ResetTrigger("closeNow");
        animator.ResetTrigger("closeAnim");
        animator.ResetTrigger("openAnim");
        animator.ResetTrigger("openNow");

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

        if (openInstantly)
            animator.SetTrigger("openNow");
        //animator.SetBool("isOpen", true);
        else
            animator.SetTrigger("openAnim");
        //canvas.enabled = true;
    }


    private void Update()
    {
        
        if (Input.GetKeyDown("space") && !choiceDialogueOpen && playerMovement.canMove == false)// && sentences.Count > 0)
        {
            DisplayNextSentence();
        }
    }

    public void StartChoiceDialogue(dialogue d, bool openInstantly = false)
    {
        if (!(d is dialogue_choices))
            return;

        choiceDialogueOpen = true;

        dialogue_choices dc = (dialogue_choices)d;
        Debug.Log("choice dialogue started");
        
        if(dc.choices.Length == 2)
        {
            Start2cDialogue(dc, openInstantly);
        }
        else if(dc.choices.Length == 3)
        {
            Start3cDialogue(dc, openInstantly);
        }
        else if (dc.choices.Length == 4)
        {
            Start4cDialogue(dc, openInstantly);
        }
    }


    public void Start2cDialogue(dialogue_choices dc, bool openInstantly = false)
    {
        c2_speaker.SetText(dc.name);
        c2_text.SetText(dc.sentences[0]);
        c2_button1.SetText(dc.choices[0]);
        c2_button2.SetText(dc.choices[1]);
        choice_handling[0] = dc.choice_results[0];
        choice_handling[1] = dc.choice_results[1];
        if (openInstantly)
            c2_animator.SetTrigger("openNow");
        else
            c2_animator.SetTrigger("openAnim");
        //c2_animator.SetBool("isOpen", true);
    }

    public void Start3cDialogue(dialogue_choices dc, bool openInstantly = false)
    {
        c3_speaker.SetText(dc.name);
        c3_text.SetText(dc.sentences[0]);
        c3_button1.SetText(dc.choices[0]);
        c3_button2.SetText(dc.choices[1]);
        c3_button3.SetText(dc.choices[2]);
        choice_handling[0] = dc.choice_results[0];
        choice_handling[1] = dc.choice_results[1];
        choice_handling[2] = dc.choice_results[2];
        if (openInstantly)
            c3_animator.SetTrigger("openNow");
        else
            c3_animator.SetTrigger("openAnim");
        //c3_animator.SetBool("isOpen", true);
    }

    public void Start4cDialogue(dialogue_choices dc, bool openInstantly = false)
    {
        c4_speaker.SetText(dc.name);
        c4_text.SetText(dc.sentences[0]);
        c4_button1.SetText(dc.choices[0]);
        c4_button2.SetText(dc.choices[1]);
        c4_button3.SetText(dc.choices[2]);
        c4_button4.SetText(dc.choices[3]);
        choice_handling[0] = dc.choice_results[0];
        choice_handling[1] = dc.choice_results[1];
        choice_handling[2] = dc.choice_results[2];
        choice_handling[3] = dc.choice_results[3];
        if (openInstantly)
            c4_animator.SetTrigger("openNow");
        else
            c4_animator.SetTrigger("openAnim");
        //c4_animator.SetBool("isOpen", true);
    }


    //public dialogue follow_choice = null;

    public void choice_clicked(int i)
    {
        Debug.Log("choice clicked: " + i);
        dialogue_result.handle_result(choice_handling[i]);

        if(nextDialogue != null && nextDialogue.sentences != null && nextDialogue.sentences.Length > 0)
        {
            choiceDialogueOpen = false;

            if (c2_animator != null)
                c2_animator.SetTrigger("closeNow");//c2_animator.SetBool("isOpen", false);
            if (c3_animator != null)
                c3_animator.SetTrigger("closeNow");// c3_animator.SetBool("isOpen", false);
            if (c4_animator != null)
                c4_animator.SetTrigger("closeNow");// c4_animator.SetBool("isOpen", false);

            StartDialogue(nextDialogue, true);

            nextDialogue = null;
        }
        else
        {
            if (c2_animator != null)
                c2_animator.SetTrigger("closeAnim");//c2_animator.SetBool("isOpen", false);
            if (c3_animator != null)
                c3_animator.SetTrigger("closeAnim");// c3_animator.SetBool("isOpen", false);
            if (c4_animator != null)
                c4_animator.SetTrigger("closeAnim");// c4_animator.SetBool("isOpen", false);
        
            hudscipt.instance.show();
            choiceDialogueOpen = false;
            playerMovement.canMove = true;
        }
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("displaynextsentence");
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
        if(nextDialogue != null && nextDialogue.sentences != null && nextDialogue.sentences.Length > 0)
        {
            Debug.Log("next dialogue not null");
            animator.SetTrigger("closeNow");
            //animator.SetBool("isOpen", false);
            //animator.SetTrigger("closeAnim");
            StartDialogue(nextDialogue, true);
            nextDialogue = null;
        }
        else
        {
            Debug.Log("next dialogue is null");
            //animator.SetBool("isOpen", false);
            animator.SetTrigger("closeAnim");
            hudscipt.instance.show();
            playerMovement.canMove = true;
        }
        //Debug.Log("End of conversation");
        //canvas.enabled = false;
        //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        //GameObject.Find("Player").GetComponent<shooting>().enabled = true;
    }



}
