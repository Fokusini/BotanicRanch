using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsBehavior : MonoBehaviour
{
    /* Las plantas tendran los siguientes estados:
     *    · Null
     *    · Seed
     *    · Stem 1
     *    · Stem 2
     *    · Growed
     *    · Complet
     *    · Dead
     *    · Ill
     *    
     * Los tiestos tendran los siguientes estados:
     *    · Neutro
     *    · Dry
     *    · Wet
     *    · Rich
    */

    public enum State { Default, Dead, God };
    public State state = State.Default;

    public bool isGod = false;
    public BoxCollider2D boxCollider;

    public Animator anim;
    private AudioPlayer audioPlayer;
    
    public int life;
    public int damage = 1;

    [Header("State")]
    public bool canMove = true;
    public bool canJump = true;
    public bool isFacingRight = true;
    public bool isJumping = false;
    public bool isRunning = false;
    public bool isLaddering = false;
    public bool isLookingUp = false;
    public bool isLookingDown = false;
     [Header("Speed")]
    public float walkSpeed;
    public float runSpeed;
    public float movementSpeed;
    public float horizontalSpeed;
    public Vector2 axis;
    [Header("Forces")]
    public float jumpWalkForce;
    public float jumpRunForce;
    public float jumpForce;
    [Header("Graphics")]
    public SpriteRenderer rend;


    void Start()
    {
        collisions = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;

        boxCollider = GetComponent<BoxCollider2D>();

        audioPlayer = GetComponentInChildren<AudioPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Default:
                DefaultUpdate();
                if (lostSpeed == true) LostSpeed();
                break;
            case State.Dead:
                DeadUpdate();
                break;
            case State.God:
                GodUpdate();
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        collisions.MyFixedUpdate();

        results = new Collider2D[maxColliders];
        numResults = Physics2D.OverlapCollider(abilityCollider, filter, results);

        if (isJumping)
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isGrounded", collisions.isGrounded);
        }
        //Aplicaremos el movimiento
        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
    }

    protected virtual void DefaultUpdate()
    {
        //Calcula el movimiento en horizontal
        HorizontalMovement();
        //Saltar

        //Escalerindando
        if (isLaddering)
        {
            VerticalMovement();
        }

        anim.SetBool("isGrounded", collisions.isGrounded);
        anim.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("speedY", rb.velocity.y);
    }

    protected virtual void DeadUpdate()
    {
        Time.timeScale = 0;
        //Animation dead player
    }

    protected virtual void GodUpdate()
    {
        //Input get axis x 
        //Input get axis y
        this.transform.position += new Vector3(axis.x * 0.1f, axis.y * 0.1f, 0);
    }
    
    void VerticalMovement()
    {
        if ((axis.y > 0.1f) || (axis.y < 0.1f))
         {
            this.transform.position += new Vector3(0, axis.y * 0.05f, 0);
        }
    }

    void Jump()
    {
        isJumping = true;
    }

    void Flip()
    {
        rend.flipX = !rend.flipX;
        isFacingRight = !isFacingRight;
        collisions.Flip();
    }
 

    #region Public functions
    public void SetAxis(Vector2 inputAxis)
    {
        axis = inputAxis;
    }
    public void ReceiveDamage()
    {
        life -= damage;
        anim.SetBool("damage", true);
        if(life <= 0)
        {
            life = 0;
            state = State.Dead;
        }
    }

    public void LiquidPositive()
    {
        walkSpeed = 10;
        runSpeed = 14;
    }
    
    #endregion
    #region Sets
    public void SetGod()
    {
        isGod = !isGod;

        if (isGod)
        {
            state = State.God;
            horizontalSpeed = 0;
            rb.gravityScale = 0;
            rb.bodyType = RigidbodyType2D.Kinematic;
            boxCollider.enabled = false;
            rb.velocity *= 0;
        }
        else
        {
            state = State.Default;
            rb.gravityScale = gravity;
            rb.bodyType = RigidbodyType2D.Dynamic;
            boxCollider.enabled = true;
        }
    }
    #endregion

}



