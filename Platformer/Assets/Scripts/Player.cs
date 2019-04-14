using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    // Config
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float jumpSpeed = 6.5f;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myCollider2D;
    BoxCollider2D myFeet;

    public GameObject startPos;
    public int bottomY = -10;

    private bool invincible = false;
    public int invincibleCntrMax = 100;
    private int invincibleCntr = 0;

    // init
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MasterControl.Instance.lives <= 0)
        {
            die();
        }

        Run();
        FlipSprite();
        Jump();
        Attack();
    }

    private void FixedUpdate()
    {
        if(invincible)
        {
            invincibleCntr++;
            if (invincibleCntr >= invincibleCntrMax)
            {
                invincibleCntr = 0;
                invincible = false;
            }
        }

    }


    // Jump
    private void Jump()
    {

        myAnimator.SetBool("Touching Ground", myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")));

        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }

    }

    // Run
    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * walkSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        myAnimator.SetBool("Walking", playerHasHorizontalSpeed);

    }

    // Face right when moving right, vice-versa
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        // if player is moving horizontally
        if (playerHasHorizontalSpeed)
        {
            // reverse scaling of x axis
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    private void Attack()
    {
        if (!CrossPlatformInputManager.GetButtonDown("Attack")) { return; }

        myAnimator.SetTrigger("Attacking");


    }

    private void die()
    {
        if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsName("DeadAnim")) { myAnimator.SetTrigger("Died"); }
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            gameObject.SetActive(false);
        }
    }

    public void Revive()
    {
        if(gameObject.transform.position.y < bottomY)
        {
            gameObject.transform.position = startPos.transform.position;
        }
        gameObject.SetActive(true);
        myAnimator.SetTrigger("Revive");
    }

    private void TakeDamage()
    {
        //Debug.Log("enemy");
        MasterControl.Instance.lives--;
        if (MasterControl.Instance.lives < 0)
        {
            MasterControl.Instance.lives = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);

        switch (collision.tag)
        {
            case "OutOfBounds":
                MasterControl.Instance.lives = 0;
                break;
            case "Enemy":
                if (!invincible)
                {
                    invincible = true;
                    //TakeDamage();
                }
                break;
            case "Fireball":
                if (!invincible)
                { 
                    invincible = true;
                    //TakeDamage();
                }
                break;
        }
    }
}
