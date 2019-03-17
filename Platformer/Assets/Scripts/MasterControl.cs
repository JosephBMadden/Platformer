using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterControl : MonoBehaviour
{
    public static MasterControl Instance;

    public int lives = 3;

    public bool[] completedLevels = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        completedLevels[0] = true; //level 1
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
