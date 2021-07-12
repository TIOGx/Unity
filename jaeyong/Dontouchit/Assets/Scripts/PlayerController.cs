using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private Animator animator;
    private float speed = 5f;
    private float horizontal;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        PlayerMove();
        ScreenCheck();
    }
    void PlayerMove()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        if(horizontal < 0)
        {
            renderer.flipX = true;
        } else
        {
            renderer.flipX = false;
        }
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }
     void ScreenCheck()
    {
        Vector3 WorlPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if(WorlPos.x < 0.05f)
        {
            WorlPos.x = 0.05f;
        } if (WorlPos.x > 0.95f)
        {
            WorlPos.x = 0.95f;
        }
        this.transform.position = Camera.main.ViewportToWorldPoint(WorlPos);
    }
}
