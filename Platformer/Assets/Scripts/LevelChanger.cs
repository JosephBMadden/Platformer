using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public GameObject foreOrange;
    public GameObject foreBlack;

    // Start is called before the first frame update
    void Start()
    {
        foreOrange.SetActive(true);
        foreBlack.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(foreOrange.active)
            {
                foreOrange.SetActive(false);
                Debug.Log("disabled black");
            }
        }
    }
}
