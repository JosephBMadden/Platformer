using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Animator myAnimator;
    BoxCollider2D myBoxCollider;
    bool isTouchingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        isTouchingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        touched();
    }

    void touched()
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Attacking")))
        {
            isTouchingPlayer = false;
            return;
        }

        if (!isTouchingPlayer)
        {
            myAnimator.SetTrigger("Touched");
            isTouchingPlayer = true;
        }
    }
}