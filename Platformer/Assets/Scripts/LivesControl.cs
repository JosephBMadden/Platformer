using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesControl : MonoBehaviour
{
    private Text lives;
    private string livesTag = "Lives: ";

    private void Awake()
    {
        lives = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lives.text = livesTag + MasterControl.Instance.lives;
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = livesTag + MasterControl.Instance.lives;
    }
}
