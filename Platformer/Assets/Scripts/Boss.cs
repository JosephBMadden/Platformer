﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject fireballPrefab;
    public Transform firepoint;

    public Rigidbody2D body;


    private bool ShootingFireball = false;
    public int ShootingFireballMax = 300;
    public int ShootingFireballCrnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fireBalls();
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
}
