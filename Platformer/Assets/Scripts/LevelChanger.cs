using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public GameObject foreBlack;
    public GameObject foreRed;
    public GameObject foreOrange;

    public string enableColor;

    // Start is called before the first frame update
    void Start()
    {
        foreRed.SetActive(false);
        foreOrange.SetActive(false);
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
            switch (enableColor)
            {
                case "orange":
                    foreOrange.SetActive(true);
                    break;
                case "red":
                    foreRed.SetActive(true);
                    break;
                default: //black
                    foreBlack.SetActive(true);
                    break;
            }
        }
    }
}
