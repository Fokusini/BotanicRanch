using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBehavior : MonoBehaviour
{
    public enum State { Neutral, Dry, Wet, Rich };
    public State state = State.Neutral;
    
    public Animator anim;
    private AudioPlayer audioPlayer;

    [Header("State")]
    /*public bool canMove = true;
    public bool canJump = true;
    public bool isFacingRight = true;*/

    [Header("Graphics")]
    public SpriteRenderer rend;
    
    void Start()
    {       
        audioPlayer = GetComponentInChildren<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.Neutral:
                NeutralUpdate();
                break;
            case State.Dry:
                DryUpdate();
                break;
            case State.Wet:
                WetUpdate();
                break;
            case State.Rich:
                RichUpdate();
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        /*collisions.MyFixedUpdate();

        results = new Collider2D[maxColliders];
        numResults = Physics2D.OverlapCollider(abilityCollider, filter, results);*/

    }

    protected virtual void NeutralUpdate()
    {
        anim.SetBool("isGrounded", collisions.isGrounded);
        anim.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("speedY", rb.velocity.y);
    }

    protected virtual void DryUpdate()
    {
        //Animation dead player
    }

    protected virtual void WetUpdate()
    {

    }

    protected virtual void RichUpdate()
    {

    }
    
    void Flip()
    {
        rend.flipX = !rend.flipX;
        isFacingRight = !isFacingRight;
        collisions.Flip();
    }
}



