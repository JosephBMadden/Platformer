using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D body;
    public LayerMask terrain; //layers recognized by lineCast

    public float speed;
	private bool invinciblePlayer = false;
	public int invincibleCntrMax = 100;
    private int invincibleCntr = 0;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        touched();
    }

    private void FixedUpdate()
    {
		if(invinciblePlayer)
        {
            invincibleCntr++;
            if (invincibleCntr >= invincibleCntrMax)
            {
                invincibleCntr = 0;
                invinciblePlayer = false;
            }
        }
		
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
			if (!invinciblePlayer){
				invinciblePlayer = true;
			if (!body.IsTouchingLayers(LayerMask.GetMask("Attacking")))
			{
				MasterControl.Instance.lives--;
			}
			}

        }
    }

    void touched()
    {
        if (body.IsTouchingLayers(LayerMask.GetMask("Attacking")))
        {
            Destroy(this.gameObject);
        }
    }

}
