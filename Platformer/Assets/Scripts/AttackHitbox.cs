using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AttackHitbox : MonoBehaviour
{
    BoxCollider2D hitBox;
    Animator animator;

    // init
    void Start()
    {
        hitBox = GetComponent<BoxCollider2D>();
        animator = GetComponentInParent<Animator>();
    }


    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            hitBox.enabled = false;
            return;
        }


        hitBox.enabled = true;

    }
}
