using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Animator myAnimator;
    BoxCollider2D myBoxCollider;
    bool isTouchingAttack;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        isTouchingAttack = false;
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
            isTouchingAttack= false;
            return;
        }

        if (!isTouchingAttack)
        {
            myAnimator.SetTrigger("Touched");
            isTouchingAttack = true;
        }
    }
}