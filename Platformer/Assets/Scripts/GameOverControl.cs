using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour
{
    public Text title;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    //called when object is activated
    void Start()
    {
        title.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(MasterControl.Instance.lives <= 0)
        {
            title.enabled = true;
        }
    }
}
