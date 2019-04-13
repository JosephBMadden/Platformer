using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    [SerializeField] float fireSpeed = .5f;
    Rigidbody2D body;

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

    void touched()
    {
        if (body.IsTouchingLayers(LayerMask.GetMask("Attacking")))
        {
            Destroy(this.gameObject);
        }
    }

}
