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

    // Update is called once per frame
    void Update()
    {
        if (canMove)
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
        movement.Normalize();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

}
