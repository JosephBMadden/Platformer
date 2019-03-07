using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterControl : MonoBehaviour
{
    public static MasterControl Instance;

    public int lives = 3;

    public GameObject gameOver;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void killPlayer(GameObject player)
    {
        Destroy(player);
    }

    public void endGame()
    {
        gameOver.SetActive(true);
    }
}
