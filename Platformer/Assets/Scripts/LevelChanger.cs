using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public GameObject toToggle;
    public bool enabled;

    // Start is called before the first frame update
    void Start()
    {
      toToggle.SetActive(enabled);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enabled = !enabled;
        if(collision.tag == "Player")
        {
          toToggle.SetActive(enabled);
        }
    }
}
