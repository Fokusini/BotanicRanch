using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsBehavior : MonoBehaviour
{
     /* Los tiestos tendran los siguientes estados:
     *    · Neutro
     *    · Dry
     *    · Wet
     *    · Rich
    */

    public enum State { Null, Seed, Stem1, Stem2, Growed, Complet, Dead, Ill };
    public State state = State.Null;
    
    public Animator anim;
    private AudioPlayer audioPlayer;
    
    /*public int life;
    public int damage = 1;*/

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
        switch (state)
        {
            case State.Null:
                NullUpdate();
                break;
            case State.Seed:
                SeedUpdate();
                break;
            case State.Stem1:
                Stem1Update();
                break;
            case State.Stem2:
                Stem2Update();
                break;
            case State.Growed:
                GrowedUpdate();
                break;
            case State.Complet:
                CompletUpdate();
                break;
            case State.Dead:
                DeadUpdate();
                break;
            case State.Ill:
                IllUpdate();
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

    protected virtual void NullUpdate()
    {       
        anim.SetBool("isGrounded", collisions.isGrounded);
        anim.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("speedY", rb.velocity.y);
    }

    protected virtual void SeedUpdate()
    {
                //Animation dead player
    }

    protected virtual void Stem1Update()
    {
        
    }

    protected virtual void Stem2Update()
    {
        
    }

    protected virtual void GrowedUpdate()
    {
     
    }

    protected virtual void CompletUpdate()
    {

    }       

    protected virtual void DeadUpdate()
    {
      
    }

    protected virtual void IllUpdate()
    {
        
    }
    
    void Flip()
    {
        rend.flipX = !rend.flipX;
        isFacingRight = !isFacingRight;
        collisions.Flip();
    }
}



