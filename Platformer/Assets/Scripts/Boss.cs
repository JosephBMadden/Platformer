using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject fireballPrefab;
    public Transform firepoint;

    //public Rigidbody2D body; // giving errors


    private bool ShootingFireball = false;
    public int ShootingFireballMax = 300;
    public int ShootingFireballCrnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        //body = GetComponent<Rigidbody2D>(); // Giving Errors
    }

    // Update is called once per frame
    void Update()
    {
        fireBalls();
        touched();
    }

    private void FixedUpdate()
    {
        if (!ShootingFireball)
        {
            ShootingFireballCrnt++;
            if (ShootingFireballCrnt > ShootingFireballMax)
            {
                ShootingFireballCrnt = 0;
                ShootingFireball = true;
            }
        }
    }

    private void fireBalls()
    {
        if (ShootingFireball)
        {
            Instantiate(fireballPrefab, firepoint.position, firepoint.rotation);
            ShootingFireball = false;
        }
    }

    void touched()
    {
        //if (body.IsTouchingLayers(LayerMask.GetMask("Attacking")))
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
