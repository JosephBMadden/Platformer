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
      switch (collision.tag)
      {
          case "Player":
              string levelName = SceneManager.GetActiveScene().name;
              int levelNumber = int.Parse(levelName.Split(' ')[1]);

              SceneManager.LoadScene("Level " + (levelNumber+1));

              MasterControl.Instance.completedLevels[levelNumber] = true; //bec compl start at 0 and levels start at 1
              break;
      }
    }
}
