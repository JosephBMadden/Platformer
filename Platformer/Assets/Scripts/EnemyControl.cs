using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MasterControl.Instance.lives--;
        if (MasterControl.Instance.lives < 0) { MasterControl.Instance.lives = 0; }
    }
}
