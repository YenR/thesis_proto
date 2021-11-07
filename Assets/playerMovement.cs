using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;
    Vector2 movement;

    public Joystick joystick;

    public Animator animator;

    public static bool canMove = true;

    void Start()
    {
        if(LevelLoader.startpos != null && LevelLoader.startpos != Vector2.zero)
        {
            this.gameObject.transform.Translate(LevelLoader.startpos);
            LevelLoader.startpos = Vector2.zero;
        }
    }

    public float stopRunningThreshold = 70f;
    public float runSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(canMove);
        if(runPastBandits)
        {
            if(rb.transform.position.x > stopRunningThreshold)
            {
                runPastBandits = false;
                playerCollider.isTrigger = false;
            }

            movement.x = 1f;
            movement.y = 0f;
        }
        else if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(joystick.Horizontal) >= 0.2f)
            {
                movement.x = joystick.Horizontal;
            }

            if (Mathf.Abs(joystick.Vertical) >= 0.2f)
            {
                movement.y = joystick.Vertical;
            }
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }

        if (movement != Vector2.zero)
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
        }
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if(runPastBandits)
        {
            rb.MovePosition(rb.position + movement * runSpeed * Time.fixedDeltaTime);
            return;
        }
        movement.Normalize();
        //Debug.Log(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public CapsuleCollider2D playerCollider;
    public bool runPastBandits = false;
    public void run()
    {
        playerCollider.isTrigger = true;
        runPastBandits = true;
    }
}
