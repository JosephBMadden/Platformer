using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Touched();
    }

    private void Touched()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Attacking")))
        {
            MasterControl.Instance.lives++;
            Destroy(this.gameObject);
        }
    }
}
