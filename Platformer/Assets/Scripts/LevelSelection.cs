using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void selectLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
