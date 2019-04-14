using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    [SerializeField] float fireSpeed = .3f;
    Rigidbody2D body;
	
	private bool invinciblePlayer = false;
	public int invincibleCntrMax = 50;
    private int invincibleCntr = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FlipSprite();
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
    }

    // Face right when moving right, vice-versa
    private void FlipSprite()
    {

        // reverse scaling of x axis
        transform.localScale = new Vector2(Mathf.Sign(-body.velocity.x), 1f);

    }

    private void Move()
    {

        Vector2 playerVelocity = new Vector2(-1 * fireSpeed, body.velocity.y);
        body.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(body.velocity.x) > Mathf.Epsilon;

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
