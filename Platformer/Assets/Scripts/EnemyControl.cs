using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    BoxCollider2D myBoxCollider;


    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        touched();
    }


    void touched()
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Attack")))
        {
            isTouchingAttack = false;
            return;
        }

        if (!isTouchingAttack)
        {
            myAnimator.SetTrigger("Touched");
            isTouchingAttack = true;
        }
    }

    private void FixedUpdate()
    {
        AvoidFalling();
        AvoidStuck();
        MoveForward();
    }

    private void MoveForward()
    {
        Vector2 velX = body.velocity;
        velX.x = -transform.right.x * speed; //- because facing left and no .left //only upd the x
        body.velocity = velX;
    }

    private void AvoidFalling()
    {
        float bodyWidth = GetComponent<SpriteRenderer>().bounds.extents.x; //extents = 1/2 width
        Vector2 start = transform.position - transform.right * bodyWidth;
        Vector2 end = start + Vector2.down;
        //Debug.DrawLine(start, end); //draws a line in scene
        bool isGrounded = Physics2D.Linecast(start, end, terrain); //start, end, mask

        if (!isGrounded)
        {
            //flip
            Vector3 rotY = transform.eulerAngles;
            rotY.y += 180;
            transform.eulerAngles = rotY;
        }
    }

    private void AvoidStuck()
    {
        float bodyWidth = GetComponent<SpriteRenderer>().bounds.extents.x; //extents = 1/2 width
        Vector2 start = transform.position - transform.right * .3f * bodyWidth; //trans vs vect3 because flips with enemy
        Vector2 end = start + Vector2.left;
        //Debug.DrawLine(start, end); //draws a line in scene
        bool isStuck = Physics2D.Linecast(start, end, terrain); //start, end, mask

        if (isStuck)
        {
            //flip
            Vector3 rotY = transform.eulerAngles;
            rotY.y += 180;
            transform.eulerAngles = rotY;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MasterControl.Instance.lives--;
        if (MasterControl.Instance.lives < 0) { MasterControl.Instance.lives = 0; }
    }
}
