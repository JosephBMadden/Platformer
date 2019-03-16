using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
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
        string levelName = SceneManager.GetActiveScene().name;
        int levelNumber = int.Parse(levelName.Split(' ')[1]);

        SceneManager.LoadScene("Level " + (levelNumber+1));
    }
}
