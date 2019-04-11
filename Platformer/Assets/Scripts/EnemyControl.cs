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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MasterControl.Instance.lives--;
        if (MasterControl.Instance.lives < 0) { MasterControl.Instance.lives = 0; }
    }
}
