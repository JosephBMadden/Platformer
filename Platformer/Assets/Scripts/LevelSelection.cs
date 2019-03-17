using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;


    public void selectLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    private void Awake()
    {
        level1.interactable = true;
        level2.interactable = false;
        level3.interactable = false;
    }

    private void Start()
    {

    }

    void Update()
    {

    }


    // called first
    void OnEnable()
    {
        if (MasterControl.Instance.completedLevels[0])
        {
            level1.interactable = true;
        }
        if (MasterControl.Instance.completedLevels[1])
        {
            level2.interactable = true;
        }
        if (MasterControl.Instance.completedLevels[2])
        {
            level3.interactable = true;
        }
    }
}
