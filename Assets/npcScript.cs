using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class npcScript : MonoBehaviour, IinteractionTrigger
{
    public dialogue[] dialogues;

    public Rigidbody2D rb;

    //public static bool pause = false;

    public Button button;
    public TMP_Text text;
    public string buttonText = "Talk";
    public interactButton ib;

    public DialogueManager dm;

    public Animator anim;

    public Transform player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        button.gameObject.SetActive(true);
        text.SetText(buttonText);
        ib.callback = this;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag != "Player")
            return;


        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;
    }
   
    public virtual void callback()
    { 
        //pause = true;


        //Debug.Log("talking");
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;

        int rng = Random.Range(0, dialogues.Length);
        dm.StartDialogue(dialogues[rng]);

        Vector2 look_direction = player.position - this.gameObject.transform.position;
        anim.SetFloat("horizontal", look_direction.x);
        anim.SetFloat("vertical", look_direction.y);
    }

    public Vector2 movement;
    public float speed = 2f;

    void FixedUpdate()
    {
        if (!playerMovement.canMove)
        {
            anim.SetFloat("speed", 0f);
            return;
        }

        int rng = Random.Range(0, 300);

        if(rng == 0)
            movement = new Vector2(1, 0);
        else if (rng == 1)
            movement = new Vector2(-1, 0);
        else if (rng == 2)
            movement = new Vector2(0, 1);
        else if (rng == 3)
            movement = new Vector2(0, -1);
        else if (rng <= 10)
            movement = new Vector2(0, 0);

        if (movement != Vector2.zero)
        {
            anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
        }

        anim.SetFloat("speed", movement.sqrMagnitude);

        movement.Normalize();
        //Debug.Log(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
